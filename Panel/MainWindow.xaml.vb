Option Explicit On
Option Strict On
Imports System.Data
Imports System.Windows.Threading
Imports System.Data.SQLite
Imports System.Windows.Media.Animation

Class MainWindow
    ReadOnly _Negocio As New Negocio.NegocioPanel
    Dim _actuales As SQLiteDataAdapter
    ReadOnly _dsActuales As DataSet = New DataSet()
    Dim _terminadas As List(Of SQLiteDataAdapter)
    Dim parpadeo As Storyboard = New Storyboard()
    Dim Hora1, Hora2, Hora3, Hora4, Hora5 As String
    ReadOnly _dsTerminadas As DataSet = New DataSet()
    Dim consultas As DataTable = New DataTable()

    ''' <summary>
    ''' Window_Loaded. Al cargar la ventana, activo el temporizador (1 segundo), consulto las colas,
    ''' cargo el nombre de las especialidades en pantalla y llamo al método que actualizará el panel de citas
    ''' cada segundo.
    ''' </summary>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ''Storyboard encargado del "parpadeo" de 30 segundos de la cita llamada.
        parpadeo = CType(TryFindResource("Parpadeo"), Storyboard)

        Dim Timer As DispatcherTimer = New DispatcherTimer()
        AddHandler Timer.Tick, AddressOf dispatcherTimer_Tick
        Timer.Interval = New TimeSpan(0, 0, 0, 1)
        Timer.Start()

        consultas = _Negocio.ConsultarColas()

        Dim Count As Integer = consultas.Rows.Count
        For index = 0 To Count - 1
            Dim Item As Integer = CType(consultas.Rows(index).Item("NumCola"), Integer)
            Select Case Item
                Case 1
                    Especialidad1.DataContext = TryCast(consultas.Rows(index).Item("NumMesa"), String)
                Case 2
                    Especialidad2.DataContext = TryCast(consultas.Rows(index).Item("NumMesa"), String)
                Case 3
                    Especialidad3.DataContext = TryCast(consultas.Rows(index).Item("NumMesa"), String)
                Case 4
                    Especialidad4.DataContext = TryCast(consultas.Rows(index).Item("NumMesa"), String)
                Case 5
                    Especialidad5.DataContext = TryCast(consultas.Rows(index).Item("NumMesa"), String)
                Case Else
            End Select
        Next
        Actualizar()
    End Sub

    ''' <summary>
    ''' Actualizar. Método encargado de actualizar el panel de citas cada segundo.
    ''' </summary>
    Public Sub Actualizar()

        ''Reloj
        Fecha.DataContext = Now.ToString()

        ''Relleno el dataset encargado de las citas actuales.
        _actuales = _Negocio.ConsultarActuales()
        _dsActuales.Clear()
        _actuales.Fill(_dsActuales, "Actuales")

        _terminadas = _Negocio.ConsultarTerminadas()
        _dsTerminadas.Clear()

        ''Relleno los datasets con las últimas citas llamadas de cada una de las colas.
        Dim i As Integer = 1
        For Each T In _terminadas
            T.Fill(_dsTerminadas, "Terminadas" + CStr(i))
            i = i + 1
        Next

        Anteriores1.DataContext = _dsTerminadas
        Anteriores2.DataContext = _dsTerminadas
        Anteriores3.DataContext = _dsTerminadas
        Anteriores4.DataContext = _dsTerminadas
        Anteriores5.DataContext = _dsTerminadas

        Dim Count As Integer = _dsActuales.Tables("Actuales").Rows.Count

        ''Vacío los DataContext de las citas actuales para limpiar el panel en caso de que ya no queden citas
        ''sin terminar.
        ConsultaActual1.DataContext = Nothing
        HoraActual1.DataContext = Nothing

        ConsultaActual2.DataContext = Nothing
        HoraActual2.DataContext = Nothing

        ConsultaActual3.DataContext = Nothing
        HoraActual3.DataContext = Nothing

        ConsultaActual4.DataContext = Nothing
        HoraActual4.DataContext = Nothing

        ConsultaActual5.DataContext = Nothing
        HoraActual5.DataContext = Nothing

        ''Con este bucle relleno cada una de las citas actuales de las 5 colas y las hago parpadear en caso de que la cita actual cambie.
        For index = 0 To Count - 1
            Dim Item As Integer = CType(_dsActuales.Tables("Actuales").Rows(index).Item("NumCola"), Integer)
            Select Case Item
                ''El código se repite por cada una de las colas
                Case 1
                    ''Controlo el parpadeo en caso de que la hora que viene sea distinta a la que ya aparece en el panel.
                    If ((Not Hora1 = "") And (Not Hora1 = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String))) Then
                        If (Not parpadeo Is Nothing) Then
                            parpadeo.Begin(HoraActual1)
                        End If
                    End If
                    ''Cargo el nombre de la consulta y la hora.
                    ConsultaActual1.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("NombreConsulta"), String)
                    HoraActual1.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String)
                    ''Variable donde almaceno la hora para compararla con la hora que viene de la Select y así controlar el parpadeo.
                    Hora1 = HoraActual1.Text
                Case 2
                    If ((Not Hora2 = "") And (Not Hora2 = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String))) Then

                        If (Not parpadeo Is Nothing) Then

                            parpadeo.Begin(HoraActual2)
                        End If
                    End If
                    ConsultaActual2.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("NombreConsulta"), String)
                    HoraActual2.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String)
                    Hora2 = HoraActual2.Text
                Case 3
                    If ((Not Hora3 = "") And (Not Hora3 = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String))) Then
                        If (Not parpadeo Is Nothing) Then
                            parpadeo.Begin(HoraActual3)
                        End If
                    End If
                    ConsultaActual3.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("NombreConsulta"), String)
                    HoraActual3.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String)
                    Hora3 = HoraActual3.Text
                Case 4
                    If ((Not Hora4 = "") And (Not Hora4 = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String))) Then
                        If (Not parpadeo Is Nothing) Then
                            parpadeo.Begin(HoraActual4)
                        End If
                    End If
                    ConsultaActual4.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("NombreConsulta"), String)
                    HoraActual4.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String)
                    Hora4 = HoraActual4.Text
                Case 5
                    If ((Not Hora5 = "") And (Not Hora5 = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String))) Then
                        If (Not parpadeo Is Nothing) Then
                            parpadeo.Begin(HoraActual5)
                        End If
                    End If
                    ConsultaActual5.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("NombreConsulta"), String)
                    HoraActual5.DataContext = TryCast(_dsActuales.Tables("Actuales").Rows(index).Item("Hora"), String)
                    Hora5 = HoraActual5.Text
                Case Else

            End Select
        Next
    End Sub

    Public Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Actualizar()
    End Sub

End Class
