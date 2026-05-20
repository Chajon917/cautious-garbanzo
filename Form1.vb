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

        Private Sub CargarPlanilla()
            Try
                Dim objetoConexion As New CConexion()

                Using conn As MySqlConnection = objetoConexion.ObtenerConexion()
                    If conn Is Nothing Then Return

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

                        dgvPlanilla.ReadOnly = True
                        dgvPlanilla.AllowUserToAddRows = False
                        dgvPlanilla.AllowUserToDeleteRows = False
                        dgvPlanilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    End Using

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

        Private Sub BtnIngreso_Click(sender As Object, e As EventArgs) Handles btnIngreso.Click
            Using ventana As New FormIngreso()
                ventana.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub BtnPlanilla_Click(sender As Object, e As EventArgs) Handles btnPlanilla.Click
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

            Dim miCheque As New FormCheque(idTexto)
            miCheque.Show()
        End Sub

        Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
            Dim r As DialogResult = MessageBox.Show(
                "¿Desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If r = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles button4.Click
            Application.Exit()
        End Sub

        Private Sub BtnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
            Using ventanaPlanilla As New FormPlanilla()
                ventanaPlanilla.ShowDialog()
            End Using
            CargarPlanilla()
        End Sub

        Private Sub TxtIdBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtIdBusqueda.TextChanged
        End Sub

        Private Sub LabelId_Click(sender As Object, e As EventArgs) Handles labelId.Click
        End Sub

        Private Sub Form1_BackgroundImageLayoutChanged(sender As Object, e As EventArgs) Handles MyBase.BackgroundImageLayoutChanged
        End Sub

        Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint
        End Sub

    End Class
End Namespace