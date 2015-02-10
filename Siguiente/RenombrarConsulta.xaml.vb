Option Explicit On
Option Strict On

Public Class RenombrarConsulta
    ReadOnly _Negocio As New Negocio.NegocioSiguiente
    Private Shared NuevoNombre As String = ""

    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    ''' <summary>
    ''' Button2_Click. Actualizamos el nombre de la consulta para mostrarla en el panel.
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As RoutedEventArgs) Handles Button2.Click
        If TBNombreConsulta.Text = "" Then
            MsgBox("Introduzca un nombre para la consulta")
            TBNombreConsulta.Focus()
        Else
            NuevoNombre = TBNombreConsulta.Text.ToUpper()
            If _Negocio.ModificarMesa(FormSiguiente.IdCola, NuevoNombre) Then
                MsgBox("Nombre de la consulta modificado con éxito.")
                FormSiguiente.NombreConsulta = NuevoNombre
                Me.Hide()
            Else
                MsgBox("Error cambiando el nombre de la consulta.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Window_Loaded. Al cargar la ventana, recuperamos el nombre de la consulta para modificarlo.
    ''' </summary>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        TBNombreConsulta.Text = FormSiguiente.NombreConsulta
    End Sub
End Class
