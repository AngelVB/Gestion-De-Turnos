Option Explicit On
Option Strict On

''' <summary>
''' ConsultarDias.vb
''' Formulario que muestra todas las colas.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class ConsultarColas
    ReadOnly _Negocio As New Negocio.NegocioMostrador

    ''' <summary>
    ''' ConsultarDias_Load
    ''' Evento OnLoad. Cargamos los datos de los festivos y añadimos los botones de eliminar.
    ''' </summary>
    Private Sub ConsultarDias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListadoColas.DataSource = _Negocio.ConsultarColas

        ListadoColas.Columns("Id").Visible = False
        ListadoColas.Columns("NumCola").Width = 100
        ListadoColas.Columns("NumMesa").Width = 100
        ListadoColas.Columns("MedicoId").Visible = False

        Dim Btn As New DataGridViewButtonColumn()

        ListadoColas.Columns.Add(Btn)
        Btn.HeaderText = ""
        Btn.Text = "Eliminar"
        Btn.Name = "btn"
        Btn.UseColumnTextForButtonValue = True

        Dim Btn2 As New DataGridViewButtonColumn()

        ListadoColas.Columns.Add(Btn2)
        Btn2.HeaderText = ""
        Btn2.Text = "Actualizar"
        Btn2.Name = "btn2"
        Btn2.UseColumnTextForButtonValue = True

    End Sub

    ''' <summary>
    ''' DataGridView1_CellClick
    ''' Elimina el festivo seleccionado.
    ''' </summary>
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListadoColas.CellClick
       
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then ''Controlo el botón eliminar
            Dim Valor As Integer = CInt(ListadoColas.Rows(e.RowIndex).Cells("Id").Value.ToString)
            Dim Result As Integer = _Negocio.EliminarCitaPorCola(Valor)

            If Result = 0 Then
                Dim Result1 As Integer = _Negocio.EliminarCola(Valor)
                If Result1 = 1 Then
                    ListadoColas.DataSource = _Negocio.ConsultarColas()
                Else
                    MsgBox("Error eliminando Cola")
                End If
            Else
                MsgBox("La Cola contiene citas. No se puede eliminar")
            End If
        End If
        If e.ColumnIndex = 1 And e.RowIndex >= 0 Then ''Controlo el botón eliminar
            Dim Valor As Integer = CInt(ListadoColas.Rows(e.RowIndex).Cells("Id").Value.ToString)

            Dim NumCola As Integer = CInt(ListadoColas.Rows(e.RowIndex).Cells("NumCola").Value.ToString)
            If NumCola < 1 Or NumCola > 5 Then
                MsgBox("El número de cola debe estar entre 1 y 5.")
            Else
                Dim NumMesa As String = ListadoColas.Rows(e.RowIndex).Cells("NumMesa").Value.ToString
                Dim MedicoId As Integer = CInt(ListadoColas.Rows(e.RowIndex).Cells("MedicoId").Value.ToString)
                Dim Result As Integer = _Negocio.ActualizarCola(Valor, NumCola, NumMesa.ToUpper, MedicoId)
                If Result = 1 Then
                    MsgBox("Cola actualizada con éxito")
                    ListadoColas.DataSource = _Negocio.ConsultarColas()
                Else
                    MsgBox("Error actualizando Cola")
                End If
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