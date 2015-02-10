Option Explicit On
Option Strict On

''' <summary>
''' AnyadirDias.vb
'''Formulario para añadir días festivos.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class AnyadirDias
    ReadOnly _Negocio As New Negocio.NegocioMostrador

    ''' <summary>
    ''' AnyadirDias_Load.
    '''Evento OnLoad. Ajustamos los límites del calendario al año actual.
    ''' </summary>
    Private Sub AnyadirDias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FechaFestivo.MinDate = New DateTime(Now.Year, 1, 1)
        FechaFestivo.MaxDate = New DateTime(Now.Year, 12, 31)
    End Sub

    ''' <summary>
    ''' AnyadirFestivo_Click
    '''Añade Festivo.
    ''' </summary>
    Private Sub AnyadirFestivo_Click(sender As Object, e As EventArgs) Handles AnyadirFestivo.Click

        If NombreFestivo.TextLength = 0 Or NombreFestivo.TextLength > 40 Then
            MsgBox("Inserte un nombre para el día festivo.")
            NombreFestivo.Focus()

        Else
            Dim Numero As Integer = _Negocio.InsertarFestivo(FechaFestivo.Value, NombreFestivo.Text)

            If Numero = 1 Then
                MsgBox("Festivo insertado con éxito.")
            Else
                MsgBox("Error Insertando festivo.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' CancelarFestivo_Click
    '''Cierra la ventana.
    ''' </summary>
    Private Sub CancelarFestivo_Click(sender As Object, e As EventArgs) Handles CancelarFestivo.Click
        Close()
    End Sub

    ''' <summary>
    ''' AnyadirDias_FormClosing
    '''Evento FormClosing. Llama a la función Salir del mostrador.
    ''' </summary>
    Private Sub AnyadirDias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
         Mostrador.Salir(e)
    End Sub
End Class