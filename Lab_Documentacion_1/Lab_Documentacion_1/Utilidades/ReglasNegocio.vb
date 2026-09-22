Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Text.RegularExpressions

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - Clase estatica de reglas.
'''
''' Concentra en un solo lugar los valores y las validaciones del dominio
''' (lista blanca de departamentos, rangos de salario y expresiones
''' regulares). Es NotInheritable y su constructor es Private: nadie puede
''' heredarla ni instanciarla, solo usar sus miembros Shared.
'''
''' Tener las reglas aqui y no repartidas por los formularios es lo que
''' permite cambiarlas en un solo punto (alta cohesion, bajo acoplamiento).
''' </summary>
Public NotInheritable Class ReglasNegocio

    Private Sub New()
    End Sub

    ' ---------- Valores del dominio ----------

    Public Const SalarioMinimo As Decimal = 325D
    Public Const SalarioMaximo As Decimal = 9500D

    Private Const PatronCedula As String = "^\d{1,2}-\d{1,4}-\d{1,6}$"
    Private Const PatronNombre As String = "^[\p{L} ]{3,40}$"

    ''' <summary>Lista blanca de departamentos permitidos.</summary>
    Private Shared ReadOnly _departamentos As New List(Of String) From {
        "Sistemas",
        "Recursos Humanos",
        "Contabilidad",
        "Operaciones",
        "Mercadeo"
    }

    ''' <summary>Se devuelve una copia para que nadie modifique la lista original.</summary>
    Public Shared ReadOnly Property Departamentos As List(Of String)
        Get
            Return New List(Of String)(_departamentos)
        End Get
    End Property

    ' ---------- Validaciones ----------

    Public Shared Function EsCedulaValida(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return Regex.IsMatch(texto.Trim(), PatronCedula)
    End Function

    Public Shared Function EsNombreValido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return Regex.IsMatch(texto.Trim(), PatronNombre)
    End Function

    Public Shared Function EsDepartamentoPermitido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return _departamentos.Any(
            Function(d) String.Equals(d, texto.Trim(), StringComparison.OrdinalIgnoreCase))
    End Function

    Public Shared Function EsSalarioValido(valor As Decimal) As Boolean
        Return valor >= SalarioMinimo AndAlso valor <= SalarioMaximo
    End Function

End Class
