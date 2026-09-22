Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' LAB_DOCUMENTACION_3 (Escenario 3) - Clase ESTATICA de utilidades de validacion y seguridad.
'''
''' Centraliza TODAS las reglas de validacion del sistema. Ningun formulario
''' escribe su propia expresion regular: todos preguntan aqui, y esta clase
''' a su vez lee los patrones desde config.xml. Esto evita duplicar logica
''' (alta cohesion, bajo acoplamiento) y facilita el mantenimiento.
'''
''' Cubre tres riesgos del OWASP Top 10 aplicados a C#/VB.NET:
'''  - Inyeccion (SQL / script)  -> lista negra + saneamiento + lista blanca.
'''  - Exposicion de datos       -> hashing SHA-256 con salt, nunca texto plano.
'''  - Validacion de entradas    -> expresiones regulares y rangos.
''' </summary>
Public NotInheritable Class ValidadorSeguro

    Private Sub New()
    End Sub

    ' Cache de expresiones regulares ya compiladas (rendimiento).
    Private Shared ReadOnly _cacheRegex As New Dictionary(Of String, Regex)(StringComparer.Ordinal)

    Private Shared Function ObtenerRegex(patron As String) As Regex
        Dim expresion As Regex = Nothing
        If Not _cacheRegex.TryGetValue(patron, expresion) Then
            expresion = New Regex(patron, RegexOptions.Compiled Or RegexOptions.CultureInvariant)
            _cacheRegex(patron) = expresion
        End If
        Return expresion
    End Function

    ' =====================================================================
    '  VALIDACIONES DE FORMATO (patrones tomados de config.xml)
    ' =====================================================================

    Public Shared Function EsNombreValido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Dim patron As String = ConfiguracionManager.ObtenerTexto(
            "PatronNombre", "^[\p{L} ]{3,40}$")
        Return ObtenerRegex(patron).IsMatch(texto.Trim())
    End Function

    Public Shared Function EsCorreoValido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Dim patron As String = ConfiguracionManager.ObtenerTexto(
            "PatronCorreo", "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")
        Return ObtenerRegex(patron).IsMatch(texto.Trim())
    End Function

    Public Shared Function EsCedulaValida(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Dim patron As String = ConfiguracionManager.ObtenerTexto(
            "PatronCedula", "^\d{1,2}-\d{1,4}-\d{1,6}$")
        Return ObtenerRegex(patron).IsMatch(texto.Trim())
    End Function

    Public Shared Function EsDepartamentoPermitido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        ' Lista BLANCA: solo se acepta lo que esta autorizado en config.xml.
        Return ConfiguracionManager.Departamentos.
            Any(Function(d) String.Equals(d, texto.Trim(), StringComparison.OrdinalIgnoreCase))
    End Function

    Public Shared Function EsSalarioValido(valor As Decimal) As Boolean
        Dim minimo As Decimal = ConfiguracionManager.ObtenerDecimal("SalarioMinimo", 325D)
        Dim maximo As Decimal = ConfiguracionManager.ObtenerDecimal("SalarioMaximo", 9500D)
        Return valor >= minimo AndAlso valor <= maximo
    End Function

    Public Shared Function EsEdadValida(valor As Integer) As Boolean
        Dim minima As Integer = ConfiguracionManager.ObtenerEntero("EdadMinima", 18)
        Dim maxima As Integer = ConfiguracionManager.ObtenerEntero("EdadMaxima", 70)
        Return valor >= minima AndAlso valor <= maxima
    End Function

    ' =====================================================================
    '  PREVENCION DE INYECCION
    ' =====================================================================

    ''' <summary>
    ''' Revisa si el texto contiene patrones tipicos de inyeccion
    ''' (SQL o script). Devuelve False y explica el motivo si los encuentra.
    ''' </summary>
    Public Shared Function EsEntradaSegura(texto As String, ByRef motivo As String) As Boolean
        motivo = String.Empty
        If String.IsNullOrEmpty(texto) Then Return True

        Dim enMayusculas As String = texto.ToUpperInvariant()

        For Each patron As String In ConfiguracionManager.PatronesPeligrosos
            If patron.Length = 0 Then Continue For
            If enMayusculas.Contains(patron.ToUpperInvariant()) Then
                motivo = "La entrada contiene el patron peligroso: " & patron.Trim()
                Return False
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' Devuelve una version limpia del texto: quita caracteres de control
    ''' y simbolos usados en inyecciones, y colapsa espacios repetidos.
    ''' NOTA: sanear NO sustituye a las consultas parametrizadas
    ''' (SqlCommand.Parameters.AddWithValue); es una defensa adicional.
    ''' </summary>
    Public Shared Function Sanitizar(texto As String) As String
        If String.IsNullOrEmpty(texto) Then Return String.Empty

        Dim limpio As New StringBuilder()
        For Each caracter As Char In texto
            Select Case caracter
                Case "'"c, """"c, ";"c, "<"c, ">"c, "\"c, "%"c, "&"c, "|"c
                    ' se descarta
                Case Else
                    If Not Char.IsControl(caracter) Then
                        limpio.Append(caracter)
                    End If
            End Select
        Next

        Return Regex.Replace(limpio.ToString(), "\s{2,}", " ").Trim()
    End Function

    ' =====================================================================
    '  MANEJO SEGURO DE CONTRASENAS
    ' =====================================================================

    ''' <summary>Genera un salt aleatorio criptograficamente seguro.</summary>
    Public Shared Function GenerarSalt(Optional cantidadBytes As Integer = 16) As String
        Dim buffer(cantidadBytes - 1) As Byte
        Using generador As RandomNumberGenerator = RandomNumberGenerator.Create()
            generador.GetBytes(buffer)
        End Using
        Return Convert.ToBase64String(buffer)
    End Function

    ''' <summary>SHA-256 en hexadecimal. La contrasena NUNCA se guarda en texto plano.</summary>
    Public Shared Function CalcularSha256(texto As String) As String
        If texto Is Nothing Then texto = String.Empty

        Using algoritmo As SHA256 = SHA256.Create()
            Dim datos() As Byte = Encoding.UTF8.GetBytes(texto)
            Dim resumen() As Byte = algoritmo.ComputeHash(datos)
            Return BitConverter.ToString(resumen).Replace("-", String.Empty).ToLowerInvariant()
        End Using
    End Function

    ''' <summary>Hash de la contrasena combinada con su salt.</summary>
    Public Shared Function HashConSalt(clave As String, salt As String) As String
        Return CalcularSha256(salt & "|" & clave)
    End Function

    ''' <summary>
    ''' Comparacion en tiempo constante: evita filtrar informacion
    ''' por el tiempo de respuesta (timing attack).
    ''' </summary>
    Public Shared Function HashCoincide(hashA As String, hashB As String) As Boolean
        If hashA Is Nothing OrElse hashB Is Nothing Then Return False
        If hashA.Length <> hashB.Length Then Return False

        Dim diferencia As Integer = 0
        For i As Integer = 0 To hashA.Length - 1
            diferencia = diferencia Or (AscW(hashA(i)) Xor AscW(hashB(i)))
        Next
        Return diferencia = 0
    End Function

    ''' <summary>
    ''' Puntua la fortaleza de la clave de 0 a 5 y explica que le falta.
    ''' La longitud minima se lee de config.xml.
    ''' </summary>
    Public Shared Function EvaluarFortalezaClave(clave As String, ByRef detalle As String) As Integer
        If clave Is Nothing Then clave = String.Empty

        Dim minimo As Integer = ConfiguracionManager.ObtenerEntero("LongitudMinimaClave", 8)
        Dim faltantes As New List(Of String)()
        Dim puntos As Integer = 0

        If clave.Length >= minimo Then
            puntos += 1
        Else
            faltantes.Add("al menos " & minimo.ToString() & " caracteres")
        End If

        If clave.Any(Function(c) Char.IsUpper(c)) Then
            puntos += 1
        Else
            faltantes.Add("una mayuscula")
        End If

        If clave.Any(Function(c) Char.IsLower(c)) Then
            puntos += 1
        Else
            faltantes.Add("una minuscula")
        End If

        If clave.Any(Function(c) Char.IsDigit(c)) Then
            puntos += 1
        Else
            faltantes.Add("un numero")
        End If

        If clave.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
            puntos += 1
        Else
            faltantes.Add("un simbolo")
        End If

        If faltantes.Count = 0 Then
            detalle = "Clave fuerte."
        Else
            detalle = "Le falta: " & String.Join(", ", faltantes) & "."
        End If

        Return puntos
    End Function

End Class
