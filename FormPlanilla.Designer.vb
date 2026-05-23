Namespace ProyectoPlanillaUMG1

    Partial Class FormPlanilla

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPlanilla))
            Me.dgvTrabajadores = New System.Windows.Forms.DataGridView()
            Me.panelToolbar = New System.Windows.Forms.Panel()
            Me.button1 = New System.Windows.Forms.Button()
            Me.lblTitulo = New System.Windows.Forms.Label()
            Me.btnEditar = New System.Windows.Forms.Button()
            Me.btnEliminar = New System.Windows.Forms.Button()
            CType(Me.dgvTrabajadores, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelToolbar.SuspendLayout()
            Me.SuspendLayout()
            '
            'dgvTrabajadores
            '
            Me.dgvTrabajadores.BackgroundColor = System.Drawing.Color.Gray
            Me.dgvTrabajadores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTrabajadores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvTrabajadores.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvTrabajadores.GridColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.dgvTrabajadores.Location = New System.Drawing.Point(0, 60)
            Me.dgvTrabajadores.Margin = New System.Windows.Forms.Padding(0)
            Me.dgvTrabajadores.Name = "dgvTrabajadores"
            Me.dgvTrabajadores.RowHeadersWidth = 40
            Me.dgvTrabajadores.RowTemplate.Height = 28
            Me.dgvTrabajadores.Size = New System.Drawing.Size(884, 369)
            Me.dgvTrabajadores.TabIndex = 0
            '
            'panelToolbar
            '
            Me.panelToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.panelToolbar.BackgroundImage = CType(resources.GetObject("panelToolbar.BackgroundImage"), System.Drawing.Image)
            Me.panelToolbar.Controls.Add(Me.button1)
            Me.panelToolbar.Controls.Add(Me.lblTitulo)
            Me.panelToolbar.Controls.Add(Me.btnEditar)
            Me.panelToolbar.Controls.Add(Me.btnEliminar)
            Me.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelToolbar.Location = New System.Drawing.Point(0, 0)
            Me.panelToolbar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.panelToolbar.Name = "panelToolbar"
            Me.panelToolbar.Size = New System.Drawing.Size(884, 58)
            Me.panelToolbar.TabIndex = 1
            '
            'button1
            '
            Me.button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.button1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.button1.ForeColor = System.Drawing.Color.White
            Me.button1.Location = New System.Drawing.Point(465, 10)
            Me.button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(119, 34)
            Me.button1.TabIndex = 3
            Me.button1.Text = "+ Agregar"
            Me.button1.UseVisualStyleBackColor = False
            '
            'lblTitulo
            '
            Me.lblTitulo.AutoSize = True
            Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
            Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitulo.ForeColor = System.Drawing.Color.White
            Me.lblTitulo.Location = New System.Drawing.Point(12, 14)
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Size = New System.Drawing.Size(260, 30)
            Me.lblTitulo.TabIndex = 0
            Me.lblTitulo.Text = "Planilla de Trabajadores"
            '
            'btnEditar
            '
            Me.btnEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.btnEditar.FlatAppearance.BorderSize = 0
            Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEditar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnEditar.ForeColor = System.Drawing.Color.White
            Me.btnEditar.Location = New System.Drawing.Point(605, 11)
            Me.btnEditar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnEditar.Name = "btnEditar"
            Me.btnEditar.Size = New System.Drawing.Size(107, 33)
            Me.btnEditar.TabIndex = 1
            Me.btnEditar.Text = "✏  Editar"
            Me.btnEditar.UseVisualStyleBackColor = False
            '
            'btnEliminar
            '
            Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.btnEliminar.FlatAppearance.BorderSize = 0
            Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnEliminar.ForeColor = System.Drawing.Color.White
            Me.btnEliminar.Location = New System.Drawing.Point(733, 10)
            Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnEliminar.Name = "btnEliminar"
            Me.btnEliminar.Size = New System.Drawing.Size(129, 34)
            Me.btnEliminar.TabIndex = 2
            Me.btnEliminar.Text = "🗑  Eliminar"
            Me.btnEliminar.UseVisualStyleBackColor = False
            '
            'FormPlanilla
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(884, 441)
            Me.Controls.Add(Me.dgvTrabajadores)
            Me.Controls.Add(Me.panelToolbar)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.Name = "FormPlanilla"
            Me.Text = "Planilla de Trabajadores"
            CType(Me.dgvTrabajadores, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelToolbar.ResumeLayout(False)
            Me.panelToolbar.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents dgvTrabajadores As System.Windows.Forms.DataGridView
        Private WithEvents btnEditar As System.Windows.Forms.Button
        Private WithEvents btnEliminar As System.Windows.Forms.Button
        Private panelToolbar As System.Windows.Forms.Panel
        Private lblTitulo As System.Windows.Forms.Label
        Private WithEvents button1 As System.Windows.Forms.Button

    End Class

End Namespace
