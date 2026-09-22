Option Strict On
Option Explicit On

Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_3 (Escenario 3) - CALIDAD Y SEGURIDAD / MANTENIMIENTO
'''
''' Demuestra:
'''  1. Lectura externa de parametros desde config.xml (clase estatica
'''     ConfiguracionManager con LINQ to XML y cache en Dictionary).
'''  2. Clase estatica de utilidades ValidadorSeguro: validacion por
'''     expresiones regulares, lista blanca, saneamiento de entradas y
'''     hashing SHA-256 con salt.
'''  3. Manejo de propiedades de control como mecanismo de seguridad:
'''     ReadOnly, MaxLength y PasswordChar.
'''
''' Atributos de calidad (ISO/IEC 25010) que se ven aqui:
'''  Portabilidad, Mantenibilidad, Seguridad y Confiabilidad.
''' </summary>
Public Class FrmSeguridad

    ' "Base de datos" simulada de un usuario registrado.
    Private _usuarioGuardado As String = String.Empty
    Private _saltGuardado As String = String.Empty
    Private _hashGuardado As String = String.Empty

    Private _intentosFallidos As Integer = 0
    Private _bloqueado As Boolean = False

    ' =====================================================================
    '  CARGA
    ' =====================================================================

    Private Sub FrmSeguridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvConfig.AutoGenerateColumns = False

        ' La longitud maxima del campo tambien sale del archivo externo.
        Me.txtClaveSeg.MaxLength = ConfiguracionManager.ObtenerEntero("LongitudMaximaClave", 20)

        MostrarConfiguracion()
        ActualizarEtiquetaIntentos()
    End Sub

    Private Sub MostrarConfiguracion()
        Me.dgvConfig.DataSource = Nothing
        Me.dgvConfig.DataSource = ConfiguracionManager.ObtenerTodos()

        If ConfiguracionManager.UsandoValoresPorDefecto Then
            Me.lblRutaConfig.BackColor = Drawing.Color.FromArgb(255, 244, 205)
            Me.lblRutaConfig.Text = "No se leyo el archivo; se usan valores por defecto. " &
                                    ConfiguracionManager.UltimoError
        Else
            Me.lblRutaConfig.BackColor = Drawing.Color.FromArgb(222, 247, 222)
            Me.lblRutaConfig.Text = "Archivo cargado: " & ConfiguracionManager.RutaArchivo
        End If
    End Sub

    ''' <summary>
    ''' Vuelve a leer el XML sin cerrar la aplicacion: se puede cambiar una
    ''' regla de negocio en caliente, sin recompilar (Mantenibilidad).
    ''' </summary>
    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        Try
            ConfiguracionManager.Recargar()
            MostrarConfiguracion()
            ActualizarEtiquetaIntentos()
            Me.txtClaveSeg.MaxLength = ConfiguracionManager.ObtenerEntero("LongitudMaximaClave", 20)

            MessageBox.Show("Configuracion recargada. Los nuevos valores ya estan activos.",
                            "config.xml", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No se pudo recargar la configuracion: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =====================================================================
    '  VALIDACION SEGURA DE ENTRADAS
    ' =====================================================================

    Private Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        Dim entrada As String = Me.txtEntrada.Text

        If String.IsNullOrWhiteSpace(entrada) Then
            Me.lblResultado.BackColor = Drawing.Color.FromArgb(255, 244, 205)
            Me.lblResultado.Text = "Escriba algo para analizar."
            Me.txtSanitizado.Clear()
            Exit Sub
        End If

        Dim motivo As String = String.Empty
        Dim segura As Boolean = ValidadorSeguro.EsEntradaSegura(entrada, motivo)

        ' El texto saneado se muestra siempre, para comparar.
        Me.txtSanitizado.Text = ValidadorSeguro.Sanitizar(entrada)

        If segura Then
            Me.lblResultado.BackColor = Drawing.Color.FromArgb(222, 247, 222)
            Me.lblResultado.Text = "ENTRADA ACEPTADA: no se detectaron patrones de inyeccion." &
                                   Environment.NewLine &
                                   "Aun asi, en una consulta real se usarian parametros " &
                                   "(cmd.Parameters.AddWithValue), nunca concatenacion."
        Else
            Me.lblResultado.BackColor = Drawing.Color.FromArgb(255, 226, 226)
            Me.lblResultado.Text = "ENTRADA RECHAZADA." & Environment.NewLine & motivo
        End If
    End Sub

    ' =====================================================================
    '  MANEJO SEGURO DE CREDENCIALES
    ' =====================================================================

    Private Sub btnHash_Click(sender As Object, e As EventArgs) Handles btnHash.Click
        Try
            Dim usuario As String = Me.txtUsuario.Text.Trim()
            Dim clave As String = Me.txtClaveSeg.Text

            If usuario.Length < 3 Then
                Throw New ExcepcionNegocio("El usuario debe tener al menos 3 caracteres.")
            End If

            Dim motivo As String = String.Empty
            If Not ValidadorSeguro.EsEntradaSegura(usuario, motivo) Then
                Throw New ExcepcionNegocio(motivo)
            End If

            Dim detalle As String = String.Empty
            Dim puntos As Integer = ValidadorSeguro.EvaluarFortalezaClave(clave, detalle)
            If puntos < 4 Then
                Throw New ExcepcionNegocio("Contrasena demasiado debil. " & detalle)
            End If

            ' Se guarda SOLO el hash y el salt: la clave original se descarta.
            _usuarioGuardado = usuario
            _saltGuardado = ValidadorSeguro.GenerarSalt()
            _hashGuardado = ValidadorSeguro.HashConSalt(clave, _saltGuardado)

            Me.txtSalt.Text = _saltGuardado
            Me.txtHash.Text = _hashGuardado

            _intentosFallidos = 0
            _bloqueado = False
            ActualizarEtiquetaIntentos()

            Me.txtClaveSeg.Clear()

            MessageBox.Show("Usuario registrado." & Environment.NewLine &
                            "En la 'base de datos' quedo guardado el hash, no la contrasena." &
                            Environment.NewLine & Environment.NewLine &
                            "Ahora escriba la contrasena de nuevo y pulse 'Verificar acceso'.",
                            "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As ExcepcionNegocio
            MessageBox.Show(ex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al generar el hash: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Try
            If _hashGuardado.Length = 0 Then
                Throw New ExcepcionNegocio("Primero debe registrar un usuario con el boton 'Registrar'.")
            End If

            If _bloqueado Then
                Throw New ExcepcionNegocio("La cuenta esta bloqueada por exceso de intentos fallidos.")
            End If

            Dim usuario As String = Me.txtUsuario.Text.Trim()
            Dim intento As String = ValidadorSeguro.HashConSalt(Me.txtClaveSeg.Text, _saltGuardado)

            Dim usuarioCorrecto As Boolean =
                String.Equals(usuario, _usuarioGuardado, StringComparison.OrdinalIgnoreCase)

            ' Comparacion en tiempo constante (no se usa el operador =).
            If usuarioCorrecto AndAlso ValidadorSeguro.HashCoincide(intento, _hashGuardado) Then
                _intentosFallidos = 0
                ActualizarEtiquetaIntentos()
                MessageBox.Show("Acceso concedido. El hash calculado coincide con el almacenado.",
                                "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                _intentosFallidos += 1

                Dim maximo As Integer = ConfiguracionManager.ObtenerEntero("MaximoIntentos", 3)
                If _intentosFallidos >= maximo Then
                    _bloqueado = True
                End If

                ActualizarEtiquetaIntentos()

                ' Mensaje generico a proposito: no se revela si fallo el
                ' usuario o la contrasena (buena practica de seguridad).
                MessageBox.Show("Usuario o contrasena incorrectos.",
                                "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As ExcepcionNegocio
            MessageBox.Show(ex.Message, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al verificar: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarEtiquetaIntentos()
        Dim maximo As Integer = ConfiguracionManager.ObtenerEntero("MaximoIntentos", 3)

        If _bloqueado Then
            Me.lblIntentos.ForeColor = Drawing.Color.Firebrick
            Me.lblIntentos.Text = "CUENTA BLOQUEADA: se alcanzaron los " & maximo.ToString() &
                                  " intentos permitidos (parametro MaximoIntentos de config.xml)."
        Else
            Me.lblIntentos.ForeColor = Drawing.Color.DimGray
            Me.lblIntentos.Text = "Intentos fallidos: " & _intentosFallidos.ToString() &
                                  " de " & maximo.ToString() & " (parametro MaximoIntentos de config.xml)."
        End If
    End Sub

    ''' <summary>El usuario no admite caracteres raros: se filtran desde el teclado.</summary>
    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsLetterOrDigit(e.KeyChar) AndAlso
           e.KeyChar <> "."c AndAlso e.KeyChar <> "_"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class
