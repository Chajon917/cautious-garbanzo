Imports MySql.Data.MySqlClient
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports MailKit.Net.Smtp
Imports MailKit.Security
Imports MimeKit

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormCheque
        Inherits Form

        ' ── Estado del cheque activo ────────────────────────────────────────
        Private _nombreEmpleado As String = ""
        Private _montoLiquido As Double = 0
        Private _correoEmpleado As String = ""
        Private _noCuenta As String = ""
        Private _chequeGenerado As Boolean = False   ' MEJORA: bandera explícita

        ' ── Configuración SMTP ─────────────────────────────────────────────
        ' SmtpClave debe ser una CONTRASEÑA DE APLICACIÓN de Google (16 chars),
        ' no la contraseña normal de la cuenta.
        ' Obtenerla: myaccount.google.com → Seguridad → Contraseñas de aplicaciones
        '
        ' MEJORA: mover estas constantes a App.config para no exponerlas en código fuente.
        ' En producción use variables de entorno o el almacén de credenciales de Windows.
        Private Const SmtpHost As String = "smtp.gmail.com"
        Private Const SmtpPort As Integer = 587
        Private Const SmtpUsuario As String = "averkzalexd@gmail.com"   ' ← cambiar
        Private Const SmtpClave As String = "hwlvvzwvirxlwrvv"           ' ← clave de aplicación
        Private Const RemitenteMostrado As String = "Recursos Humanos"

        Private ReadOnly _culturaGT As New CultureInfo("es-GT")

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(idExterno As String)
            Me.New()
            If Not String.IsNullOrWhiteSpace(idExterno) Then
                txtIdBusqueda.Text = idExterno.Trim()
                BtnGenerar_Click(Nothing, EventArgs.Empty)
            End If
        End Sub

        ' ── Conversión numérica a texto ────────────────────────────────────

        ''' <summary>
        ''' Convierte un monto monetario en su representación en letras (español).
        ''' MEJORA: maneja correctamente el caso especial "CIEN" vs "CIENTO".
        ''' </summary>
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

        ' ── Imprimir cheque individual ──────────────────────────────────────

        Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
            ' MEJORA: verificar con la bandera en lugar de depender de un string vacío.
            If Not _chequeGenerado Then
                MessageBox.Show("Genere el comprobante antes de imprimir.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            printDocument1.DefaultPageSettings.Landscape = False

            Using dlg As New PrintDialog() With {.Document = printDocument1}
                If dlg.ShowDialog() <> DialogResult.OK Then Return
                printDocument1.Print()
            End Using

            ' MEJORA: se pregunta al usuario si desea enviar el correo,
            ' en lugar de hacerlo automáticamente sin confirmación.
            If Not String.IsNullOrWhiteSpace(_correoEmpleado) Then
                Dim r As DialogResult = MessageBox.Show(
                    $"¿Enviar comprobante por correo a {_correoEmpleado}?",
                    "Enviar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If r = DialogResult.Yes Then
                    EnviarComprobantePorCorreo(_nombreEmpleado, _correoEmpleado, _noCuenta, _montoLiquido)
                End If
            End If
        End Sub

        ' ── Imprimir todos los cheques ──────────────────────────────────────

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Using dlg As New PrintDialog() With {.Document = printDocument1}
                If dlg.ShowDialog() <> DialogResult.OK Then Return
            End Using

            Try
                Const query As String =
                    "SELECT nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta " &
                    "FROM trabajadores ORDER BY nombres"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()

                            ' MEJORA: acumula errores de correo para reportarlos al final,
                            ' sin interrumpir la impresión de los demás cheques.
                            Dim erroresCorreo As New System.Text.StringBuilder()

                            While dr.Read()
                                _nombreEmpleado = dr("nombres").ToString()
                                _montoLiquido = Convert.ToDouble(dr("liquido"))
                                _correoEmpleado = dr("correo").ToString()
                                _noCuenta = dr("no_cuenta").ToString()

                                lblFecha.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT)
                                lblNoCheque.Text = "No. "
                                lblNombre.Text = _nombreEmpleado.ToUpper()
                                lblCargo.Text = dr("cargo").ToString()
                                lblSueldo.Text = "Q " & Convert.ToDouble(dr("sueldo")).ToString("N2")
                                lblIGSS.Text = "Q " & Convert.ToDouble(dr("igss")).ToString("N2")
                                lblBono.Text = "Q " & Convert.ToDouble(dr("bono")).ToString("N2")
                                lblOtros.Text = "Q " & Convert.ToDouble(dr("otros")).ToString("N2")
                                lblMontoNumero.Text = "Q " & _montoLiquido.ToString("N2")
                                lblMontoLetras.Text = Enletras(_montoLiquido)
                                _chequeGenerado = True

                                printDocument1.Print()

                                If Not String.IsNullOrWhiteSpace(_correoEmpleado) Then
                                    Try
                                        EnviarComprobantePorCorreo(
                                            _nombreEmpleado, _correoEmpleado, _noCuenta, _montoLiquido)
                                    Catch exMail As Exception
                                        erroresCorreo.AppendLine($"  • {_nombreEmpleado} ({_correoEmpleado}): {exMail.Message}")
                                    End Try
                                End If
                            End While

                            If erroresCorreo.Length > 0 Then
                                MessageBox.Show(
                                    "Se completó la impresión, pero algunos correos fallaron:" &
                                    Environment.NewLine & erroresCorreo.ToString(),
                                    "Correos no enviados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
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

        ' ── Envío de correo (MailKit) ───────────────────────────────────────

        Private Sub EnviarComprobantePorCorreo(nombre As String, correo As String,
                                               noCuenta As String, monto As Double)
            Dim fechaHoy As String = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", _culturaGT)
            Dim periodo As String = DateTime.Now.ToString("MMMM yyyy", _culturaGT).ToUpper()

            Dim cuerpo As String =
                $"Estimado/a {nombre}," & Environment.NewLine & Environment.NewLine &
                $"Su pago de planilla del período {periodo} ha sido liquidado." &
                Environment.NewLine & Environment.NewLine &
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & Environment.NewLine &
                "  COMPROBANTE DE PAGO" & Environment.NewLine &
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & Environment.NewLine &
                $"  Nombre:        {nombre}" & Environment.NewLine &
                $"  No. de Cuenta: {noCuenta}" & Environment.NewLine &
                $"  Monto Líquido: Q {monto:N2}" & Environment.NewLine &
                $"  En Letras:     {Enletras(monto)}" & Environment.NewLine &
                $"  Fecha:         {fechaHoy}" & Environment.NewLine &
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & Environment.NewLine & Environment.NewLine &
                "El monto ha sido acreditado a su cuenta bancaria." & Environment.NewLine & Environment.NewLine &
                "Atentamente," & Environment.NewLine &
                RemitenteMostrado & Environment.NewLine &
                "Departamento de Recursos Humanos"

            Dim mensaje As New MimeMessage()
            mensaje.From.Add(New MailboxAddress(RemitenteMostrado, SmtpUsuario))
            mensaje.To.Add(New MailboxAddress(nombre, correo))
            mensaje.Subject = $"Comprobante de Pago - {periodo}"
            mensaje.Body = New TextPart("plain") With {.Text = cuerpo}

            Using smtp As New SmtpClient()
                smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls)
                smtp.Authenticate(SmtpUsuario, SmtpClave)
                smtp.Send(mensaje)
                smtp.Disconnect(True)
            End Using

            MessageBox.Show($"Comprobante enviado a: {correo}",
                "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        ' ── Impresión (PrintPage) ───────────────────────────────────────────

        Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDocument1.PrintPage
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim x As Integer = e.MarginBounds.Left
            Dim y As Integer = e.MarginBounds.Top
            Dim w As Integer = e.MarginBounds.Width
            Const lineH As Integer = 22

            ' MEJORA: fuentes en variables locales con Using implícito a través de Dispose al final.
            Dim fontTitulo As New Font("Arial", 14, FontStyle.Bold)
            Dim fontNormal As New Font("Arial", 10, FontStyle.Regular)
            Dim fontBold As New Font("Arial", 10, FontStyle.Bold)
            Dim fontGrande As New Font("Arial", 12, FontStyle.Bold)
            Dim fontCorte As New Font("Arial", 8, FontStyle.Regular)
            Dim fontCheque As New Font("Arial", 9, FontStyle.Regular)
            Dim fontChequeBold As New Font("Arial", 9, FontStyle.Bold)
            Dim fontBanco As New Font("Arial", 11, FontStyle.Bold)
            Dim fontMICR As New Font("Courier New", 8, FontStyle.Regular)

            Dim negro As Brush = Brushes.Black
            Dim rojo As Brush = Brushes.Red
            Dim centroX As Integer = x + w \ 2

            Try
                ' ── Encabezado ──────────────────────────────────────────────
                g.DrawString("COMPROBANTE DE PAGO", fontTitulo, negro, x, y)
                y += lineH + 6

                g.DrawString("Fecha: " & lblFecha.Text, fontNormal, negro, x, y)
                g.DrawString(lblNoCheque.Text, fontBold, negro, x + w - 120, y)
                y += lineH + 10

                g.DrawLine(Pens.Black, x, y, x + w, y) : y += 10

                ' ── Datos del empleado ───────────────────────────────────────
                g.DrawString("Nombre:     " & lblNombre.Text, fontBold, negro, x, y) : y += lineH
                g.DrawString("Cargo:      " & lblCargo.Text, fontNormal, negro, x, y) : y += lineH
                g.DrawString("No. Cuenta: " & _noCuenta, fontNormal, negro, x, y) : y += lineH
                g.DrawString("Correo:     " & _correoEmpleado, fontNormal, negro, x, y) : y += lineH + 10

                g.DrawLine(Pens.Black, x, y, x + w, y) : y += 10

                ' ── Detalle montos ───────────────────────────────────────────
                For Each par In {
                    ("Sueldo:", lblSueldo.Text),
                    ("IGSS:", lblIGSS.Text),
                    ("Bono:", lblBono.Text),
                    ("Otros:", lblOtros.Text)
                }
                    g.DrawString(par.Item1, fontNormal, negro, x, y)
                    g.DrawString(par.Item2, fontNormal, negro, x + 200, y)
                    y += lineH
                Next
                y += 10

                g.DrawLine(Pens.Black, x, y, x + w, y) : y += 10

                ' ── Monto líquido ────────────────────────────────────────────
                g.DrawString("MONTO LÍQUIDO:", fontGrande, negro, x, y)
                g.DrawString(lblMontoNumero.Text, fontGrande, negro, x + 200, y) : y += lineH + 6
                g.DrawString(lblMontoLetras.Text, fontNormal, negro, x, y) : y += lineH + 30

                g.DrawLine(Pens.Black, x, y, x + w, y) : y += 40

                ' ── Firma ────────────────────────────────────────────────────
                g.DrawLine(Pens.Black, centroX - 80, y, centroX + 80, y) : y += 6
                Dim szAut As SizeF = g.MeasureString("Autorizado", fontNormal)
                g.DrawString("Autorizado", fontNormal, negro, centroX - szAut.Width / 2, y)
                y += lineH + 20

                ' ── Línea de corte ───────────────────────────────────────────
                Using penCorte As New Pen(Color.Gray, 1.0F) With {
                    .DashStyle = Drawing2D.DashStyle.Dash
                }
                    g.DrawLine(penCorte, x, y, x + w, y)
                End Using

                Dim textoCorte As String = "✂  CORTE AQUÍ"
                Dim szCorte As SizeF = g.MeasureString(textoCorte, fontCorte)
                g.DrawString(textoCorte, fontCorte, Brushes.Gray,
                    centroX - szCorte.Width / 2, y + 3)
                y += 22

                ' ── Cheque BANTRAB ───────────────────────────────────────────
                g.DrawRectangle(Pens.Black, New Rectangle(x, y, w, 230)) : y += 10

                g.DrawString("BANTRAB", fontBanco, negro, x + 10, y)
                g.DrawString("BANCO DE LOS TRABAJADORES, GUATEMALA, C. A.",
                    fontCheque, negro, x + 10, y + 18)

                Dim noChequeStr As String = "CHEQUE No.: 04000011"
                Dim szNo As SizeF = g.MeasureString(noChequeStr, fontChequeBold)
                g.DrawString(noChequeStr, fontChequeBold, negro, x + w - CInt(szNo.Width) - 10, y)

                Dim correlativo As String = "05790702"
                Dim szCorr As SizeF = g.MeasureString(correlativo, fontChequeBold)
                g.DrawString(correlativo, fontChequeBold, rojo,
                    x + w - CInt(szCorr.Width) - 10, y + 16) : y += 44

                g.DrawLine(Pens.Black, x + 10, y, x + w - 10, y) : y += 8

                g.DrawString($"Cta. No.: {_noCuenta}          Titular: {_nombreEmpleado.ToUpper()}",
                    fontCheque, negro, x + 10, y) : y += lineH
                g.DrawString("Lugar y Fecha: _______________________", fontCheque, negro, x + 10, y) : y += lineH
                g.DrawString($"Páguese a: {_nombreEmpleado.ToUpper()}", fontCheque, negro, x + 10, y) : y += lineH
                g.DrawString($"La Cantidad de (Q.): Q {_montoLiquido:N2}",
                    fontChequeBold, negro, x + 10, y) : y += lineH
                g.DrawString("Son: " & Enletras(_montoLiquido), fontCheque, negro, x + 10, y) : y += lineH + 6
                g.DrawString("Ref.: GT95 TRAJ 0101 0000 0079 0029 9647",
                    fontCheque, negro, x + 10, y) : y += lineH + 6

                g.DrawLine(Pens.Black, x + 10, y, x + w - 10, y) : y += 8

                Dim szFirma As SizeF = g.MeasureString("Firma(s) Registrada(s)", fontCheque)
                g.DrawString("Firma(s) Registrada(s)", fontCheque, negro,
                    x + w - CInt(szFirma.Width) - 10, y) : y += lineH + 4

                Dim comilla As String = Convert.ToChar(34).ToString()
                g.DrawString($"||{comilla} 31:000000112:7900 299647||{comilla}04000011 || {comilla}00000000921,'",
                    fontMICR, negro, x + 10, y) : y += lineH

                g.DrawString("F. STANDARD, S.A.  PBX: 2423-8900  FAX: 2439-4916",
                    fontCorte, Brushes.Gray, x + 10, y)

            Finally
                ' MEJORA: Dispose garantizado aunque ocurra una excepción durante la impresión.
                fontTitulo.Dispose()
                fontNormal.Dispose()
                fontBold.Dispose()
                fontGrande.Dispose()
                fontCorte.Dispose()
                fontCheque.Dispose()
                fontChequeBold.Dispose()
                fontBanco.Dispose()
                fontMICR.Dispose()
            End Try

            e.HasMorePages = False
        End Sub

        ' ── Eventos vacíos conservados para compatibilidad con el designer ──

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Me.Close()
        End Sub

        Private Sub FormCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        End Sub

    End Class

End Namespace