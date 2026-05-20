Imports System
Imports System.Windows.Forms
Imports ProyectoPlanillaUMG1
Imports ProyectoPlanillaUMG1.ProyectoPlanillaUMG1

''' <summary>
''' Formulario de inicio de sesión.
''' MEJORA: credenciales no se comparan en texto plano; se usa hashing SHA-256.
''' En producción real, las credenciales deben validarse contra la base de datos.
''' </summary>
Public Class FormLogin

    ' MEJORA: hash SHA-256 de "12345" para no guardar contraseñas en texto plano.
    ' Genera este valor con: SHA256("admin" + ":" + "12345")
    ' Valor de referencia (usuario=admin, clave=12345):
    '   5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5
    Private Const UsuarioCorrecto As String = "admin"
    Private Const HashClaveCorrecto As String = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5"

    ' Límite de intentos antes de bloquear el formulario.
    Private _intentosFallidos As Integer = 0
    Private Const MaxIntentos As Integer = 3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IniciarSesion()
    End Sub

    ' MEJORA: responder a Enter en los campos de texto.
    Private Sub TxtContraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown
        If e.KeyCode = Keys.Enter Then IniciarSesion()
    End Sub

    Private Sub TxtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then txtContraseña.Focus()
    End Sub

    Private Sub IniciarSesion()
        ' MEJORA: bloqueo tras varios intentos fallidos.
        If _intentosFallidos >= MaxIntentos Then
            MessageBox.Show(
                "Demasiados intentos fallidos. Reinicie la aplicación.",
                "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim usuario As String = txtUsuario.Text.Trim()
        Dim clave As String = txtContraseña.Text  ' no se recorta — espacios son parte de la clave

        If String.IsNullOrWhiteSpace(usuario) OrElse String.IsNullOrEmpty(clave) Then
            MessageBox.Show(
                "Ingrese usuario y contraseña.",
                "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' MEJORA: comparación contra hash SHA-256, no texto plano.
        Dim hashIngresado As String = ComputarSHA256(clave)

        If String.Equals(usuario, UsuarioCorrecto, StringComparison.OrdinalIgnoreCase) AndAlso
           String.Equals(hashIngresado, HashClaveCorrecto, StringComparison.Ordinal) Then

            ' MEJORA: abrir Form1 como instancia nueva y ocultar el login,
            ' en lugar de simplemente llamar Form1.Show() (forma estática/global).
            Me.Hide()
            Dim principal As New Form1()
            AddHandler principal.FormClosed, Sub(s, args) Me.Close()
            principal.Show()
        Else
            _intentosFallidos += 1
            Dim restantes As Integer = MaxIntentos - _intentosFallidos
            Dim mensaje As String = If(
                restantes > 0,
                $"Usuario o contraseña incorrectos. Intentos restantes: {restantes}.",
                "Último intento fallido. La aplicación quedará bloqueada.")
            MessageBox.Show(mensaje, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContraseña.Clear()
            txtContraseña.Focus()
        End If
    End Sub

    ''' <summary>Calcula el hash SHA-256 de un texto y lo devuelve en hexadecimal.</summary>
    Private Shared Function ComputarSHA256(texto As String) As String
        Using sha As New System.Security.Cryptography.SHA256Managed()
            Dim bytes() As Byte = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto))
            Return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant()
        End Using
    End Function

End Class