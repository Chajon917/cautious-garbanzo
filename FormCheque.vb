Imports MySql.Data.MySqlClient
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports MailKit.Net.Smtp
Imports MailKit.Security
Imports MimeKit

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormCheque
        Inherits Form

        Private _nombreEmpleado As String = ""
        Private _montoLiquido As Double = 0
        Private _correoEmpleado As String = ""
        Private _noCuenta As String = ""
        Private _chequeGenerado As Boolean = False
        Private _idActual As Integer = 0
        Private _cargoActual As String = ""
        Private _sueldoActual As Double = 0
        Private _igssActual As Double = 0
        Private _bonoActual As Double = 0
        Private _otrosActual As Double = 0

        Private Const SmtpHost As String = "smtp.gmail.com"
        Private Const SmtpUsuario As String = "averkzalexd@gmail.com"
        Private Const SmtpClave As String = "hwlvvzwvirxlwrvv"
        Private Const RemitenteMostrado As String = "Recursos Humanos"

        Private ReadOnly _culturaGT As New CultureInfo("es-GT")

        Private ReadOnly _carpetaComprobantes As String =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Comprobantes de Planilla")

        Public Sub New()
            InitializeComponent()
            Directory.CreateDirectory(_carpetaComprobantes)
        End Sub

        Public Sub New(idExterno As String)
            Me.New()
            If Not String.IsNullOrWhiteSpace(idExterno) Then
                txtIdBusqueda.Text = idExterno.Trim()
                BtnGenerar_Click(Nothing, EventArgs.Empty)
            End If
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' Conversión numérica a texto
        ' ══════════════════════════════════════════════════════════════════

        Public Function Enletras(total As Double) As String
            If total < 0 Then Return "Monto inválido"
            Dim entero As Long = CLng(Math.Floor(total))
            Dim centavos As Integer = CInt(Math.Round((total - entero) * 100))
            Dim sufijo As String = If(centavos > 0,
                $" CON {centavos:D2}/100 CENTAVOS",
                " EXACTOS")
            Return NumeroALetras(entero) & " QUETZALES" & sufijo
        End Function

        Private Function NumeroALetras(valor As Long) As String
            If valor = 0 Then Return "CERO"
            If valor < 0 Then Return "MENOS " & NumeroALetras(CLng(Math.Abs(CDec(valor))))

            Dim unidades() As String = {
                "", "UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE",
                "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE",
                "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE"
            }
            Dim decenas() As String = {
                "", "", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA",
                "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"
            }
            Dim centenas() As String = {
                "", "CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS",
                "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"
            }

            If valor < 20 Then Return unidades(CInt(valor))
            If valor = 100 Then Return "CIEN"
            If valor < 100 Then
                Dim resto As Long = valor Mod 10
                Return decenas(CInt(valor \ 10)) & If(resto > 0, " Y " & unidades(CInt(resto)), "")
            End If
            If valor < 1000 Then
                Return centenas(CInt(valor \ 100)) &
                       If(valor Mod 100 > 0, " " & NumeroALetras(valor Mod 100), "")
            End If
            If valor < 1_000_000 Then
                Return If(valor \ 1000 = 1, "MIL", NumeroALetras(valor \ 1000) & " MIL") &
                       If(valor Mod 1000 > 0, " " & NumeroALetras(valor Mod 1000), "")
            End If
            If valor < 1_000_000_000 Then
                Return If(valor \ 1_000_000 = 1, "UN MILLON",
                          NumeroALetras(valor \ 1_000_000) & " MILLONES") &
                       If(valor Mod 1_000_000 > 0, " " & NumeroALetras(valor Mod 1_000_000), "")
            End If
            Return ""
        End Function

        ' ══════════════════════════════════════════════════════════════════
        ' Generar cheque desde BD
        ' ══════════════════════════════════════════════════════════════════

        Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
            Dim idTexto As String = txtIdBusqueda.Text.Trim()

            If String.IsNullOrWhiteSpace(idTexto) Then
                MessageBox.Show("Ingrese un ID de trabajador.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim idTrabajador As Integer
            If Not Integer.TryParse(idTexto, idTrabajador) OrElse idTrabajador <= 0 Then
                MessageBox.Show("El ID debe ser un numero entero positivo.",
                    "ID invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                Const query As String =
                    "SELECT nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta " &
                    "FROM trabajadores WHERE id_trabajador = @id"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", idTrabajador)

                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If Not dr.Read() Then
                                MessageBox.Show(
                                    $"No se encontro ningun trabajador con el ID {idTrabajador}.",
                                    "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                _chequeGenerado = False
                                Return
                            End If

                            _idActual = idTrabajador
                            _nombreEmpleado = dr("nombres").ToString()
                            _montoLiquido = Convert.ToDouble(dr("liquido"))
                            _correoEmpleado = dr("correo").ToString()
                            _noCuenta = dr("no_cuenta").ToString()
                            _cargoActual = dr("cargo").ToString()
                            _sueldoActual = Convert.ToDouble(dr("sueldo"))
                            _igssActual = Convert.ToDouble(dr("igss"))
                            _bonoActual = Convert.ToDouble(dr("bono"))
                            _otrosActual = Convert.ToDouble(dr("otros"))

                            lblFecha.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT)
                            lblNoCheque.Text = "No. " & idTrabajador.ToString("D6")
                            lblNombre.Text = _nombreEmpleado.ToUpper()
                            lblCargo.Text = _cargoActual
                            lblSueldo.Text = "Q " & _sueldoActual.ToString("N2")
                            lblIGSS.Text = "Q " & _igssActual.ToString("N2")
                            lblBono.Text = "Q " & _bonoActual.ToString("N2")
                            lblOtros.Text = "Q " & _otrosActual.ToString("N2")
                            lblMontoNumero.Text = "Q " & _montoLiquido.ToString("N2")
                            lblMontoLetras.Text = Enletras(_montoLiquido)

                            _chequeGenerado = True
                        End Using
                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show("Error de base de datos: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error inesperado: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' Cerrar formulario
        ' ══════════════════════════════════════════════════════════════════

        Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
            Me.Close()
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' Generar imagen PNG del comprobante (SIN cheque — solo para correo
        ' y para guardar en carpeta Comprobantes de Planilla)
        ' ══════════════════════════════════════════════════════════════════

        Private Function GenerarImagenComprobante(
            id As Integer, nombre As String, cargo As String,
            sueldo As Double, igss As Double, bono As Double,
            otros As Double, liquido As Double, noCuenta As String) As String

            Dim bmp As New Bitmap(700, 480)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)

                Dim fontTitulo As New Font("Arial", 13, FontStyle.Bold)
                Dim fontNormal As New Font("Arial", 9, FontStyle.Regular)
                Dim fontNegrita As New Font("Arial", 9, FontStyle.Bold)
                Dim brushN As Brush = Brushes.Black

                Dim x As Integer = 30
                Dim y As Integer = 20
                Dim lineH As Integer = 22

                g.DrawString("BANTRAB - COMPROBANTE DE PLANILLA", fontTitulo, brushN, x, y)
                y += lineH + 6

                g.DrawString("Fecha: " & DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT),
                    fontNormal, brushN, x, y)
                g.DrawString("No. " & id.ToString("D8"), fontNegrita, brushN, x + 450, y)
                y += lineH

                g.DrawString("Empleado:   " & nombre.ToUpper(), fontNegrita, brushN, x, y) : y += lineH
                g.DrawString("Cargo:      " & cargo, fontNormal, brushN, x, y) : y += lineH
                g.DrawString("No. Cuenta: " & noCuenta, fontNormal, brushN, x, y) : y += lineH + 6

                g.DrawLine(Pens.Gray, x, y, 670, y) : y += 8

                g.DrawString("DESGLOSE DE PLANILLA", fontNegrita, brushN, x, y) : y += lineH

                Dim conceptos() As String = {"Sueldo Base:", "Bono Incentivo:", "Retencion IGSS:", "Otros Descuentos:"}
                Dim montos() As String = {
                    "Q " & sueldo.ToString("N2"),
                    "Q " & bono.ToString("N2"),
                    "Q " & igss.ToString("N2"),
                    "Q " & otros.ToString("N2")
                }

                For i As Integer = 0 To conceptos.Length - 1
                    g.DrawString(conceptos(i), fontNormal, brushN, x, y)
                    g.DrawString(montos(i), fontNormal, brushN, x + 220, y)
                    y += lineH
                Next

                g.DrawLine(Pens.Gray, x, y, 400, y) : y += 6
                g.DrawString("Total Liquido:", fontNegrita, brushN, x, y)
                g.DrawString("Q " & liquido.ToString("N2"), fontNegrita, brushN, x + 220, y)
                y += lineH + 6

                g.DrawString("En letras: " & Enletras(liquido), fontNormal, brushN, x, y)
                y += lineH + 10

                g.DrawLine(Pens.Black, x, y, 280, y)
                g.DrawLine(Pens.Black, 380, y, 660, y)
                y += 4
                g.DrawString("Firma Empleado", fontNormal, brushN, x + 60, y)
                g.DrawString("Autorizado por RRHH", fontNormal, brushN, x + 400, y)

                fontTitulo.Dispose()
                fontNormal.Dispose()
                fontNegrita.Dispose()
            End Using

            Dim nombreArchivo As String = Path.Combine(
                _carpetaComprobantes,
                $"Comprobante_{id:D6}_{nombre.Replace(" ", "_")}.png")

            bmp.Save(nombreArchivo, ImageFormat.Png)
            bmp.Dispose()
            Return nombreArchivo
        End Function

        ' ══════════════════════════════════════════════════════════════════
        ' Enviar correo con el comprobante PNG adjunto
        ' ══════════════════════════════════════════════════════════════════

        Private Sub EnviarCorreoComprobante(
            correo As String, nombre As String,
            liquido As Double, rutaArchivo As String)

            If String.IsNullOrWhiteSpace(correo) Then
                Throw New Exception("El trabajador no tiene correo registrado.")
            End If

            Dim mensaje As New MimeMessage()
            mensaje.From.Add(New MailboxAddress(RemitenteMostrado, SmtpUsuario))
            mensaje.To.Add(MailboxAddress.Parse(correo))
            mensaje.Subject = "Comprobante de Planilla - " &
                              DateTime.Now.ToString("MMMM yyyy", _culturaGT)

            Dim builder As New BodyBuilder()
            builder.TextBody =
                $"Estimado/a {nombre}," & Environment.NewLine & Environment.NewLine &
                "Adjunto encontrara su comprobante de planilla correspondiente al periodo " &
                DateTime.Now.ToString("MMMM yyyy", _culturaGT) & "." &
                Environment.NewLine & Environment.NewLine &
                $"Monto liquido a recibir: Q {liquido:N2}" &
                Environment.NewLine & Environment.NewLine &
                "Atentamente," & Environment.NewLine & "Recursos Humanos"
            builder.Attachments.Add(rutaArchivo)
            mensaje.Body = builder.ToMessageBody()

            Dim enviado As Boolean = False
            Dim ultimoError As String = ""

            Dim puertos() As Integer = {587, 465}
            Dim opciones() As SecureSocketOptions = {
                SecureSocketOptions.StartTls,
                SecureSocketOptions.SslOnConnect
            }

            For i As Integer = 0 To puertos.Length - 1
                Try
                    Using smtp As New SmtpClient()
                        smtp.Timeout = 15000
                        smtp.Connect(SmtpHost, puertos(i), opciones(i))
                        smtp.Authenticate(SmtpUsuario, SmtpClave)
                        smtp.Send(mensaje)
                        smtp.Disconnect(True)
                    End Using
                    enviado = True
                    Exit For
                Catch ex As Exception
                    ultimoError = $"Puerto {puertos(i)}: {ex.Message}"
                End Try
            Next

            If Not enviado Then
                Throw New Exception(
                    "No se pudo conectar al servidor de correo." & Environment.NewLine &
                    ultimoError & Environment.NewLine & Environment.NewLine &
                    "Verifique que su App Password de Gmail sea valido.")
            End If
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' Botón Imprimir — imprime comprobante + línea de corte + cheque
        ' en una sola hoja apaisada (Letter landscape)
        ' ══════════════════════════════════════════════════════════════════

        Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
            If Not _chequeGenerado Then
                MessageBox.Show("Primero debe generar un cheque valido.",
                    "Accion invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                Dim pd As New PrintDocument()
                ' Hoja Letter apaisada: 1100 × 850 centésimas de pulgada
                pd.DefaultPageSettings.Landscape = True
                pd.DefaultPageSettings.PaperSize = New PaperSize("Letter", 1100, 850)
                pd.DefaultPageSettings.Margins = New Margins(30, 30, 30, 30)
                AddHandler pd.PrintPage, AddressOf Documento_PrintPage

                Using pdi As New PrintPreviewDialog()
                    pdi.Document = pd
                    pdi.WindowState = FormWindowState.Maximized
                    pdi.Text = "Vista previa - Comprobante + Cheque BANTRAB"
                    pdi.ShowDialog()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al imprimir: " & ex.Message,
                    "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Generar PNG (solo comprobante) y enviar correo
            Try
                Dim rutaArchivo As String = GenerarImagenComprobante(
                    _idActual, _nombreEmpleado, _cargoActual,
                    _sueldoActual, _igssActual, _bonoActual,
                    _otrosActual, _montoLiquido, _noCuenta)

                EnviarCorreoComprobante(_correoEmpleado, _nombreEmpleado, _montoLiquido, rutaArchivo)

                MessageBox.Show("Comprobante enviado correctamente a: " & _correoEmpleado,
                    "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(
                    "El comprobante PNG se guardo, pero hubo un problema al enviar el correo:" &
                    Environment.NewLine & ex.Message,
                    "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' PrintPage — dibuja en una sola hoja Letter apaisada:
        '   ① Comprobante de planilla  (mitad superior)
        '   ② Línea de corte con marca de agua
        '   ③ Cheque BANTRAB           (mitad inferior, orientación horizontal)
        ' ══════════════════════════════════════════════════════════════════

        Private Sub Documento_PrintPage(sender As Object, e As PrintPageEventArgs)
            Try
                Dim g As Graphics = e.Graphics
                Dim L As Single = e.MarginBounds.Left
                Dim T As Single = e.MarginBounds.Top
                Dim W As Single = e.MarginBounds.Width
                Dim R As Single = e.MarginBounds.Right
                Dim BT As Single = e.MarginBounds.Bottom   ' bottom total

                ' ── Fuentes compartidas ────────────────────────────────────
                Dim fTitulo As New Font("Arial", 11, FontStyle.Bold)
                Dim fNormal As New Font("Arial", 8, FontStyle.Regular)
                Dim fNegrita As New Font("Arial", 8, FontStyle.Bold)
                Dim fCampo As New Font("Arial", 9, FontStyle.Regular)
                Dim fMonto As New Font("Arial", 9, FontStyle.Bold)
                Dim fCheqNum As New Font("Arial", 11, FontStyle.Bold)
                Dim fMicr As New Font("Courier New", 7, FontStyle.Regular)
                Dim fCorte As New Font("Arial", 7, FontStyle.Italic)
                Dim fLogo As New Font("Arial", 15, FontStyle.Bold)

                Dim negro As Brush = Brushes.Black
                Dim rojo As Brush = Brushes.DarkRed
                Dim gris As Brush = Brushes.Gray

                Dim sfL As New StringFormat() : sfL.Alignment = StringAlignment.Near
                Dim sfR As New StringFormat() : sfR.Alignment = StringAlignment.Far
                Dim sfC As New StringFormat() : sfC.Alignment = StringAlignment.Center

                Dim lh As Single = 16   ' alto de línea estándar

                ' ══════════════════════════════════════════════════════════
                ' ZONA 1 — COMPROBANTE DE PLANILLA (mitad superior)
                ' Ocupa desde T hasta T + mitadAltura - margen
                ' ══════════════════════════════════════════════════════════
                Dim alturaTotal As Single = BT - T
                Dim mitad As Single = alturaTotal * 0.48F   ' 48 % para comprobante
                Dim yC As Single = T                     ' cursor vertical comprobante

                ' Título
                g.DrawString("BANTRAB  —  COMPROBANTE DE PLANILLA",
                    fTitulo, negro, New RectangleF(L, yC, W, lh + 4), sfC)
                yC += lh + 8

                ' Fecha y número
                g.DrawString(
                    "Fecha: " & DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT),
                    fNormal, negro, L, yC)
                g.DrawString("No. " & _idActual.ToString("D8"), fNegrita, negro,
                    New RectangleF(L, yC, W, lh), sfR)
                yC += lh + 4

                g.DrawLine(Pens.Gray, L, yC, R, yC) : yC += 6

                ' Datos del empleado — col izquierda / col derecha
                Dim colA As Single = L
                Dim colB As Single = L + W * 0.5F

                g.DrawString("Empleado:", fNegrita, negro, colA, yC)
                g.DrawString(_nombreEmpleado.ToUpper(), fNormal, negro, colA + 65, yC)
                g.DrawString("No. Cuenta:", fNegrita, negro, colB, yC)
                g.DrawString(_noCuenta, fNormal, negro, colB + 75, yC)
                yC += lh + 2

                g.DrawString("Cargo:", fNegrita, negro, colA, yC)
                g.DrawString(_cargoActual, fNormal, negro, colA + 65, yC)
                yC += lh + 6

                g.DrawLine(Pens.Gray, L, yC, R, yC) : yC += 6

                ' Encabezado desglose
                g.DrawString("CONCEPTO", fNegrita, negro, colA, yC)
                g.DrawString("MONTO", fNegrita, negro, colA + 200, yC)
                g.DrawString("CONCEPTO", fNegrita, negro, colB, yC)
                g.DrawString("MONTO", fNegrita, negro, colB + 200, yC)
                yC += lh + 2

                ' Filas de desglose en dos columnas para aprovechar el ancho
                Dim filasCon() As String = {"Sueldo Base:", "Bono Incentivo:"}
                Dim filasDesc() As String = {"Retencion IGSS:", "Otros Descuentos:"}
                Dim montosCon() As String = {
                    "Q " & _sueldoActual.ToString("N2"),
                    "Q " & _bonoActual.ToString("N2")
                }
                Dim montosDesc() As String = {
                    "Q " & _igssActual.ToString("N2"),
                    "Q " & _otrosActual.ToString("N2")
                }

                For i As Integer = 0 To 1
                    g.DrawString(filasCon(i), fNormal, negro, colA, yC)
                    g.DrawString(montosCon(i), fNormal, negro, colA + 200, yC)
                    g.DrawString(filasDesc(i), fNormal, negro, colB, yC)
                    g.DrawString(montosDesc(i), fNormal, negro, colB + 200, yC)
                    yC += lh + 2
                Next

                yC += 4
                g.DrawLine(Pens.Gray, L, yC, R, yC) : yC += 6

                ' Total líquido
                g.DrawString("TOTAL LIQUIDO A RECIBIR:", fNegrita, negro, L, yC)
                g.DrawString("Q " & _montoLiquido.ToString("N2"), fMonto, negro,
                    New RectangleF(L, yC, W, lh), sfR)
                yC += lh + 4

                ' En letras
                g.DrawString("En letras: " & Enletras(_montoLiquido),
                    fNormal, negro, New RectangleF(L, yC, W, lh * 2))
                yC += lh * 2 + 6

                ' Líneas de firma dentro del comprobante
                Dim xF1S As Single = L + 20
                Dim xF1E As Single = L + W * 0.35F
                Dim xF2S As Single = L + W * 0.65F
                Dim xF2E As Single = R - 20
                g.DrawLine(Pens.Black, xF1S, yC, xF1E, yC)
                g.DrawLine(Pens.Black, xF2S, yC, xF2E, yC)
                yC += 3
                g.DrawString("Firma Empleado", fNormal, gris,
                    New RectangleF(xF1S, yC, xF1E - xF1S, lh), sfC)
                g.DrawString("Autorizado RRHH", fNormal, gris,
                    New RectangleF(xF2S, yC, xF2E - xF2S, lh), sfC)

                ' ══════════════════════════════════════════════════════════
                ' ZONA 2 — LÍNEA DE CORTE CON MARCA DE AGUA
                ' Centrada entre las dos mitades
                ' ══════════════════════════════════════════════════════════
                Dim yCorte As Single = T + mitad + 10

                ' Línea punteada simulada con guiones cortos
                Dim dashPen As New Pen(Color.Gray, 0.5F)
                dashPen.DashStyle = Drawing2D.DashStyle.Dash
                g.DrawLine(dashPen, L, yCorte, R, yCorte)
                dashPen.Dispose()

                ' Tijera y texto marca de agua centrados sobre la línea
                Dim textoCorte As String = "✂  CORTE AQUI  —  SEPARE EL COMPROBANTE DEL CHEQUE  —  ✂"
                Dim szCorte As SizeF = g.MeasureString(textoCorte, fCorte)
                Dim xTextoCorte As Single = L + (W - szCorte.Width) / 2
                ' Fondo blanco detrás del texto para que tape la línea punteada
                g.FillRectangle(Brushes.White, xTextoCorte - 4, yCorte - szCorte.Height / 2 - 1,
                    szCorte.Width + 8, szCorte.Height + 2)
                g.DrawString(textoCorte, fCorte, Brushes.Gray,
                    xTextoCorte, yCorte - szCorte.Height / 2)

                ' ══════════════════════════════════════════════════════════
                ' ZONA 3 — CHEQUE BANTRAB (mitad inferior, orientación
                ' horizontal — los datos van de izquierda a derecha)
                ' ══════════════════════════════════════════════════════════
                Dim yQ As Single = yCorte + 14   ' inicio del área del cheque
                Dim hQ As Single = BT - yQ        ' altura disponible para el cheque
                Dim lhQ As Single = 15             ' interlineado del cheque

                ' ── Logo BANTRAB arriba izquierda ──────────────────────────
                g.DrawString("* BANTRAB", fLogo, negro, L, yQ)
                g.DrawString(_noCuenta, fNegrita, negro, L, yQ + 22)
                g.DrawString(_nombreEmpleado.ToUpper(), fNegrita, negro, L, yQ + 22 + lhQ)

                ' ── Cheque No. arriba derecha ──────────────────────────────
                g.DrawString("CHEQUE No.", fNegrita, negro,
                    New RectangleF(L, yQ, W, lhQ), sfR)
                g.DrawString(_idActual.ToString("D8"), fCheqNum, negro,
                    New RectangleF(L, yQ + 14, W, lhQ + 4), sfR)
                g.DrawString(Enletras(_montoLiquido), fNormal, negro,
                    New RectangleF(L + W * 0.55F, yQ + 30, W * 0.45F, lhQ * 2), sfR)

                ' ── Fila 1: Lugar y fecha ──────────────────────────────────
                Dim yQ1 As Single = yQ + 62
                g.DrawString("LUGAR Y FECHA:", fNegrita, negro, L, yQ1)
                g.DrawString(
                    "Guatemala, " & DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT),
                    fCampo, negro, L + 100, yQ1)
                g.DrawString("0921", fNegrita, rojo,
                    New RectangleF(L, yQ1, W, lhQ), sfR)
                g.DrawLine(Pens.Black, L, yQ1 + lhQ, R, yQ1 + lhQ)

                ' ── Fila 2: Páguese a ──────────────────────────────────────
                Dim yQ2 As Single = yQ1 + lhQ + 6
                g.DrawString("PAGUESE A:", fNegrita, negro, L, yQ2)
                g.DrawString(_nombreEmpleado.ToUpper(), fMonto, negro, L + 80, yQ2)
                g.DrawString("Q.", fNegrita, negro,
                    New RectangleF(L, yQ2, W - 65, lhQ), sfR)
                g.DrawString(_montoLiquido.ToString("N2"), fMonto, negro,
                    New RectangleF(L, yQ2, W, lhQ), sfR)
                g.DrawLine(Pens.Black, L + 80, yQ2 + lhQ, R - 85, yQ2 + lhQ)

                ' ── Fila 3: La cantidad de ─────────────────────────────────
                Dim yQ3 As Single = yQ2 + lhQ + 6
                g.DrawString("LA CANTIDAD DE:", fNegrita, negro, L, yQ3)
                g.DrawString(Enletras(_montoLiquido), fCampo, negro,
                    New RectangleF(L + 115, yQ3, W - 115, lhQ * 2))

                Dim refTexto As String =
                    "GT95 TRAJ 0101 0000 " &
                    _noCuenta.Replace("-", "").PadLeft(8, "0"c) & " " &
                    _idActual.ToString("D4") & " " &
                    DateTime.Now.Year.ToString()
                g.DrawString(refTexto, fNegrita, rojo, L, yQ3 + lhQ + 4)
                g.DrawLine(Pens.Black, L, yQ3 + lhQ * 2 + 4, R, yQ3 + lhQ * 2 + 4)

                ' ── Bloque inferior del cheque: ref + firma + Q. ───────────
                Dim yQF As Single = yQ3 + lhQ * 2 + 10
                g.DrawString("Ref.:", fNegrita, negro, L, yQF)
                g.DrawString("BANCO DE LOS TRABAJADORES, GUATEMALA, C.A.",
                    fNormal, negro, L + 40, yQF)

                Dim xFirmaIni As Single = R - 190
                g.DrawLine(Pens.Black, xFirmaIni, yQF + lhQ + 2, R, yQF + lhQ + 2)
                g.DrawString("Firma(s) Registrada(s)", fNormal, negro,
                    xFirmaIni, yQF + lhQ + 4)

                Dim yQM As Single = yQF + lhQ * 2 + 4
                g.DrawString("Q.", fNegrita, negro, R - 130, yQM)
                g.DrawString(_montoLiquido.ToString("N2"), fMonto, negro, R - 105, yQM)
                g.DrawString("QUETZALES.", fNormal, negro,
                    New RectangleF(L, yQM, W, lhQ), sfR)

                ' ── Línea MICR inferior ────────────────────────────────────
                Dim yMicr As Single = BT - 12
                Dim micrTexto As String =
                    "||" & _idActual.ToString("D9") & "|| " &
                    _noCuenta.Replace("-", "").PadLeft(10, "0"c) & "|| " &
                    _idActual.ToString("D8") & "||"
                g.DrawString(micrTexto, fMicr, negro, L, yMicr)

                ' ── Liberar recursos ───────────────────────────────────────
                fTitulo.Dispose() : fNormal.Dispose() : fNegrita.Dispose()
                fCampo.Dispose() : fMonto.Dispose() : fCheqNum.Dispose()
                fMicr.Dispose() : fCorte.Dispose() : fLogo.Dispose()
                sfL.Dispose() : sfR.Dispose() : sfC.Dispose()

                e.HasMorePages = False

            Catch ex As Exception
                MessageBox.Show("Error al dibujar la hoja: " & ex.Message,
                    "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' ══════════════════════════════════════════════════════════════════
        ' Botón Planilla completa — genera y envía comprobante a todos
        ' (igual que antes; no imprime el cheque masivamente)
        ' ══════════════════════════════════════════════════════════════════

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Try
                Dim ids As New System.Collections.Generic.List(Of Integer)
                Dim nombres As New System.Collections.Generic.List(Of String)
                Dim cargos As New System.Collections.Generic.List(Of String)
                Dim sueldos As New System.Collections.Generic.List(Of Double)
                Dim igssArr As New System.Collections.Generic.List(Of Double)
                Dim bonos As New System.Collections.Generic.List(Of Double)
                Dim otrosArr As New System.Collections.Generic.List(Of Double)
                Dim liquidos As New System.Collections.Generic.List(Of Double)
                Dim correos As New System.Collections.Generic.List(Of String)
                Dim cuentas As New System.Collections.Generic.List(Of String)

                Const query As String =
                    "SELECT id_trabajador, nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta " &
                    "FROM trabajadores"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            While dr.Read()
                                ids.Add(Convert.ToInt32(dr("id_trabajador")))
                                nombres.Add(dr("nombres").ToString())
                                cargos.Add(dr("cargo").ToString())
                                sueldos.Add(Convert.ToDouble(dr("sueldo")))
                                igssArr.Add(Convert.ToDouble(dr("igss")))
                                bonos.Add(Convert.ToDouble(dr("bono")))
                                otrosArr.Add(Convert.ToDouble(dr("otros")))
                                liquidos.Add(Convert.ToDouble(dr("liquido")))
                                correos.Add(dr("correo").ToString())
                                cuentas.Add(dr("no_cuenta").ToString())
                            End While
                        End Using
                    End Using
                End Using

                If ids.Count = 0 Then
                    MessageBox.Show("No hay trabajadores registrados en la planilla.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim errores As New System.Collections.Generic.List(Of String)

                For i As Integer = 0 To ids.Count - 1
                    Try
                        Dim ruta As String = GenerarImagenComprobante(
                            ids(i), nombres(i), cargos(i),
                            sueldos(i), igssArr(i), bonos(i),
                            otrosArr(i), liquidos(i), cuentas(i))
                        Try
                            EnviarCorreoComprobante(correos(i), nombres(i), liquidos(i), ruta)
                        Catch exMail As Exception
                            errores.Add($"Correo no enviado a {nombres(i)}: {exMail.Message}")
                        End Try
                    Catch exT As Exception
                        errores.Add($"Error procesando a {nombres(i)}: {exT.Message}")
                    End Try
                Next

                Dim resumen As String =
                    $"Planilla procesada: {ids.Count} comprobante(s) generado(s) y guardado(s) en:" &
                    Environment.NewLine & _carpetaComprobantes

                If errores.Count > 0 Then
                    resumen &= Environment.NewLine & Environment.NewLine &
                               "Advertencias:" & Environment.NewLine &
                               String.Join(Environment.NewLine, errores)
                End If

                MessageBox.Show(resumen, "Proceso completado", MessageBoxButtons.OK,
                    If(errores.Count > 0, MessageBoxIcon.Warning, MessageBoxIcon.Information))

            Catch ex As MySqlException
                MessageBox.Show("Error de base de datos: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error inesperado: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace