Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace ProyectoPlanillaUMG1

    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            ' Suscripción de eventos — reemplaza las cláusulas Handles
            AddHandler MyBase.Load, AddressOf Form1_Load
            AddHandler btnIngreso.Click, AddressOf BtnIngreso_Click
            AddHandler btnPlanilla.Click, AddressOf BtnPlanilla_Click
            AddHandler btnVisualizar.Click, AddressOf BtnVisualizar_Click
            AddHandler btnCheque.Click, AddressOf BtnCheque_Click
            AddHandler btnSalir.Click, AddressOf BtnSalir_Click
            AddHandler button4.Click, AddressOf Button4_Click
            AddHandler labelId.Click, AddressOf LabelId_Click
            AddHandler lblTituloResumen.Click, AddressOf LblTituloResumen_Click
        End Sub

        ' ── Carga inicial ───────────────────────────────────────────────────────

        Private Sub Form1_Load(sender As Object, e As EventArgs)
            CargarPlanilla()
        End Sub

        ''' <summary>
        ''' Carga la tabla de trabajadores y los totales resumen.
        ''' Una sola conexión para ambas consultas; COALESCE evita nulos en totales.
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
                        "SELECT COUNT(*)                   AS total_emp," &
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
        ''' </summary>
        Friend Shared Sub ConfigurarGrid(dgv As DataGridView)
            dgv.ReadOnly = True
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Sub

        ' ── Navegación ─────────────────────────────────────────────────────────

        Private Sub BtnIngreso_Click(sender As Object, e As EventArgs)
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub BtnPlanilla_Click(sender As Object, e As EventArgs)
            AbrirFormPlanilla()
        End Sub

        Private Sub BtnVisualizar_Click(sender As Object, e As EventArgs)
            AbrirFormPlanilla()
        End Sub

        Private Sub AbrirFormPlanilla()
            Using ventana As New FormPlanilla()
                ventana.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub BtnCheque_Click(sender As Object, e As EventArgs)
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

            Dim miCheque As New FormCheque(idTexto)
            miCheque.Show()
        End Sub

        Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
            If MessageBox.Show(
                    "¿Desea salir del sistema?",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs)
            BtnSalir_Click(sender, e)
        End Sub

        Private Sub LabelId_Click(sender As Object, e As EventArgs)
            ' Sin implementación
        End Sub

        Private Sub LblTituloResumen_Click(sender As Object, e As EventArgs)
            ' Sin implementación
        End Sub

    End Class

End Namespace