Option Strict On
Option Explicit On

Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_2 - Punto de entrada.
''' El manejador global de Application.ThreadException es la ultima red de
''' seguridad: si una excepcion se escapa de todos los Try-Catch, la
''' aplicacion avisa en vez de cerrarse sola.
''' </summary>
Module Program

    <STAThread()>
    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        AddHandler Application.ThreadException, AddressOf ManejarErrorDeHilo

        Application.Run(New FrmValidacion())

    End Sub

    Private Sub ManejarErrorDeHilo(sender As Object, e As Threading.ThreadExceptionEventArgs)
        MessageBox.Show(
            "Ocurrio un error inesperado, pero la aplicacion sigue funcionando." &
            Environment.NewLine & Environment.NewLine & e.Exception.Message,
            "Error controlado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Module
