Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Namespace ProyectoPlanillaUMG1

    ''' <summary>
    ''' Clase de conexión a la base de datos MySQL.
    ''' La cadena de conexión se lee desde App.config.
    ''' </summary>
    Public Class CConexion

        Private ReadOnly cadena As String

        Public Sub New()
            Dim cs = ConfigurationManager.ConnectionStrings("PlanillaDB")
            If cs Is Nothing OrElse String.IsNullOrWhiteSpace(cs.ConnectionString) Then
                Throw New InvalidOperationException(
                    "No se encontró la cadena de conexión 'PlanillaDB' en App.config.")
            End If

            ' Agregamos Connection Timeout explícito para no bloquear la UI indefinidamente.
            Dim builder As New MySqlConnectionStringBuilder(cs.ConnectionString)
            builder.ConnectionTimeout = 10
            cadena = builder.ConnectionString
        End Sub

        ''' <summary>
        ''' Abre y devuelve una nueva conexión. El llamador es responsable de
        ''' cerrarla (idealmente con 'Using'). Devuelve Nothing si falla.
        ''' </summary>
        Public Function ObtenerConexion() As MySqlConnection
            Try
                Dim conex As New MySqlConnection(cadena)
                conex.Open()
                Return conex
            Catch ex As MySqlException
                MessageBox.Show(
                    "Error de conexión a la base de datos:" & Environment.NewLine & ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Return Nothing
            Catch ex As Exception
                MessageBox.Show(
                    "Error inesperado al conectar:" & Environment.NewLine & ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Function

        ' Alias para compatibilidad hacia atrás.
        Public Function EstablecerConexion() As MySqlConnection
            Return ObtenerConexion()
        End Function

    End Class

End Namespace