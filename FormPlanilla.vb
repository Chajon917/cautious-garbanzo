Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Partial Public Class FormPlanilla
        Inherits Form

        Public Sub New()
            InitializeComponent()
            CargarDatos()
        End Sub

        Public Sub CargarDatos()
            Try
                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Const query As String =
                        "SELECT id_trabajador AS 'ID'," &
                        "       nombres       AS 'Nombre'," &
                        "       cargo         AS 'Cargo'," &
                        "       sueldo        AS 'Sueldo Base'," &
                        "       igss          AS 'IGSS'," &
                        "       bono          AS 'Bono'," &
                        "       otros         AS 'Otros'," &
                        "       liquido       AS 'Líquido'," &
                        "       no_cuenta     AS 'No. Cuenta'," &
                        "       correo        AS 'Correo Electrónico'" &
                        " FROM trabajadores" &
                        " ORDER BY id_trabajador"

                    Using da As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvTrabajadores.DataSource = dt
                    End Using

                    ' MEJORA: configuración del grid centralizada en Form1.
                    Form1.ConfigurarGrid(dgvTrabajadores)
                End Using
            Catch ex As Exception
                MessageBox.Show(
                    "Error al cargar la planilla: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
            If dgvTrabajadores.CurrentRow Is Nothing Then
                MessageBox.Show("Seleccione un trabajador para editar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim fila As DataGridViewRow = dgvTrabajadores.CurrentRow
            If fila.Cells("ID").Value Is Nothing Then Return

            Dim id As Integer = Convert.ToInt32(fila.Cells("ID").Value)
            Dim nombre As String = ObtenerCelda(fila, "Nombre")
            Dim cargo As String = ObtenerCelda(fila, "Cargo")
            Dim sueldo As Double = Convert.ToDouble(
                fila.Cells("Sueldo Base").Value,
                Globalization.CultureInfo.InvariantCulture)
            Dim correo As String = ObtenerCelda(fila, "Correo Electrónico")
            Dim noCuenta As String = ObtenerCelda(fila, "No. Cuenta")

            Using dlg As New FormEditar(id, nombre, cargo, sueldo, correo, noCuenta)
                If dlg.ShowDialog() = DialogResult.OK Then CargarDatos()
            End Using
        End Sub

        Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
            If dgvTrabajadores.CurrentRow Is Nothing Then
                MessageBox.Show("Seleccione un trabajador para eliminar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim fila As DataGridViewRow = dgvTrabajadores.CurrentRow
            If fila.Cells("ID").Value Is Nothing Then Return

            Dim id As Integer = Convert.ToInt32(fila.Cells("ID").Value)
            Dim nombre As String = ObtenerCelda(fila, "Nombre", "(sin nombre)")

            If MessageBox.Show(
                    $"¿Está seguro de eliminar al trabajador '{nombre}' (ID: {id})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) <> DialogResult.Yes Then Return

            Try
                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(
                        "DELETE FROM trabajadores WHERE id_trabajador = @id", conn)
                        cmd.Parameters.AddWithValue("@id", id)
                        Dim afectados As Integer = cmd.ExecuteNonQuery()

                        ' MEJORA: verificar que realmente se eliminó una fila.
                        If afectados = 0 Then
                            MessageBox.Show("El trabajador ya no existe en la base de datos.",
                                "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                End Using

                MessageBox.Show("Trabajador eliminado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarDatos()

            Catch ex As MySqlException
                MessageBox.Show("Error de base de datos al eliminar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarDatos()
        End Sub

        ''' <summary>
        ''' Lee el valor de una celda como String de forma segura.
        ''' MEJORA: elimina la repetición de checks IsNot Nothing/ToString() en todo el código.
        ''' </summary>
        Private Shared Function ObtenerCelda(fila As DataGridViewRow, columna As String,
                                             Optional porDefecto As String = "") As String
            Dim val = fila.Cells(columna).Value
            Return If(val IsNot Nothing, val.ToString(), porDefecto)
        End Function

    End Class

    ' ════════════════════════════════════════════════════════════════════════════
    '  FormEditar — diálogo modal para editar un trabajador existente
    ' ════════════════════════════════════════════════════════════════════════════
    Public Class FormEditar
        Inherits Form

        Private ReadOnly _id As Integer
        Private Const TasaIGSS As Double = 0.0483
        Private Const MontoBonoFijo As Double = 250.0

        Private ReadOnly txtNombre As TextBox
        Private ReadOnly txtCargo As TextBox
        Private ReadOnly txtSueldo As TextBox
        Private ReadOnly txtCorreo As TextBox
        Private ReadOnly txtNoCuenta As TextBox

        Public Sub New(id As Integer, nombre As String, cargo As String,
                       sueldo As Double, correo As String, noCuenta As String)
            _id = id
            Text = $"Editar Trabajador — ID {id}"
            ClientSize = New Drawing.Size(420, 420)
            BackColor = Drawing.Color.FromArgb(45, 45, 48)
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterParent
            MaximizeBox = False
            MinimizeBox = False

            Dim campos As (Label As String, Valor As String, Y As Integer)() = {
                ("Nombre:", nombre, 30),
                ("Cargo:", cargo, 80),
                ("Sueldo Base:", sueldo.ToString("F2"), 130),
                ("No. Cuenta:", noCuenta, 180),
                ("Correo:", correo, 230)
            }

            ' MEJORA: construcción del formulario en un bucle; elimina la repetición
            ' de bloques Controls.Add idénticos para cada campo.
            Dim txtBoxes As New List(Of TextBox)()
            For Each campo In campos
                Controls.Add(New Label With {
                    .Text = campo.Label,
                    .ForeColor = Drawing.Color.Gainsboro,
                    .Font = New Drawing.Font("Segoe UI", 9.0F, Drawing.FontStyle.Bold),
                    .Location = New Drawing.Point(20, campo.Y),
                    .AutoSize = True
                })
                Dim tb As New TextBox With {
                    .Text = campo.Valor,
                    .Location = New Drawing.Point(150, campo.Y - 3),
                    .Size = New Drawing.Size(240, 26),
                    .BackColor = Drawing.Color.FromArgb(30, 30, 30),
                    .ForeColor = Drawing.Color.White,
                    .BorderStyle = BorderStyle.FixedSingle
                }
                Controls.Add(tb)
                txtBoxes.Add(tb)
            Next

            txtNombre = txtBoxes(0)
            txtCargo = txtBoxes(1)
            txtSueldo = txtBoxes(2)
            txtNoCuenta = txtBoxes(3)
            txtCorreo = txtBoxes(4)

            Dim btnGuardar As New Button With {
                .Text = "Guardar Cambios",
                .Location = New Drawing.Point(60, 320),
                .Size = New Drawing.Size(160, 36),
                .BackColor = Drawing.Color.FromArgb(39, 174, 96),
                .ForeColor = Drawing.Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Drawing.Font("Segoe UI", 9.0F, Drawing.FontStyle.Bold)
            }
            btnGuardar.FlatAppearance.BorderSize = 0
            AddHandler btnGuardar.Click, AddressOf BtnGuardar_Click
            Controls.Add(btnGuardar)

            Dim btnCancelar As New Button With {
                .Text = "Cancelar",
                .Location = New Drawing.Point(255, 320),
                .Size = New Drawing.Size(100, 36),
                .BackColor = Drawing.Color.FromArgb(192, 57, 43),
                .ForeColor = Drawing.Color.White,
                .FlatStyle = FlatStyle.Flat,
                .DialogResult = DialogResult.Cancel
            }
            btnCancelar.FlatAppearance.BorderSize = 0
            Controls.Add(btnCancelar)
        End Sub

        Private Sub BtnGuardar_Click(sender As Object, e As EventArgs)
            ' ── Validaciones ────────────────────────────────────────────────
            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
               String.IsNullOrWhiteSpace(txtCargo.Text) OrElse
               String.IsNullOrWhiteSpace(txtSueldo.Text) OrElse
               String.IsNullOrWhiteSpace(txtNoCuenta.Text) OrElse
               String.IsNullOrWhiteSpace(txtCorreo.Text) Then
                MessageBox.Show("Todos los campos son obligatorios.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim correo As String = txtCorreo.Text.Trim()
            If Not System.Text.RegularExpressions.Regex.IsMatch(
                    correo, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
                MessageBox.Show("Ingrese un correo electrónico válido.",
                    "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim sueldo As Double
            If Not Double.TryParse(
                    txtSueldo.Text.Trim(),
                    Globalization.NumberStyles.Any,
                    Globalization.CultureInfo.InvariantCulture,
                    sueldo) OrElse sueldo <= 0 Then
                MessageBox.Show(
                    "El sueldo debe ser un número mayor a cero (use punto decimal).",
                    "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim igss As Double = Math.Round(sueldo * TasaIGSS, 2)
            Dim liquido As Double = Math.Round(sueldo - igss + MontoBonoFijo, 2)

            Try
                Const query As String =
                    "UPDATE trabajadores " &
                    "SET nombres   = @nombre," &
                    "    cargo     = @cargo," &
                    "    sueldo    = @sueldo," &
                    "    igss      = @igss," &
                    "    bono      = @bono," &
                    "    otros     = 0," &
                    "    liquido   = @liquido," &
                    "    correo    = @correo," &
                    "    no_cuenta = @no_cuenta " &
                    "WHERE id_trabajador = @id"

                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                        cmd.Parameters.AddWithValue("@cargo", txtCargo.Text.Trim())
                        cmd.Parameters.AddWithValue("@sueldo", sueldo)
                        cmd.Parameters.AddWithValue("@igss", igss)
                        cmd.Parameters.AddWithValue("@bono", MontoBonoFijo)
                        cmd.Parameters.AddWithValue("@liquido", liquido)
                        cmd.Parameters.AddWithValue("@correo", correo)
                        cmd.Parameters.AddWithValue("@no_cuenta", txtNoCuenta.Text.Trim())
                        cmd.Parameters.AddWithValue("@id", _id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Datos actualizados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                DialogResult = DialogResult.OK
                Close()

            Catch ex As MySqlException
                MessageBox.Show("Error de base de datos al actualizar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al actualizar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

End Namespace