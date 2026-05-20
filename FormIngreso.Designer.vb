Namespace ProyectoPlanillaUMG1

    Partial Class FormIngreso

        ''' <summary>
        ''' Variable del diseñador requerida.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Limpiar los recursos que se estén utilizando.
        ''' </summary>
        ''' <param name="disposing">True si los recursos administrados se deben desechar; de lo contrario, False.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Método necesario para la compatibilidad con el Diseñador. No modifique
        ''' el contenido de este método con el editor de código.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.btnGuardar = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.txtId = New System.Windows.Forms.TextBox()
            Me.txtNombre = New System.Windows.Forms.TextBox()
            Me.txtSueldo = New System.Windows.Forms.TextBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.txtCargo = New System.Windows.Forms.TextBox()
            Me.button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            ' btnGuardar
            '
            Me.btnGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption
            Me.btnGuardar.ForeColor = System.Drawing.Color.Black
            Me.btnGuardar.Location = New System.Drawing.Point(138, 461)
            Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.btnGuardar.Name = "btnGuardar"
            Me.btnGuardar.Size = New System.Drawing.Size(154, 30)
            Me.btnGuardar.TabIndex = 3
            Me.btnGuardar.Text = "Guardar Datos"
            Me.btnGuardar.UseVisualStyleBackColor = False
            '
            ' label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8F, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CByte(0))
            Me.label1.ForeColor = System.Drawing.Color.DarkGoldenrod
            Me.label1.Location = New System.Drawing.Point(76, 75)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(153, 20)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Código empleado:"
            '
            ' label2
            '
            Me.label2.AutoSize = True
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8F, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CByte(0))
            Me.label2.ForeColor = System.Drawing.Color.Teal
            Me.label2.Location = New System.Drawing.Point(76, 240)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(157, 20)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Nombre Completo:"
            '
            ' label3
            '
            Me.label3.AutoSize = True
            Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8F, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CByte(0))
            Me.label3.ForeColor = System.Drawing.Color.Teal
            Me.label3.Location = New System.Drawing.Point(76, 374)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(116, 20)
            Me.label3.TabIndex = 3
            Me.label3.Text = "Sueldo Base:"
            '
            ' txtId
            '
            Me.txtId.BackColor = System.Drawing.Color.SkyBlue
            Me.txtId.Location = New System.Drawing.Point(235, 71)
            Me.txtId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtId.Name = "txtId"
            Me.txtId.Size = New System.Drawing.Size(140, 26)
            Me.txtId.TabIndex = 0
            '
            ' txtNombre
            '
            Me.txtNombre.BackColor = System.Drawing.Color.SkyBlue
            Me.txtNombre.Location = New System.Drawing.Point(236, 232)
            Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Size = New System.Drawing.Size(140, 26)
            Me.txtNombre.TabIndex = 1
            '
            ' txtSueldo
            '
            Me.txtSueldo.BackColor = System.Drawing.Color.SkyBlue
            Me.txtSueldo.Location = New System.Drawing.Point(235, 366)
            Me.txtSueldo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtSueldo.Name = "txtSueldo"
            Me.txtSueldo.Size = New System.Drawing.Size(140, 26)
            Me.txtSueldo.TabIndex = 2
            '
            ' label4
            '
            Me.label4.AutoSize = True
            Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8F, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CByte(0))
            Me.label4.ForeColor = System.Drawing.Color.Teal
            Me.label4.Location = New System.Drawing.Point(76, 150)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(62, 20)
            Me.label4.TabIndex = 4
            Me.label4.Text = "Cargo:"
            '
            ' txtCargo
            '
            Me.txtCargo.BackColor = System.Drawing.Color.SkyBlue
            Me.txtCargo.Location = New System.Drawing.Point(235, 150)
            Me.txtCargo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtCargo.Name = "txtCargo"
            Me.txtCargo.Size = New System.Drawing.Size(140, 26)
            Me.txtCargo.TabIndex = 5
            '
            ' button1
            '
            Me.button1.BackColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
            Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0F)
            Me.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.button1.Location = New System.Drawing.Point(495, 2)
            Me.button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(102, 56)
            Me.button1.TabIndex = 6
            Me.button1.Text = "X"
            Me.button1.UseVisualStyleBackColor = False
            '
            ' FormIngreso
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(598, 534)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.txtCargo)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.txtSueldo)
            Me.Controls.Add(Me.txtNombre)
            Me.Controls.Add(Me.txtId)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.btnGuardar)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.Name = "FormIngreso"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        #End Region

        Private WithEvents btnGuardar As System.Windows.Forms.Button
        Private WithEvents label1 As System.Windows.Forms.Label
        Private WithEvents label2 As System.Windows.Forms.Label
        Private WithEvents label3 As System.Windows.Forms.Label
        Private WithEvents txtId As System.Windows.Forms.TextBox
        Private WithEvents txtNombre As System.Windows.Forms.TextBox
        Private WithEvents txtSueldo As System.Windows.Forms.TextBox
        Private WithEvents label4 As System.Windows.Forms.Label
        Private WithEvents txtCargo As System.Windows.Forms.TextBox
        Private WithEvents button1 As System.Windows.Forms.Button

    End Class

End Namespace
