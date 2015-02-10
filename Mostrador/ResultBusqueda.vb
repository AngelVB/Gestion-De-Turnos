Option Explicit On
Option Strict On

''' <summary>
''' ResultBusqueda.vb
''' Contiene el formulario en el que se muestra un listado con los resultados encontrados.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class ResultBusqueda
    ReadOnly _Negocio As New Negocio.NegocioMostrador
    Private _FilaSeleccionada As Integer = -1
    Dim btn As New DataGridViewButtonColumn()

    ''' <summary>
    ''' ListadoMedicos_Load. Hace que, al cargar el formulario, asignamos propiedades al DataGridViewButtonColumn.
    ''' </summary>
    Private Sub ListadoMedicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn.HeaderText = ""
        btn.Text = "Mostrar"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
    End Sub

    ''' <summary>
    ''' ListadoMed_CellClick. Hace que, al hacer clic en Mostrar, se abra el formulario de Altas con los datos de la persona seleccionada.
    ''' </summary>
    Private Sub ListadoMed_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListadoBusq.CellClick

        If e.RowIndex >= 0 And e.ColumnIndex = 22 Then ''Controlo el botón eliminar
            FilaSeleccionada = e.RowIndex

            Select Case Mostrador.MenuSelec
                Case 1, 2
                    Altas.MdiParent = Mostrador
                    Altas.WindowState = FormWindowState.Minimized
                    Altas.WindowState = FormWindowState.Normal

                    Altas.Show()
                Case 3, 4
                    ConsultarCitas.MdiParent = Mostrador
                    ConsultarCitas.WindowState = FormWindowState.Minimized
                    ConsultarCitas.WindowState = FormWindowState.Normal
                    ConsultarCitas.Show()
                Case 8
                    AnyadirCita.MdiParent = Mostrador
                    AnyadirCita.WindowState = FormWindowState.Minimized
                    AnyadirCita.WindowState = FormWindowState.Normal
                    AnyadirCita.Show()
            End Select

        End If

        '' FilaSeleccionada = e.RowIndex
        '' MsgBox(ListadoBusq.Rows(FilaSeleccionada).Cells("Baja").Value)
    End Sub
   
    ''' <summary>
    ''' ResultBusqueda_Enter. Hace que, al entrar en el formulario, se muestren unas columnas determinadas con los datos de la búsqueda
    ''' </summary>
    Private Sub ResultBusqueda_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        ListadoBusq.DataSource = Buscar.Resultados
        Select Case Mostrador.MenuSelec
            Case 1, 3
                Me.Text = "Listado Médicos Encontrados"
                For I As Integer = 0 To ListadoBusq.ColumnCount - 1
                    ListadoBusq.Columns(I).Visible = False
                Next
                ListadoBusq.Columns("Nombre").Visible = True
                ListadoBusq.Columns("Apellidos").Visible = True
                ListadoBusq.Columns("Nif").Visible = True
                ListadoBusq.Columns("NumColegiado").Visible = True

            Case 2, 4, 8

                Me.Text = "Listado Pacientes Encontrados"
                For I As Integer = 0 To ListadoBusq.ColumnCount - 1
                    ListadoBusq.Columns(I).Visible = False
                Next
                ListadoBusq.Columns("Nombre").Visible = True
                ListadoBusq.Columns("Apellidos").Visible = True
                ListadoBusq.Columns("Nif").Visible = True
                ListadoBusq.Columns("SIP").Visible = True





        End Select
        If ListadoBusq.Columns.Contains(btn) Then
            ListadoBusq.Columns("btn").Visible = True
        Else
            ListadoBusq.Columns.Add(btn)
        End If
        ListadoBusq.Sort(ListadoBusq.Columns("Apellidos"), System.ComponentModel.ListSortDirection.Ascending)


    End Sub

    '''<summary>
    '''Propiedad FilaSeleccionada (Integer) Fila seleccionada.
    '''</summary>
    Public Property FilaSeleccionada As Integer
        Get
            FilaSeleccionada = _FilaSeleccionada
        End Get
        Set(Value As Integer)
            _FilaSeleccionada = Value
        End Set
    End Property

    Private Sub ListadoBusq_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListadoBusq.CellContentClick

    End Sub
End Class