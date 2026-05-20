Imports System
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormIngreso
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
            ' Validar campos vacíos.
            If String.IsNullOrWhiteSpace(txtId.Text) OrElse
               String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
               String.IsNullOrWhiteSpace(txtCargo.Text) OrElse
               String.IsNullOrWhiteSpace(txtSueldo.Text) OrElse
               String.IsNullOrWhiteSpace(txtCorreo.Text) OrElse
               String.IsNullOrWhiteSpace(txtNoCuenta.Text) Then
                MessageBox.Show(
                    "Por favor, complete todos los campos antes de guardar.",
                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validar ID entero positivo.
            Dim id As Integer
            If Not Integer.TryParse(txtId.Text.Trim(), id) OrElse id <= 0 Then
                MessageBox.Show(
                    "El ID debe ser un número entero positivo.",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtId.Focus()
                Return
            End If

            ' Validar formato básico de correo electrónico.
            Dim correo As String = txtCorreo.Text.Trim()
            If Not correo.Contains("@") OrElse Not correo.Contains(".") Then
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.",
                    "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCorreo.Focus()
                Return
            End If

            ' Validar número de cuenta no vacío.
            Dim noCuenta As String = txtNoCuenta.Text.Trim()

            ' CORRECCIÓN: usar InvariantCulture para aceptar punto decimal en cualquier
            ' configuración regional del sistema operativo.
            Dim sueldoBase As Double
            If Not Double.TryParse(
                    txtSueldo.Text.Trim(),
                    Globalization.NumberStyles.Any,
                    Globalization.CultureInfo.InvariantCulture,
                    sueldoBase) OrElse sueldoBase <= 0 Then
                MessageBox.Show(
                    "El sueldo debe ser un número mayor a cero (use punto como separador decimal).",
                    "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSueldo.Focus()
                Return
            End If

            Try
                Dim nombre As String = txtNombre.Text.Trim()
                Dim cargo As String = txtCargo.Text.Trim()

                ' Cálculos de planilla (IGSS 4.83 %, bono fijo Q250).
                Dim igss As Double = Math.Round(sueldoBase * 0.0483, 2)
                Dim bono As Double = 250.0
                Dim otros As Double = 0
                Dim liquido As Double = Math.Round(sueldoBase - igss + bono - otros, 2)

                ' Parámetros para evitar SQL Injection.
                Const query As String =
                    "INSERT INTO trabajadores " &
                    "(id_trabajador, nombres, cargo, sueldo, igss, bono, otros, liquido, correo, no_cuenta) " &
                    "VALUES " &
                    "(@id, @nombre, @cargo, @sueldo, @igss, @bono, @otros, @liquido, @correo, @no_cuenta)"

                Dim objetoConexion As New CConexion()
                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using comando As New MySqlCommand(query, conn)
                        comando.Parameters.AddWithValue("@id", id)
                        comando.Parameters.AddWithValue("@nombre", nombre)
                        comando.Parameters.AddWithValue("@cargo", cargo)
                        comando.Parameters.AddWithValue("@sueldo", sueldoBase)
                        comando.Parameters.AddWithValue("@igss", igss)
                        comando.Parameters.AddWithValue("@bono", bono)
                        comando.Parameters.AddWithValue("@otros", otros)
                        comando.Parameters.AddWithValue("@liquido", liquido)
                        comando.Parameters.AddWithValue("@correo", correo)
                        comando.Parameters.AddWithValue("@no_cuenta", noCuenta)

                        comando.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show(
                    "¡Empleado guardado exitosamente!",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Limpiar campos y devolver el foco al primero.
                txtId.Clear()
                txtNombre.Clear()
                txtCargo.Clear()
                txtSueldo.Clear()
                txtCorreo.Clear()
                txtNoCuenta.Clear()
                txtId.Focus()
            Catch ex As MySqlException When ex.Number = 1062  ' Duplicate entry
                MessageBox.Show(
                    "Ya existe un empleado con el ID " & txtId.Text.Trim() & ". Use un ID diferente.",
                    "ID duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Catch ex As Exception
                MessageBox.Show(
                    "Error al guardar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Me.Close()
        End Sub

        Private Sub FormIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        End Sub

        Private Sub Label3_Click(sender As Object, e As EventArgs) Handles label3.Click
        End Sub

        Private Sub TxtCargo_TextChanged(sender As Object, e As EventArgs) Handles txtCargo.TextChanged
        End Sub

        Private Sub TxtSueldo_TextChanged(sender As Object, e As EventArgs) Handles txtSueldo.TextChanged
        End Sub

        Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        End Sub

    End Class

End Namespace