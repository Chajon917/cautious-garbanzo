Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports ProyectoPlanillaUMG1.ProyectoPlanillaUMG1

Public Class FormLogin
    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim usuario As String
        Dim contraseña As Integer
        usuario = txtUsuario.Text
        contraseña = txtContraseña.Text
        If (usuario = "admin") And (contraseña = "12345") Then
            Form1.Show()
        Else
            MsgBox("Usuario o contraseña incorrecta")
        End If


    End Sub
End Class