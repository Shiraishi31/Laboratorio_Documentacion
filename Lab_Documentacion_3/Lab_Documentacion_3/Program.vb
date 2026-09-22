Option Strict On
Option Explicit On

Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_3 - Punto de entrada.
''' Antes de abrir el formulario se carga el archivo de configuracion
''' externo. Si falla, la aplicacion NO se cae: avisa y sigue con los
''' valores por defecto (Confiabilidad / ISO 25010).
''' </summary>
Module Program

    <STAThread()>
    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        AddHandler Application.ThreadException, AddressOf ManejarErrorDeHilo

        Try
            ConfiguracionManager.Cargar()
        Catch ex As Exception
            MessageBox.Show(
                "No se pudo leer el archivo config.xml." & Environment.NewLine &
                "La aplicacion continuara con los valores por defecto." & Environment.NewLine &
                Environment.NewLine & "Detalle: " & ex.Message,
                "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Application.Run(New FrmSeguridad())

    End Sub

    Private Sub ManejarErrorDeHilo(sender As Object, e As Threading.ThreadExceptionEventArgs)
        MessageBox.Show(
            "Ocurrio un error inesperado, pero la aplicacion sigue funcionando." &
            Environment.NewLine & Environment.NewLine & e.Exception.Message,
            "Error controlado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Module
