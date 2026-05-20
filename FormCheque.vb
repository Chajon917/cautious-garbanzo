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

        Private Const SmtpHost As String = "smtp.gmail.com"
        Private Const SmtpPort As Integer = 587
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

        ' ── Conversión numérica a texto ────────────────────────────────────

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
                "QUINCE", "DIECISÉIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE"
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
                Return If(valor \ 1_000_000 = 1, "UN MILLÓN",
                          NumeroALetras(valor \ 1_000_000) & " MILLONES") &
                       If(valor Mod 1_000_000 > 0, " " & NumeroALetras(valor Mod 1_000_000), "")
            End If
            Return ""
        End Function

        ' ── Generar cheque ─────────────────────────────────────────────────

        Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
            Dim idTexto As String = txtIdBusqueda.Text.Trim()

            If String.IsNullOrWhiteSpace(idTexto) Then
                MessageBox.Show("Ingrese un ID de trabajador.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim idTrabajador As Integer
            If Not Integer.TryParse(idTexto, idTrabajador) OrElse idTrabajador <= 0 Then
                MessageBox.Show("El ID debe ser un número entero positivo.",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                Const query As String =
                    "SELECT nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta " &
                    "FROM trabajadores " &
                    "WHERE id_trabajador = @id"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", idTrabajador)

                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If Not dr.Read() Then
                                MessageBox.Show(
                                    $"No se encontró ningún trabajador con el ID {idTrabajador}.",
                                    "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                _chequeGenerado = False
                                Return
                            End If

                            _nombreEmpleado = dr("nombres").ToString()
                            _montoLiquido = Convert.ToDouble(dr("liquido"))
                            _correoEmpleado = dr("correo").ToString()
                            _noCuenta = dr("no_cuenta").ToString()

                            lblFecha.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT)
                            lblNoCheque.Text = "No. " & idTrabajador.ToString("D6")
                            lblNombre.Text = _nombreEmpleado.ToUpper()
                            lblCargo.Text = dr("cargo").ToString()
                            lblSueldo.Text = "Q " & Convert.ToDouble(dr("sueldo")).ToString("N2")
                            lblIGSS.Text = "Q " & Convert.ToDouble(dr("igss")).ToString("N2")
                            lblBono.Text = "Q " & Convert.ToDouble(dr("bono")).ToString("N2")
                            lblOtros.Text = "Q " & Convert.ToDouble(dr("otros")).ToString("N2")
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

        ' ── Cerrar formulario ──────────────────────────────────────────────
        ' CORRECCIÓN 1: Handler del botón cerrar que faltaba completamente

        Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
            Me.Close()
        End Sub

        ' ── Imprimir cheque individual ──────────────────────────────────────
        ' CORRECCIÓN 2: Se envuelve en Try/Catch para capturar errores silenciosos
        '              y se usa PrintDialog antes del preview para garantizar
        '              que haya una impresora seleccionada.

        Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
            If Not _chequeGenerado Then
                MessageBox.Show("Primero debe generar un cheque válido.",
                    "Acción inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf Documento_PrintPage

                ' Mostrar diálogo de impresora para que el usuario elija o confirme
                Using dlg As New PrintDialog()
                    dlg.Document = pd
                    dlg.AllowSomePages = False
                    dlg.UseEXDialog = True

                    If dlg.ShowDialog() = DialogResult.OK Then
                        ' Vista previa antes de imprimir
                        Using pdi As New PrintPreviewDialog()
                            pdi.Document = pd
                            pdi.Width = 900
                            pdi.Height = 650
                            pdi.Text = "Vista previa del cheque"
                            pdi.ShowDialog()
                        End Using
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al preparar la impresión: " & ex.Message,
                    "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' ── Evento de impresión ────────────────────────────────────────────

        Private Sub Documento_PrintPage(sender As Object, e As PrintPageEventArgs)
            Try
                Dim g As Graphics = e.Graphics
                Dim fontTitulo As New Font("Arial", 14, FontStyle.Bold)
                Dim fontNormal As New Font("Arial", 10, FontStyle.Regular)
                Dim fontNegrita As New Font("Arial", 10, FontStyle.Bold)

                Dim x As Integer = 50
                Dim y As Integer = 50
                Dim lineH As Integer = 25

                g.DrawString("BANCO DE LA REPUBLICA", fontTitulo, Brushes.Black, x, y)
                y += lineH * 2

                g.DrawString("Fecha: " & lblFecha.Text, fontNormal, Brushes.Black, x, y)
                g.DrawString(lblNoCheque.Text, fontNegrita, Brushes.Black, x + 400, y)
                y += lineH

                g.DrawString("Páguese a la orden de: " & lblNombre.Text, fontNormal, Brushes.Black, x, y)
                g.DrawString(lblMontoNumero.Text, fontNegrita, Brushes.Black, x + 400, y)
                y += lineH

                g.DrawString("La suma de: " & lblMontoLetras.Text, fontNormal, Brushes.Black, x, y)
                y += lineH * 2

                g.DrawString("DESGLOSE DE PLANILLA", fontNegrita, Brushes.Black, x, y)
                y += lineH

                Dim detalles As New System.Collections.Generic.List(Of (Concepto As String, Monto As String)) From {
                    ("Sueldo Base:", lblSueldo.Text),
                    ("Bono Incentivo:", lblBono.Text),
                    ("Retención IGSS:", lblIGSS.Text),
                    ("Otros Descuentos:", lblOtros.Text),
                    ("Total Líquido:", lblMontoNumero.Text)
                }

                For Each par In detalles
                    g.DrawString(par.Concepto, fontNormal, Brushes.Black, x, y)
                    g.DrawString(par.Monto, fontNormal, Brushes.Black, x + 200, y)
                    y += lineH
                Next

                e.HasMorePages = False

            Catch ex As Exception
                MessageBox.Show("Error al dibujar el cheque: " & ex.Message,
                    "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Try
                Dim trabajadores As New System.Collections.Generic.List(Of (
            Id As Integer,
            Nombre As String,
            Cargo As String,
            Sueldo As Double,
            IGSS As Double,
            Bono As Double,
            Otros As Double,
            Liquido As Double,
            Correo As String,
            NoCuenta As String
        ))

                Const query As String =
            "SELECT id_trabajador, nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta " &
            "FROM trabajadores"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            While dr.Read()
                                trabajadores.Add((
                            Convert.ToInt32(dr("id_trabajador")),
                            dr("nombres").ToString(),
                            dr("cargo").ToString(),
                            Convert.ToDouble(dr("sueldo")),
                            Convert.ToDouble(dr("igss")),
                            Convert.ToDouble(dr("bono")),
                            Convert.ToDouble(dr("otros")),
                            Convert.ToDouble(dr("liquido")),
                            dr("correo").ToString(),
                            dr("no_cuenta").ToString()
                        ))
                            End While
                        End Using
                    End Using
                End Using

                If trabajadores.Count = 0 Then
                    MessageBox.Show("No hay trabajadores registrados en la planilla.",
                "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim errores As New System.Collections.Generic.List(Of String)

                For Each t In trabajadores
                    Try
                        ' ── Generar imagen del comprobante ──────────────────────────
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

                            g.DrawString("BANCO DE LA REPUBLICA — COMPROBANTE DE PLANILLA", fontTitulo, brushN, x, y)
                            y += lineH + 6

                            g.DrawString("Fecha: " & DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT), fontNormal, brushN, x, y)
                            g.DrawString("No. " & t.Id.ToString("D6"), fontNegrita, brushN, x + 450, y)
                            y += lineH

                            g.DrawString("Empleado: " & t.Nombre.ToUpper(), fontNegrita, brushN, x, y)
                            y += lineH
                            g.DrawString("Cargo: " & t.Cargo, fontNormal, brushN, x, y)
                            y += lineH
                            g.DrawString("No. Cuenta: " & t.NoCuenta, fontNormal, brushN, x, y)
                            y += lineH + 6

                            g.DrawLine(Pens.Gray, x, y, 670, y)
                            y += 8

                            g.DrawString("DESGLOSE DE PLANILLA", fontNegrita, brushN, x, y)
                            y += lineH

                            Dim detalles As New System.Collections.Generic.List(Of (String, String)) From {
                        ("Sueldo Base:", "Q " & t.Sueldo.ToString("N2")),
                        ("Bono Incentivo:", "Q " & t.Bono.ToString("N2")),
                        ("Retención IGSS:", "Q " & t.IGSS.ToString("N2")),
                        ("Otros Descuentos:", "Q " & t.Otros.ToString("N2"))
                    }

                            For Each par In detalles
                                g.DrawString(par.Item1, fontNormal, brushN, x, y)
                                g.DrawString(par.Item2, fontNormal, brushN, x + 220, y)
                                y += lineH
                            Next

                            g.DrawLine(Pens.Gray, x, y, 400, y)
                            y += 6
                            g.DrawString("Total Líquido:", fontNegrita, brushN, x, y)
                            g.DrawString("Q " & t.Liquido.ToString("N2"), fontNegrita, brushN, x + 220, y)
                            y += lineH + 6

                            g.DrawString("En letras: " & Enletras(t.Liquido), fontNormal, brushN, x, y)
                            y += lineH + 10

                            g.DrawLine(Pens.Black, x, y, 280, y)
                            g.DrawLine(Pens.Black, 380, y, 660, y)
                            y += 4
                            g.DrawString("Firma Empleado", fontNormal, brushN, x + 60, y)
                            g.DrawString("Autorizado por RRHH", fontNormal, brushN, x + 400, y)
                        End Using

                        ' ── Guardar PNG en carpeta de comprobantes ──────────────────
                        Dim nombreArchivo As String = Path.Combine(
                    _carpetaComprobantes,
                    $"Comprobante_{t.Id:D6}_{t.Nombre.Replace(" ", "_")}.png")

                        bmp.Save(nombreArchivo, ImageFormat.Png)

                        ' ── Enviar correo con el comprobante adjunto ────────────────
                        If Not String.IsNullOrWhiteSpace(t.Correo) Then
                            Try
                                Dim mensaje As New MimeMessage()
                                mensaje.From.Add(New MailboxAddress(RemitenteMostrado, SmtpUsuario))
                                mensaje.To.Add(MailboxAddress.Parse(t.Correo))
                                mensaje.Subject = "Comprobante de Planilla — " & DateTime.Now.ToString("MMMM yyyy", _culturaGT)

                                Dim builder As New BodyBuilder()
                                builder.TextBody =
                            $"Estimado/a {t.Nombre}," & Environment.NewLine & Environment.NewLine &
                            "Adjunto encontrará su comprobante de planilla correspondiente al período " &
                            DateTime.Now.ToString("MMMM yyyy", _culturaGT) & "." & Environment.NewLine & Environment.NewLine &
                            $"Monto líquido a recibir: Q {t.Liquido:N2}" & Environment.NewLine & Environment.NewLine &
                            "Atentamente," & Environment.NewLine &
                            "Recursos Humanos"
                                builder.Attachments.Add(nombreArchivo)
                                mensaje.Body = builder.ToMessageBody()

                                Using smtp As New SmtpClient()
                                    smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls)
                                    smtp.Authenticate(SmtpUsuario, SmtpClave)
                                    smtp.Send(mensaje)
                                    smtp.Disconnect(True)
                                End Using

                            Catch exMail As Exception
                                errores.Add($"Correo no enviado a {t.Nombre}: {exMail.Message}")
                            End Try
                        End If

                        bmp.Dispose()

                    Catch exT As Exception
                        errores.Add($"Error procesando a {t.Nombre}: {exT.Message}")
                    End Try
                Next

                Dim resumen As String =
            $"Planilla procesada: {trabajadores.Count} comprobante(s) generado(s) y guardado(s) en:{Environment.NewLine}{_carpetaComprobantes}"

                If errores.Count > 0 Then
                    resumen &= Environment.NewLine & Environment.NewLine &
                       "Advertencias:" & Environment.NewLine &
                       String.Join(Environment.NewLine, errores)
                End If

                MessageBox.Show(resumen, "Proceso completado",
            MessageBoxButtons.OK,
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