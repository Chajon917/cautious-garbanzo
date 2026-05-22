Imports System
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormIngreso
        Inherits Form

        ' MEJORA: constantes centralizadas para los parámetros de planilla.
        ' Si cambia la tasa del IGSS o el bono, se edita en un solo lugar.
        Private Const TasaIGSS As Double = 0.0483   ' 4.83 %
        Private Const MontoBonoFijo As Double = 250.0

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
            Dim id As Integer
            Dim sueldoBase As Double

            ' ── Validaciones ────────────────────────────────────────────────
            If Not ValidarCampos(id, sueldoBase) Then Return

            Try
                Dim nombre As String = txtNombre.Text.Trim()
                Dim cargo As String = txtCargo.Text.Trim()
                Dim correo As String = txtCorreo.Text.Trim()
                Dim noCuenta As String = txtNoCuenta.Text.Trim()

                ' MEJORA: cálculos centralizados con la constante TasaIGSS.
                Dim igss As Double = Math.Round(sueldoBase * TasaIGSS, 2)
                Dim bono As Double = MontoBonoFijo
                Dim otros As Double = 0
                Dim liquido As Double = Math.Round(sueldoBase - igss + bono - otros, 2)

                Const query As String =
                    "INSERT INTO trabajadores " &
                    "(id_trabajador, nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta) " &
                    "VALUES (@id, @nombre, @cargo, @sueldo, @igss, @bono, @otros, @liquido, @correo, @no_cuenta)"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", id)
                        cmd.Parameters.AddWithValue("@nombre", nombre)
                        cmd.Parameters.AddWithValue("@cargo", cargo)
                        cmd.Parameters.AddWithValue("@sueldo", sueldoBase)
                        cmd.Parameters.AddWithValue("@igss", igss)
                        cmd.Parameters.AddWithValue("@bono", bono)
                        cmd.Parameters.AddWithValue("@otros", otros)
                        cmd.Parameters.AddWithValue("@liquido", liquido)
                        cmd.Parameters.AddWithValue("@correo", correo)
                        cmd.Parameters.AddWithValue("@no_cuenta", noCuenta)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show(
                    $"¡Empleado '{nombre}' guardado exitosamente!" & Environment.NewLine &
                    $"Sueldo líquido calculado: Q {liquido:N2}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarFormulario()

            Catch ex As MySqlException When ex.Number = 1062   ' Duplicate entry
                MessageBox.Show(
                    $"Ya existe un empleado con el ID {id}. Use un ID diferente.",
                    "ID duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtId.Focus()
            Catch ex As Exception
                MessageBox.Show(
                    "Error al guardar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' Valida todos los campos del formulario.
        ''' Devuelve True si todo es válido; parámetros de salida con valores parseados.
        ''' MEJORA: validaciones separadas en su propio método; uso de Regex para correo.
        ''' </summary>
        Private Function ValidarCampos(ByRef id As Integer, ByRef sueldoBase As Double) As Boolean
            If String.IsNullOrWhiteSpace(txtId.Text) OrElse
               String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
               String.IsNullOrWhiteSpace(txtCargo.Text) OrElse
               String.IsNullOrWhiteSpace(txtSueldo.Text) OrElse
               String.IsNullOrWhiteSpace(txtCorreo.Text) OrElse
               String.IsNullOrWhiteSpace(txtNoCuenta.Text) Then
                MessageBox.Show(
                    "Por favor, complete todos los campos antes de guardar.",
                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If Not Integer.TryParse(txtId.Text.Trim(), id) OrElse id <= 0 Then
                MessageBox.Show("El ID debe ser un número entero positivo.",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtId.Focus()
                Return False
            End If

            ' MEJORA: validación de correo con expresión regular básica (RFC 5322 simplificado).
            Dim correo As String = txtCorreo.Text.Trim()
            If Not System.Text.RegularExpressions.Regex.IsMatch(
                    correo, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
                MessageBox.Show("Ingrese un correo electrónico válido (ej. nombre@dominio.com).",
                    "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCorreo.Focus()
                Return False
            End If

            If Not Double.TryParse(
                    txtSueldo.Text.Trim(),
                    Globalization.NumberStyles.Any,
                    Globalization.CultureInfo.InvariantCulture,
                    sueldoBase) OrElse sueldoBase <= 0 Then
                MessageBox.Show(
                    "El sueldo debe ser un número mayor a cero (use punto como separador decimal).",
                    "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSueldo.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub LimpiarFormulario()
            txtId.Clear()
            txtNombre.Clear()
            txtCargo.Clear()
            txtSueldo.Clear()
            txtCorreo.Clear()
            txtNoCuenta.Clear()
            txtId.Focus()
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Me.Close()
        End Sub

        Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

        End Sub

        Private Sub txtCargo_TextChanged(sender As Object, e As EventArgs) Handles txtCargo.TextChanged

        End Sub

        Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

        End Sub
    End Class

End Namespace