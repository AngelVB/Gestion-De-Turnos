Option Explicit On
Option Strict On

''' <summary>
''' AnyadirCola.vb
'''Formulario para añadir colas.
''' </summary>
''' <author> Ángel Valera</author>
Public Class AnyadirCola
    ReadOnly _Negocio As New Negocio.NegocioMostrador


    ''' <summary>
    '''RellenarColas
    '''Rellenamos el combobox con el número de cola disponible.
    ''' </summary>
    Public Sub RellenarColas()
        Dim Coinc As Integer = -1
        CBNumCola.Items.Clear()
        CBNumCola.Text = ""
        For i As Integer = 1 To 5
            CBNumCola.Items.Add(i)
        Next
        Dim Consultas As DataTable = _Negocio.ConsultarColas
        For Each Row As DataRow In Consultas.Rows

            Coinc = CBNumCola.FindStringExact(CStr(Row("NumCola")))
            If Coinc >= 0 Then
                CBNumCola.Items.RemoveAt(Coinc)
            End If
        Next 
    End Sub

    ''' <summary>
    '''Button1_Click
    '''Validamos los datos y añadimos la cola al sistema.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Pmedico As Integer

        '' DESCOMENTANDO ESTAS LÍNEAS Y HACIENDO VISIBLE EL COMBOBOX, PERMITO ASIGNAR MÉDICO AL GENERAR LA COLA
        '' If CStr(CBMedico.Text) = "" Then
        Pmedico = -1
        ''  Else
        '' Pmedico = CInt(CBMedico.SelectedValue)
        '' End If

        If CStr(CBNumCola.Text) = "" Then
            MsgBox("Debe seleccionar un número de cola")
        ElseIf CStr(TBNumMesa.Text) = "" Then
            MsgBox("Debe escribir un número de mesa")
        ElseIf _Negocio.InsertarCola(CInt(CBNumCola.Text), TBNumMesa.Text.ToUpper, Pmedico) = 1 Then
            MsgBox("Cola insertada con éxito")
            RellenarColas()
            TBNumMesa.Text = ""
            CBMedico.Text = ""
        Else
            MsgBox("Error creando cola.")
        End If

    End Sub

    ''' <summary>
    '''Button2_Click
    '''Cierra el formulario
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    ''' <summary>
    '''AnyadirCola_Enter
    '''Preparamos el combobox de colas disponibles y médicos de nuestro formulario
    ''' </summary>
    Private Sub AnyadirCola_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        RellenarColas()

        With CBMedico
            .DisplayMember = "Nombre Completo"
            .ValueMember = "Id"
            .DataSource = _Negocio.ListarMedicos
            .Text = ""
        End With
    End Sub
End Class