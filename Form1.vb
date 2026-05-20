Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CargarPlanilla()
        End Sub

        ' ── Carga el DataGridView y actualiza el panel de resumen ──────────────
        Private Sub CargarPlanilla()
            Try
                Dim objetoConexion As New CConexion()

                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
                    If conn Is Nothing Then Return

                    ' CORRECCIÓN: columnas con alias consistentes para evitar
                    ' referencias frágiles por índice numérico.
                    Dim query As String =
                        "SELECT id_trabajador  AS 'ID'," &
                        "       nombres        AS 'Nombre'," &
                        "       cargo          AS 'Cargo'," &
                        "       sueldo         AS 'Sueldo Base'," &
                        "       igss           AS 'IGSS'," &
                        "       bono           AS 'Bono'," &
                        "       otros          AS 'Otros'," &
                        "       liquido        AS 'Líquido'" &
                        " FROM trabajadores" &
                        " ORDER BY id_trabajador"

                    Using adaptador As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        adaptador.Fill(dt)
                        dgvPlanilla.DataSource = dt

                        ' Impedir edición directa en el grid principal.
                        dgvPlanilla.ReadOnly = True
                        dgvPlanilla.AllowUserToAddRows = False
                        dgvPlanilla.AllowUserToDeleteRows = False
                        dgvPlanilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    End Using

                    ' CORRECCIÓN: query aparte para totales; la conexión ya está abierta
                    ' y no hace falta crear un segundo objeto CConexion.
                    Dim queryTotales As String =
                        "SELECT COUNT(*)        AS total_emp," &
                        "       COALESCE(SUM(sueldo),  0) AS planilla_bruta," &
                        "       COALESCE(SUM(liquido), 0) AS planilla_liquida" &
                        " FROM trabajadores"

                    Using cmd As New MySqlCommand(queryTotales, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If dr.Read() Then
                                Dim numEmp As Integer = If(dr.IsDBNull(0), 0, Convert.ToInt32(dr(0)))
                                Dim bruta As Double = If(dr.IsDBNull(1), 0, Convert.ToDouble(dr(1)))
                                Dim liquida As Double = If(dr.IsDBNull(2), 0, Convert.ToDouble(dr(2)))

                                lblNumEmpVal.Text = numEmp.ToString()
                                lblBrutaVal.Text = "Q. " & bruta.ToString("N2")
                                lblLiquidaVal.Text = "Q. " & liquida.ToString("N2")
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(
                    "Error al cargar la planilla: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' ── Botones de navegación ──────────────────────────────────────────────
        Private Sub btnIngreso_Click(sender As Object, e As EventArgs) Handles btnIngreso.Click
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarPlanilla() ' Refrescar tras agregar un empleado
        End Sub

        Private Sub btnPlanilla_Click(sender As Object, e As EventArgs) Handles btnPlanilla.Click
            Dim ventana As New FormPlanilla()
            ventana.Show()
        End Sub

        Private Sub btnCheque_Click(sender As Object, e As EventArgs) Handles btnCheque.Click
            Dim idTexto As String = txtIdBusqueda.Text.Trim()

            ' CORRECCIÓN: validar que sea un número entero válido antes de abrir el form.
            If String.IsNullOrWhiteSpace(idTexto) Then
                MessageBox.Show(
                    "Por favor, ingrese un ID para generar el cheque.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIdBusqueda.Focus()
                Return
            End If

            Dim id As Integer
            If Not Integer.TryParse(idTexto, id) OrElse id <= 0 Then
                MessageBox.Show(
                    "El ID debe ser un número entero positivo.",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIdBusqueda.Focus()
                Return
            End If

            Dim miCheque As New FormCheque(idTexto)
            miCheque.Show()
        End Sub

        Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
            ' CORRECCIÓN: confirmar antes de cerrar la aplicación.
            Dim r As DialogResult = MessageBox.Show(
                "¿Desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If r = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        ' ── Eventos vacíos mantenidos por compatibilidad ───────────────────────
        Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        End Sub

        Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        End Sub

        Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
            Application.Exit()
        End Sub

        Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
            Dim ventanaPlanilla As New FormPlanilla()
            ventanaPlanilla.Show()
        End Sub

        Private Sub txtIdBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtIdBusqueda.TextChanged
        End Sub

        Private Sub labelId_Click(sender As Object, e As EventArgs) Handles labelId.Click
        End Sub

        Private Sub Form1_BackgroundImageLayoutChanged(sender As Object, e As EventArgs) Handles MyBase.BackgroundImageLayoutChanged
        End Sub

        Private Sub panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint
        End Sub

    End Class

End Namespace
