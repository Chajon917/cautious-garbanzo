Imports System
Imports System.Windows.Forms

Namespace ProyectoPlanillaUMG1

    Friend Module Program

        ''' <summary>
        ''' Punto de entrada principal para la aplicación.
        ''' </summary>
        <STAThread>
        Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub

    End Module

End Namespace