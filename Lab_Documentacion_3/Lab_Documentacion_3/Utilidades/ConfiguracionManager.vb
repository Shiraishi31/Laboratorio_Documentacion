Option Strict On
Option Explicit On

Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq

''' <summary>
''' LAB_DOCUMENTACION_3 (Escenario 3) - Clase ESTATICA de utilidades (NotInheritable + New privado).
'''
''' Lee los parametros de la aplicacion desde el archivo externo config.xml
''' usando LINQ to XML (XDocument). Los valores quedan en cache dentro de
''' un Dictionary(Of String, String) para no releer el disco en cada consulta.
'''
''' Impacto en calidad (ISO/IEC 25010):
'''  - Portabilidad  : cambiar una regla NO exige recompilar el .exe.
'''  - Mantenibilidad: un solo punto del sistema conoce el formato del XML.
'''  - Confiabilidad : si el archivo falta o esta danado se usan valores
'''                    por defecto y la aplicacion NO se cae.
''' </summary>
Public NotInheritable Class ConfiguracionManager

    ''' <summary>Constructor privado: nadie puede instanciar esta clase.</summary>
    Private Sub New()
    End Sub

    ' ---------- Cache interno ----------
    Private Shared ReadOnly _parametros As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private Shared ReadOnly _listaParametros As New List(Of ParametroConfig)()
    Private Shared ReadOnly _departamentos As New List(Of String)()
    Private Shared ReadOnly _patronesPeligrosos As New List(Of String)()

    Private Shared _cargado As Boolean = False
    Private Shared _usandoPorDefecto As Boolean = True
    Private Shared _ultimoError As String = String.Empty

    ' ---------- Propiedades de estado ----------

    ''' <summary>Ruta completa del config.xml (junto al ejecutable).</summary>
    Public Shared ReadOnly Property RutaArchivo As String
        Get
            Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml")
        End Get
    End Property

    ''' <summary>True si no se pudo leer el XML y se usan valores internos.</summary>
    Public Shared ReadOnly Property UsandoValoresPorDefecto As Boolean
        Get
            Return _usandoPorDefecto
        End Get
    End Property

    Public Shared ReadOnly Property UltimoError As String
        Get
            Return _ultimoError
        End Get
    End Property

    Public Shared ReadOnly Property Departamentos As List(Of String)
        Get
            AsegurarCarga()
            Return New List(Of String)(_departamentos)
        End Get
    End Property

    Public Shared ReadOnly Property PatronesPeligrosos As List(Of String)
        Get
            AsegurarCarga()
            Return New List(Of String)(_patronesPeligrosos)
        End Get
    End Property

    ''' <summary>Todos los parametros, listos para enlazar a un DataGridView.</summary>
    Public Shared Function ObtenerTodos() As List(Of ParametroConfig)
        AsegurarCarga()
        Return New List(Of ParametroConfig)(_listaParametros)
    End Function

    ' ---------- Carga del archivo ----------

    Public Shared Sub Cargar()
        _parametros.Clear()
        _listaParametros.Clear()
        _departamentos.Clear()
        _patronesPeligrosos.Clear()
        _ultimoError = String.Empty
        _usandoPorDefecto = True

        ' 1) Siempre se siembran valores por defecto (red de seguridad).
        AplicarValoresPorDefecto()

        ' 2) Luego el XML sobrescribe lo que encuentre.
        Try
            If Not File.Exists(RutaArchivo) Then
                Throw New FileNotFoundException("No se encontro el archivo de configuracion.", RutaArchivo)
            End If

            Dim documento As XDocument = XDocument.Load(RutaArchivo)
            Dim raiz As XElement = documento.Root
            If raiz Is Nothing Then
                Throw New InvalidDataException("El archivo config.xml esta vacio.")
            End If

            ' Secciones con <parametro clave="..." valor="..." />
            For Each seccion As XElement In raiz.Elements()
                For Each nodo As XElement In seccion.Elements("parametro")

                    Dim attClave As XAttribute = nodo.Attribute("clave")
                    Dim attValor As XAttribute = nodo.Attribute("valor")

                    If attClave IsNot Nothing AndAlso attValor IsNot Nothing Then
                        Dim clave As String = attClave.Value.Trim()
                        Dim valor As String = attValor.Value.Trim()

                        If clave.Length > 0 Then
                            _parametros(clave) = valor
                            _listaParametros.Add(New ParametroConfig(seccion.Name.LocalName, clave, valor))
                        End If
                    End If
                Next
            Next

            ' Lista blanca de departamentos
            Dim nodoDeptos As XElement = raiz.Element("departamentos")
            If nodoDeptos IsNot Nothing Then
                Dim leidos As List(Of String) = nodoDeptos.Elements("departamento").
                        Select(Function(x) x.Value.Trim()).
                        Where(Function(t) t.Length > 0).
                        ToList()

                If leidos.Count > 0 Then
                    _departamentos.Clear()
                    _departamentos.AddRange(leidos)
                    For Each d As String In leidos
                        _listaParametros.Add(New ParametroConfig("departamentos", "departamento", d))
                    Next
                End If
            End If

            ' Patrones peligrosos (seguridad)
            Dim nodoSeg As XElement = raiz.Element("seguridad")
            If nodoSeg IsNot Nothing Then
                Dim leidos As List(Of String) = nodoSeg.Elements("patronPeligroso").
                        Select(Function(x) x.Value.Trim()).
                        Where(Function(t) t.Length > 0).
                        ToList()

                If leidos.Count > 0 Then
                    _patronesPeligrosos.Clear()
                    _patronesPeligrosos.AddRange(leidos)
                    For Each p As String In leidos
                        _listaParametros.Add(New ParametroConfig("seguridad", "patronPeligroso", p))
                    Next
                End If
            End If

            _usandoPorDefecto = False

        Catch ex As Exception
            ' No se relanza: la aplicacion debe seguir viva con los defaults.
            _ultimoError = ex.Message
            _usandoPorDefecto = True
        Finally
            _cargado = True
        End Try
    End Sub

    Public Shared Sub Recargar()
        Cargar()
    End Sub

    Private Shared Sub AsegurarCarga()
        If Not _cargado Then
            Cargar()
        End If
    End Sub

    ''' <summary>Valores internos usados si el XML no esta disponible.</summary>
    Private Shared Sub AplicarValoresPorDefecto()
        _parametros("TituloApp") = "Investigacion #1 - Escenarios en VB.NET"
        _parametros("Universidad") = "Universidad Tecnologica de Panama - FISC"
        _parametros("Version") = "1.0.0"
        _parametros("Autor") = "Estudiante FISC"

        _parametros("SalarioMinimo") = "325.00"
        _parametros("SalarioMaximo") = "9500.00"
        _parametros("EdadMinima") = "18"
        _parametros("EdadMaxima") = "70"
        _parametros("LongitudMinimaClave") = "8"
        _parametros("LongitudMaximaClave") = "20"
        _parametros("MaximoIntentos") = "3"
        _parametros("PatronCorreo") = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"
        _parametros("PatronCedula") = "^\d{1,2}-\d{1,4}-\d{1,6}$"
        ' \p{L} = cualquier letra Unicode (incluye tildes y la letra enie)
        _parametros("PatronNombre") = "^[\p{L} ]{3,40}$"

        _departamentos.AddRange(New String() {"Sistemas", "Recursos Humanos", "Contabilidad"})
        _patronesPeligrosos.AddRange(New String() {"--", ";", "'", "DROP ", "SELECT ", "OR 1=1", "<script"})
    End Sub

    ' ---------- Lectura tipada de parametros ----------

    Public Shared Function ObtenerTexto(clave As String, valorPorDefecto As String) As String
        AsegurarCarga()
        Dim valor As String = Nothing
        If _parametros.TryGetValue(clave, valor) AndAlso Not String.IsNullOrWhiteSpace(valor) Then
            Return valor
        End If
        Return valorPorDefecto
    End Function

    Public Shared Function ObtenerEntero(clave As String, valorPorDefecto As Integer) As Integer
        Dim texto As String = ObtenerTexto(clave, String.Empty)
        Dim resultado As Integer
        If Integer.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, resultado) Then
            Return resultado
        End If
        Return valorPorDefecto
    End Function

    Public Shared Function ObtenerDecimal(clave As String, valorPorDefecto As Decimal) As Decimal
        Dim texto As String = ObtenerTexto(clave, String.Empty)
        Dim resultado As Decimal
        If Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, resultado) Then
            Return resultado
        End If
        Return valorPorDefecto
    End Function

    Public Shared Function ObtenerBooleano(clave As String, valorPorDefecto As Boolean) As Boolean
        Dim texto As String = ObtenerTexto(clave, String.Empty)
        Dim resultado As Boolean
        If Boolean.TryParse(texto, resultado) Then
            Return resultado
        End If
        Return valorPorDefecto
    End Function

End Class
