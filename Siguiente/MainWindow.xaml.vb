Option Explicit On
Option Strict On
Class MainWindow
    ReadOnly _Negocio As New Negocio.NegocioSiguiente
    Private Shared _numColegiado As String

    Public Shared Property NumColegiado As String
        Get
            Return _numColegiado
        End Get
        Set(value As String)
            _numColegiado = value
        End Set
    End Property

    ''' <summary>
    ''' Button2_Click. Botón encargado de validar los datos de acceso del médico
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As RoutedEventArgs) Handles Button2.Click
        If TBNumColegiado.Text = "" Then
            MsgBox("Introduzca su número de colegiado")
            TBNumColegiado.Focus()
        ElseIf TBPassword.Password = "" Then
            MsgBox("Introduzca su contraseña.")
            TBPassword.Focus()
        ElseIf TBPassword.Password.Length < 6 Then
            MsgBox("La contraseña debe tener al menos 6 carácteres")
            TBPassword.Focus()
        Else
            NumColegiado = TBNumColegiado.Text
            If _Negocio.ConsultarLogin(NumColegiado, TBPassword.Password) Then
                Dim Siguiente As FormSiguiente = New FormSiguiente()
                Siguiente.Show()
                Me.Hide()
            Else
                MsgBox("Nº de colegiado o contraseña incorrectos.")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
