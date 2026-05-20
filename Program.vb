Imports System
Imports System.Windows.Forms

Namespace ProyectoPlanillaUMG1

    Friend Module Program

        ''' <summary>
        ''' Punto de entrada principal para la aplicación.
        ''' MEJORA: arranca desde FormLogin en lugar de Form1,
        ''' y registra un manejador global de excepciones no capturadas.
        ''' </summary>
        <STAThread>
        Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            ' MEJORA: captura cualquier excepción no manejada en el hilo UI
            ' para mostrar un mensaje amigable en lugar de colapsar silenciosamente.
            AddHandler Application.ThreadException,
                Sub(s As Object, ex As System.Threading.ThreadExceptionEventArgs)
                    MessageBox.Show(
                        "Error inesperado:" & Environment.NewLine & ex.Exception.Message,
                        "Error de aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Sub

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

            ' MEJORA: iniciar desde el formulario de login.
            Application.Run(New FormLogin())
        End Sub

    End Module

End Namespace