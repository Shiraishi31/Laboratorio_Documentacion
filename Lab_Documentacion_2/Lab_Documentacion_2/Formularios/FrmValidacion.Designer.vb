Option Strict On
Option Explicit On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmValidacion
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
        Me.components = New System.ComponentModel.Container()
        Me.errProveedor = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblExplicacion = New System.Windows.Forms.Label()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblConfirmar = New System.Windows.Forms.Label()
        Me.txtConfirmar = New System.Windows.Forms.TextBox()
        Me.pgbFortaleza = New System.Windows.Forms.ProgressBar()
        Me.lblFortaleza = New System.Windows.Forms.Label()
        Me.chkVerClave = New System.Windows.Forms.CheckBox()
        Me.lblSalario = New System.Windows.Forms.Label()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.grpErrores = New System.Windows.Forms.GroupBox()
        Me.lblTipoError = New System.Windows.Forms.Label()
        Me.cboTipoError = New System.Windows.Forms.ComboBox()
        Me.btnProvocar = New System.Windows.Forms.Button()
        Me.lblInfoError = New System.Windows.Forms.Label()
        Me.lblBitacora = New System.Windows.Forms.Label()
        Me.txtBitacora = New System.Windows.Forms.TextBox()
        Me.lblTeclas = New System.Windows.Forms.Label()
        Me.btnLimpiarBitacora = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.errProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.grpErrores.SuspendLayout()
        Me.SuspendLayout()
        '
        'errProveedor
        '
        Me.errProveedor.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProveedor.ContainerControl = Me
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(16, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(430, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Lab_Documentacion_2: Validacion y Robustez (ErrorProvider + Try-Catch)"
        '
        'lblExplicacion
        '
        Me.lblExplicacion.ForeColor = System.Drawing.Color.DimGray
        Me.lblExplicacion.Location = New System.Drawing.Point(18, 40)
        Me.lblExplicacion.Name = "lblExplicacion"
        Me.lblExplicacion.Size = New System.Drawing.Size(906, 30)
        Me.lblExplicacion.TabIndex = 1
        Me.lblExplicacion.Text = "Tres capas de defensa: (1) el teclado se filtra con KeyPress y las propiedades MaxLength / PasswordChar / ReadOnly; (2) el evento Validating marca los errores con ErrorProvider; (3) todo lo demas se atrapa con Try-Catch-Finally."
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblNombre)
        Me.grpDatos.Controls.Add(Me.txtNombre)
        Me.grpDatos.Controls.Add(Me.lblCedula)
        Me.grpDatos.Controls.Add(Me.txtCedula)
        Me.grpDatos.Controls.Add(Me.lblEdad)
        Me.grpDatos.Controls.Add(Me.txtEdad)
        Me.grpDatos.Controls.Add(Me.lblTelefono)
        Me.grpDatos.Controls.Add(Me.txtTelefono)
        Me.grpDatos.Controls.Add(Me.lblCorreo)
        Me.grpDatos.Controls.Add(Me.txtCorreo)
        Me.grpDatos.Controls.Add(Me.lblClave)
        Me.grpDatos.Controls.Add(Me.txtClave)
        Me.grpDatos.Controls.Add(Me.lblConfirmar)
        Me.grpDatos.Controls.Add(Me.txtConfirmar)
        Me.grpDatos.Controls.Add(Me.pgbFortaleza)
        Me.grpDatos.Controls.Add(Me.lblFortaleza)
        Me.grpDatos.Controls.Add(Me.chkVerClave)
        Me.grpDatos.Controls.Add(Me.lblSalario)
        Me.grpDatos.Controls.Add(Me.txtSalario)
        Me.grpDatos.Controls.Add(Me.lblCodigo)
        Me.grpDatos.Controls.Add(Me.txtCodigo)
        Me.grpDatos.Controls.Add(Me.btnGuardar)
        Me.grpDatos.Controls.Add(Me.btnLimpiar)
        Me.grpDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpDatos.Location = New System.Drawing.Point(18, 74)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(436, 462)
        Me.grpDatos.TabIndex = 2
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Registro de usuario"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNombre.Location = New System.Drawing.Point(16, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(120, 15)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre (solo letras)"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(18, 44)
        Me.txtNombre.MaxLength = 40
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(190, 23)
        Me.txtNombre.TabIndex = 1
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCedula.Location = New System.Drawing.Point(226, 26)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(130, 15)
        Me.lblCedula.TabIndex = 2
        Me.lblCedula.Text = "Cedula (8-1234-56789)"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(228, 44)
        Me.txtCedula.MaxLength = 14
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(190, 23)
        Me.txtCedula.TabIndex = 3
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEdad.Location = New System.Drawing.Point(16, 78)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(140, 15)
        Me.lblEdad.TabIndex = 4
        Me.lblEdad.Text = "Edad (MaxLength = 3)"
        '
        'txtEdad
        '
        Me.txtEdad.Location = New System.Drawing.Point(18, 96)
        Me.txtEdad.MaxLength = 3
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(190, 23)
        Me.txtEdad.TabIndex = 5
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTelefono.Location = New System.Drawing.Point(226, 78)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(140, 15)
        Me.lblTelefono.TabIndex = 6
        Me.lblTelefono.Text = "Telefono (solo digitos)"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(228, 96)
        Me.txtTelefono.MaxLength = 8
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(190, 23)
        Me.txtTelefono.TabIndex = 7
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorreo.Location = New System.Drawing.Point(16, 130)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(230, 15)
        Me.lblCorreo.TabIndex = 8
        Me.lblCorreo.Text = "Correo (validado con expresion regular)"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(18, 148)
        Me.txtCorreo.MaxLength = 60
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(400, 23)
        Me.txtCorreo.TabIndex = 9
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblClave.Location = New System.Drawing.Point(16, 182)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(160, 15)
        Me.lblClave.TabIndex = 10
        Me.lblClave.Text = "Contrasena (PasswordChar)"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(18, 200)
        Me.txtClave.MaxLength = 20
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtClave.Size = New System.Drawing.Size(190, 23)
        Me.txtClave.TabIndex = 11
        '
        'lblConfirmar
        '
        Me.lblConfirmar.AutoSize = True
        Me.lblConfirmar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConfirmar.Location = New System.Drawing.Point(226, 182)
        Me.lblConfirmar.Name = "lblConfirmar"
        Me.lblConfirmar.Size = New System.Drawing.Size(120, 15)
        Me.lblConfirmar.TabIndex = 12
        Me.lblConfirmar.Text = "Confirmar contrasena"
        '
        'txtConfirmar
        '
        Me.txtConfirmar.Location = New System.Drawing.Point(228, 200)
        Me.txtConfirmar.MaxLength = 20
        Me.txtConfirmar.Name = "txtConfirmar"
        Me.txtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirmar.Size = New System.Drawing.Size(190, 23)
        Me.txtConfirmar.TabIndex = 13
        '
        'pgbFortaleza
        '
        Me.pgbFortaleza.Location = New System.Drawing.Point(18, 232)
        Me.pgbFortaleza.Maximum = 5
        Me.pgbFortaleza.Name = "pgbFortaleza"
        Me.pgbFortaleza.Size = New System.Drawing.Size(400, 12)
        Me.pgbFortaleza.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgbFortaleza.TabIndex = 14
        '
        'lblFortaleza
        '
        Me.lblFortaleza.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblFortaleza.ForeColor = System.Drawing.Color.DimGray
        Me.lblFortaleza.Location = New System.Drawing.Point(16, 248)
        Me.lblFortaleza.Name = "lblFortaleza"
        Me.lblFortaleza.Size = New System.Drawing.Size(402, 30)
        Me.lblFortaleza.TabIndex = 15
        Me.lblFortaleza.Text = "Fortaleza de la contrasena"
        '
        'chkVerClave
        '
        Me.chkVerClave.AutoSize = True
        Me.chkVerClave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkVerClave.Location = New System.Drawing.Point(18, 280)
        Me.chkVerClave.Name = "chkVerClave"
        Me.chkVerClave.Size = New System.Drawing.Size(190, 19)
        Me.chkVerClave.TabIndex = 16
        Me.chkVerClave.Text = "Mostrar contrasena"
        Me.chkVerClave.UseVisualStyleBackColor = True
        '
        'lblSalario
        '
        Me.lblSalario.AutoSize = True
        Me.lblSalario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSalario.Location = New System.Drawing.Point(16, 310)
        Me.lblSalario.Name = "lblSalario"
        Me.lblSalario.Size = New System.Drawing.Size(180, 15)
        Me.lblSalario.TabIndex = 17
        Me.lblSalario.Text = "Salario esperado (TryParse)"
        '
        'txtSalario
        '
        Me.txtSalario.Location = New System.Drawing.Point(18, 328)
        Me.txtSalario.MaxLength = 10
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(190, 23)
        Me.txtSalario.TabIndex = 18
        Me.txtSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCodigo.Location = New System.Drawing.Point(226, 310)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(160, 15)
        Me.lblCodigo.TabIndex = 19
        Me.lblCodigo.Text = "Codigo interno (ReadOnly)"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigo.Location = New System.Drawing.Point(228, 328)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(190, 23)
        Me.txtCodigo.TabIndex = 20
        Me.txtCodigo.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(18, 372)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(190, 38)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.Text = "Validar y guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(228, 372)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(190, 38)
        Me.btnLimpiar.TabIndex = 22
        Me.btnLimpiar.Text = "Limpiar formulario"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'grpErrores
        '
        Me.grpErrores.Controls.Add(Me.lblTipoError)
        Me.grpErrores.Controls.Add(Me.cboTipoError)
        Me.grpErrores.Controls.Add(Me.btnProvocar)
        Me.grpErrores.Controls.Add(Me.lblInfoError)
        Me.grpErrores.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpErrores.Location = New System.Drawing.Point(468, 74)
        Me.grpErrores.Name = "grpErrores"
        Me.grpErrores.Size = New System.Drawing.Size(456, 168)
        Me.grpErrores.TabIndex = 3
        Me.grpErrores.TabStop = False
        Me.grpErrores.Text = "Laboratorio de excepciones (Try - Catch - Finally)"
        '
        'lblTipoError
        '
        Me.lblTipoError.AutoSize = True
        Me.lblTipoError.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTipoError.Location = New System.Drawing.Point(16, 28)
        Me.lblTipoError.Name = "lblTipoError"
        Me.lblTipoError.Size = New System.Drawing.Size(200, 15)
        Me.lblTipoError.TabIndex = 0
        Me.lblTipoError.Text = "Tipo de error a provocar:"
        '
        'cboTipoError
        '
        Me.cboTipoError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoError.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboTipoError.FormattingEnabled = True
        Me.cboTipoError.Location = New System.Drawing.Point(18, 46)
        Me.cboTipoError.Name = "cboTipoError"
        Me.cboTipoError.Size = New System.Drawing.Size(290, 23)
        Me.cboTipoError.TabIndex = 1
        '
        'btnProvocar
        '
        Me.btnProvocar.Location = New System.Drawing.Point(318, 45)
        Me.btnProvocar.Name = "btnProvocar"
        Me.btnProvocar.Size = New System.Drawing.Size(120, 26)
        Me.btnProvocar.TabIndex = 2
        Me.btnProvocar.Text = "Ejecutar"
        Me.btnProvocar.UseVisualStyleBackColor = True
        '
        'lblInfoError
        '
        Me.lblInfoError.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblInfoError.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoError.Location = New System.Drawing.Point(16, 80)
        Me.lblInfoError.Name = "lblInfoError"
        Me.lblInfoError.Size = New System.Drawing.Size(424, 76)
        Me.lblInfoError.TabIndex = 3
        Me.lblInfoError.Text = "Cada opcion lanza una excepcion real. El bloque Catch la atrapa por tipo (del mas especifico al mas general) y el bloque Finally se ejecuta siempre, haya error o no. La aplicacion nunca se cierra."
        '
        'lblBitacora
        '
        Me.lblBitacora.AutoSize = True
        Me.lblBitacora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBitacora.Location = New System.Drawing.Point(468, 252)
        Me.lblBitacora.Name = "lblBitacora"
        Me.lblBitacora.Size = New System.Drawing.Size(200, 15)
        Me.lblBitacora.TabIndex = 4
        Me.lblBitacora.Text = "Bitacora de ejecucion"
        '
        'txtBitacora
        '
        Me.txtBitacora.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtBitacora.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtBitacora.ForeColor = System.Drawing.Color.Lime
        Me.txtBitacora.Location = New System.Drawing.Point(468, 272)
        Me.txtBitacora.Multiline = True
        Me.txtBitacora.Name = "txtBitacora"
        Me.txtBitacora.ReadOnly = True
        Me.txtBitacora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBitacora.Size = New System.Drawing.Size(456, 200)
        Me.txtBitacora.TabIndex = 5
        '
        'lblTeclas
        '
        Me.lblTeclas.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblTeclas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTeclas.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTeclas.Location = New System.Drawing.Point(468, 480)
        Me.lblTeclas.Name = "lblTeclas"
        Me.lblTeclas.Padding = New System.Windows.Forms.Padding(6)
        Me.lblTeclas.Size = New System.Drawing.Size(456, 50)
        Me.lblTeclas.TabIndex = 6
        Me.lblTeclas.Text = "Eventos de teclado: escriba en el campo Cedula para ver KeyDown / KeyPress / KeyUp."
        '
        'btnLimpiarBitacora
        '
        Me.btnLimpiarBitacora.Location = New System.Drawing.Point(468, 544)
        Me.btnLimpiarBitacora.Name = "btnLimpiarBitacora"
        Me.btnLimpiarBitacora.Size = New System.Drawing.Size(150, 30)
        Me.btnLimpiarBitacora.TabIndex = 7
        Me.btnLimpiarBitacora.Text = "Limpiar bitacora"
        Me.btnLimpiarBitacora.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(824, 544)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 30)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'FrmValidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 588)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiarBitacora)
        Me.Controls.Add(Me.lblTeclas)
        Me.Controls.Add(Me.txtBitacora)
        Me.Controls.Add(Me.lblBitacora)
        Me.Controls.Add(Me.grpErrores)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.lblExplicacion)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmValidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab_Documentacion_2 - Validacion y Robustez"
        CType(Me.errProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.grpErrores.ResumeLayout(False)
        Me.grpErrores.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents errProveedor As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblExplicacion As System.Windows.Forms.Label
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents txtEdad As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblCorreo As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmar As System.Windows.Forms.Label
    Friend WithEvents txtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents pgbFortaleza As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFortaleza As System.Windows.Forms.Label
    Friend WithEvents chkVerClave As System.Windows.Forms.CheckBox
    Friend WithEvents lblSalario As System.Windows.Forms.Label
    Friend WithEvents txtSalario As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents grpErrores As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoError As System.Windows.Forms.Label
    Friend WithEvents cboTipoError As System.Windows.Forms.ComboBox
    Friend WithEvents btnProvocar As System.Windows.Forms.Button
    Friend WithEvents lblInfoError As System.Windows.Forms.Label
    Friend WithEvents lblBitacora As System.Windows.Forms.Label
    Friend WithEvents txtBitacora As System.Windows.Forms.TextBox
    Friend WithEvents lblTeclas As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarBitacora As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button

End Class
