Imports System

Namespace ProyectoPlanillaUMG1

    Partial Class FormCheque

        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCheque))
            Me.txtIdBusqueda = New System.Windows.Forms.TextBox()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.btnCerrar = New System.Windows.Forms.Button()
            Me.panelCheque = New System.Windows.Forms.Panel()
            Me.pnlMonto = New System.Windows.Forms.Panel()
            Me.lblValorNumLbl = New System.Windows.Forms.Label()
            Me.lblMontoNumero = New System.Windows.Forms.Label()
            Me.lblFechaLbl = New System.Windows.Forms.Label()
            Me.lblFecha = New System.Windows.Forms.Label()
            Me.lblPaguese = New System.Windows.Forms.Label()
            Me.lblNombre = New System.Windows.Forms.Label()
            Me.lineaNombre = New System.Windows.Forms.Label()
            Me.lblCargoLbl = New System.Windows.Forms.Label()
            Me.lblCargo = New System.Windows.Forms.Label()
            Me.lblValorLetLbl = New System.Windows.Forms.Label()
            Me.lblMontoLetras = New System.Windows.Forms.Label()
            Me.lineaLetras = New System.Windows.Forms.Label()
            Me.lblDetalleLbl = New System.Windows.Forms.Label()
            Me.lblSueldoLbl = New System.Windows.Forms.Label()
            Me.lblSueldo = New System.Windows.Forms.Label()
            Me.lblIGSSLbl = New System.Windows.Forms.Label()
            Me.lblIGSS = New System.Windows.Forms.Label()
            Me.lblBonoLbl = New System.Windows.Forms.Label()
            Me.lblBono = New System.Windows.Forms.Label()
            Me.lblOtrosLbl = New System.Windows.Forms.Label()
            Me.lblOtros = New System.Windows.Forms.Label()
            Me.lineaTotal = New System.Windows.Forms.Label()
            Me.lblLineaFirma = New System.Windows.Forms.Label()
            Me.lblFirmaLbl = New System.Windows.Forms.Label()
            Me.lblAutorizado = New System.Windows.Forms.Label()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblBancoNombre = New System.Windows.Forms.Label()
            Me.lblBancoSlogan = New System.Windows.Forms.Label()
            Me.lblNoCheque = New System.Windows.Forms.Label()
            Me.printDocument1 = New System.Drawing.Printing.PrintDocument()
            Me.pnlSide = New System.Windows.Forms.Panel()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblSideTitle = New System.Windows.Forms.Label()
            Me.lblIdLbl = New System.Windows.Forms.Label()
            Me.panelCheque.SuspendLayout()
            Me.pnlMonto.SuspendLayout()
            Me.pnlHeader.SuspendLayout()
            Me.pnlSide.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtIdBusqueda
            '
            Me.txtIdBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.txtIdBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdBusqueda.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
            Me.txtIdBusqueda.ForeColor = System.Drawing.Color.White
            Me.txtIdBusqueda.Location = New System.Drawing.Point(15, 121)
            Me.txtIdBusqueda.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.txtIdBusqueda.Name = "txtIdBusqueda"
            Me.txtIdBusqueda.Size = New System.Drawing.Size(171, 30)
            Me.txtIdBusqueda.TabIndex = 0
            Me.txtIdBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnGenerar
            '
            Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.btnGenerar.FlatAppearance.BorderSize = 0
            Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGenerar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnGenerar.ForeColor = System.Drawing.Color.White
            Me.btnGenerar.Location = New System.Drawing.Point(13, 171)
            Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(171, 58)
            Me.btnGenerar.TabIndex = 1
            Me.btnGenerar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comprobante"
            Me.btnGenerar.UseVisualStyleBackColor = False
            '
            'btnImprimir
            '
            Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
            Me.btnImprimir.FlatAppearance.BorderSize = 0
            Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnImprimir.ForeColor = System.Drawing.Color.White
            Me.btnImprimir.Location = New System.Drawing.Point(12, 244)
            Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(171, 37)
            Me.btnImprimir.TabIndex = 2
            Me.btnImprimir.Text = "Imprimir"
            Me.btnImprimir.UseVisualStyleBackColor = False
            '
            'btnCerrar
            '
            Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.btnCerrar.FlatAppearance.BorderSize = 0
            Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCerrar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCerrar.ForeColor = System.Drawing.Color.White
            Me.btnCerrar.Location = New System.Drawing.Point(12, 416)
            Me.btnCerrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnCerrar.Name = "btnCerrar"
            Me.btnCerrar.Size = New System.Drawing.Size(171, 32)
            Me.btnCerrar.TabIndex = 3
            Me.btnCerrar.Text = "Cerrar"
            Me.btnCerrar.UseVisualStyleBackColor = False
            '
            'panelCheque
            '
            Me.panelCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.panelCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.panelCheque.Controls.Add(Me.pnlMonto)
            Me.panelCheque.Controls.Add(Me.lblFechaLbl)
            Me.panelCheque.Controls.Add(Me.lblFecha)
            Me.panelCheque.Controls.Add(Me.lblPaguese)
            Me.panelCheque.Controls.Add(Me.lblNombre)
            Me.panelCheque.Controls.Add(Me.lineaNombre)
            Me.panelCheque.Controls.Add(Me.lblCargoLbl)
            Me.panelCheque.Controls.Add(Me.lblCargo)
            Me.panelCheque.Controls.Add(Me.lblValorLetLbl)
            Me.panelCheque.Controls.Add(Me.lblMontoLetras)
            Me.panelCheque.Controls.Add(Me.lineaLetras)
            Me.panelCheque.Controls.Add(Me.lblDetalleLbl)
            Me.panelCheque.Controls.Add(Me.lblSueldoLbl)
            Me.panelCheque.Controls.Add(Me.lblSueldo)
            Me.panelCheque.Controls.Add(Me.lblIGSSLbl)
            Me.panelCheque.Controls.Add(Me.lblIGSS)
            Me.panelCheque.Controls.Add(Me.lblBonoLbl)
            Me.panelCheque.Controls.Add(Me.lblBono)
            Me.panelCheque.Controls.Add(Me.lblOtrosLbl)
            Me.panelCheque.Controls.Add(Me.lblOtros)
            Me.panelCheque.Controls.Add(Me.lineaTotal)
            Me.panelCheque.Controls.Add(Me.lblLineaFirma)
            Me.panelCheque.Controls.Add(Me.lblFirmaLbl)
            Me.panelCheque.Controls.Add(Me.lblAutorizado)
            Me.panelCheque.Location = New System.Drawing.Point(204, 58)
            Me.panelCheque.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.panelCheque.Name = "panelCheque"
            Me.panelCheque.Size = New System.Drawing.Size(765, 344)
            Me.panelCheque.TabIndex = 5
            '
            'pnlMonto
            '
            Me.pnlMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.pnlMonto.Controls.Add(Me.lblValorNumLbl)
            Me.pnlMonto.Controls.Add(Me.lblMontoNumero)
            Me.pnlMonto.Location = New System.Drawing.Point(483, 94)
            Me.pnlMonto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.pnlMonto.Name = "pnlMonto"
            Me.pnlMonto.Size = New System.Drawing.Size(281, 54)
            Me.pnlMonto.TabIndex = 1
            '
            'lblValorNumLbl
            '
            Me.lblValorNumLbl.AutoSize = True
            Me.lblValorNumLbl.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
            Me.lblValorNumLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.lblValorNumLbl.Location = New System.Drawing.Point(-3, 0)
            Me.lblValorNumLbl.Name = "lblValorNumLbl"
            Me.lblValorNumLbl.Size = New System.Drawing.Size(50, 17)
            Me.lblValorNumLbl.TabIndex = 0
            Me.lblValorNumLbl.Text = "VALOR"
            '
            'lblMontoNumero
            '
            Me.lblMontoNumero.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblMontoNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lblMontoNumero.Location = New System.Drawing.Point(0, 17)
            Me.lblMontoNumero.Name = "lblMontoNumero"
            Me.lblMontoNumero.Size = New System.Drawing.Size(281, 40)
            Me.lblMontoNumero.TabIndex = 1
            Me.lblMontoNumero.Text = "Q 0.00"
            Me.lblMontoNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblFechaLbl
            '
            Me.lblFechaLbl.AutoSize = True
            Me.lblFechaLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblFechaLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblFechaLbl.Location = New System.Drawing.Point(479, 62)
            Me.lblFechaLbl.Name = "lblFechaLbl"
            Me.lblFechaLbl.Size = New System.Drawing.Size(53, 20)
            Me.lblFechaLbl.TabIndex = 2
            Me.lblFechaLbl.Text = "Fecha:"
            '
            'lblFecha
            '
            Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lblFecha.Location = New System.Drawing.Point(525, 66)
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Size = New System.Drawing.Size(187, 16)
            Me.lblFecha.TabIndex = 3
            Me.lblFecha.Text = "—"
            '
            'lblPaguese
            '
            Me.lblPaguese.AutoSize = True
            Me.lblPaguese.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblPaguese.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblPaguese.Location = New System.Drawing.Point(12, 94)
            Me.lblPaguese.Name = "lblPaguese"
            Me.lblPaguese.Size = New System.Drawing.Size(165, 20)
            Me.lblPaguese.TabIndex = 4
            Me.lblPaguese.Text = "Páguese a la orden de:"
            '
            'lblNombre
            '
            Me.lblNombre.Font = New System.Drawing.Font("Georgia", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lblNombre.Location = New System.Drawing.Point(12, 112)
            Me.lblNombre.Name = "lblNombre"
            Me.lblNombre.Size = New System.Drawing.Size(427, 25)
            Me.lblNombre.TabIndex = 5
            Me.lblNombre.Text = "—"
            '
            'lineaNombre
            '
            Me.lineaNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lineaNombre.Location = New System.Drawing.Point(12, 139)
            Me.lineaNombre.Name = "lineaNombre"
            Me.lineaNombre.Size = New System.Drawing.Size(427, 2)
            Me.lineaNombre.TabIndex = 10
            '
            'lblCargoLbl
            '
            Me.lblCargoLbl.AutoSize = True
            Me.lblCargoLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblCargoLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lblCargoLbl.Location = New System.Drawing.Point(12, 141)
            Me.lblCargoLbl.Name = "lblCargoLbl"
            Me.lblCargoLbl.Size = New System.Drawing.Size(54, 20)
            Me.lblCargoLbl.TabIndex = 6
            Me.lblCargoLbl.Text = "Cargo:"
            '
            'lblCargo
            '
            Me.lblCargo.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblCargo.Location = New System.Drawing.Point(61, 145)
            Me.lblCargo.Name = "lblCargo"
            Me.lblCargo.Size = New System.Drawing.Size(267, 16)
            Me.lblCargo.TabIndex = 7
            Me.lblCargo.Text = "—"
            '
            'lblValorLetLbl
            '
            Me.lblValorLetLbl.AutoSize = True
            Me.lblValorLetLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblValorLetLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblValorLetLbl.Location = New System.Drawing.Point(11, 162)
            Me.lblValorLetLbl.Name = "lblValorLetLbl"
            Me.lblValorLetLbl.Size = New System.Drawing.Size(139, 20)
            Me.lblValorLetLbl.TabIndex = 8
            Me.lblValorLetLbl.Text = "Cantidad en letras:"
            '
            'lblMontoLetras
            '
            Me.lblMontoLetras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
            Me.lblMontoLetras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lblMontoLetras.Location = New System.Drawing.Point(12, 182)
            Me.lblMontoLetras.Name = "lblMontoLetras"
            Me.lblMontoLetras.Size = New System.Drawing.Size(743, 40)
            Me.lblMontoLetras.TabIndex = 9
            Me.lblMontoLetras.Text = "—"
            '
            'lineaLetras
            '
            Me.lineaLetras.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lineaLetras.Location = New System.Drawing.Point(12, 214)
            Me.lineaLetras.Name = "lineaLetras"
            Me.lineaLetras.Size = New System.Drawing.Size(743, 1)
            Me.lineaLetras.TabIndex = 11
            '
            'lblDetalleLbl
            '
            Me.lblDetalleLbl.AutoSize = True
            Me.lblDetalleLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
            Me.lblDetalleLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.lblDetalleLbl.Location = New System.Drawing.Point(12, 222)
            Me.lblDetalleLbl.Name = "lblDetalleLbl"
            Me.lblDetalleLbl.Size = New System.Drawing.Size(141, 19)
            Me.lblDetalleLbl.TabIndex = 13
            Me.lblDetalleLbl.Text = "DESGLOSE DE PAGO"
            '
            'lblSueldoLbl
            '
            Me.lblSueldoLbl.AutoSize = True
            Me.lblSueldoLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSueldoLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblSueldoLbl.Location = New System.Drawing.Point(12, 238)
            Me.lblSueldoLbl.Name = "lblSueldoLbl"
            Me.lblSueldoLbl.Size = New System.Drawing.Size(93, 20)
            Me.lblSueldoLbl.TabIndex = 14
            Me.lblSueldoLbl.Text = "Sueldo Base:"
            '
            'lblSueldo
            '
            Me.lblSueldo.Font = New System.Drawing.Font("Courier New", 8.5!)
            Me.lblSueldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.lblSueldo.Location = New System.Drawing.Point(183, 241)
            Me.lblSueldo.Name = "lblSueldo"
            Me.lblSueldo.Size = New System.Drawing.Size(116, 16)
            Me.lblSueldo.TabIndex = 15
            Me.lblSueldo.Text = "Q 0.00"
            Me.lblSueldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblIGSSLbl
            '
            Me.lblIGSSLbl.AutoSize = True
            Me.lblIGSSLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblIGSSLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblIGSSLbl.Location = New System.Drawing.Point(12, 260)
            Me.lblIGSSLbl.Name = "lblIGSSLbl"
            Me.lblIGSSLbl.Size = New System.Drawing.Size(115, 20)
            Me.lblIGSSLbl.TabIndex = 16
            Me.lblIGSSLbl.Text = "(-) IGSS (4.83%):"
            '
            'lblIGSS
            '
            Me.lblIGSS.Font = New System.Drawing.Font("Courier New", 8.5!)
            Me.lblIGSS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.lblIGSS.Location = New System.Drawing.Point(187, 262)
            Me.lblIGSS.Name = "lblIGSS"
            Me.lblIGSS.Size = New System.Drawing.Size(112, 18)
            Me.lblIGSS.TabIndex = 17
            Me.lblIGSS.Text = "Q 0.00"
            Me.lblIGSS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBonoLbl
            '
            Me.lblBonoLbl.AutoSize = True
            Me.lblBonoLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblBonoLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblBonoLbl.Location = New System.Drawing.Point(12, 281)
            Me.lblBonoLbl.Name = "lblBonoLbl"
            Me.lblBonoLbl.Size = New System.Drawing.Size(91, 20)
            Me.lblBonoLbl.TabIndex = 18
            Me.lblBonoLbl.Text = "(+) Bono 14:"
            '
            'lblBono
            '
            Me.lblBono.Font = New System.Drawing.Font("Courier New", 8.5!)
            Me.lblBono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.lblBono.Location = New System.Drawing.Point(179, 277)
            Me.lblBono.Name = "lblBono"
            Me.lblBono.Size = New System.Drawing.Size(121, 30)
            Me.lblBono.TabIndex = 19
            Me.lblBono.Text = "Q 0.00"
            Me.lblBono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOtrosLbl
            '
            Me.lblOtrosLbl.AutoSize = True
            Me.lblOtrosLbl.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblOtrosLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblOtrosLbl.Location = New System.Drawing.Point(13, 302)
            Me.lblOtrosLbl.Name = "lblOtrosLbl"
            Me.lblOtrosLbl.Size = New System.Drawing.Size(146, 20)
            Me.lblOtrosLbl.TabIndex = 20
            Me.lblOtrosLbl.Text = "(-) Otros descuentos:"
            '
            'lblOtros
            '
            Me.lblOtros.Font = New System.Drawing.Font("Courier New", 8.5!)
            Me.lblOtros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.lblOtros.Location = New System.Drawing.Point(179, 302)
            Me.lblOtros.Name = "lblOtros"
            Me.lblOtros.Size = New System.Drawing.Size(121, 27)
            Me.lblOtros.TabIndex = 21
            Me.lblOtros.Text = "Q 0.00"
            Me.lblOtros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lineaTotal
            '
            Me.lineaTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lineaTotal.Location = New System.Drawing.Point(13, 321)
            Me.lineaTotal.Name = "lineaTotal"
            Me.lineaTotal.Size = New System.Drawing.Size(284, 7)
            Me.lineaTotal.TabIndex = 12
            '
            'lblLineaFirma
            '
            Me.lblLineaFirma.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.lblLineaFirma.Location = New System.Drawing.Point(516, 313)
            Me.lblLineaFirma.Name = "lblLineaFirma"
            Me.lblLineaFirma.Size = New System.Drawing.Size(231, 2)
            Me.lblLineaFirma.TabIndex = 22
            '
            'lblFirmaLbl
            '
            Me.lblFirmaLbl.AutoSize = True
            Me.lblFirmaLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!)
            Me.lblFirmaLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lblFirmaLbl.Location = New System.Drawing.Point(541, 318)
            Me.lblFirmaLbl.Name = "lblFirmaLbl"
            Me.lblFirmaLbl.Size = New System.Drawing.Size(111, 19)
            Me.lblFirmaLbl.TabIndex = 23
            Me.lblFirmaLbl.Text = "Firma autorizada"
            '
            'lblAutorizado
            '
            Me.lblAutorizado.AutoSize = True
            Me.lblAutorizado.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutorizado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.lblAutorizado.Location = New System.Drawing.Point(299, 274)
            Me.lblAutorizado.Name = "lblAutorizado"
            Me.lblAutorizado.Size = New System.Drawing.Size(202, 57)
            Me.lblAutorizado.TabIndex = 24
            Me.lblAutorizado.Text = "PAGADO"
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.lblBancoNombre)
            Me.pnlHeader.Controls.Add(Me.lblBancoSlogan)
            Me.pnlHeader.Controls.Add(Me.lblNoCheque)
            Me.pnlHeader.Location = New System.Drawing.Point(204, 23)
            Me.pnlHeader.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(764, 57)
            Me.pnlHeader.TabIndex = 0
            '
            'lblBancoNombre
            '
            Me.lblBancoNombre.AutoSize = True
            Me.lblBancoNombre.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblBancoNombre.ForeColor = System.Drawing.Color.White
            Me.lblBancoNombre.Location = New System.Drawing.Point(11, 0)
            Me.lblBancoNombre.Name = "lblBancoNombre"
            Me.lblBancoNombre.Size = New System.Drawing.Size(396, 35)
            Me.lblBancoNombre.TabIndex = 0
            Me.lblBancoNombre.Text = "BANCO PLANILLA UMG"
            '
            'lblBancoSlogan
            '
            Me.lblBancoSlogan.AutoSize = True
            Me.lblBancoSlogan.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
            Me.lblBancoSlogan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.lblBancoSlogan.Location = New System.Drawing.Point(13, 33)
            Me.lblBancoSlogan.Name = "lblBancoSlogan"
            Me.lblBancoSlogan.Size = New System.Drawing.Size(228, 20)
            Me.lblBancoSlogan.TabIndex = 1
            Me.lblBancoSlogan.Text = "Su confianza, nuestro compromiso"
            '
            'lblNoCheque
            '
            Me.lblNoCheque.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblNoCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lblNoCheque.Location = New System.Drawing.Point(604, 18)
            Me.lblNoCheque.Name = "lblNoCheque"
            Me.lblNoCheque.Size = New System.Drawing.Size(151, 22)
            Me.lblNoCheque.TabIndex = 2
            Me.lblNoCheque.Text = "No. 000000"
            Me.lblNoCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlSide
            '
            Me.pnlSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.pnlSide.Controls.Add(Me.Button2)
            Me.pnlSide.Controls.Add(Me.lblSideTitle)
            Me.pnlSide.Controls.Add(Me.lblIdLbl)
            Me.pnlSide.Controls.Add(Me.txtIdBusqueda)
            Me.pnlSide.Controls.Add(Me.btnGenerar)
            Me.pnlSide.Controls.Add(Me.btnImprimir)
            Me.pnlSide.Controls.Add(Me.btnCerrar)
            Me.pnlSide.Location = New System.Drawing.Point(0, 0)
            Me.pnlSide.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.pnlSide.Name = "pnlSide"
            Me.pnlSide.Size = New System.Drawing.Size(196, 464)
            Me.pnlSide.TabIndex = 6
            '
            'Button2
            '
            Me.Button2.BackColor = System.Drawing.Color.Goldenrod
            Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.ForeColor = System.Drawing.Color.White
            Me.Button2.Location = New System.Drawing.Point(12, 300)
            Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(171, 39)
            Me.Button2.TabIndex = 7
            Me.Button2.Text = "Imprimir planila"
            Me.Button2.UseVisualStyleBackColor = False
            '
            'lblSideTitle
            '
            Me.lblSideTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSideTitle.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblSideTitle.Location = New System.Drawing.Point(12, 16)
            Me.lblSideTitle.Name = "lblSideTitle"
            Me.lblSideTitle.Size = New System.Drawing.Size(171, 64)
            Me.lblSideTitle.TabIndex = 0
            Me.lblSideTitle.Text = "COMPROBANTE DE PAGO"
            Me.lblSideTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblIdLbl
            '
            Me.lblIdLbl.AutoSize = True
            Me.lblIdLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblIdLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.lblIdLbl.Location = New System.Drawing.Point(43, 92)
            Me.lblIdLbl.Name = "lblIdLbl"
            Me.lblIdLbl.Size = New System.Drawing.Size(101, 20)
            Me.lblIdLbl.TabIndex = 1
            Me.lblIdLbl.Text = "Ingrese su ID"
            '
            'FormCheque
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(971, 471)
            Me.Controls.Add(Me.pnlHeader)
            Me.Controls.Add(Me.pnlSide)
            Me.Controls.Add(Me.panelCheque)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.Name = "FormCheque"
            Me.Text = "Comprobante de Pago"
            Me.panelCheque.ResumeLayout(False)
            Me.panelCheque.PerformLayout()
            Me.pnlMonto.ResumeLayout(False)
            Me.pnlMonto.PerformLayout()
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlSide.ResumeLayout(False)
            Me.pnlSide.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

        ' ── Declaraciones de campos ──────────────────────────────────────────
        Private WithEvents txtIdBusqueda As System.Windows.Forms.TextBox
        Private WithEvents btnGenerar As System.Windows.Forms.Button
        Private WithEvents btnImprimir As System.Windows.Forms.Button
        Private WithEvents btnCerrar As System.Windows.Forms.Button
        Private WithEvents panelCheque As System.Windows.Forms.Panel
        Private pnlHeader As System.Windows.Forms.Panel
        Private pnlMonto As System.Windows.Forms.Panel
        Private pnlSide As System.Windows.Forms.Panel
        Private WithEvents printDocument1 As System.Drawing.Printing.PrintDocument

        Private lblBancoNombre As System.Windows.Forms.Label
        Private lblBancoSlogan As System.Windows.Forms.Label
        Private lblNoCheque As System.Windows.Forms.Label
        Private lblFechaLbl As System.Windows.Forms.Label
        Private lblFecha As System.Windows.Forms.Label
        Private lblPaguese As System.Windows.Forms.Label
        Private lblNombre As System.Windows.Forms.Label
        Private lblCargoLbl As System.Windows.Forms.Label
        Private lblCargo As System.Windows.Forms.Label
        Private lblValorNumLbl As System.Windows.Forms.Label
        Private WithEvents lblMontoNumero As System.Windows.Forms.Label
        Private lblValorLetLbl As System.Windows.Forms.Label
        Private WithEvents lblMontoLetras As System.Windows.Forms.Label
        Private lblDetalleLbl As System.Windows.Forms.Label
        Private lblSueldoLbl As System.Windows.Forms.Label
        Private lblSueldo As System.Windows.Forms.Label
        Private lblIGSSLbl As System.Windows.Forms.Label
        Private lblIGSS As System.Windows.Forms.Label
        Private lblBonoLbl As System.Windows.Forms.Label
        Private lblBono As System.Windows.Forms.Label
        Private lblOtrosLbl As System.Windows.Forms.Label
        Private WithEvents lblOtros As System.Windows.Forms.Label
        Private lblLineaFirma As System.Windows.Forms.Label
        Private lblFirmaLbl As System.Windows.Forms.Label
        Private WithEvents lblAutorizado As System.Windows.Forms.Label
        Private lineaNombre As System.Windows.Forms.Label
        Private lineaLetras As System.Windows.Forms.Label
        Private lineaTotal As System.Windows.Forms.Label
        Private lblSideTitle As System.Windows.Forms.Label
        Private lblIdLbl As System.Windows.Forms.Label
        Friend WithEvents Button2 As Windows.Forms.Button
    End Class

End Namespace