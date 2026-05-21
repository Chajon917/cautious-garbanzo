Namespace ProyectoPlanillaUMG1

    Partial Class Form1
        Inherits System.Windows.Forms.Form

        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.button4 = New System.Windows.Forms.Button()
            Me.btnVisualizar = New System.Windows.Forms.Button()
            Me.panel1 = New System.Windows.Forms.Panel()
            CType(Me.dgvPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelResumen.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnIngreso
            '
            Me.btnIngreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnIngreso.FlatAppearance.BorderSize = 0
            Me.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnIngreso.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnIngreso.ForeColor = System.Drawing.Color.White
            Me.btnIngreso.Location = New System.Drawing.Point(154, 27)
            Me.btnIngreso.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.btnIngreso.Name = "btnIngreso"
            Me.btnIngreso.Size = New System.Drawing.Size(143, 27)
            Me.btnIngreso.TabIndex = 0
            Me.btnIngreso.Text = "➕  Nuevo Ingreso"
            Me.btnIngreso.UseVisualStyleBackColor = False
            '
            'btnPlanilla
            '
            Me.btnPlanilla.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
            Me.btnPlanilla.FlatAppearance.BorderSize = 0
            Me.btnPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPlanilla.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnPlanilla.ForeColor = System.Drawing.Color.White
            Me.btnPlanilla.Location = New System.Drawing.Point(477, 27)
            Me.btnPlanilla.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.btnPlanilla.Name = "btnPlanilla"
            Me.btnPlanilla.Size = New System.Drawing.Size(160, 28)
            Me.btnPlanilla.TabIndex = 1
            Me.btnPlanilla.Text = "📋  Consultar Planilla"
            Me.btnPlanilla.UseVisualStyleBackColor = False
            '
            'btnCheque
            '
            Me.btnCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
            Me.btnCheque.FlatAppearance.BorderSize = 0
            Me.btnCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCheque.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCheque.ForeColor = System.Drawing.Color.White
            Me.btnCheque.Location = New System.Drawing.Point(315, 27)
            Me.btnCheque.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.btnCheque.Name = "btnCheque"
            Me.btnCheque.Size = New System.Drawing.Size(145, 28)
            Me.btnCheque.TabIndex = 3
            Me.btnCheque.Text = "🖨  Generar Cheque"
            Me.btnCheque.UseVisualStyleBackColor = False
            '
            'btnSalir
            '
            Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.btnSalir.FlatAppearance.BorderSize = 0
            Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSalir.ForeColor = System.Drawing.Color.White
            Me.btnSalir.Location = New System.Drawing.Point(670, 12)
            Me.btnSalir.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.btnSalir.Name = "btnSalir"
            Me.btnSalir.Size = New System.Drawing.Size(88, 28)
            Me.btnSalir.TabIndex = 5
            Me.btnSalir.Text = "✖  Salir"
            Me.btnSalir.UseVisualStyleBackColor = False
            '
            'labelId
            '
            Me.labelId.AutoSize = True
            Me.labelId.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.labelId.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.labelId.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.labelId.ForeColor = System.Drawing.Color.Transparent
            Me.labelId.Location = New System.Drawing.Point(19, 14)
            Me.labelId.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.labelId.Name = "labelId"
            Me.labelId.Size = New System.Drawing.Size(94, 15)
            Me.labelId.TabIndex = 10
            Me.labelId.Text = "INGRESE SU ID "
            '
            'txtIdBusqueda
            '
            Me.txtIdBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
            Me.txtIdBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtIdBusqueda.ForeColor = System.Drawing.Color.White
            Me.txtIdBusqueda.Location = New System.Drawing.Point(18, 40)
            Me.txtIdBusqueda.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.txtIdBusqueda.Name = "txtIdBusqueda"
            Me.txtIdBusqueda.Size = New System.Drawing.Size(67, 24)
            Me.txtIdBusqueda.TabIndex = 2
            '
            'dgvPlanilla
            '
            Me.dgvPlanilla.AllowUserToAddRows = False
            Me.dgvPlanilla.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.dgvPlanilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvPlanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvPlanilla.BackgroundColor = System.Drawing.Color.Silver
            Me.dgvPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.None
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPlanilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvPlanilla.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvPlanilla.EnableHeadersVisualStyles = False
            Me.dgvPlanilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.dgvPlanilla.Location = New System.Drawing.Point(8, 83)
            Me.dgvPlanilla.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.dgvPlanilla.Name = "dgvPlanilla"
            Me.dgvPlanilla.ReadOnly = True
            Me.dgvPlanilla.RowHeadersWidth = 62
            Me.dgvPlanilla.RowTemplate.Height = 26
            Me.dgvPlanilla.Size = New System.Drawing.Size(562, 231)
            Me.dgvPlanilla.TabIndex = 6
            '
            'panelResumen
            '
            Me.panelResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.panelResumen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelResumen.Controls.Add(Me.lblTituloResumen)
            Me.panelResumen.Controls.Add(Me.lblNumEmp)
            Me.panelResumen.Controls.Add(Me.lblNumEmpVal)
            Me.panelResumen.Controls.Add(Me.lblBruta)
            Me.panelResumen.Controls.Add(Me.lblBrutaVal)
            Me.panelResumen.Controls.Add(Me.lblLiquida)
            Me.panelResumen.Controls.Add(Me.lblLiquidaVal)
            Me.panelResumen.Location = New System.Drawing.Point(587, 83)
            Me.panelResumen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.panelResumen.Name = "panelResumen"
            Me.panelResumen.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
            Me.panelResumen.Size = New System.Drawing.Size(190, 232)
            Me.panelResumen.TabIndex = 7
            '
            'lblTituloResumen
            '
            Me.lblTituloResumen.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
            Me.lblTituloResumen.Location = New System.Drawing.Point(6, 6)
            Me.lblTituloResumen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblTituloResumen.Name = "lblTituloResumen"
            Me.lblTituloResumen.Size = New System.Drawing.Size(182, 20)
            Me.lblTituloResumen.TabIndex = 0
            Me.lblTituloResumen.Text = "📊 Resumen de Planilla"
            Me.lblTituloResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNumEmp
            '
            Me.lblNumEmp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblNumEmp.ForeColor = System.Drawing.Color.Silver
            Me.lblNumEmp.Location = New System.Drawing.Point(39, 41)
            Me.lblNumEmp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblNumEmp.Name = "lblNumEmp"
            Me.lblNumEmp.Size = New System.Drawing.Size(130, 13)
            Me.lblNumEmp.TabIndex = 1
            Me.lblNumEmp.Text = "No. de Empleados"
            '
            'lblNumEmpVal
            '
            Me.lblNumEmpVal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblNumEmpVal.ForeColor = System.Drawing.Color.White
            Me.lblNumEmpVal.Location = New System.Drawing.Point(61, 58)
            Me.lblNumEmpVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblNumEmpVal.Name = "lblNumEmpVal"
            Me.lblNumEmpVal.Size = New System.Drawing.Size(67, 26)
            Me.lblNumEmpVal.TabIndex = 2
            Me.lblNumEmpVal.Text = "0"
            Me.lblNumEmpVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBruta
            '
            Me.lblBruta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBruta.ForeColor = System.Drawing.Color.Silver
            Me.lblBruta.Location = New System.Drawing.Point(7, 95)
            Me.lblBruta.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblBruta.Name = "lblBruta"
            Me.lblBruta.Size = New System.Drawing.Size(177, 18)
            Me.lblBruta.TabIndex = 3
            Me.lblBruta.Text = "Planilla Bruta (Total Sueldos)"
            '
            'lblBrutaVal
            '
            Me.lblBrutaVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblBrutaVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblBrutaVal.Location = New System.Drawing.Point(10, 119)
            Me.lblBrutaVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblBrutaVal.Name = "lblBrutaVal"
            Me.lblBrutaVal.Size = New System.Drawing.Size(174, 24)
            Me.lblBrutaVal.TabIndex = 4
            Me.lblBrutaVal.Text = "Q. 0.00"
            Me.lblBrutaVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLiquida
            '
            Me.lblLiquida.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblLiquida.ForeColor = System.Drawing.Color.Silver
            Me.lblLiquida.Location = New System.Drawing.Point(7, 156)
            Me.lblLiquida.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblLiquida.Name = "lblLiquida"
            Me.lblLiquida.Size = New System.Drawing.Size(183, 20)
            Me.lblLiquida.TabIndex = 5
            Me.lblLiquida.Text = "Planilla Líquida (Total a Pagar)"
            '
            'lblLiquidaVal
            '
            Me.lblLiquidaVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblLiquidaVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
            Me.lblLiquidaVal.Location = New System.Drawing.Point(10, 176)
            Me.lblLiquidaVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblLiquidaVal.Name = "lblLiquidaVal"
            Me.lblLiquidaVal.Size = New System.Drawing.Size(174, 24)
            Me.lblLiquidaVal.TabIndex = 6
            Me.lblLiquidaVal.Text = "Q. 0.00"
            Me.lblLiquidaVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(-67, -65)
            Me.button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(1, 1)
            Me.button1.TabIndex = 20
            Me.button1.Visible = False
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(-67, -65)
            Me.button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(1, 1)
            Me.button2.TabIndex = 21
            Me.button2.Visible = False
            '
            'button4
            '
            Me.button4.Location = New System.Drawing.Point(-67, -65)
            Me.button4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.button4.Name = "button4"
            Me.button4.Size = New System.Drawing.Size(1, 1)
            Me.button4.TabIndex = 22
            Me.button4.Visible = False
            '
            'btnVisualizar
            '
            Me.btnVisualizar.Location = New System.Drawing.Point(-67, -65)
            Me.btnVisualizar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(1, 1)
            Me.btnVisualizar.TabIndex = 23
            Me.btnVisualizar.Visible = False
            '
            'panel1
            '
            Me.panel1.Location = New System.Drawing.Point(-67, -65)
            Me.panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(1, 1)
            Me.panel1.TabIndex = 24
            Me.panel1.Visible = False
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(777, 323)
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
            Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.MinimumSize = New System.Drawing.Size(750, 362)
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