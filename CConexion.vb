Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration

Namespace ProyectoPlanillaUMG1

    ''' <summary>
    ''' Clase de conexión a la base de datos MySQL.
    ''' La cadena de conexión se lee desde App.config (clave "PlanillaDB").
    ''' MEJORA: implementa IDisposable para liberar recursos correctamente;
    ''' expone un método de prueba de conexión separado del de producción.
    ''' </summary>
    Public Class CConexion
        Implements IDisposable

        Private ReadOnly _cadena As String
        Private _disposed As Boolean = False

        Public Sub New()
            Dim cs = ConfigurationManager.ConnectionStrings("PlanillaDB")
            If cs Is Nothing OrElse String.IsNullOrWhiteSpace(cs.ConnectionString) Then
                Throw New InvalidOperationException(
                    "No se encontró la cadena de conexión 'PlanillaDB' en App.config.")
            End If

            Dim builder As New MySqlConnectionStringBuilder(cs.ConnectionString)
            builder.ConnectionTimeout = 10
            ' MEJORA: tiempo máximo de espera para sentencias largas (evita UI congelada).
            builder.DefaultCommandTimeout = 30
            _cadena = builder.ConnectionString
        End Sub

        ''' <summary>
        ''' Abre y devuelve una nueva conexión lista para usar.
        ''' Ciérrela con Using o llamando a .Dispose().
        ''' Devuelve Nothing y muestra un mensaje si falla.
        ''' </summary>
        Public Function ObtenerConexion() As MySqlConnection
            Try
                Dim conex As New MySqlConnection(_cadena)
                conex.Open()
                Return conex
            Catch ex As MySqlException
                ' MEJORA: mensaje distingue entre problemas de red y de credenciales.
                Dim detalle As String = If(ex.Number = 1045,
                    "Credenciales incorrectas. Revise usuario/contraseña en App.config.",
                    ex.Message)
                MostrarErrorConexion(detalle)
                Return Nothing
            Catch ex As Exception
                MostrarErrorConexion(ex.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Prueba si la conexión puede establecerse sin mostrar UI.
        ''' Útil para verificar configuración al arrancar la app.
        ''' </summary>
        Public Function PuedoConectar() As Boolean
            Try
                Using conn As New MySqlConnection(_cadena)
                    conn.Open()
                    Return True
                End Using
            Catch
                Return False
            End Try
        End Function

        ' Alias para compatibilidad con código existente.
        Public Function EstablecerConexion() As MySqlConnection
            Return ObtenerConexion()
        End Function

        Private Shared Sub MostrarErrorConexion(detalle As String)
            Windows.Forms.MessageBox.Show(
                "Error de conexión a la base de datos:" & Environment.NewLine & detalle,
                "Error de conexión",
                Windows.Forms.MessageBoxButtons.OK,
                Windows.Forms.MessageBoxIcon.Error)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            _disposed = True
        End Sub

    End Class

End Namespace