Imports System
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
                Dim objetoConexion As New CConexion()
                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
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

                    Using adaptador As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        adaptador.Fill(dt)
                        dgvTrabajadores.DataSource = dt

                        dgvTrabajadores.ReadOnly = True
                        dgvTrabajadores.AllowUserToAddRows = False
                        dgvTrabajadores.AllowUserToDeleteRows = False
                        dgvTrabajadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(
                    "Error al cargar la planilla: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
            If dgvTrabajadores.CurrentRow Is Nothing Then
                MessageBox.Show(
                    "Seleccione un trabajador para editar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim fila As DataGridViewRow = dgvTrabajadores.CurrentRow
            If fila.Cells("ID").Value Is Nothing Then Return

            Dim id As Integer = Convert.ToInt32(fila.Cells("ID").Value)
            Dim nombre As String = If(fila.Cells("Nombre").Value IsNot Nothing, fila.Cells("Nombre").Value.ToString(), "")
            Dim cargo As String = If(fila.Cells("Cargo").Value IsNot Nothing, fila.Cells("Cargo").Value.ToString(), "")
            Dim sueldo As Double = Convert.ToDouble(fila.Cells("Sueldo Base").Value,
                                                    Globalization.CultureInfo.InvariantCulture)
            Dim correo As String = If(fila.Cells("Correo Electrónico").Value IsNot Nothing, fila.Cells("Correo Electrónico").Value.ToString(), "")
            Dim noCuenta As String = If(fila.Cells("No. Cuenta").Value IsNot Nothing, fila.Cells("No. Cuenta").Value.ToString(), "")

            Using dlg As New FormEditar(id, nombre, cargo, sueldo, correo, noCuenta)
                If dlg.ShowDialog() = DialogResult.OK Then
                    CargarDatos()
                End If
            End Using
        End Sub

        Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
            If dgvTrabajadores.CurrentRow Is Nothing Then
                MessageBox.Show(
                    "Seleccione un trabajador para eliminar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If dgvTrabajadores.CurrentRow.Cells("ID").Value Is Nothing Then Return

            Dim id As Integer = Convert.ToInt32(dgvTrabajadores.CurrentRow.Cells("ID").Value)
            Dim nombre As String = If(dgvTrabajadores.CurrentRow.Cells("Nombre").Value IsNot Nothing, dgvTrabajadores.CurrentRow.Cells("Nombre").Value.ToString(), "(sin nombre)")

            Dim confirm As DialogResult = MessageBox.Show(
                "¿Está seguro de eliminar al trabajador '" & nombre & "' (ID: " & id & ")?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If confirm <> DialogResult.Yes Then Return

            Try
                Dim objetoConexion As New CConexion()
                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(
                        "DELETE FROM trabajadores WHERE id_trabajador = @id", conn)
                        cmd.Parameters.AddWithValue("@id", id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show(
                    "Trabajador eliminado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                CargarDatos()
            Catch ex As MySqlException
                MessageBox.Show(
                    "Error de base de datos al eliminar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(
                    "Error al eliminar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub DgvTrabajadores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrabajadores.CellContentClick
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarDatos()
        End Sub

    End Class

    Public Class FormEditar
        Inherits Form

        Private ReadOnly _id As Integer
        Private ReadOnly txtNombre As System.Windows.Forms.TextBox
        Private ReadOnly txtCargo As System.Windows.Forms.TextBox
        Private ReadOnly txtSueldo As System.Windows.Forms.TextBox
        Private ReadOnly txtCorreo As System.Windows.Forms.TextBox
        Private ReadOnly txtNoCuenta As System.Windows.Forms.TextBox

        Public Sub New(id As Integer, nombre As String, cargo As String, sueldo As Double,
                       correo As String, noCuenta As String)
            _id = id
            Text = "Editar Trabajador"
            ClientSize = New System.Drawing.Size(420, 420)
            BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterParent
            MaximizeBox = False
            MinimizeBox = False

            ' ── Nombre ────────────────────────────────────────────────────
            Controls.Add(New System.Windows.Forms.Label With {
                .Text = "Nombre:",
                .ForeColor = System.Drawing.Color.Gainsboro,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
                .Location = New System.Drawing.Point(20, 30),
                .AutoSize = True
            })
            txtNombre = New System.Windows.Forms.TextBox With {
                .Text = nombre,
                .Location = New System.Drawing.Point(150, 27),
                .Size = New System.Drawing.Size(240, 26),
                .BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                .ForeColor = System.Drawing.Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }
            Controls.Add(txtNombre)

            ' ── Cargo ─────────────────────────────────────────────────────
            Controls.Add(New System.Windows.Forms.Label With {
                .Text = "Cargo:",
                .ForeColor = System.Drawing.Color.Gainsboro,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
                .Location = New System.Drawing.Point(20, 80),
                .AutoSize = True
            })
            txtCargo = New System.Windows.Forms.TextBox With {
                .Text = cargo,
                .Location = New System.Drawing.Point(150, 77),
                .Size = New System.Drawing.Size(240, 26),
                .BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                .ForeColor = System.Drawing.Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }
            Controls.Add(txtCargo)

            ' ── Sueldo ────────────────────────────────────────────────────
            Controls.Add(New System.Windows.Forms.Label With {
                .Text = "Sueldo Base:",
                .ForeColor = System.Drawing.Color.Gainsboro,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
                .Location = New System.Drawing.Point(20, 130),
                .AutoSize = True
            })
            txtSueldo = New System.Windows.Forms.TextBox With {
                .Text = sueldo.ToString("F2"),
                .Location = New System.Drawing.Point(150, 127),
                .Size = New System.Drawing.Size(240, 26),
                .BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                .ForeColor = System.Drawing.Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }
            Controls.Add(txtSueldo)

            ' ── No. Cuenta ────────────────────────────────────────────────
            Controls.Add(New System.Windows.Forms.Label With {
                .Text = "No. Cuenta:",
                .ForeColor = System.Drawing.Color.Gainsboro,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
                .Location = New System.Drawing.Point(20, 180),
                .AutoSize = True
            })
            txtNoCuenta = New System.Windows.Forms.TextBox With {
                .Text = noCuenta,
                .Location = New System.Drawing.Point(150, 177),
                .Size = New System.Drawing.Size(240, 26),
                .BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                .ForeColor = System.Drawing.Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }
            Controls.Add(txtNoCuenta)

            ' ── Correo ────────────────────────────────────────────────────
            Controls.Add(New System.Windows.Forms.Label With {
                .Text = "Correo:",
                .ForeColor = System.Drawing.Color.Gainsboro,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
                .Location = New System.Drawing.Point(20, 230),
                .AutoSize = True
            })
            txtCorreo = New System.Windows.Forms.TextBox With {
                .Text = correo,
                .Location = New System.Drawing.Point(150, 227),
                .Size = New System.Drawing.Size(240, 26),
                .BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                .ForeColor = System.Drawing.Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }
            Controls.Add(txtCorreo)

            ' ── Botones ───────────────────────────────────────────────────
            Dim btnGuardar As New System.Windows.Forms.Button With {
                .Text = "Guardar Cambios",
                .Location = New System.Drawing.Point(60, 320),
                .Size = New System.Drawing.Size(160, 36),
                .BackColor = System.Drawing.Color.FromArgb(39, 174, 96),
                .ForeColor = System.Drawing.Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            }
            btnGuardar.FlatAppearance.BorderSize = 0
            AddHandler btnGuardar.Click, AddressOf BtnGuardar_Click
            Controls.Add(btnGuardar)

            Dim btnCancelar As New System.Windows.Forms.Button With {
                .Text = "Cancelar",
                .Location = New System.Drawing.Point(255, 320),
                .Size = New System.Drawing.Size(100, 36),
                .BackColor = System.Drawing.Color.FromArgb(192, 57, 43),
                .ForeColor = System.Drawing.Color.White,
                .FlatStyle = FlatStyle.Flat,
                .DialogResult = DialogResult.Cancel
            }
            btnCancelar.FlatAppearance.BorderSize = 0
            Controls.Add(btnCancelar)
        End Sub

        Private Sub BtnGuardar_Click(sender As Object, e As EventArgs)
            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
               String.IsNullOrWhiteSpace(txtCargo.Text) OrElse
               String.IsNullOrWhiteSpace(txtSueldo.Text) OrElse
               String.IsNullOrWhiteSpace(txtNoCuenta.Text) OrElse
               String.IsNullOrWhiteSpace(txtCorreo.Text) Then
                MessageBox.Show(
                    "Todos los campos son obligatorios.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validar formato básico de correo
            Dim correo As String = txtCorreo.Text.Trim()
            If Not correo.Contains("@") OrElse Not correo.Contains(".") Then
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.",
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
                    "El sueldo debe ser un número mayor a cero (use punto como separador decimal).",
                    "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim igss As Double = Math.Round(sueldo * 0.0483, 2)
            Dim bono As Double = 250.0
            Dim otros As Double = 0
            Dim liquido As Double = Math.Round(sueldo - igss + bono - otros, 2)

            Try
                Const query As String =
                    "UPDATE trabajadores " &
                    "SET nombres   = @nombre," &
                    "    cargo     = @cargo," &
                    "    sueldo    = @sueldo," &
                    "    igss      = @igss," &
                    "    bono      = @bono," &
                    "    otros     = @otros," &
                    "    liquido   = @liquido," &
                    "    correo    = @correo," &
                    "    no_cuenta = @no_cuenta " &
                    "WHERE id_trabajador = @id"

                Dim objetoConexion As New CConexion()
                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
                    If conn Is Nothing Then Return

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                        cmd.Parameters.AddWithValue("@cargo", txtCargo.Text.Trim())
                        cmd.Parameters.AddWithValue("@sueldo", sueldo)
                        cmd.Parameters.AddWithValue("@igss", igss)
                        cmd.Parameters.AddWithValue("@bono", bono)
                        cmd.Parameters.AddWithValue("@otros", otros)
                        cmd.Parameters.AddWithValue("@liquido", liquido)
                        cmd.Parameters.AddWithValue("@correo", correo)
                        cmd.Parameters.AddWithValue("@no_cuenta", txtNoCuenta.Text.Trim())
                        cmd.Parameters.AddWithValue("@id", _id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show(
                    "Datos actualizados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                DialogResult = DialogResult.OK
                Close()
            Catch ex As MySqlException
                MessageBox.Show(
                    "Error de base de datos al actualizar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(
                    "Error al actualizar: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

End Namespace