Option Strict On
Option Explicit On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSeguridad
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim estiloEncabezado As New System.Windows.Forms.DataGridViewCellStyle()

        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblExplicacion = New System.Windows.Forms.Label()
        Me.grpConfig = New System.Windows.Forms.GroupBox()
        Me.dgvConfig = New System.Windows.Forms.DataGridView()
        Me.colSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRecargar = New System.Windows.Forms.Button()
        Me.lblRutaConfig = New System.Windows.Forms.Label()
        Me.grpEntrada = New System.Windows.Forms.GroupBox()
        Me.lblEntrada = New System.Windows.Forms.Label()
        Me.txtEntrada = New System.Windows.Forms.TextBox()
        Me.btnValidar = New System.Windows.Forms.Button()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.lblTituloSanitizado = New System.Windows.Forms.Label()
        Me.txtSanitizado = New System.Windows.Forms.TextBox()
        Me.lblEjemplos = New System.Windows.Forms.Label()
        Me.grpClaves = New System.Windows.Forms.GroupBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblClaveSeg = New System.Windows.Forms.Label()
        Me.txtClaveSeg = New System.Windows.Forms.TextBox()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.lblTituloSalt = New System.Windows.Forms.Label()
        Me.txtSalt = New System.Windows.Forms.TextBox()
        Me.lblTituloHash = New System.Windows.Forms.Label()
        Me.txtHash = New System.Windows.Forms.TextBox()
        Me.lblIntentos = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpConfig.SuspendLayout()
        CType(Me.dgvConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEntrada.SuspendLayout()
        Me.grpClaves.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(16, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(500, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Lab_Documentacion_3: Calidad y Seguridad (config.xml + clases estaticas)"
        '
        'lblExplicacion
        '
        Me.lblExplicacion.ForeColor = System.Drawing.Color.DimGray
        Me.lblExplicacion.Location = New System.Drawing.Point(18, 40)
        Me.lblExplicacion.Name = "lblExplicacion"
        Me.lblExplicacion.Size = New System.Drawing.Size(966, 30)
        Me.lblExplicacion.TabIndex = 1
        Me.lblExplicacion.Text = "Ningun parametro esta quemado en el codigo: todos se leen del archivo externo config.xml mediante la clase estatica ConfiguracionManager. La clase estatica ValidadorSeguro concentra las validaciones, el saneamiento de entradas y el hashing SHA-256."
        '
        'grpConfig
        '
        Me.grpConfig.Controls.Add(Me.dgvConfig)
        Me.grpConfig.Controls.Add(Me.btnRecargar)
        Me.grpConfig.Controls.Add(Me.lblRutaConfig)
        Me.grpConfig.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpConfig.Location = New System.Drawing.Point(18, 74)
        Me.grpConfig.Name = "grpConfig"
        Me.grpConfig.Size = New System.Drawing.Size(470, 512)
        Me.grpConfig.TabIndex = 2
        Me.grpConfig.TabStop = False
        Me.grpConfig.Text = "Parametros leidos del archivo externo config.xml"
        '
        'dgvConfig
        '
        estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        estiloEncabezado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        estiloEncabezado.ForeColor = System.Drawing.Color.White
        Me.dgvConfig.AllowUserToAddRows = False
        Me.dgvConfig.AllowUserToDeleteRows = False
        Me.dgvConfig.BackgroundColor = System.Drawing.Color.White
        Me.dgvConfig.ColumnHeadersDefaultCellStyle = estiloEncabezado
        Me.dgvConfig.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSeccion, Me.colClave, Me.colValor})
        Me.dgvConfig.EnableHeadersVisualStyles = False
        Me.dgvConfig.Location = New System.Drawing.Point(16, 28)
        Me.dgvConfig.MultiSelect = False
        Me.dgvConfig.Name = "dgvConfig"
        Me.dgvConfig.ReadOnly = True
        Me.dgvConfig.RowHeadersVisible = False
        Me.dgvConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConfig.Size = New System.Drawing.Size(438, 396)
        Me.dgvConfig.TabIndex = 0
        '
        'colSeccion
        '
        Me.colSeccion.DataPropertyName = "Seccion"
        Me.colSeccion.HeaderText = "Seccion"
        Me.colSeccion.Name = "colSeccion"
        Me.colSeccion.ReadOnly = True
        Me.colSeccion.Width = 100
        '
        'colClave
        '
        Me.colClave.DataPropertyName = "Clave"
        Me.colClave.HeaderText = "Clave"
        Me.colClave.Name = "colClave"
        Me.colClave.ReadOnly = True
        Me.colClave.Width = 140
        '
        'colValor
        '
        Me.colValor.DataPropertyName = "Valor"
        Me.colValor.HeaderText = "Valor"
        Me.colValor.Name = "colValor"
        Me.colValor.ReadOnly = True
        Me.colValor.Width = 190
        '
        'btnRecargar
        '
        Me.btnRecargar.Location = New System.Drawing.Point(16, 432)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(200, 32)
        Me.btnRecargar.TabIndex = 1
        Me.btnRecargar.Text = "Recargar config.xml"
        Me.btnRecargar.UseVisualStyleBackColor = True
        '
        'lblRutaConfig
        '
        Me.lblRutaConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRutaConfig.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblRutaConfig.Location = New System.Drawing.Point(16, 470)
        Me.lblRutaConfig.Name = "lblRutaConfig"
        Me.lblRutaConfig.Padding = New System.Windows.Forms.Padding(6)
        Me.lblRutaConfig.Size = New System.Drawing.Size(438, 34)
        Me.lblRutaConfig.TabIndex = 2
        Me.lblRutaConfig.Text = "Ruta del archivo"
        '
        'grpEntrada
        '
        Me.grpEntrada.Controls.Add(Me.lblEntrada)
        Me.grpEntrada.Controls.Add(Me.txtEntrada)
        Me.grpEntrada.Controls.Add(Me.btnValidar)
        Me.grpEntrada.Controls.Add(Me.lblResultado)
        Me.grpEntrada.Controls.Add(Me.lblTituloSanitizado)
        Me.grpEntrada.Controls.Add(Me.txtSanitizado)
        Me.grpEntrada.Controls.Add(Me.lblEjemplos)
        Me.grpEntrada.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpEntrada.Location = New System.Drawing.Point(504, 74)
        Me.grpEntrada.Name = "grpEntrada"
        Me.grpEntrada.Size = New System.Drawing.Size(480, 236)
        Me.grpEntrada.TabIndex = 3
        Me.grpEntrada.TabStop = False
        Me.grpEntrada.Text = "Validacion segura de entradas (prevencion de inyeccion)"
        '
        'lblEntrada
        '
        Me.lblEntrada.AutoSize = True
        Me.lblEntrada.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEntrada.Location = New System.Drawing.Point(16, 26)
        Me.lblEntrada.Name = "lblEntrada"
        Me.lblEntrada.Size = New System.Drawing.Size(200, 15)
        Me.lblEntrada.TabIndex = 0
        Me.lblEntrada.Text = "Texto a analizar:"
        '
        'txtEntrada
        '
        Me.txtEntrada.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEntrada.Location = New System.Drawing.Point(16, 44)
        Me.txtEntrada.MaxLength = 120
        Me.txtEntrada.Name = "txtEntrada"
        Me.txtEntrada.Size = New System.Drawing.Size(310, 23)
        Me.txtEntrada.TabIndex = 1
        '
        'btnValidar
        '
        Me.btnValidar.Location = New System.Drawing.Point(336, 43)
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Size = New System.Drawing.Size(128, 26)
        Me.btnValidar.TabIndex = 2
        Me.btnValidar.Text = "Analizar"
        Me.btnValidar.UseVisualStyleBackColor = True
        '
        'lblResultado
        '
        Me.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResultado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblResultado.Location = New System.Drawing.Point(16, 78)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Padding = New System.Windows.Forms.Padding(6)
        Me.lblResultado.Size = New System.Drawing.Size(448, 48)
        Me.lblResultado.TabIndex = 3
        Me.lblResultado.Text = "Resultado del analisis"
        '
        'lblTituloSanitizado
        '
        Me.lblTituloSanitizado.AutoSize = True
        Me.lblTituloSanitizado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTituloSanitizado.Location = New System.Drawing.Point(16, 134)
        Me.lblTituloSanitizado.Name = "lblTituloSanitizado"
        Me.lblTituloSanitizado.Size = New System.Drawing.Size(240, 15)
        Me.lblTituloSanitizado.TabIndex = 4
        Me.lblTituloSanitizado.Text = "Texto saneado (ReadOnly):"
        '
        'txtSanitizado
        '
        Me.txtSanitizado.BackColor = System.Drawing.Color.Gainsboro
        Me.txtSanitizado.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtSanitizado.Location = New System.Drawing.Point(16, 152)
        Me.txtSanitizado.Name = "txtSanitizado"
        Me.txtSanitizado.ReadOnly = True
        Me.txtSanitizado.Size = New System.Drawing.Size(448, 22)
        Me.txtSanitizado.TabIndex = 5
        Me.txtSanitizado.TabStop = False
        '
        'lblEjemplos
        '
        Me.lblEjemplos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblEjemplos.ForeColor = System.Drawing.Color.DimGray
        Me.lblEjemplos.Location = New System.Drawing.Point(16, 180)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(448, 48)
        Me.lblEjemplos.TabIndex = 6
        Me.lblEjemplos.Text = "Pruebe con: admin' OR 1=1 --   |   Robert'); DROP TABLE alumnos;--   |   <script>alert(1)</script>"
        '
        'grpClaves
        '
        Me.grpClaves.Controls.Add(Me.lblUsuario)
        Me.grpClaves.Controls.Add(Me.txtUsuario)
        Me.grpClaves.Controls.Add(Me.lblClaveSeg)
        Me.grpClaves.Controls.Add(Me.txtClaveSeg)
        Me.grpClaves.Controls.Add(Me.btnHash)
        Me.grpClaves.Controls.Add(Me.btnVerificar)
        Me.grpClaves.Controls.Add(Me.lblTituloSalt)
        Me.grpClaves.Controls.Add(Me.txtSalt)
        Me.grpClaves.Controls.Add(Me.lblTituloHash)
        Me.grpClaves.Controls.Add(Me.txtHash)
        Me.grpClaves.Controls.Add(Me.lblIntentos)
        Me.grpClaves.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpClaves.Location = New System.Drawing.Point(504, 322)
        Me.grpClaves.Name = "grpClaves"
        Me.grpClaves.Size = New System.Drawing.Size(480, 264)
        Me.grpClaves.TabIndex = 4
        Me.grpClaves.TabStop = False
        Me.grpClaves.Text = "Manejo seguro de credenciales (SHA-256 + salt)"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUsuario.Location = New System.Drawing.Point(16, 26)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(60, 15)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(16, 44)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(200, 23)
        Me.txtUsuario.TabIndex = 1
        '
        'lblClaveSeg
        '
        Me.lblClaveSeg.AutoSize = True
        Me.lblClaveSeg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblClaveSeg.Location = New System.Drawing.Point(226, 26)
        Me.lblClaveSeg.Name = "lblClaveSeg"
        Me.lblClaveSeg.Size = New System.Drawing.Size(80, 15)
        Me.lblClaveSeg.TabIndex = 2
        Me.lblClaveSeg.Text = "Contrasena"
        '
        'txtClaveSeg
        '
        Me.txtClaveSeg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtClaveSeg.Location = New System.Drawing.Point(226, 44)
        Me.txtClaveSeg.MaxLength = 20
        Me.txtClaveSeg.Name = "txtClaveSeg"
        Me.txtClaveSeg.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtClaveSeg.Size = New System.Drawing.Size(238, 23)
        Me.txtClaveSeg.TabIndex = 3
        '
        'btnHash
        '
        Me.btnHash.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnHash.ForeColor = System.Drawing.Color.White
        Me.btnHash.Location = New System.Drawing.Point(16, 76)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(200, 32)
        Me.btnHash.TabIndex = 4
        Me.btnHash.Text = "Registrar (guardar hash)"
        Me.btnHash.UseVisualStyleBackColor = False
        '
        'btnVerificar
        '
        Me.btnVerificar.Location = New System.Drawing.Point(226, 76)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(238, 32)
        Me.btnVerificar.TabIndex = 5
        Me.btnVerificar.Text = "Verificar acceso"
        Me.btnVerificar.UseVisualStyleBackColor = True
        '
        'lblTituloSalt
        '
        Me.lblTituloSalt.AutoSize = True
        Me.lblTituloSalt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTituloSalt.Location = New System.Drawing.Point(16, 116)
        Me.lblTituloSalt.Name = "lblTituloSalt"
        Me.lblTituloSalt.Size = New System.Drawing.Size(180, 15)
        Me.lblTituloSalt.TabIndex = 6
        Me.lblTituloSalt.Text = "Salt generado (aleatorio)"
        '
        'txtSalt
        '
        Me.txtSalt.BackColor = System.Drawing.Color.Gainsboro
        Me.txtSalt.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtSalt.Location = New System.Drawing.Point(16, 134)
        Me.txtSalt.Name = "txtSalt"
        Me.txtSalt.ReadOnly = True
        Me.txtSalt.Size = New System.Drawing.Size(448, 22)
        Me.txtSalt.TabIndex = 7
        Me.txtSalt.TabStop = False
        '
        'lblTituloHash
        '
        Me.lblTituloHash.AutoSize = True
        Me.lblTituloHash.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTituloHash.Location = New System.Drawing.Point(16, 162)
        Me.lblTituloHash.Name = "lblTituloHash"
        Me.lblTituloHash.Size = New System.Drawing.Size(260, 15)
        Me.lblTituloHash.TabIndex = 8
        Me.lblTituloHash.Text = "Hash almacenado (nunca la clave real)"
        '
        'txtHash
        '
        Me.txtHash.BackColor = System.Drawing.Color.Gainsboro
        Me.txtHash.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtHash.Location = New System.Drawing.Point(16, 180)
        Me.txtHash.Multiline = True
        Me.txtHash.Name = "txtHash"
        Me.txtHash.ReadOnly = True
        Me.txtHash.Size = New System.Drawing.Size(448, 42)
        Me.txtHash.TabIndex = 9
        Me.txtHash.TabStop = False
        '
        'lblIntentos
        '
        Me.lblIntentos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblIntentos.ForeColor = System.Drawing.Color.DimGray
        Me.lblIntentos.Location = New System.Drawing.Point(16, 228)
        Me.lblIntentos.Name = "lblIntentos"
        Me.lblIntentos.Size = New System.Drawing.Size(448, 28)
        Me.lblIntentos.TabIndex = 10
        Me.lblIntentos.Text = "Intentos de acceso"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(884, 596)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 30)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'FrmSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1002, 640)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.grpClaves)
        Me.Controls.Add(Me.grpEntrada)
        Me.Controls.Add(Me.grpConfig)
        Me.Controls.Add(Me.lblExplicacion)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmSeguridad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab_Documentacion_3 - Calidad y Seguridad"
        Me.grpConfig.ResumeLayout(False)
        CType(Me.dgvConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEntrada.ResumeLayout(False)
        Me.grpEntrada.PerformLayout()
        Me.grpClaves.ResumeLayout(False)
        Me.grpClaves.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblExplicacion As System.Windows.Forms.Label
    Friend WithEvents grpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents dgvConfig As System.Windows.Forms.DataGridView
    Friend WithEvents colSeccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRecargar As System.Windows.Forms.Button
    Friend WithEvents lblRutaConfig As System.Windows.Forms.Label
    Friend WithEvents grpEntrada As System.Windows.Forms.GroupBox
    Friend WithEvents lblEntrada As System.Windows.Forms.Label
    Friend WithEvents txtEntrada As System.Windows.Forms.TextBox
    Friend WithEvents btnValidar As System.Windows.Forms.Button
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents lblTituloSanitizado As System.Windows.Forms.Label
    Friend WithEvents txtSanitizado As System.Windows.Forms.TextBox
    Friend WithEvents lblEjemplos As System.Windows.Forms.Label
    Friend WithEvents grpClaves As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblClaveSeg As System.Windows.Forms.Label
    Friend WithEvents txtClaveSeg As System.Windows.Forms.TextBox
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents lblTituloSalt As System.Windows.Forms.Label
    Friend WithEvents txtSalt As System.Windows.Forms.TextBox
    Friend WithEvents lblTituloHash As System.Windows.Forms.Label
    Friend WithEvents txtHash As System.Windows.Forms.TextBox
    Friend WithEvents lblIntentos As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button

End Class
