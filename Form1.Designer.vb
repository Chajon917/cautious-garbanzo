Namespace ProyectoPlanillaUMG1

    Partial Class Form1

        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnIngreso = New System.Windows.Forms.Button()
            Me.btnPlanilla = New System.Windows.Forms.Button()
            Me.btnCheque = New System.Windows.Forms.Button()
            Me.btnSalir = New System.Windows.Forms.Button()
            Me.labelId = New System.Windows.Forms.Label()
            Me.txtIdBusqueda = New System.Windows.Forms.TextBox()
            Me.dgvPlanilla = New System.Windows.Forms.DataGridView()
            Me.panelResumen = New System.Windows.Forms.Panel()
            Me.lblTituloResumen = New System.Windows.Forms.Label()
            Me.lblNumEmp = New System.Windows.Forms.Label()
            Me.lblNumEmpVal = New System.Windows.Forms.Label()
            Me.lblBruta = New System.Windows.Forms.Label()
            Me.lblBrutaVal = New System.Windows.Forms.Label()
            Me.lblLiquida = New System.Windows.Forms.Label()
            Me.lblLiquidaVal = New System.Windows.Forms.Label()
            ' Controles placeholder para eventos vacíos
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.button4 = New System.Windows.Forms.Button()
            Me.btnVisualizar = New System.Windows.Forms.Button()
            Me.panel1 = New System.Windows.Forms.Panel()
            CType(Me.dgvPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelResumen.SuspendLayout()
            Me.SuspendLayout()
            '
            ' btnIngreso
            '
            Me.btnIngreso.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
            Me.btnIngreso.FlatAppearance.BorderSize = 0
            Me.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnIngreso.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnIngreso.ForeColor = System.Drawing.Color.White
            Me.btnIngreso.Location = New System.Drawing.Point(26, 13)
            Me.btnIngreso.Name = "btnIngreso"
            Me.btnIngreso.Size = New System.Drawing.Size(140, 38)
            Me.btnIngreso.TabIndex = 0
            Me.btnIngreso.Text = "➕  Nuevo Ingreso"
            Me.btnIngreso.UseVisualStyleBackColor = False
            '
            ' btnPlanilla
            '
            Me.btnPlanilla.BackColor = System.Drawing.Color.FromArgb(39, 174, 96)
            Me.btnPlanilla.FlatAppearance.BorderSize = 0
            Me.btnPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPlanilla.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnPlanilla.ForeColor = System.Drawing.Color.White
            Me.btnPlanilla.Location = New System.Drawing.Point(172, 12)
            Me.btnPlanilla.Name = "btnPlanilla"
            Me.btnPlanilla.Size = New System.Drawing.Size(140, 38)
            Me.btnPlanilla.TabIndex = 1
            Me.btnPlanilla.Text = "📋  Ver Planilla"
            Me.btnPlanilla.UseVisualStyleBackColor = False
            '
            ' btnCheque
            '
            Me.btnCheque.BackColor = System.Drawing.Color.FromArgb(243, 156, 18)
            Me.btnCheque.FlatAppearance.BorderSize = 0
            Me.btnCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCheque.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnCheque.ForeColor = System.Drawing.Color.White
            Me.btnCheque.Location = New System.Drawing.Point(456, 12)
            Me.btnCheque.Name = "btnCheque"
            Me.btnCheque.Size = New System.Drawing.Size(140, 38)
            Me.btnCheque.TabIndex = 3
            Me.btnCheque.Text = "🖨  Generar Cheque"
            Me.btnCheque.UseVisualStyleBackColor = False
            '
            ' btnSalir
            '
            Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnSalir.FlatAppearance.BorderSize = 0
            Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnSalir.ForeColor = System.Drawing.Color.White
            Me.btnSalir.Location = New System.Drawing.Point(615, 12)
            Me.btnSalir.Name = "btnSalir"
            Me.btnSalir.Size = New System.Drawing.Size(132, 38)
            Me.btnSalir.TabIndex = 5
            Me.btnSalir.Text = "✖  Salir"
            Me.btnSalir.UseVisualStyleBackColor = False
            '
            ' labelId
            '
            Me.labelId.AutoSize = True
            Me.labelId.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            Me.labelId.ForeColor = System.Drawing.Color.White
            Me.labelId.Location = New System.Drawing.Point(308, 20)
            Me.labelId.Name = "labelId"
            Me.labelId.Size = New System.Drawing.Size(36, 25)
            Me.labelId.TabIndex = 10
            Me.labelId.Text = "ID:"
            '
            ' txtIdBusqueda
            '
            Me.txtIdBusqueda.BackColor = System.Drawing.Color.FromArgb(50, 50, 50)
            Me.txtIdBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.5F)
            Me.txtIdBusqueda.ForeColor = System.Drawing.Color.White
            Me.txtIdBusqueda.Location = New System.Drawing.Point(350, 18)
            Me.txtIdBusqueda.Name = "txtIdBusqueda"
            Me.txtIdBusqueda.Size = New System.Drawing.Size(100, 33)
            Me.txtIdBusqueda.TabIndex = 2
            '
            ' dgvPlanilla
            '
            Me.dgvPlanilla.AllowUserToAddRows = False
            Me.dgvPlanilla.AllowUserToDeleteRows = False
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(55, 55, 55)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.dgvPlanilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvPlanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvPlanilla.BackgroundColor = System.Drawing.Color.FromArgb(40, 40, 40)
            Me.dgvPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.None
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30)
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18)
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True
            Me.dgvPlanilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
            Me.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(45, 45, 45)
            dataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219)
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False
            Me.dgvPlanilla.DefaultCellStyle = dataGridViewCellStyle3
            Me.dgvPlanilla.EnableHeadersVisualStyles = False
            Me.dgvPlanilla.GridColor = System.Drawing.Color.FromArgb(60, 60, 60)
            Me.dgvPlanilla.Location = New System.Drawing.Point(12, 62)
            Me.dgvPlanilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.dgvPlanilla.Name = "dgvPlanilla"
            Me.dgvPlanilla.ReadOnly = True
            Me.dgvPlanilla.RowHeadersWidth = 62
            Me.dgvPlanilla.RowTemplate.Height = 26
            Me.dgvPlanilla.Size = New System.Drawing.Size(844, 420)
            Me.dgvPlanilla.TabIndex = 6
            '
            ' panelResumen
            '
            Me.panelResumen.BackColor = System.Drawing.Color.FromArgb(30, 30, 30)
            Me.panelResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.panelResumen.Controls.Add(Me.lblTituloResumen)
            Me.panelResumen.Controls.Add(Me.lblNumEmp)
            Me.panelResumen.Controls.Add(Me.lblNumEmpVal)
            Me.panelResumen.Controls.Add(Me.lblBruta)
            Me.panelResumen.Controls.Add(Me.lblBrutaVal)
            Me.panelResumen.Controls.Add(Me.lblLiquida)
            Me.panelResumen.Controls.Add(Me.lblLiquidaVal)
            Me.panelResumen.Location = New System.Drawing.Point(868, 62)
            Me.panelResumen.Name = "panelResumen"
            Me.panelResumen.Padding = New System.Windows.Forms.Padding(10)
            Me.panelResumen.Size = New System.Drawing.Size(295, 420)
            Me.panelResumen.TabIndex = 7
            '
            ' lblTituloResumen
            '
            Me.lblTituloResumen.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Bold)
            Me.lblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18)
            Me.lblTituloResumen.Location = New System.Drawing.Point(10, 14)
            Me.lblTituloResumen.Name = "lblTituloResumen"
            Me.lblTituloResumen.Size = New System.Drawing.Size(196, 30)
            Me.lblTituloResumen.TabIndex = 0
            Me.lblTituloResumen.Text = "📊 Resumen de Planilla"
            Me.lblTituloResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' lblNumEmp
            '
            Me.lblNumEmp.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            Me.lblNumEmp.ForeColor = System.Drawing.Color.Silver
            Me.lblNumEmp.Location = New System.Drawing.Point(10, 70)
            Me.lblNumEmp.Name = "lblNumEmp"
            Me.lblNumEmp.Size = New System.Drawing.Size(196, 20)
            Me.lblNumEmp.TabIndex = 1
            Me.lblNumEmp.Text = "No. de Empleados"
            '
            ' lblNumEmpVal
            '
            Me.lblNumEmpVal.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
            Me.lblNumEmpVal.ForeColor = System.Drawing.Color.White
            Me.lblNumEmpVal.Location = New System.Drawing.Point(-7, 90)
            Me.lblNumEmpVal.Name = "lblNumEmpVal"
            Me.lblNumEmpVal.Size = New System.Drawing.Size(196, 40)
            Me.lblNumEmpVal.TabIndex = 2
            Me.lblNumEmpVal.Text = "0"
            Me.lblNumEmpVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' lblBruta
            '
            Me.lblBruta.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            Me.lblBruta.ForeColor = System.Drawing.Color.Silver
            Me.lblBruta.Location = New System.Drawing.Point(10, 155)
            Me.lblBruta.Name = "lblBruta"
            Me.lblBruta.Size = New System.Drawing.Size(266, 27)
            Me.lblBruta.TabIndex = 3
            Me.lblBruta.Text = "Planilla Bruta (Total Sueldos)"
            '
            ' lblBrutaVal
            '
            Me.lblBrutaVal.Font = New System.Drawing.Font("Segoe UI", 14.0F, System.Drawing.FontStyle.Bold)
            Me.lblBrutaVal.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219)
            Me.lblBrutaVal.Location = New System.Drawing.Point(-7, 175)
            Me.lblBrutaVal.Name = "lblBrutaVal"
            Me.lblBrutaVal.Size = New System.Drawing.Size(196, 36)
            Me.lblBrutaVal.TabIndex = 4
            Me.lblBrutaVal.Text = "Q. 0.00"
            Me.lblBrutaVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' lblLiquida
            '
            Me.lblLiquida.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            Me.lblLiquida.ForeColor = System.Drawing.Color.Silver
            Me.lblLiquida.Location = New System.Drawing.Point(10, 240)
            Me.lblLiquida.Name = "lblLiquida"
            Me.lblLiquida.Size = New System.Drawing.Size(274, 30)
            Me.lblLiquida.TabIndex = 5
            Me.lblLiquida.Text = "Planilla Líquida (Total a Pagar)"
            '
            ' lblLiquidaVal
            '
            Me.lblLiquidaVal.Font = New System.Drawing.Font("Segoe UI", 14.0F, System.Drawing.FontStyle.Bold)
            Me.lblLiquidaVal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96)
            Me.lblLiquidaVal.Location = New System.Drawing.Point(-6, 260)
            Me.lblLiquidaVal.Name = "lblLiquidaVal"
            Me.lblLiquidaVal.Size = New System.Drawing.Size(196, 36)
            Me.lblLiquidaVal.TabIndex = 6
            Me.lblLiquidaVal.Text = "Q. 0.00"
            Me.lblLiquidaVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' Botones placeholder (invisible, solo para manejar eventos heredados)
            '
            Me.button1.Location = New System.Drawing.Point(-100, -100)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(1, 1)
            Me.button1.TabIndex = 20
            Me.button1.Visible = False

            Me.button2.Location = New System.Drawing.Point(-100, -100)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(1, 1)
            Me.button2.TabIndex = 21
            Me.button2.Visible = False

            Me.button4.Location = New System.Drawing.Point(-100, -100)
            Me.button4.Name = "button4"
            Me.button4.Size = New System.Drawing.Size(1, 1)
            Me.button4.TabIndex = 22
            Me.button4.Visible = False

            Me.btnVisualizar.Location = New System.Drawing.Point(-100, -100)
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(1, 1)
            Me.btnVisualizar.TabIndex = 23
            Me.btnVisualizar.Visible = False

            Me.panel1.Location = New System.Drawing.Point(-100, -100)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(1, 1)
            Me.panel1.TabIndex = 24
            Me.panel1.Visible = False
            '
            ' Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(35, 35, 35)
            Me.ClientSize = New System.Drawing.Size(1165, 494)
            Me.Controls.Add(Me.btnIngreso)
            Me.Controls.Add(Me.btnPlanilla)
            Me.Controls.Add(Me.labelId)
            Me.Controls.Add(Me.txtIdBusqueda)
            Me.Controls.Add(Me.btnCheque)
            Me.Controls.Add(Me.btnSalir)
            Me.Controls.Add(Me.dgvPlanilla)
            Me.Controls.Add(Me.panelResumen)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button4)
            Me.Controls.Add(Me.btnVisualizar)
            Me.Controls.Add(Me.panel1)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.MinimumSize = New System.Drawing.Size(1116, 533)
            Me.Name = "Form1"
            Me.Text = "Sistema de Planilla UMG"
            CType(Me.dgvPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelResumen.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        #End Region

        Private WithEvents btnIngreso As System.Windows.Forms.Button
        Private WithEvents btnPlanilla As System.Windows.Forms.Button
        Private WithEvents btnCheque As System.Windows.Forms.Button
        Private WithEvents btnSalir As System.Windows.Forms.Button
        Private WithEvents labelId As System.Windows.Forms.Label
        Private WithEvents txtIdBusqueda As System.Windows.Forms.TextBox
        Private WithEvents dgvPlanilla As System.Windows.Forms.DataGridView
        Private panelResumen As System.Windows.Forms.Panel
        Private lblTituloResumen As System.Windows.Forms.Label
        Private lblNumEmp As System.Windows.Forms.Label
        Private lblNumEmpVal As System.Windows.Forms.Label
        Private lblBruta As System.Windows.Forms.Label
        Private lblBrutaVal As System.Windows.Forms.Label
        Private lblLiquida As System.Windows.Forms.Label
        Private lblLiquidaVal As System.Windows.Forms.Label
        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
        Private WithEvents button4 As System.Windows.Forms.Button
        Private WithEvents btnVisualizar As System.Windows.Forms.Button
        Private WithEvents panel1 As System.Windows.Forms.Panel

    End Class

End Namespace
