Option Strict On
Option Explicit On

Imports System.ComponentModel

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - Clase base del modelo orientado a objetos.
'''
''' Es MustInherit (abstracta): no se instancia directamente, solo sirve
''' como contrato comun para todo tipo de persona del sistema.
''' Implementa INotifyPropertyChanged para que el DataGridView enlazado
''' se actualice solo cuando cambia una propiedad (enlace bidireccional).
''' Los campos son Private (principio de minimo privilegio / encapsulamiento)
''' y se exponen mediante propiedades que validan y normalizan el valor.
''' </summary>
Public MustInherit Class Persona
    Implements INotifyPropertyChanged

    ' ---------- Campos privados (estado interno protegido) ----------
    Private _cedula As String = String.Empty
    Private _nombre As String = String.Empty
    Private _apellido As String = String.Empty
    Private _fechaNacimiento As Date = Date.Today.AddYears(-18)

    ''' <summary>Evento exigido por INotifyPropertyChanged.</summary>
    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>Notifica a la interfaz que una propiedad cambio.</summary>
    Protected Sub NotificarCambio(nombrePropiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(nombrePropiedad))
    End Sub

    ' ---------- Propiedades publicas ----------

    Public Property Cedula As String
        Get
            Return _cedula
        End Get
        Set(value As String)
            _cedula = If(value, String.Empty).Trim().ToUpperInvariant()
            NotificarCambio(NameOf(Cedula))
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = If(value, String.Empty).Trim()
            NotificarCambio(NameOf(Nombre))
            NotificarCambio(NameOf(NombreCompleto))
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = If(value, String.Empty).Trim()
            NotificarCambio(NameOf(Apellido))
            NotificarCambio(NameOf(NombreCompleto))
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
            NotificarCambio(NameOf(FechaNacimiento))
            NotificarCambio(NameOf(Edad))
        End Set
    End Property

    ' ---------- Propiedades calculadas (solo lectura) ----------

    Public ReadOnly Property NombreCompleto As String
        Get
            Return (_nombre & " " & _apellido).Trim()
        End Get
    End Property

    Public ReadOnly Property Edad As Integer
        Get
            Dim anios As Integer = Date.Today.Year - _fechaNacimiento.Year
            If _fechaNacimiento.Date > Date.Today.AddYears(-anios) Then
                anios -= 1
            End If
            Return If(anios < 0, 0, anios)
        End Get
    End Property

    ''' <summary>
    ''' Miembro abstracto: cada clase hija DEBE decir que rol cumple.
    ''' Base del polimorfismo usado en el Escenario 1.
    ''' </summary>
    Public MustOverride ReadOnly Property Rol As String

    Public Overrides Function ToString() As String
        Return String.Format("{0} ({1})", NombreCompleto, Rol)
    End Function

End Class
