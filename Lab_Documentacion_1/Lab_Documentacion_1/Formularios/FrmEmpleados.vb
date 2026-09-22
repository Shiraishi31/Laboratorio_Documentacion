Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - ESTRUCTURA Y DATOS
'''
''' Demuestra:
'''  1. Coleccion generica BindingList(Of Empleado) enlazada a un DataGridView
'''     por medio de un BindingSource (enlace a datos, no llenado manual de filas).
'''  2. Clases de modelo orientadas a objetos: Persona (abstracta) -> Empleado -> Gerente.
'''  3. Separacion de responsabilidades: la clase RepositorioEmpleados contiene
'''     la logica de negocio; este formulario solo presenta informacion.
'''  4. Consultas LINQ para el resumen (Sum, Average, GroupBy).
''' </summary>
Public Class FrmEmpleados

    ' Capa de negocio/datos (el formulario NO manipula la lista directamente).
    Private ReadOnly _repositorio As New RepositorioEmpleados()

    ' Intermediario entre la coleccion y el DataGridView.
    Private ReadOnly _origenDatos As New BindingSource()

    ' Evita que el evento SelectionChanged reescriba los cuadros de texto
    ' mientras el codigo esta cargando datos.
    Private _cargando As Boolean = False

    ' =====================================================================
    '  CARGA DEL FORMULARIO
    ' =====================================================================

    Private Sub FrmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' La lista blanca de departamentos la define la clase estatica ReglasNegocio
        Me.cboDepartamento.Items.Clear()
        For Each departamento As String In ReglasNegocio.Departamentos
            Me.cboDepartamento.Items.Add(departamento)
        Next
        If Me.cboDepartamento.Items.Count > 0 Then
            Me.cboDepartamento.SelectedIndex = 0
        End If

        Me.dtpFechaIngreso.MaxDate = Date.Today

        ' ---- ENLACE A DATOS ----
        ' AutoGenerateColumns = False porque las columnas ya estan definidas
        ' en el disenador con su DataPropertyName.
        Me.dgvEmpleados.AutoGenerateColumns = False
        _origenDatos.DataSource = _repositorio.Datos
        Me.dgvEmpleados.DataSource = _origenDatos

        _repositorio.CargarDatosDemo()
        ActualizarResumen()
    End Sub

    ' =====================================================================
    '  BOTONES (CRUD)
    ' =====================================================================

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim nuevo As Empleado = ConstruirDesdeFormulario()

            ' Es el repositorio quien valida: el formulario solo reporta.
            _repositorio.Agregar(nuevo)

            QuitarFiltro()
            SeleccionarPorCedula(nuevo.Cedula)
            LimpiarFormulario()
            ActualizarResumen()

        Catch ex As ExcepcionNegocio
            AvisarReglaDeNegocio(ex)
        Catch ex As Exception
            MessageBox.Show("Error inesperado al agregar: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Dim seleccionado As Empleado = ObtenerSeleccionado()
            If seleccionado Is Nothing Then
                Throw New ExcepcionNegocio("Seleccione primero una fila de la tabla.")
            End If

            Dim indice As Integer = _repositorio.Datos.IndexOf(seleccionado)
            Dim modificado As Empleado = ConstruirDesdeFormulario()

            _repositorio.Actualizar(indice, modificado)

            QuitarFiltro()
            SeleccionarPorCedula(modificado.Cedula)
            ActualizarResumen()

        Catch ex As ExcepcionNegocio
            AvisarReglaDeNegocio(ex)
        Catch ex As Exception
            MessageBox.Show("Error inesperado al actualizar: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim seleccionado As Empleado = ObtenerSeleccionado()
            If seleccionado Is Nothing Then
                Throw New ExcepcionNegocio("Seleccione primero la fila que desea eliminar.")
            End If

            Dim respuesta As DialogResult = MessageBox.Show(
                "Esta seguro de eliminar a " & seleccionado.NombreCompleto & "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then Exit Sub

            _repositorio.Eliminar(_repositorio.Datos.IndexOf(seleccionado))

            QuitarFiltro()
            LimpiarFormulario()
            ActualizarResumen()

        Catch ex As ExcepcionNegocio
            AvisarReglaDeNegocio(ex)
        Catch ex As Exception
            MessageBox.Show("Error inesperado al eliminar: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarFormulario()
    End Sub

    Private Sub btnDemo_Click(sender As Object, e As EventArgs) Handles btnDemo.Click
        Me.txtBuscar.Clear()
        _repositorio.CargarDatosDemo()
        QuitarFiltro()
        ActualizarResumen()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    ' =====================================================================
    '  BUSQUEDA CON LINQ (filtro en vivo)
    ' =====================================================================

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim criterio As String = Me.txtBuscar.Text.Trim()

        If criterio.Length = 0 Then
            _origenDatos.DataSource = _repositorio.Datos
        Else
            Dim encontrados As List(Of Empleado) = _repositorio.Filtrar(criterio)
            _origenDatos.DataSource = New BindingList(Of Empleado)(encontrados)
        End If

        _origenDatos.ResetBindings(False)
        ActualizarResumen()
    End Sub

    Private Sub QuitarFiltro()
        Me.txtBuscar.Text = String.Empty
        _origenDatos.DataSource = _repositorio.Datos
        _origenDatos.ResetBindings(False)
    End Sub

    ' =====================================================================
    '  SELECCION EN LA TABLA
    ' =====================================================================

    Private Sub dgvEmpleados_SelectionChanged(sender As Object, e As EventArgs) _
            Handles dgvEmpleados.SelectionChanged

        If _cargando Then Exit Sub

        Dim seleccionado As Empleado = ObtenerSeleccionado()
        If seleccionado Is Nothing Then Exit Sub

        _cargando = True
        Try
            Me.txtCedula.Text = seleccionado.Cedula
            Me.txtNombre.Text = seleccionado.Nombre
            Me.txtApellido.Text = seleccionado.Apellido
            Me.txtSalario.Text = seleccionado.Salario.ToString("0.00", CultureInfo.CurrentCulture)
            Me.dtpFechaIngreso.Value = seleccionado.FechaIngreso
            Me.chkActivo.Checked = seleccionado.Activo
            Me.chkEsGerente.Checked = (TypeOf seleccionado Is Gerente)

            Dim posicion As Integer = Me.cboDepartamento.Items.IndexOf(seleccionado.Departamento)
            Me.cboDepartamento.SelectedIndex = posicion
        Finally
            _cargando = False
        End Try
    End Sub

    ''' <summary>Devuelve el objeto Empleado de la fila seleccionada (o Nothing).</summary>
    Private Function ObtenerSeleccionado() As Empleado
        If Me.dgvEmpleados.CurrentRow Is Nothing Then Return Nothing
        Return TryCast(Me.dgvEmpleados.CurrentRow.DataBoundItem, Empleado)
    End Function

    Private Sub SeleccionarPorCedula(cedula As String)
        For Each elemento As Object In Me.dgvEmpleados.Rows
            Dim fila As DataGridViewRow = TryCast(elemento, DataGridViewRow)
            If fila Is Nothing Then Continue For

            Dim emp As Empleado = TryCast(fila.DataBoundItem, Empleado)
            If emp IsNot Nothing AndAlso
               String.Equals(emp.Cedula, cedula, StringComparison.OrdinalIgnoreCase) Then

                fila.Selected = True
                Me.dgvEmpleados.CurrentCell = fila.Cells(0)
                Exit For
            End If
        Next
    End Sub

    ' =====================================================================
    '  APOYO
    ' =====================================================================

    ''' <summary>
    ''' Crea el objeto del modelo a partir de los controles.
    ''' Si la casilla "Es gerente" esta marcada se instancia un Gerente:
    ''' misma coleccion, comportamiento distinto (polimorfismo).
    ''' </summary>
    Private Function ConstruirDesdeFormulario() As Empleado

        Dim salario As Decimal = LeerSalario()
        Dim departamento As String = If(Me.cboDepartamento.SelectedItem Is Nothing,
                                        String.Empty,
                                        Me.cboDepartamento.SelectedItem.ToString())

        If Me.chkEsGerente.Checked Then
            Return New Gerente(Me.txtCedula.Text, Me.txtNombre.Text, Me.txtApellido.Text,
                               departamento, salario, Me.dtpFechaIngreso.Value,
                               Me.chkActivo.Checked)
        End If

        Return New Empleado(Me.txtCedula.Text, Me.txtNombre.Text, Me.txtApellido.Text,
                            departamento, salario, Me.dtpFechaIngreso.Value,
                            Me.chkActivo.Checked)
    End Function

    ''' <summary>Convierte el texto del salario usando TryParse (nunca CDec directo).</summary>
    Private Function LeerSalario() As Decimal
        Dim texto As String = Me.txtSalario.Text.Trim().Replace(",", ".")
        Dim valor As Decimal

        If Not Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, valor) Then
            Throw New ExcepcionNegocio("El salario debe ser un numero valido. Ejemplo: 1250.00", "Salario")
        End If

        Return valor
    End Function

    Private Sub LimpiarFormulario()
        Me.txtCedula.Clear()
        Me.txtNombre.Clear()
        Me.txtApellido.Clear()
        Me.txtSalario.Clear()
        Me.chkActivo.Checked = True
        Me.chkEsGerente.Checked = False
        Me.dtpFechaIngreso.Value = Date.Today
        If Me.cboDepartamento.Items.Count > 0 Then
            Me.cboDepartamento.SelectedIndex = 0
        End If
        Me.txtCedula.Focus()
    End Sub

    ''' <summary>Resumen calculado con LINQ dentro del repositorio.</summary>
    Private Sub ActualizarResumen()
        Dim texto As New StringBuilder()

        texto.Append("Registros: ").Append(_repositorio.Cantidad.ToString())
        texto.Append("   |   Activos: ").Append(_repositorio.CantidadActivos().ToString())
        texto.Append("   |   Planilla mensual (activos): ").Append(_repositorio.TotalPlanilla().ToString("C2"))
        texto.Append("   |   Salario promedio: ").Append(_repositorio.PromedioSalario().ToString("C2"))
        texto.AppendLine()

        Dim porDepartamento As Dictionary(Of String, Integer) = _repositorio.ConteoPorDepartamento()
        If porDepartamento.Count > 0 Then
            Dim partes As List(Of String) = porDepartamento.
                OrderBy(Function(par) par.Key).
                Select(Function(par) par.Key & ": " & par.Value.ToString()).
                ToList()

            texto.Append("Por departamento -> ").Append(String.Join("   ", partes))
        End If

        Me.lblResumen.Text = texto.ToString()
    End Sub

    ''' <summary>Mensaje amable cuando se rompe una regla de negocio.</summary>
    Private Sub AvisarReglaDeNegocio(ex As ExcepcionNegocio)
        MessageBox.Show(ex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Select Case ex.Campo
            Case "Cedula" : Me.txtCedula.Focus()
            Case "Nombre" : Me.txtNombre.Focus()
            Case "Apellido" : Me.txtApellido.Focus()
            Case "Departamento" : Me.cboDepartamento.Focus()
            Case "Salario" : Me.txtSalario.Focus()
            Case "FechaIngreso" : Me.dtpFechaIngreso.Focus()
        End Select
    End Sub

    ' =====================================================================
    '  VALIDACION DE TECLADO (refuerzo de la validacion)
    ' =====================================================================

    ''' <summary>Cedula: solo digitos y guiones.</summary>
    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>Nombre y apellido: solo letras y espacio.</summary>
    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) _
            Handles txtNombre.KeyPress, txtApellido.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsLetter(e.KeyChar) AndAlso
           e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>Salario: digitos y un solo separador decimal.</summary>
    Private Sub txtSalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalario.KeyPress
        Dim caja As TextBox = TryCast(sender, TextBox)
        If caja Is Nothing Then Exit Sub

        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Exit Sub

        If e.KeyChar = "."c OrElse e.KeyChar = ","c Then
            If caja.Text.Contains(".") OrElse caja.Text.Contains(",") Then
                e.Handled = True
            End If
            Exit Sub
        End If

        e.Handled = True
    End Sub

End Class
