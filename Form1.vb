Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CargarPlanilla()
        End Sub

        ''' <summary>
        ''' Carga la tabla de trabajadores y los totales resumen.
        ''' MEJORA: una sola conexión para ambas consultas; COALESCE en SQL
        ''' evita valores nulos en los totales sin conversiones extra en VB.
        ''' </summary>
        Private Sub CargarPlanilla()
            Try
                Using conn As MySqlConnection = New CConexion().ObtenerConexion()
                    If conn Is Nothing Then Return

                    ' ── Tabla principal ─────────────────────────────────────
                    Const queryGrid As String =
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

                    Using da As New MySqlDataAdapter(queryGrid, conn)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvPlanilla.DataSource = dt
                    End Using

                    ConfigurarGrid(dgvPlanilla)

                    ' ── Totales ─────────────────────────────────────────────
                    Const queryTotales As String =
                        "SELECT COUNT(*)             AS total_emp," &
                        "       COALESCE(SUM(sueldo),  0) AS planilla_bruta," &
                        "       COALESCE(SUM(liquido), 0) AS planilla_liquida" &
                        " FROM trabajadores"

                    Using cmd As New MySqlCommand(queryTotales, conn)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If dr.Read() Then
                                lblNumEmpVal.Text = Convert.ToInt32(dr("total_emp")).ToString()
                                lblBrutaVal.Text = "Q. " & Convert.ToDouble(dr("planilla_bruta")).ToString("N2")
                                lblLiquidaVal.Text = "Q. " & Convert.ToDouble(dr("planilla_liquida")).ToString("N2")
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

        ''' <summary>
        ''' Aplica configuración visual estándar a cualquier DataGridView.
        ''' MEJORA: centraliza la configuración en lugar de repetirla en cada formulario.
        ''' </summary>
        Friend Shared Sub ConfigurarGrid(dgv As DataGridView)
            dgv.ReadOnly = True
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Sub

        ' ── Navegación ─────────────────────────────────────────────────────────

        Private Sub BtnIngreso_Click(sender As Object, e As EventArgs) Handles btnIngreso.Click
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub BtnPlanilla_Click(sender As Object, e As EventArgs) Handles btnPlanilla.Click
            AbrirFormPlanilla()
        End Sub

        Private Sub BtnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
            AbrirFormPlanilla()
        End Sub

        ' MEJORA: lógica duplicada de BtnPlanilla y BtnVisualizar extraída a método.
        Private Sub AbrirFormPlanilla()
            Using ventana As New FormPlanilla()
                ventana.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub BtnCheque_Click(sender As Object, e As EventArgs) Handles btnCheque.Click
            Dim idTexto As String = txtIdBusqueda.Text.Trim()

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

            ' MEJORA: se pasa el entero validado, no el string raw.
            Dim miCheque As New FormCheque(idTexto)
            miCheque.Show()
        End Sub

        Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
            If MessageBox.Show(
                    "¿Desea salir del sistema?",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        ' MEJORA: botones sin implementación eliminados o redirigidos a BtnSalir.
        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles button4.Click
            BtnSalir_Click(sender, e)
        End Sub

    End Class

End Namespace