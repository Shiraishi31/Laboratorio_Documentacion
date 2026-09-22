Option Strict On
Option Explicit On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmpleados
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
        Dim estiloMoneda As New System.Windows.Forms.DataGridViewCellStyle()
        Dim estiloFecha As New System.Windows.Forms.DataGridViewCellStyle()
        Dim estiloCentrado As New System.Windows.Forms.DataGridViewCellStyle()
        Dim estiloEncabezado As New System.Windows.Forms.DataGridViewCellStyle()

        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblApellido = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblSalario = New System.Windows.Forms.Label()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.chkEsGerente = New System.Windows.Forms.CheckBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnDemo = New System.Windows.Forms.Button()
        Me.dgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.colCedula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSalario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSalarioAnual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAntiguedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        Me.lblExplicacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(16, 14)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(420, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Lab_Documentacion_1: Estructura y Datos (List(Of T) + DataGridView)"
        '
        'lblExplicacion
        '
        Me.lblExplicacion.ForeColor = System.Drawing.Color.DimGray
        Me.lblExplicacion.Location = New System.Drawing.Point(18, 42)
        Me.lblExplicacion.Name = "lblExplicacion"
        Me.lblExplicacion.Size = New System.Drawing.Size(960, 34)
        Me.lblExplicacion.TabIndex = 1
        Me.lblExplicacion.Text = "La coleccion generica BindingList(Of Empleado) vive en la clase RepositorioEmpleados (logica de negocio). El formulario solo muestra datos: no valida ni calcula. Los objetos Gerente heredan de Empleado y sobrescriben el salario anual (polimorfismo)."
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblCedula)
        Me.grpDatos.Controls.Add(Me.txtCedula)
        Me.grpDatos.Controls.Add(Me.lblNombre)
        Me.grpDatos.Controls.Add(Me.txtNombre)
        Me.grpDatos.Controls.Add(Me.lblApellido)
        Me.grpDatos.Controls.Add(Me.txtApellido)
        Me.grpDatos.Controls.Add(Me.lblDepartamento)
        Me.grpDatos.Controls.Add(Me.cboDepartamento)
        Me.grpDatos.Controls.Add(Me.lblSalario)
        Me.grpDatos.Controls.Add(Me.txtSalario)
        Me.grpDatos.Controls.Add(Me.lblFechaIngreso)
        Me.grpDatos.Controls.Add(Me.dtpFechaIngreso)
        Me.grpDatos.Controls.Add(Me.chkActivo)
        Me.grpDatos.Controls.Add(Me.chkEsGerente)
        Me.grpDatos.Controls.Add(Me.btnAgregar)
        Me.grpDatos.Controls.Add(Me.btnActualizar)
        Me.grpDatos.Controls.Add(Me.btnEliminar)
        Me.grpDatos.Controls.Add(Me.btnLimpiar)
        Me.grpDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpDatos.Location = New System.Drawing.Point(18, 84)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(320, 448)
        Me.grpDatos.TabIndex = 2
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos del empleado"
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCedula.Location = New System.Drawing.Point(18, 32)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(150, 15)
        Me.lblCedula.TabIndex = 0
        Me.lblCedula.Text = "Cedula (ej. 8-1234-56789)"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(20, 50)
        Me.txtCedula.MaxLength = 14
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(280, 23)
        Me.txtCedula.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNombre.Location = New System.Drawing.Point(18, 80)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(52, 15)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(20, 98)
        Me.txtNombre.MaxLength = 40
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(280, 23)
        Me.txtNombre.TabIndex = 3
        '
        'lblApellido
        '
        Me.lblApellido.AutoSize = True
        Me.lblApellido.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApellido.Location = New System.Drawing.Point(18, 128)
        Me.lblApellido.Name = "lblApellido"
        Me.lblApellido.Size = New System.Drawing.Size(54, 15)
        Me.lblApellido.TabIndex = 4
        Me.lblApellido.Text = "Apellido"
        '
        'txtApellido
        '
        Me.txtApellido.Location = New System.Drawing.Point(20, 146)
        Me.txtApellido.MaxLength = 40
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(280, 23)
        Me.txtApellido.TabIndex = 5
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartamento.Location = New System.Drawing.Point(18, 176)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(190, 15)
        Me.lblDepartamento.TabIndex = 6
        Me.lblDepartamento.Text = "Departamento (lista autorizada)"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Location = New System.Drawing.Point(20, 194)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(280, 23)
        Me.cboDepartamento.TabIndex = 7
        '
        'lblSalario
        '
        Me.lblSalario.AutoSize = True
        Me.lblSalario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSalario.Location = New System.Drawing.Point(18, 224)
        Me.lblSalario.Name = "lblSalario"
        Me.lblSalario.Size = New System.Drawing.Size(120, 15)
        Me.lblSalario.TabIndex = 8
        Me.lblSalario.Text = "Salario mensual (B/.)"
        '
        'txtSalario
        '
        Me.txtSalario.Location = New System.Drawing.Point(20, 242)
        Me.txtSalario.MaxLength = 10
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(280, 23)
        Me.txtSalario.TabIndex = 9
        Me.txtSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFechaIngreso.Location = New System.Drawing.Point(18, 272)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(98, 15)
        Me.lblFechaIngreso.TabIndex = 10
        Me.lblFechaIngreso.Text = "Fecha de ingreso"
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(20, 290)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(280, 23)
        Me.dtpFechaIngreso.TabIndex = 11
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkActivo.Location = New System.Drawing.Point(20, 324)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(120, 19)
        Me.chkActivo.TabIndex = 12
        Me.chkActivo.Text = "Empleado activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'chkEsGerente
        '
        Me.chkEsGerente.AutoSize = True
        Me.chkEsGerente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEsGerente.Location = New System.Drawing.Point(160, 324)
        Me.chkEsGerente.Name = "chkEsGerente"
        Me.chkEsGerente.Size = New System.Drawing.Size(140, 19)
        Me.chkEsGerente.TabIndex = 13
        Me.chkEsGerente.Text = "Es gerente (herencia)"
        Me.chkEsGerente.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(20, 358)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(135, 34)
        Me.btnAgregar.TabIndex = 14
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(165, 358)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(135, 34)
        Me.btnActualizar.TabIndex = 15
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(20, 398)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(135, 34)
        Me.btnEliminar.TabIndex = 16
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(165, 398)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(135, 34)
        Me.btnLimpiar.TabIndex = 17
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(352, 90)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(230, 15)
        Me.lblBuscar.TabIndex = 3
        Me.lblBuscar.Text = "Buscar (nombre, cedula o departamento):"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(588, 87)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(250, 23)
        Me.txtBuscar.TabIndex = 4
        '
        'btnDemo
        '
        Me.btnDemo.Location = New System.Drawing.Point(848, 86)
        Me.btnDemo.Name = "btnDemo"
        Me.btnDemo.Size = New System.Drawing.Size(130, 26)
        Me.btnDemo.TabIndex = 5
        Me.btnDemo.Text = "Cargar datos demo"
        Me.btnDemo.UseVisualStyleBackColor = True
        '
        'dgvEmpleados
        '
        estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        estiloEncabezado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        estiloEncabezado.ForeColor = System.Drawing.Color.White
        Me.dgvEmpleados.AllowUserToAddRows = False
        Me.dgvEmpleados.AllowUserToDeleteRows = False
        Me.dgvEmpleados.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmpleados.ColumnHeadersDefaultCellStyle = estiloEncabezado
        Me.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCedula, Me.colNombre, Me.colRol, Me.colDepartamento, Me.colSalario, Me.colSalarioAnual, Me.colFechaIngreso, Me.colAntiguedad, Me.colActivo})
        Me.dgvEmpleados.EnableHeadersVisualStyles = False
        Me.dgvEmpleados.Location = New System.Drawing.Point(352, 118)
        Me.dgvEmpleados.MultiSelect = False
        Me.dgvEmpleados.Name = "dgvEmpleados"
        Me.dgvEmpleados.ReadOnly = True
        Me.dgvEmpleados.RowHeadersVisible = False
        Me.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleados.Size = New System.Drawing.Size(626, 344)
        Me.dgvEmpleados.TabIndex = 6
        '
        'colCedula
        '
        Me.colCedula.DataPropertyName = "Cedula"
        Me.colCedula.HeaderText = "Cedula"
        Me.colCedula.Name = "colCedula"
        Me.colCedula.ReadOnly = True
        Me.colCedula.Width = 95
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "NombreCompleto"
        Me.colNombre.HeaderText = "Nombre completo"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 135
        '
        'colRol
        '
        Me.colRol.DataPropertyName = "Rol"
        Me.colRol.HeaderText = "Rol"
        Me.colRol.Name = "colRol"
        Me.colRol.ReadOnly = True
        Me.colRol.Width = 70
        '
        'colDepartamento
        '
        Me.colDepartamento.DataPropertyName = "Departamento"
        Me.colDepartamento.HeaderText = "Departamento"
        Me.colDepartamento.Name = "colDepartamento"
        Me.colDepartamento.ReadOnly = True
        Me.colDepartamento.Width = 110
        '
        'colSalario
        '
        estiloMoneda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        estiloMoneda.Format = "C2"
        Me.colSalario.DataPropertyName = "Salario"
        Me.colSalario.DefaultCellStyle = estiloMoneda
        Me.colSalario.HeaderText = "Salario"
        Me.colSalario.Name = "colSalario"
        Me.colSalario.ReadOnly = True
        Me.colSalario.Width = 85
        '
        'colSalarioAnual
        '
        Me.colSalarioAnual.DataPropertyName = "SalarioAnual"
        Me.colSalarioAnual.DefaultCellStyle = estiloMoneda
        Me.colSalarioAnual.HeaderText = "Salario anual"
        Me.colSalarioAnual.Name = "colSalarioAnual"
        Me.colSalarioAnual.ReadOnly = True
        Me.colSalarioAnual.Width = 95
        '
        'colFechaIngreso
        '
        estiloFecha.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        estiloFecha.Format = "dd/MM/yyyy"
        Me.colFechaIngreso.DataPropertyName = "FechaIngreso"
        Me.colFechaIngreso.DefaultCellStyle = estiloFecha
        Me.colFechaIngreso.HeaderText = "Ingreso"
        Me.colFechaIngreso.Name = "colFechaIngreso"
        Me.colFechaIngreso.ReadOnly = True
        Me.colFechaIngreso.Width = 85
        '
        'colAntiguedad
        '
        estiloCentrado.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAntiguedad.DataPropertyName = "AntiguedadAnios"
        Me.colAntiguedad.DefaultCellStyle = estiloCentrado
        Me.colAntiguedad.HeaderText = "Anios"
        Me.colAntiguedad.Name = "colAntiguedad"
        Me.colAntiguedad.ReadOnly = True
        Me.colAntiguedad.Width = 55
        '
        'colActivo
        '
        Me.colActivo.DataPropertyName = "Activo"
        Me.colActivo.HeaderText = "Activo"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.ReadOnly = True
        Me.colActivo.Width = 55
        '
        'lblResumen
        '
        Me.lblResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResumen.Location = New System.Drawing.Point(352, 470)
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Padding = New System.Windows.Forms.Padding(8)
        Me.lblResumen.Size = New System.Drawing.Size(626, 62)
        Me.lblResumen.TabIndex = 7
        Me.lblResumen.Text = "Resumen"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(878, 542)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 30)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'FrmEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(996, 584)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lblResumen)
        Me.Controls.Add(Me.dgvEmpleados)
        Me.Controls.Add(Me.btnDemo)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.lblExplicacion)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmEmpleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab_Documentacion_1 - Estructura y Datos"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblExplicacion As System.Windows.Forms.Label
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblSalario As System.Windows.Forms.Label
    Friend WithEvents txtSalario As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaIngreso As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkEsGerente As System.Windows.Forms.CheckBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnDemo As System.Windows.Forms.Button
    Friend WithEvents dgvEmpleados As System.Windows.Forms.DataGridView
    Friend WithEvents colCedula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepartamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalarioAnual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAntiguedad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button

End Class
