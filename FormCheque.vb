Imports MySql.Data.MySqlClient
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormCheque
        Inherits Form

        Private _nombreEmpleado As String = ""
        Private _montoLiquido As Double = 0

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(idExterno As String)
            Me.New()
            If Not String.IsNullOrWhiteSpace(idExterno) Then
                txtIdBusqueda.Text = idExterno.Trim()
                btnGenerar_Click(Nothing, EventArgs.Empty)
            End If
        End Sub

        ' ── Número a letras ────────────────────────────────────────────────────
        Public Function Enletras(total As Double) As String
            If total < 0 Then Return "Monto inválido"
            Dim entero As Long = CLng(Math.Floor(total))
            Dim centavos As Integer = CInt(Math.Round((total - entero) * 100))
            Dim parteEntera As String = NumeroALetras(entero)
            Dim parteCentavos As String = If(centavos > 0,
                " CON " & centavos.ToString("D2") & "/100 CENTAVOS",
                " EXACTOS")
            Return parteEntera & " QUETZALES" & parteCentavos
        End Function

        Private Function NumeroALetras(valor As Long) As String
            If valor = 0 Then Return "CERO"
            If valor < 0 Then Return "MENOS " & NumeroALetras(Math.Abs(valor))

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
            If valor < 100 Then
                Return decenas(CInt(valor \ 10)) & If(valor Mod 10 > 0, " Y " & unidades(CInt(valor Mod 10)), "")
            End If
            If valor = 100 Then Return "CIEN"
            If valor < 1000 Then
                Return centenas(CInt(valor \ 100)) & If(valor Mod 100 > 0, " " & NumeroALetras(valor Mod 100), "")
            End If
            If valor < 1000000 Then
                Return (If(valor \ 1000 = 1, "MIL", NumeroALetras(valor \ 1000) & " MIL")) &
                       If(valor Mod 1000 > 0, " " & NumeroALetras(valor Mod 1000), "")
            End If
            If valor < 1000000000 Then
                Return (If(valor \ 1000000 = 1, "UN MILLÓN", NumeroALetras(valor \ 1000000) & " MILLONES")) &
                       If(valor Mod 1000000 > 0, " " & NumeroALetras(valor Mod 1000000), "")
            End If
            Return ""
        End Function

        ' ── Generar cheque ─────────────────────────────────────────────────────
        Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
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
                    "SELECT nombres, cargo, sueldo, igss, bono, otros, liquido " &
                    "FROM trabajadores " &
                    "WHERE id_trabajador = @id"

                Dim obj As New CConexion()
                Using conn As MySqlConnection = obj.ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", idTrabajador)

                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If Not dr.Read() Then
                                MessageBox.Show(
                                    "No se encontró ningún trabajador con el ID " & idTrabajador & ".",
                                    "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If

                            Dim culturaGT As New CultureInfo("es-GT")

                            _nombreEmpleado = dr("nombres").ToString()
                            _montoLiquido = Convert.ToDouble(dr("liquido"))

                            lblFecha.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", culturaGT)
                            lblNoCheque.Text = "No. " & idTrabajador.ToString("D6")
                            lblNombre.Text = _nombreEmpleado.ToUpper()
                            lblCargo.Text = dr("cargo").ToString()
                            lblSueldo.Text = "Q " & Convert.ToDouble(dr("sueldo")).ToString("N2")
                            lblIGSS.Text = "Q " & Convert.ToDouble(dr("igss")).ToString("N2")
                            lblBono.Text = "Q " & Convert.ToDouble(dr("bono")).ToString("N2")
                            lblOtros.Text = "Q " & Convert.ToDouble(dr("otros")).ToString("N2")
                            lblMontoNumero.Text = "Q " & _montoLiquido.ToString("N2")
                            lblMontoLetras.Text = Enletras(_montoLiquido)
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

        ' ── Imprimir ───────────────────────────────────────────────────────────
        Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
            If String.IsNullOrEmpty(_nombreEmpleado) Then
                MessageBox.Show("Genere el comprobante antes de imprimir.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            printDocument1.DefaultPageSettings.Landscape = False

            Dim dlg As New PrintDialog()
            dlg.Document = printDocument1
            If dlg.ShowDialog() = DialogResult.OK Then
                printDocument1.Print()
            End If
        End Sub

        ' ── Evento PrintPage (dibuja directo, sin capturar panel) ──────────────
        Private Sub printDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDocument1.PrintPage
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim x As Integer = e.MarginBounds.Left
            Dim y As Integer = e.MarginBounds.Top
            Dim w As Integer = e.MarginBounds.Width
            Dim lineH As Integer = 22

            Dim fontTitulo As New Font("Arial", 14, FontStyle.Bold)
            Dim fontNormal As New Font("Arial", 10, FontStyle.Regular)
            Dim fontBold As New Font("Arial", 10, FontStyle.Bold)
            Dim fontGrande As New Font("Arial", 12, FontStyle.Bold)
            Dim fontCorte As New Font("Arial", 8, FontStyle.Regular)
            Dim fontCheque As New Font("Arial", 9, FontStyle.Regular)
            Dim fontChequeBold As New Font("Arial", 9, FontStyle.Bold)
            Dim fontBanco As New Font("Arial", 11, FontStyle.Bold)
            Dim negro As Brush = Brushes.Black
            Dim rojo As Brush = Brushes.Red

            ' ── Encabezado ────────────────────────────────────────────────
            g.DrawString("COMPROBANTE DE PAGO", fontTitulo, negro, x, y)
            y += lineH + 6

            g.DrawString("Fecha: " & lblFecha.Text, fontNormal, negro, x, y)
            g.DrawString(lblNoCheque.Text, fontBold, negro, x + w - 120, y)
            y += lineH + 10

            g.DrawLine(Pens.Black, x, y, x + w, y)
            y += 10

            ' ── Datos del empleado ────────────────────────────────────────
            g.DrawString("Nombre:  " & lblNombre.Text, fontBold, negro, x, y) : y += lineH
            g.DrawString("Cargo:   " & lblCargo.Text, fontNormal, negro, x, y) : y += lineH + 10

            g.DrawLine(Pens.Black, x, y, x + w, y)
            y += 10

            ' ── Detalle de montos ─────────────────────────────────────────
            g.DrawString("Sueldo:", fontNormal, negro, x, y)
            g.DrawString(lblSueldo.Text, fontNormal, negro, x + 200, y) : y += lineH

            g.DrawString("IGSS:", fontNormal, negro, x, y)
            g.DrawString(lblIGSS.Text, fontNormal, negro, x + 200, y) : y += lineH

            g.DrawString("Bono:", fontNormal, negro, x, y)
            g.DrawString(lblBono.Text, fontNormal, negro, x + 200, y) : y += lineH

            g.DrawString("Otros:", fontNormal, negro, x, y)
            g.DrawString(lblOtros.Text, fontNormal, negro, x + 200, y) : y += lineH + 10

            g.DrawLine(Pens.Black, x, y, x + w, y)
            y += 10

            ' ── Monto líquido ─────────────────────────────────────────────
            g.DrawString("MONTO LÍQUIDO:", fontGrande, negro, x, y)
            g.DrawString(lblMontoNumero.Text, fontGrande, negro, x + 200, y) : y += lineH + 6

            g.DrawString(lblMontoLetras.Text, fontNormal, negro, x, y)
            y += lineH + 30

            g.DrawLine(Pens.Black, x, y, x + w, y)
            y += 40

            ' ── Firma ─────────────────────────────────────────────────────
            Dim centroX As Integer = x + w \ 2
            g.DrawLine(Pens.Black, centroX - 80, y, centroX + 80, y)
            y += 6
            g.DrawString("Autorizado", fontNormal, negro,
                centroX - g.MeasureString("Autorizado", fontNormal).Width / 2, y)
            y += lineH + 20

            ' ── LÍNEA DE CORTE ────────────────────────────────────────────
            Dim penCorte As New Pen(Color.Gray, 1.0F)
            penCorte.DashStyle = Drawing2D.DashStyle.Dash
            g.DrawLine(penCorte, x, y, x + w, y)

            Dim textoCorte As String = "✂  CORTE AQUÍ"
            Dim szCorte As SizeF = g.MeasureString(textoCorte, fontCorte)
            g.DrawString(textoCorte, fontCorte, Brushes.Gray,
                centroX - szCorte.Width / 2, y + 3)
            y += 22

            ' ── CHEQUE BANTRAB ────────────────────────────────────────────
            Dim rectCheque As New Rectangle(x, y, w, 230)
            g.DrawRectangle(Pens.Black, rectCheque)
            y += 10

            ' ── Cabecera del banco ────────────────────────────────────────
            g.DrawString("BANTRAB", fontBanco, negro, x + 10, y)
            g.DrawString("BANCO DE LOS TRABAJADORES, GUATEMALA, C. A.", fontCheque, negro, x + 10, y + 18)

            Dim noCheque As String = "CHEQUE No.: 04000011"
            Dim szNo As SizeF = g.MeasureString(noCheque, fontChequeBold)
            g.DrawString(noCheque, fontChequeBold, negro, x + w - CInt(szNo.Width) - 10, y)

            Dim correlativo As String = "05790702"
            Dim szCorr As SizeF = g.MeasureString(correlativo, fontChequeBold)
            g.DrawString(correlativo, fontChequeBold, rojo,
                x + w - CInt(szCorr.Width) - 10, y + 16)

            y += 44
            g.DrawLine(Pens.Black, x + 10, y, x + w - 10, y)
            y += 8

            ' ── Cuenta y titular dinámico ─────────────────────────────────
            g.DrawString("Cta. No.: 790029964-7          Titular: " & _nombreEmpleado.ToUpper(),
                fontCheque, negro, x + 10, y) : y += lineH

            ' ── Fecha / Páguese a ─────────────────────────────────────────
            g.DrawString("Lugar y Fecha: _______________________", fontCheque, negro, x + 10, y)
            y += lineH

            ' ── Páguese a: nombre del empleado ───────────────────────────
            g.DrawString("Páguese a: " & _nombreEmpleado.ToUpper(),
                fontCheque, negro, x + 10, y) : y += lineH

            ' ── Monto en números ──────────────────────────────────────────
            g.DrawString("La Cantidad de (Q.): " & "Q " & _montoLiquido.ToString("N2"),
                fontChequeBold, negro, x + 10, y) : y += lineH

            ' ── Monto en letras ───────────────────────────────────────────
            g.DrawString("Son: " & Enletras(_montoLiquido),
                fontCheque, negro, x + 10, y) : y += lineH + 6

            ' ── Referencia IBAN ───────────────────────────────────────────
            g.DrawString("Ref.: GT95 TRAJ 0101 0000 0079 0029 9647",
                fontCheque, negro, x + 10, y) : y += lineH + 6

            g.DrawLine(Pens.Black, x + 10, y, x + w - 10, y)
            y += 8

            ' ── Firma(s) registrada(s) ────────────────────────────────────
            Dim firmaLabel As String = "Firma(s) Registrada(s)"
            Dim szFirma As SizeF = g.MeasureString(firmaLabel, fontCheque)
            g.DrawString(firmaLabel, fontCheque, negro,
                x + w - CInt(szFirma.Width) - 10, y) : y += lineH + 4

            ' ── Banda MICR ────────────────────────────────────────────────
            Dim fontMICR As New Font("Courier New", 8, FontStyle.Regular)
            Dim comilla As String = Convert.ToChar(34).ToString()
            g.DrawString("||" & comilla & " 31:000000112:7900 299647||" & comilla & "04000011 || " & comilla & "00000000921,'",
                fontMICR, negro, x + 10, y) : y += lineH

            g.DrawString("F. STANDARD, S.A.  PBX: 2423-8900  FAX: 2439-4916",
                fontCorte, Brushes.Gray, x + 10, y)

            ' ── Liberar recursos ──────────────────────────────────────────
            fontTitulo.Dispose()
            fontNormal.Dispose()
            fontBold.Dispose()
            fontGrande.Dispose()
            fontCorte.Dispose()
            fontCheque.Dispose()
            fontChequeBold.Dispose()
            fontBanco.Dispose()
            penCorte.Dispose()
            fontMICR.Dispose()

            e.HasMorePages = False
        End Sub

        ' ── Eventos vacíos ─────────────────────────────────────────────────────
        Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Me.Close()
        End Sub

        Private Sub lblMontoLetras_Click(sender As Object, e As EventArgs) Handles lblMontoLetras.Click
        End Sub

        Private Sub FormCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        End Sub

        Private Sub lblAutorizado_Click(sender As Object, e As EventArgs) Handles lblAutorizado.Click
        End Sub

        Private Sub panelCheque_Paint(sender As Object, e As PaintEventArgs) Handles panelCheque.Paint
        End Sub

        Private Sub lblOtros_Click(sender As Object, e As EventArgs) Handles lblOtros.Click
        End Sub

        Private Sub lblMontoNumero_Click(sender As Object, e As EventArgs) Handles lblMontoNumero.Click
        End Sub

        Private Sub label1_Click(sender As Object, e As EventArgs)
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            ' Imprimir todos
            Try
                Const query As String = "SELECT nombres, cargo, sueldo, igss, bono, otros, liquido FROM trabajadores;"

                Dim obj As New CConexion()
                Using conn As MySqlConnection = obj.ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            While dr.Read()

                                Dim culturaGT As New System.Globalization.CultureInfo("es-GT")

                                _nombreEmpleado = dr("nombres").ToString()
                                _montoLiquido = Convert.ToDouble(dr("liquido"))

                                lblFecha.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", culturaGT)
                                lblNoCheque.Text = "No. "
                                lblNombre.Text = _nombreEmpleado.ToUpper()
                                lblCargo.Text = dr("cargo").ToString()
                                lblSueldo.Text = "Q " & Convert.ToDouble(dr("sueldo")).ToString("N2")
                                lblIGSS.Text = "Q " & Convert.ToDouble(dr("igss")).ToString("N2")
                                lblBono.Text = "Q " & Convert.ToDouble(dr("bono")).ToString("N2")
                                lblOtros.Text = "Q " & Convert.ToDouble(dr("otros")).ToString("N2")
                                lblMontoNumero.Text = "Q " & _montoLiquido.ToString("N2")
                                lblMontoLetras.Text = Enletras(_montoLiquido)

                                btnImprimir.PerformClick()
                            End While
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
    End Class

End Namespace