Option Explicit On
Option Strict On
''' <summary>
''' Buscar.vb
''' Formulario Búsqueda.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class Buscar
    ReadOnly _Negocio As New Negocio.NegocioMostrador
    Private _Resultados As DataTable

    Public Property Resultados As DataTable
        Get
            Return _Resultados
        End Get
        Set(value As DataTable)
            _Resultados = value
        End Set
    End Property

    ''' <summary>
    ''' Button1_Click
    ''' Almacena la cadena de búsqueda y llama al formulario ResultBusqueda
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CadenaBusqueda.Text = "" Then
            MsgBox("Introduzca texto a buscar")
        Else
            If Mostrador.MenuSelec = 2 Or Mostrador.MenuSelec = 4 Or Mostrador.MenuSelec = 8 Then
                Resultados = _Negocio.BuscarPacientes(CadenaBusqueda.Text)
            ElseIf Mostrador.MenuSelec = 1 Or Mostrador.MenuSelec = 3 Then
                Resultados = _Negocio.BuscarMedicos(CadenaBusqueda.Text)
            End If
            If Not Resultados Is Nothing Then
                If Resultados.Rows.Count = 0 Then
                    If Mostrador.MenuSelec = 2 Or Mostrador.MenuSelec = 4 Or Mostrador.MenuSelec = 8 Then
                        MsgBox("No existen pacientes con esos datos.")
                    ElseIf Mostrador.MenuSelec = 1 Or Mostrador.MenuSelec = 3 Then
                        MsgBox("No existen médicos con esos datos.")
                    End If
                Else
                    Hide()
                    ResultBusqueda.MdiParent = Mostrador
                    ResultBusqueda.Show()
                End If
            Else
                If Mostrador.MenuSelec = 2 Or Mostrador.MenuSelec = 4 Or Mostrador.MenuSelec = 8 Then
                    MsgBox("No existen pacientes con esos datos.")
                ElseIf Mostrador.MenuSelec = 1 Or Mostrador.MenuSelec = 3 Then
                    MsgBox("No existen médicos con esos datos.")
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Buscar_Enter
    ''' Evento On Enter. Asignamos el título del formulario dependiendo de desde qué opción llamemos al buscador.
    ''' </summary>
    Private Sub Buscar_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Mostrador.MenuSelec = 2 Or Mostrador.MenuSelec = 4 Or Mostrador.MenuSelec = 8 Then
            Me.Text = "Buscar Paciente"
        ElseIf Mostrador.MenuSelec = 1 Or Mostrador.MenuSelec = 3 Then
            Me.Text = "Buscar Médico"
        End If

    End Sub


    ''' <summary>
    '''Resetear
    ''' Resetea las propiedades de los campos del formulario.
    ''' </summary>
    Public Sub Resetear()
        Resultados = Nothing
        CadenaBusqueda.Text = ""
        If Mostrador.MenuSelec = 2 Or Mostrador.MenuSelec = 4 Or Mostrador.MenuSelec = 8 Then
            Me.Text = "Buscar Paciente"
        ElseIf Mostrador.MenuSelec = 1 Or Mostrador.MenuSelec = 3 Then
            Me.Text = "Buscar Médico"
        End If
    End Sub

    ''' <summary>
    ''' Button2_Click
    '''Cierra la ventana.
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    ''' <summary>
    ''' AnyadirDias_FormClosing
    '''Evento FormClosing. Llama a la función Salir del mostrador.
    ''' </summary>
    Private Sub BuscarMedico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mostrador.Salir(e)
    End Sub
End Class