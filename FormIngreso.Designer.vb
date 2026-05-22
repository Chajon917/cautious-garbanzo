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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIngreso))
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
            Me.txtCorreo = New System.Windows.Forms.TextBox()
            Me.txtNoCuenta = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.SuspendLayout()
            '
            'btnGuardar
            '
            Me.btnGuardar.BackColor = System.Drawing.SystemColors.AppWorkspace
            Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGuardar.ForeColor = System.Drawing.Color.Black
            Me.btnGuardar.Location = New System.Drawing.Point(92, 296)
            Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2)
            Me.btnGuardar.Name = "btnGuardar"
            Me.btnGuardar.Size = New System.Drawing.Size(155, 31)
            Me.btnGuardar.TabIndex = 3
            Me.btnGuardar.Text = "INGRESAR DATOS"
            Me.btnGuardar.UseVisualStyleBackColor = False
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.BackColor = System.Drawing.Color.Transparent
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.ForeColor = System.Drawing.Color.White
            Me.label1.Location = New System.Drawing.Point(38, 73)
            Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(126, 13)
            Me.label1.TabIndex = 1
            Me.label1.Text = "INGRESE NUEVO ID"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.BackColor = System.Drawing.Color.Transparent
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label2.ForeColor = System.Drawing.Color.White
            Me.label2.Location = New System.Drawing.Point(35, 148)
            Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(131, 13)
            Me.label2.TabIndex = 2
            Me.label2.Text = "NOMBRE COMPLETO"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.BackColor = System.Drawing.Color.Transparent
            Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label3.ForeColor = System.Drawing.Color.White
            Me.label3.Location = New System.Drawing.Point(61, 257)
            Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(85, 15)
            Me.label3.TabIndex = 3
            Me.label3.Text = "SUELDO BASE"
            '
            'txtId
            '
            Me.txtId.BackColor = System.Drawing.Color.Gainsboro
            Me.txtId.Location = New System.Drawing.Point(181, 68)
            Me.txtId.Margin = New System.Windows.Forms.Padding(2)
            Me.txtId.Name = "txtId"
            Me.txtId.Size = New System.Drawing.Size(95, 20)
            Me.txtId.TabIndex = 0
            '
            'txtNombre
            '
            Me.txtNombre.BackColor = System.Drawing.Color.Gainsboro
            Me.txtNombre.Location = New System.Drawing.Point(181, 143)
            Me.txtNombre.Margin = New System.Windows.Forms.Padding(2)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Size = New System.Drawing.Size(95, 20)
            Me.txtNombre.TabIndex = 1
            '
            'txtSueldo
            '
            Me.txtSueldo.BackColor = System.Drawing.Color.Gainsboro
            Me.txtSueldo.Location = New System.Drawing.Point(180, 255)
            Me.txtSueldo.Margin = New System.Windows.Forms.Padding(2)
            Me.txtSueldo.Name = "txtSueldo"
            Me.txtSueldo.Size = New System.Drawing.Size(95, 20)
            Me.txtSueldo.TabIndex = 2
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.BackColor = System.Drawing.Color.Transparent
            Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label4.ForeColor = System.Drawing.Color.White
            Me.label4.Location = New System.Drawing.Point(77, 110)
            Me.label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(50, 13)
            Me.label4.TabIndex = 4
            Me.label4.Text = "CARGO"
            '
            'txtCargo
            '
            Me.txtCargo.BackColor = System.Drawing.Color.Gainsboro
            Me.txtCargo.Location = New System.Drawing.Point(181, 106)
            Me.txtCargo.Margin = New System.Windows.Forms.Padding(2)
            Me.txtCargo.Name = "txtCargo"
            Me.txtCargo.Size = New System.Drawing.Size(95, 20)
            Me.txtCargo.TabIndex = 5
            '
            'button1
            '
            Me.button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
            Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
            Me.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.button1.Location = New System.Drawing.Point(295, 11)
            Me.button1.Margin = New System.Windows.Forms.Padding(2)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(55, 37)
            Me.button1.TabIndex = 6
            Me.button1.Text = "X"
            Me.button1.UseVisualStyleBackColor = False
            '
            'txtCorreo
            '
            Me.txtCorreo.BackColor = System.Drawing.Color.Gainsboro
            Me.txtCorreo.Location = New System.Drawing.Point(181, 179)
            Me.txtCorreo.Margin = New System.Windows.Forms.Padding(2)
            Me.txtCorreo.Name = "txtCorreo"
            Me.txtCorreo.Size = New System.Drawing.Size(94, 20)
            Me.txtCorreo.TabIndex = 7
            '
            'txtNoCuenta
            '
            Me.txtNoCuenta.BackColor = System.Drawing.Color.Gainsboro
            Me.txtNoCuenta.Location = New System.Drawing.Point(180, 217)
            Me.txtNoCuenta.Margin = New System.Windows.Forms.Padding(2)
            Me.txtNoCuenta.Name = "txtNoCuenta"
            Me.txtNoCuenta.Size = New System.Drawing.Size(94, 20)
            Me.txtNoCuenta.TabIndex = 8
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(21, 185)
            Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(150, 13)
            Me.Label5.TabIndex = 9
            Me.Label5.Text = "CORREO ELECTRONICO"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(57, 220)
            Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(94, 15)
            Me.Label6.TabIndex = 10
            Me.Label6.Text = "NO. DE CUENTA"
            Me.Label6.UseWaitCursor = True
            '
            'TextBox1
            '
            Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox1.ForeColor = System.Drawing.SystemColors.Window
            Me.TextBox1.Location = New System.Drawing.Point(70, 26)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(203, 22)
            Me.TextBox1.TabIndex = 11
            Me.TextBox1.Text = "INGRESE NUEVO USUARIO"
            Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
            '
            'FormIngreso
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(361, 347)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.txtNoCuenta)
            Me.Controls.Add(Me.txtCorreo)
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
            Me.Margin = New System.Windows.Forms.Padding(2)
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
        Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
        Friend WithEvents txtNoCuenta As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    End Class

End Namespace
