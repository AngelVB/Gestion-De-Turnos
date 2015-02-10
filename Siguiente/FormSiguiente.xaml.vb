Option Explicit On
Option Strict On
Imports System.Data
Imports Siguiente.MainWindow
Imports System.Data.SQLite
Imports System.Windows.Threading

Partial Public Class FormSiguiente
    ReadOnly _Negocio As New Negocio.NegocioSiguiente
    Dim Datos As SQLiteDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim Consultas As DataTable = New DataTable()
    Private Shared _idCola As Integer
    Private Shared _nombreConsulta As String
    Dim Especialidad As String

    Public Shared Property IdCola As Integer
        Get
            Return _idCola
        End Get
        Set(value As Integer)
            _idCola = value
        End Set
    End Property

    Public Shared Property NombreConsulta As String
        Get
            Return _nombreConsulta
        End Get
        Set(value As String)
            _nombreConsulta = value
        End Set
    End Property


    Private Sub Window_SourceInitialized(sender As Object, e As EventArgs)

    End Sub

    ''' <summary>
    ''' Window_Loaded. Tras ser cargada la ventana, Rellenamos el ComboBox de consultas con todas las consultas
    ''' de nuestro centro e iniciamos el temporizador que actualizará nuestra lista de citas cada minuto
    ''' </summary>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim cb As SQLiteCommandBuilder
        cb = New SQLiteCommandBuilder(Datos)
        Consultas = _Negocio.ConsultarColas(NumColegiado)
        ComboColas.DataContext = Consultas
        ComboColas.SelectedIndex = 0

        Dim Timer As DispatcherTimer = New DispatcherTimer()
        AddHandler Timer.Tick, AddressOf dispatcherTimer_Tick
        Timer.Interval = New TimeSpan(0, 0, 1, 0)
        Timer.Start()
    End Sub

    ''' <summary>
    ''' Button_Click_1. Al hacer clic sobre el botón Siguiente, marcamos la cita seleccionada como terminada.
    '''
    ''' </summary>
    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim drv As DataRowView = TryCast(DGCitas.SelectedItem, DataRowView)
        If Not drv Is Nothing Then

            Dim CitaId As Integer = CInt(drv("Id"))
            If (_Negocio.TerminarCita(CitaId)) Then
                ds.Clear()
                Datos.Fill(ds, "tabla")
            End If
        Else
            MsgBox("No hay linea seleccionada.")
        End If
    End Sub

    ''' <summary>
    ''' ComboColas_SelectionChanged. Al cambiar de consulta, rellenamos el dataset con las citas de dicha consulta
    ''' y se la asignamos al médico, de esa forma, otro médico no podrá pasar consulta de esa misma especialidad
    ''' a la vez.
    '''
    ''' </summary>
    Private Sub ComboColas_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ComboColas.SelectionChanged
        If (IdCola > 0) Then
            _Negocio.AsignarMedico(IdCola, "-1")
        End If
        IdCola = CInt(ComboColas.SelectedValue)
        ds.Clear()
        Dim drv As DataRowView = CType(ComboColas.SelectedItem, DataRowView)
        Dim MedicoId As Integer = CInt(drv("MedicoId"))
        Especialidad = CStr(drv("NumMesa"))
        NombreConsulta = drv("NombreConsulta").ToString()
        If (MedicoId = -1) Then
            _Negocio.AsignarMedico(IdCola, NumColegiado)
        End If

        Datos = _Negocio.ConsultarCitasMedico(NumColegiado, New DateTime(Now.Year, Now.Month, Now.Day), IdCola)
        Datos.Fill(ds, "tabla")

        DGCitas.DataContext = ds
        ''cierro el submenú, que no sé por qué, no cierra automáticamente
        MenuGestionItem.IsSubmenuOpen = False

        txtNombreConsulta.DataContext = NombreConsulta
        txtEspecialidad.DataContext = Especialidad
        txtFecha.DataContext = Date.Today.ToString("dd-MM-yyyy")
    End Sub

    ''' <summary>
    ''' MenuItem_Click. Muestro el menú de renombrar consulta
    '''
    ''' </summary>
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim Renombrar As RenombrarConsulta = New RenombrarConsulta()
        Renombrar.Show()
    End Sub

    ''' <summary>
    ''' Window_Activated. Al activar la ventana, Actualizo el nombre de la consulta seleccionada modificada desde
    ''' el cuadro de diálogo de Renombrar Consulta.
    '''
    ''' </summary>
    Private Sub Window_Activated(sender As Object, e As EventArgs)
        IdCola = CInt(ComboColas.SelectedValue)
        Dim drv As DataRowView = CType(ComboColas.SelectedItem, DataRowView)
        '' Consultas = _Negocio.ConsultarColas(NumColegiado)
        If (Not drv Is Nothing) Then
            Consultas.Rows(ComboColas.SelectedIndex).Item("NombreConsulta") = NombreConsulta
            txtNombreConsulta.DataContext = NombreConsulta
        End If
    End Sub

    ''' <summary>
    ''' Salir
    '''Cuadro de diálogo para cerrar aplicación.
    ''' </summary>
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim Result As MessageBoxResult
        Result = MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButton.YesNo)
        'if user clicked no, cancel form closing
        If (Result = 7) Then
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Window_Closed. Antes de cerrar finalmente la ventana, liberamos la consulta actual para que otro médico 
    ''' pueda acceder.
    '''
    ''' </summary>
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        If (IdCola > 0) Then
            _Negocio.AsignarMedico(IdCola, "-1")
        End If
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' dispatcherTimer_Tick. Actualizamos la lista de citas cada minuto.
    '''
    ''' </summary>
    Public Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)

        Datos = _Negocio.ConsultarCitasMedico(NumColegiado, New DateTime(Now.Year, Now.Month, Now.Day), IdCola)
        ds.Clear()
        Datos.Fill(ds, "tabla")
        DGCitas.DataContext = ds

    End Sub
End Class

Public Class Asig

End Class
