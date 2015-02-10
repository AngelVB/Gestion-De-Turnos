Option Explicit On
Option Strict On

''' <summary>
''' ConsultarDias.vb
''' Formulario que muestra todos los festivos del año actual
''' </summary>
''' <author> Ángel Valera</author> 
Public Class ConsultarDias
    ReadOnly _Negocio As New Negocio.NegocioMostrador

    ''' <summary>
    ''' ConsultarDias_Load
    ''' Evento OnLoad. Cargamos los datos de los festivos y añadimos los botones de eliminar.
    ''' </summary>
    Private Sub ConsultarDias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListadoFestivos.DataSource = _Negocio.ConsultarFestivos
        ListadoFestivos.Columns("Id").Visible = False
        ListadoFestivos.Columns("NombreFestivo").Width = 230
        Dim btn As New DataGridViewButtonColumn()

        ListadoFestivos.Columns.Add(btn)
        btn.HeaderText = ""
        btn.Text = "Eliminar"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True

    End Sub

    ''' <summary>
    ''' DataGridView1_CellClick
    ''' Elimina el festivo seleccionado.
    ''' </summary>
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListadoFestivos.CellClick

        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then ''Controlo el botón eliminar
            Dim Valor As Integer = CInt(ListadoFestivos.Rows(e.RowIndex).Cells("Id").Value.ToString)
            Dim Result As Integer = _Negocio.EliminarFestivo(Valor)
            If Result = 1 Then
                ListadoFestivos.DataSource = _Negocio.ConsultarFestivos()
            Else
                MsgBox("Error eliminando Festivo")
            End If
        End If
    End Sub

    ''' <summary>
    ''' BtCerrar_Click
    '''Cierra la ventana.
    ''' </summary>
    Private Sub BtCerrar_Click(sender As Object, e As EventArgs) Handles BtCerrar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' ConsultarDias_FormClosing
    '''Evento FormClosing. Llama a la función Salir del mostrador.
    ''' </summary>
    Private Sub ConsultarDias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
         Mostrador.Salir(e)
    End Sub
End Class