Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_2 (Escenario 2) - VALIDACION Y ROBUSTEZ
'''
''' Demuestra las tres capas de defensa de una aplicacion de escritorio:
'''
'''  CAPA 1 - Prevencion: propiedades del control (MaxLength, PasswordChar,
'''           ReadOnly) y eventos de teclado (KeyDown, KeyPress, KeyUp) que
'''           impiden que se escriba un caracter invalido.
'''
'''  CAPA 2 - Verificacion: evento Validating + ErrorProvider, que marca el
'''           campo con un icono rojo y un mensaje sin usar MessageBox.
'''
'''  CAPA 3 - Contencion: Try-Catch-Finally con captura por tipo de
'''           excepcion, para que ningun error inesperado cierre el programa.
''' </summary>
Public Class FrmValidacion

    Private _contadorGuardados As Integer = 0

    ' =====================================================================
    '  CARGA
    ' =====================================================================

    Private Sub FrmValidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Permite que Validating marque el error sin secuestrar el foco.
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange

        ' Regla tomada de la clase estatica ValidadorEntradas
        Dim maximoClave As Integer = ValidadorEntradas.LongitudMaximaClave
        Me.txtClave.MaxLength = maximoClave
        Me.txtConfirmar.MaxLength = maximoClave

        ' Campo de solo lectura generado por el sistema
        Me.txtCodigo.Text = "USR-" & Date.Now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture)

        Me.cboTipoError.Items.Clear()
        Me.cboTipoError.Items.Add("1. DivideByZeroException (division entre cero)")
        Me.cboTipoError.Items.Add("2. InvalidCastException (conversion invalida)")
        Me.cboTipoError.Items.Add("3. IndexOutOfRangeException (indice fuera de rango)")
        Me.cboTipoError.Items.Add("4. NullReferenceException (objeto no instanciado)")
        Me.cboTipoError.Items.Add("5. FileNotFoundException (archivo inexistente)")
        Me.cboTipoError.Items.Add("6. OverflowException (desbordamiento)")
        Me.cboTipoError.Items.Add("7. ExcepcionNegocio (excepcion personalizada)")
        Me.cboTipoError.Items.Add("8. Sin error (solo Try y Finally)")
        Me.cboTipoError.SelectedIndex = 0

        Registrar("Formulario iniciado. Longitud maxima de clave = " & maximoClave.ToString() & " caracteres.")
    End Sub

    ' =====================================================================
    '  CAPA 1 - EVENTOS DE TECLADO
    ' =====================================================================

    ''' <summary>Nombre: solo letras, espacio y teclas de control.</summary>
    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsLetter(e.KeyChar) AndAlso
           e.KeyChar <> " "c Then

            e.Handled = True  ' se descarta la tecla: nunca llega al TextBox
            Beep()
        End If
    End Sub

    ''' <summary>Cedula: digitos y guion.</summary>
    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>Edad y telefono: solo digitos.</summary>
    Private Sub SoloDigitos_KeyPress(sender As Object, e As KeyPressEventArgs) _
            Handles txtEdad.KeyPress, txtTelefono.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>Salario: digitos y un unico punto decimal.</summary>
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

    ''' <summary>KeyDown: ocurre ANTES de KeyPress y si conoce las teclas especiales.</summary>
    Private Sub txtCedula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCedula.KeyDown
        Me.lblTeclas.Text = "KeyDown -> tecla: " & e.KeyCode.ToString() &
                            "  |  Shift: " & e.Shift.ToString() &
                            "  |  Ctrl: " & e.Control.ToString()

        ' Ejemplo util: bloquear el pegado con Ctrl+V en un campo critico.
        If e.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
            Registrar("Se bloqueo un intento de pegar (Ctrl+V) en el campo Cedula.")
        End If
    End Sub

    ''' <summary>KeyUp: ocurre al soltar la tecla, cuando el texto YA cambio.</summary>
    Private Sub txtCedula_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCedula.KeyUp
        Me.lblTeclas.Text = Me.lblTeclas.Text & Environment.NewLine &
                            "KeyUp -> el texto ya vale: """ & Me.txtCedula.Text & """"
    End Sub

    ''' <summary>La propiedad PasswordChar se activa o desactiva en caliente.</summary>
    Private Sub chkVerClave_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerClave.CheckedChanged
        Dim caracter As Char = If(Me.chkVerClave.Checked, ControlChars.NullChar, ChrW(9679))
        Me.txtClave.PasswordChar = caracter
        Me.txtConfirmar.PasswordChar = caracter
    End Sub

    ''' <summary>Indicador de fortaleza en tiempo real.</summary>
    Private Sub txtClave_TextChanged(sender As Object, e As EventArgs) Handles txtClave.TextChanged
        Dim detalle As String = String.Empty
        Dim puntos As Integer = ValidadorEntradas.EvaluarFortalezaClave(Me.txtClave.Text, detalle)

        Me.pgbFortaleza.Value = puntos
        Me.lblFortaleza.Text = "Fortaleza: " & puntos.ToString() & " de 5. " & detalle
    End Sub

    ' =====================================================================
    '  CAPA 2 - VALIDATING + ERRORPROVIDER
    ' =====================================================================

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If Not ValidadorEntradas.EsNombreValido(Me.txtNombre.Text) Then
            MarcarError(Me.txtNombre, e, "Escriba un nombre real (solo letras, minimo 3 caracteres).")
        Else
            LimpiarError(Me.txtNombre, e)
        End If
    End Sub

    Private Sub txtCedula_Validating(sender As Object, e As CancelEventArgs) Handles txtCedula.Validating
        If Not ValidadorEntradas.EsCedulaValida(Me.txtCedula.Text) Then
            MarcarError(Me.txtCedula, e, "Formato de cedula invalido. Ejemplo: 8-1234-56789.")
        Else
            LimpiarError(Me.txtCedula, e)
        End If
    End Sub

    Private Sub txtEdad_Validating(sender As Object, e As CancelEventArgs) Handles txtEdad.Validating
        Dim edad As Integer

        ' TryParse: convierte SIN lanzar excepcion (programacion defensiva).
        If Not Integer.TryParse(Me.txtEdad.Text.Trim(), edad) Then
            MarcarError(Me.txtEdad, e, "La edad debe ser un numero entero.")
            Exit Sub
        End If

        If Not ValidadorEntradas.EsEdadValida(edad) Then
            MarcarError(Me.txtEdad, e,
                "La edad debe estar entre " &
                ValidadorEntradas.EdadMinima.ToString() & " y " &
                ValidadorEntradas.EdadMaxima.ToString() & " anios.")
            Exit Sub
        End If

        LimpiarError(Me.txtEdad, e)
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As CancelEventArgs) Handles txtTelefono.Validating
        Dim texto As String = Me.txtTelefono.Text.Trim()
        If texto.Length < 7 Then
            MarcarError(Me.txtTelefono, e, "El telefono debe tener al menos 7 digitos.")
        Else
            LimpiarError(Me.txtTelefono, e)
        End If
    End Sub

    Private Sub txtCorreo_Validating(sender As Object, e As CancelEventArgs) Handles txtCorreo.Validating
        If Not ValidadorEntradas.EsCorreoValido(Me.txtCorreo.Text) Then
            MarcarError(Me.txtCorreo, e, "Correo invalido. Ejemplo: nombre@dominio.com")
        Else
            LimpiarError(Me.txtCorreo, e)
        End If
    End Sub

    Private Sub txtClave_Validating(sender As Object, e As CancelEventArgs) Handles txtClave.Validating
        Dim detalle As String = String.Empty
        Dim puntos As Integer = ValidadorEntradas.EvaluarFortalezaClave(Me.txtClave.Text, detalle)

        If puntos < 4 Then
            MarcarError(Me.txtClave, e, "Contrasena debil. " & detalle)
        Else
            LimpiarError(Me.txtClave, e)
        End If
    End Sub

    Private Sub txtConfirmar_Validating(sender As Object, e As CancelEventArgs) Handles txtConfirmar.Validating
        If Not String.Equals(Me.txtClave.Text, Me.txtConfirmar.Text, StringComparison.Ordinal) Then
            MarcarError(Me.txtConfirmar, e, "Las contrasenas no coinciden.")
        Else
            LimpiarError(Me.txtConfirmar, e)
        End If
    End Sub

    Private Sub txtSalario_Validating(sender As Object, e As CancelEventArgs) Handles txtSalario.Validating
        Dim valor As Decimal
        Dim texto As String = Me.txtSalario.Text.Trim().Replace(",", ".")

        If Not Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, valor) Then
            MarcarError(Me.txtSalario, e, "El salario debe ser numerico. Ejemplo: 1250.00")
            Exit Sub
        End If

        If Not ValidadorEntradas.EsSalarioValido(valor) Then
            MarcarError(Me.txtSalario, e,
                String.Format("El salario debe estar entre {0:C2} y {1:C2}.",
                    ValidadorEntradas.SalarioMinimo,
                    ValidadorEntradas.SalarioMaximo))
            Exit Sub
        End If

        LimpiarError(Me.txtSalario, e)
    End Sub

    ''' <summary>Pone el icono rojo del ErrorProvider y marca el campo como invalido.</summary>
    Private Sub MarcarError(ctrl As Control, e As CancelEventArgs, mensaje As String)
        Me.errProveedor.SetError(ctrl, mensaje)
        ctrl.BackColor = Drawing.Color.FromArgb(255, 235, 235)
        e.Cancel = True   ' con AutoValidate.EnableAllowFocusChange no atrapa el foco
    End Sub

    Private Sub LimpiarError(ctrl As Control, e As CancelEventArgs)
        Me.errProveedor.SetError(ctrl, String.Empty)
        ctrl.BackColor = Drawing.Color.White
        e.Cancel = False
    End Sub

    ' =====================================================================
    '  GUARDAR
    ' =====================================================================

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Registrar("--- Inicio del proceso de guardado ---")

            ' Dispara el evento Validating de TODOS los controles hijos.
            ' Se usa ValidationConstraints.Enabled para que tambien se validen
            ' los controles que estan dentro del GroupBox.
            If Not Me.ValidateChildren(ValidationConstraints.Enabled) Then
                Registrar("VALIDACION FALLIDA: hay campos marcados con el ErrorProvider.")
                MessageBox.Show("Corrija los campos marcados en rojo antes de continuar.",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Ultima comprobacion de negocio: la edad y el salario ya pasaron
            ' por Validating, pero aqui se vuelve a leer con TryParse porque
            ' el codigo que guarda NUNCA debe confiar en la interfaz.
            Dim edad As Integer
            If Not Integer.TryParse(Me.txtEdad.Text.Trim(), edad) Then
                Throw New ExcepcionNegocio("La edad no se pudo interpretar como numero.", "Edad")
            End If

            _contadorGuardados += 1

            Registrar("Registro #" & _contadorGuardados.ToString() & " valido.")
            Registrar("   Nombre  : " & Me.txtNombre.Text.Trim())
            Registrar("   Cedula  : " & Me.txtCedula.Text.Trim())
            Registrar("   Edad    : " & edad.ToString() & " anios")
            Registrar("   Correo  : " & Me.txtCorreo.Text.Trim())
            Registrar("   Codigo  : " & Me.txtCodigo.Text)

            MessageBox.Show("Datos validados y guardados correctamente." & Environment.NewLine &
                            "Ningun campo llego con un valor invalido al codigo de guardado.",
                            "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As ExcepcionNegocio
            Registrar("REGLA DE NEGOCIO: " & ex.Message)
            MessageBox.Show(ex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            Registrar("ERROR INESPERADO: " & ex.GetType().Name & " - " & ex.Message)
            MessageBox.Show("Ocurrio un error inesperado: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Registrar("--- Fin del proceso (bloque Finally: siempre se ejecuta) ---")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.errProveedor.Clear()

        For Each elemento As Object In Me.grpDatos.Controls
            Dim caja As TextBox = TryCast(elemento, TextBox)
            If caja IsNot Nothing AndAlso Not caja.ReadOnly Then
                caja.Clear()
                caja.BackColor = Drawing.Color.White
            End If
        Next

        Me.pgbFortaleza.Value = 0
        Me.lblFortaleza.Text = "Fortaleza de la contrasena"
        Me.txtNombre.Focus()
        Registrar("Formulario limpiado.")
    End Sub

    ' =====================================================================
    '  CAPA 3 - LABORATORIO DE EXCEPCIONES
    ' =====================================================================

    Private Sub btnProvocar_Click(sender As Object, e As EventArgs) Handles btnProvocar.Click

        Dim opcion As Integer = Me.cboTipoError.SelectedIndex
        Registrar("=== TRY: ejecutando la opcion " & (opcion + 1).ToString() & " ===")

        Try
            ProvocarError(opcion)
            Registrar("   El bloque Try termino sin errores.")

        Catch ex As DivideByZeroException
            Registrar("   CATCH DivideByZeroException -> " & ex.Message)

        Catch ex As InvalidCastException
            Registrar("   CATCH InvalidCastException -> " & ex.Message)

        Catch ex As IndexOutOfRangeException
            Registrar("   CATCH IndexOutOfRangeException -> " & ex.Message)

        Catch ex As NullReferenceException
            Registrar("   CATCH NullReferenceException -> " & ex.Message)

        Catch ex As FileNotFoundException
            Registrar("   CATCH FileNotFoundException -> " & ex.Message)

        Catch ex As OverflowException
            Registrar("   CATCH OverflowException -> " & ex.Message)

        Catch ex As ExcepcionNegocio
            Registrar("   CATCH ExcepcionNegocio (personalizada) -> " & ex.Message)

        Catch ex As Exception
            ' Catch general: SIEMPRE va de ultimo, del mas especifico al mas general.
            Registrar("   CATCH Exception (general) -> " & ex.GetType().Name & ": " & ex.Message)

        Finally
            Registrar("   FINALLY: aqui se liberan recursos. Se ejecuta con o sin error.")
            Registrar("")
        End Try
    End Sub

    ''' <summary>Genera intencionalmente cada tipo de excepcion.</summary>
    Private Sub ProvocarError(opcion As Integer)
        Select Case opcion

            Case 0  ' Division entre cero con enteros
                Dim divisor As Integer = 0
                Dim resultado As Integer = 100 \ divisor
                Registrar("   Resultado: " & resultado.ToString())

            Case 1  ' Conversion invalida
                Dim texto As Object = "abc"
                Dim numero As Integer = CInt(texto)
                Registrar("   Numero: " & numero.ToString())

            Case 2  ' Indice fuera de rango
                Dim numeros() As Integer = New Integer() {1, 2, 3}
                Registrar("   Valor: " & numeros(10).ToString())

            Case 3  ' Objeto no instanciado
                Dim lista As List(Of String) = Nothing
                Registrar("   Elementos: " & lista.Count.ToString())

            Case 4  ' Archivo inexistente
                Dim contenido As String = File.ReadAllText("C:\archivo_que_no_existe_12345.txt")
                Registrar("   Contenido: " & contenido)

            Case 5  ' Desbordamiento
                Dim pequeno As Byte = 200
                pequeno = CByte(pequeno + 100)
                Registrar("   Byte: " & pequeno.ToString())

            Case 6  ' Excepcion personalizada del dominio
                Throw New ExcepcionNegocio(
                    "El cliente no tiene saldo suficiente para la operacion.", "Saldo")

            Case Else  ' Sin error
                Registrar("   Operacion exitosa: 100 / 5 = " & (100 \ 5).ToString())

        End Select
    End Sub

    ' =====================================================================
    '  BITACORA
    ' =====================================================================

    Private Sub Registrar(mensaje As String)
        Dim linea As New StringBuilder()

        If mensaje.Length > 0 Then
            linea.Append("[").Append(Date.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)).Append("] ")
        End If
        linea.Append(mensaje)

        Me.txtBitacora.AppendText(linea.ToString() & Environment.NewLine)
    End Sub

    Private Sub btnLimpiarBitacora_Click(sender As Object, e As EventArgs) Handles btnLimpiarBitacora.Click
        Me.txtBitacora.Clear()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class
