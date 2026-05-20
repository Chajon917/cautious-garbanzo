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
            Dim dataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As New System.Windows.Forms.DataGridViewCellStyle()
            Me.dgvTrabajadores = New System.Windows.Forms.DataGridView()
            Me.btnEditar = New System.Windows.Forms.Button()
            Me.btnEliminar = New System.Windows.Forms.Button()
            Me.panelToolbar = New System.Windows.Forms.Panel()
            Me.button1 = New System.Windows.Forms.Button()
            Me.lblTitulo = New System.Windows.Forms.Label()
            CType(Me.dgvTrabajadores, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelToolbar.SuspendLayout()
            Me.SuspendLayout()
            '
            ' dgvTrabajadores
            '
            Me.dgvTrabajadores.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30)
            Me.dgvTrabajadores.BorderStyle = System.Windows.Forms.BorderStyle.None
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True
            Me.dgvTrabajadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38)
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185)
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False
            Me.dgvTrabajadores.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvTrabajadores.GridColor = System.Drawing.Color.FromArgb(60, 60, 60)
            Me.dgvTrabajadores.Location = New System.Drawing.Point(0, 60)
            Me.dgvTrabajadores.Margin = New System.Windows.Forms.Padding(0)
            Me.dgvTrabajadores.Name = "dgvTrabajadores"
            Me.dgvTrabajadores.RowHeadersWidth = 40
            Me.dgvTrabajadores.RowTemplate.Height = 28
            Me.dgvTrabajadores.Size = New System.Drawing.Size(960, 480)
            Me.dgvTrabajadores.TabIndex = 0
            '
            ' btnEditar
            '
            Me.btnEditar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185)
            Me.btnEditar.FlatAppearance.BorderSize = 0
            Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEditar.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnEditar.ForeColor = System.Drawing.Color.White
            Me.btnEditar.Location = New System.Drawing.Point(699, 13)
            Me.btnEditar.Name = "btnEditar"
            Me.btnEditar.Size = New System.Drawing.Size(120, 44)
            Me.btnEditar.TabIndex = 1
            Me.btnEditar.Text = "✏  Editar"
            Me.btnEditar.UseVisualStyleBackColor = False
            '
            ' btnEliminar
            '
            Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnEliminar.FlatAppearance.BorderSize = 0
            Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            Me.btnEliminar.ForeColor = System.Drawing.Color.White
            Me.btnEliminar.Location = New System.Drawing.Point(825, 13)
            Me.btnEliminar.Name = "btnEliminar"
            Me.btnEliminar.Size = New System.Drawing.Size(120, 44)
            Me.btnEliminar.TabIndex = 2
            Me.btnEliminar.Text = "🗑  Eliminar"
            Me.btnEliminar.UseVisualStyleBackColor = False
            '
            ' panelToolbar
            '
            Me.panelToolbar.BackColor = System.Drawing.Color.FromArgb(37, 37, 38)
            Me.panelToolbar.Controls.Add(Me.button1)
            Me.panelToolbar.Controls.Add(Me.lblTitulo)
            Me.panelToolbar.Controls.Add(Me.btnEditar)
            Me.panelToolbar.Controls.Add(Me.btnEliminar)
            Me.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelToolbar.Location = New System.Drawing.Point(0, 0)
            Me.panelToolbar.Name = "panelToolbar"
            Me.panelToolbar.Size = New System.Drawing.Size(983, 73)
            Me.panelToolbar.TabIndex = 1
            '
            ' button1
            '
            Me.button1.BackColor = System.Drawing.Color.FromArgb(0, 192, 0)
            Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0F)
            Me.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.button1.Location = New System.Drawing.Point(603, 13)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(90, 44)
            Me.button1.TabIndex = 3
            Me.button1.Text = "+"
            Me.button1.UseVisualStyleBackColor = False
            '
            ' lblTitulo
            '
            Me.lblTitulo.AutoSize = True
            Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0F, System.Drawing.FontStyle.Bold)
            Me.lblTitulo.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblTitulo.Location = New System.Drawing.Point(14, 16)
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Size = New System.Drawing.Size(302, 36)
            Me.lblTitulo.TabIndex = 0
            Me.lblTitulo.Text = "Planilla de Trabajadores"
            '
            ' FormPlanilla
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(30, 30, 30)
            Me.ClientSize = New System.Drawing.Size(983, 540)
            Me.Controls.Add(Me.dgvTrabajadores)
            Me.Controls.Add(Me.panelToolbar)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
