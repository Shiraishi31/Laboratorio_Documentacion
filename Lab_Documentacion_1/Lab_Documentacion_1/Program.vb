Option Strict On
Option Explicit On

Imports System.Windows.Forms

''' <summary>
''' LAB_DOCUMENTACION_1 - Punto de entrada.
''' Se usa un Sub Main explicito para instalar un manejador global de
''' errores antes de abrir el formulario principal.
''' </summary>
Module Program

    <STAThread()>
    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        AddHandler Application.ThreadException, AddressOf ManejarErrorDeHilo

        Application.Run(New FrmEmpleados())

    End Sub

    Private Sub ManejarErrorDeHilo(sender As Object, e As Threading.ThreadExceptionEventArgs)
        MessageBox.Show(
            "Ocurrio un error inesperado, pero la aplicacion sigue funcionando." &
            Environment.NewLine & Environment.NewLine & e.Exception.Message,
            "Error controlado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Module
