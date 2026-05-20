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
            'btnGuardar
            '
            Me.btnGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption
            Me.btnGuardar.ForeColor = System.Drawing.Color.Black
            Me.btnGuardar.Location = New System.Drawing.Point(123, 369)
            Me.btnGuardar.Name = "btnGuardar"
            Me.btnGuardar.Size = New System.Drawing.Size(137, 24)
            Me.btnGuardar.TabIndex = 3
            Me.btnGuardar.Text = "Guardar Datos"
            Me.btnGuardar.UseVisualStyleBackColor = False
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.ForeColor = System.Drawing.Color.DarkGoldenrod
            Me.label1.Location = New System.Drawing.Point(68, 60)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(135, 16)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Código empleado:"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label2.ForeColor = System.Drawing.Color.Teal
            Me.label2.Location = New System.Drawing.Point(68, 192)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(136, 16)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Nombre Completo:"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label3.ForeColor = System.Drawing.Color.Teal
            Me.label3.Location = New System.Drawing.Point(68, 299)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(100, 16)
            Me.label3.TabIndex = 3
            Me.label3.Text = "Sueldo Base:"
            '
            'txtId
            '
            Me.txtId.BackColor = System.Drawing.Color.SkyBlue
            Me.txtId.Location = New System.Drawing.Point(209, 57)
            Me.txtId.Name = "txtId"
            Me.txtId.Size = New System.Drawing.Size(125, 22)
            Me.txtId.TabIndex = 0
            '
            'txtNombre
            '
            Me.txtNombre.BackColor = System.Drawing.Color.SkyBlue
            Me.txtNombre.Location = New System.Drawing.Point(210, 186)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Size = New System.Drawing.Size(125, 22)
            Me.txtNombre.TabIndex = 1
            '
            'txtSueldo
            '
            Me.txtSueldo.BackColor = System.Drawing.Color.SkyBlue
            Me.txtSueldo.Location = New System.Drawing.Point(209, 293)
            Me.txtSueldo.Name = "txtSueldo"
            Me.txtSueldo.Size = New System.Drawing.Size(125, 22)
            Me.txtSueldo.TabIndex = 2
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label4.ForeColor = System.Drawing.Color.Teal
            Me.label4.Location = New System.Drawing.Point(68, 120)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(53, 16)
            Me.label4.TabIndex = 4
            Me.label4.Text = "Cargo:"
            '
            'txtCargo
            '
            Me.txtCargo.BackColor = System.Drawing.Color.SkyBlue
            Me.txtCargo.Location = New System.Drawing.Point(209, 120)
            Me.txtCargo.Name = "txtCargo"
            Me.txtCargo.Size = New System.Drawing.Size(125, 22)
            Me.txtCargo.TabIndex = 5
            '
            'button1
            '
            Me.button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
            Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
            Me.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.button1.Location = New System.Drawing.Point(364, 2)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(91, 45)
            Me.button1.TabIndex = 6
            Me.button1.Text = "X"
            Me.button1.UseVisualStyleBackColor = False
            '
            'FormIngreso
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.BackgroundImage = Global.ProyectoPlanillaUMG1.My.Resources.Resources.Conoce_Bantrab
            Me.ClientSize = New System.Drawing.Size(456, 427)
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
