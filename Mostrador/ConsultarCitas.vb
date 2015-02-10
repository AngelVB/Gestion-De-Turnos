Option Explicit On
Option Strict On

Imports Microsoft.Reporting.WinForms

''' <summary>
''' ConsultarDias.vb
''' Formulario que muestra todas las citas.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class ConsultarCitas
    ReadOnly _Negocio As New Negocio.NegocioMostrador
    Dim Id As String = ""
    Dim NombreMedico As String = ""
    Dim NombrePaciente As String = ""
    Dim Fila As Integer = -1

    ''' <summary>
    ''' ConsultarDias_Load
    ''' Evento OnLoad. Cargamos los datos de las citas y añadimos los botones de eliminar y actualizar.
    ''' </summary>
    Private Sub ConsultarDias_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Enter

        Dim NumFila As Integer = -1
        NumFila = ResultBusqueda.FilaSeleccionada
        Dim Fila As DataGridViewRow

        If Mostrador.MenuSelec = 3 Then
            Text = "Listados Citas Médico"
            DPFecha.Visible = True
            LabelFecha.Visible = True
            CBHora.Visible = False
            LabelHora.Visible = False
        ElseIf Mostrador.MenuSelec = 4 Then
            Text = "Listados Citas Paciente"
            DPFecha.Visible = False
            LabelFecha.Visible = False
            CBHora.Visible = True
            LabelHora.Visible = True
        End If
        ''Comprobamos si venimos del formulario de búsqueda.
        If NumFila <> -1 Then
            Fila = ResultBusqueda.ListadoBusq.Rows(NumFila)

            Dim R As DataRowView = DirectCast(Fila.DataBoundItem, DataRowView)

            If Mostrador.MenuSelec = 3 Then ''Datos Médico
                Id = Fila.Cells("NumColegiado").Value.ToString
                NombreMedico = Fila.Cells("Nombre").Value.ToString + " " + Fila.Cells("Apellidos").Value.ToString
                Text = "Listado Consultas Dr. " + NombreMedico + " nº Colegiado: " + Id

            ElseIf Mostrador.MenuSelec = 4 Then ''Datos Paciente
                Id = Fila.Cells("SIP").Value.ToString
                NombrePaciente = Fila.Cells("Nombre").Value.ToString + " " + Fila.Cells("Apellidos").Value.ToString
                Text = "Listado Citas Paciente: " + NombrePaciente + " con SIP: " + Id

            End If

            ResultBusqueda.Close()
        End If
        If Mostrador.MenuSelec = 4 Then
            ListadoCitas.DataSource = _Negocio.ConsultarCitasPaciente(Id)
        ElseIf Mostrador.MenuSelec = 3 Then
            ListadoCitas.DataSource = _Negocio.ConsultarCitasMedico(Id, DPFecha.Value)
        End If
        Resetear()
    End Sub

    ''' <summary>
    ''' Resetear
    ''' Resetea las propiedades de los controles del formulario.
    ''' </summary>
    Public Sub Resetear()
        If ListadoCitas.Columns.Count <> 0 Then
            ListadoCitas.Columns("Id").Visible = False
            ListadoCitas.Columns("Fecha").Width = 80
            ListadoCitas.Columns("Hora").Visible = True
            ListadoCitas.Columns("Hora").ReadOnly = True
            ListadoCitas.Columns("Duracion").Width = 55
            ListadoCitas.Columns("Terminada").Visible = False
            ListadoCitas.Columns("TipoCita").Visible = False
            ListadoCitas.Columns("Cola_Id").Visible = False
            ListadoCitas.Columns("Paciente_Id").Visible = False

            If Mostrador.MenuSelec = 4 Then

                If Not ListadoCitas.Columns.Contains("btn") Then
                    Dim Btn As New DataGridViewButtonColumn()
                    ListadoCitas.Columns.Add(Btn)
                    Btn.HeaderText = ""
                    Btn.Text = "Eliminar"
                    Btn.Name = "btn"
                    Btn.UseColumnTextForButtonValue = True

                    Dim Btn2 As New DataGridViewButtonColumn()

                    ListadoCitas.Columns.Add(Btn2)
                    Btn2.HeaderText = ""
                    Btn2.Text = "Actualizar"
                    Btn2.Name = "btn2"
                    Btn2.UseColumnTextForButtonValue = True
                   
                End If
                ListadoCitas.Columns("btn").Visible = True
                ListadoCitas.Columns("btn2").Visible = True
                Button1.Visible = False
            ElseIf Mostrador.MenuSelec = 3 Then
                ListadoCitas.Columns("Nombre").Visible = True
                ListadoCitas.Columns("Apellidos").Visible = True
                ListadoCitas.Columns("Telefono").Visible = True

                ListadoCitas.ReadOnly = True
                If ListadoCitas.Columns.Contains("btn") Then
                    ListadoCitas.Columns("btn").Visible = False
                    ListadoCitas.Columns("btn2").Visible = False
                    Button1.Visible = True
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' DataGridView1_CellClick
    ''' Controla los botones de eliminar y actualizar cita.
    ''' </summary>
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListadoCitas.CellClick
        If Mostrador.MenuSelec = 4 Then

            If (e.ColumnIndex = 0 And e.RowIndex >= 0) Then ''Controlo el botón eliminar
                Dim Valor As Integer = CInt(ListadoCitas.Rows(e.RowIndex).Cells("Id").Value.ToString)
                Dim Result As Integer = _Negocio.EliminarCita(Valor)

                If Result = 1 Then

                    ListadoCitas.DataSource = _Negocio.ConsultarCitasPaciente(Id)

                Else
                    MsgBox("Error eliminando Cita")
                End If
            End If

            If (e.ColumnIndex = 1 And e.RowIndex >= 0) Then ''Controlo el botón eliminar

                Dim Valor As Integer = CInt(ListadoCitas.Rows(e.RowIndex).Cells("Id").Value.ToString)

                Dim Duracion As Integer = CInt(ListadoCitas.Rows(e.RowIndex).Cells("Duracion").Value.ToString)
                If Duracion < 15 Or Duracion > 59 Then
                    MsgBox("La duración debe estar comprendida entre 15 y 59 minutos.")
                Else
                    Dim Fecha As Date = CDate(ListadoCitas.Rows(e.RowIndex).Cells("Fecha").Value.ToString)

                    If ComprobarFestivo(Fecha) Then

                        MsgBox("Este día es festivo, introduzca otra fecha.")

                    Else
                        Dim Hora As String = ListadoCitas.Rows(e.RowIndex).Cells("Hora").Value.ToString
                        Dim PId As Integer = CType(ListadoCitas.Rows(e.RowIndex).Cells("Id").Value.ToString, Integer)

                        Dim PDuracion As Integer = CType(ListadoCitas.Rows(e.RowIndex).Cells("Duracion").Value.ToString, Integer)
                        Dim PTerminada As Integer = 0
                        If CBool(ListadoCitas.Rows(e.RowIndex).Cells("Terminada").Value) = True Then
                            PTerminada = 1
                        Else
                            PTerminada = 0
                        End If

                        Dim PTipoCita As Integer = 0
                        If CBool(ListadoCitas.Rows(e.RowIndex).Cells("TipoCita").Value) = True Then
                            PTipoCita = 1
                        Else
                            PTipoCita = 0
                        End If
                        Dim PColaId As Integer = CType(ListadoCitas.Rows(e.RowIndex).Cells("Cola_Id").Value.ToString, Integer)
                        Dim PPacienteId As Integer = CType(ListadoCitas.Rows(e.RowIndex).Cells("Paciente_Id").Value.ToString, Integer)
                        Dim Result As Integer = _Negocio.ActualizarCita(PId, Fecha, Hora, PDuracion, PTerminada, PTipoCita, PColaId, PPacienteId)

                        If Result = 1 Then
                            MsgBox("Cita actualizada con éxito")
                            ListadoCitas.DataSource = _Negocio.ConsultarCitasPaciente(Id)
                        ElseIf Result = 2 Then
                            MsgBox("Error modificando Cita. Ya hay una cita durante ese periodo de tiempo.")
                        Else

                            MsgBox("Error actualizando Cita")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    '''ComprobarFestivo
    '''Comprobamos si la fecha seleccionada es Festivo
    ''' <param name="PFestivo">(Date)Fecha seleccionada.</param>
    ''' </summary>
    Private Function ComprobarFestivo(ByVal PFestivo As Date) As Boolean
        Dim result As Integer

        result = _Negocio.ConsultarFestivo(PFestivo)
        If result = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    '''Rellenahoras
    '''Función encargada de rellenar el ComboBox de horas únicamente con las horas disponibles para un día y una cola en concreto.
    ''' </summary>
    ''' <param name="Fecha">(Date) Fecha cita</param>
    ''' <param name=" Pcola ">(Integer) Cola cita</param> 
    Private Sub Rellenahoras(ByVal Fecha As Date, ByVal PCola As Integer)
        Dim ListaHoras As New List(Of String)

        ''Comprobamos las horas ya ocupadas con ese día en la cita seleccionada.
        Dim PFecha As DateTime
        PFecha = New DateTime(Fecha.Year, Fecha.Month, Fecha.Day)

        ''Rellenamos ComboBox con todas las horas
        Dim hora As String
        CBHora.Items.Clear()
        ''borramos las horas ya transcurridas en el caso de cita inmediata.

        For i As Integer = 8 To 14
            For j As Integer = 0 To 45 Step 15
                If i <= 9 And j <= 9 Then
                    hora = "0" + i.ToString + ":0" + j.ToString
                ElseIf i <= 9 And j > 9 Then
                    hora = "0" + i.ToString + ":" + j.ToString
                ElseIf i > 9 And j <= 9 Then
                    hora = i.ToString + ":0" + j.ToString
                Else
                    hora = i.ToString + ":" + j.ToString
                End If
                ListaHoras.Add(hora)
            Next
        Next

        Dim Horas As DataTable = _Negocio.ListadoHoras(PFecha, PCola)
        Dim Coincide As Integer = -1

        Dim Horafin As String
        Dim Veces As Integer = 0

        ''recorremos la lista de citas devuelta
        For Each Row As DataRow In Horas.Rows


            ''Comprobamos hora inicio
            Coincide = ListaHoras.IndexOf(CStr(Row("Hora")))
            If Coincide >= 0 Then
                ListaHoras.RemoveAt(Coincide)
            End If


            ''Comprobamos hora fin cita y borramos los periodos intermedios.

            Dim HoraTemp As DateTime = New DateTime(Fecha.Year, Fecha.Month, Fecha.Day, CInt(CStr(Row("Hora")).Substring(0, 2)), CInt(CStr(Row("Hora")).Substring(3, 2)), 0)

            If CInt(Row("Duracion")) > 15 And CInt(Row("Duracion")) <= 30 Then
                Veces = 1
            ElseIf CInt(Row("Duracion")) > 30 And CInt(Row("Duracion")) <= 45 Then
                Veces = 2
            ElseIf CInt(Row("Duracion")) > 45 And CInt(Row("Duracion")) <= 60 Then
                Veces = 3
            End If

            If Veces > 0 Then
                For I As Integer = 1 To Veces
                    HoraTemp = HoraTemp.AddMinutes(15)

                    If HoraTemp.Hour >= 10 And HoraTemp.Minute >= 10 Then
                        Horafin = HoraTemp.Hour.ToString + ":" + HoraTemp.Minute.ToString

                    ElseIf HoraTemp.Hour < 10 And HoraTemp.Minute >= 10 Then
                        Horafin = "0" + HoraTemp.Hour.ToString + ":" + HoraTemp.Minute.ToString
                    ElseIf HoraTemp.Hour >= 10 And HoraTemp.Minute < 10 Then
                        Horafin = HoraTemp.Hour.ToString + ":0" + HoraTemp.Minute.ToString
                    Else
                        Horafin = "0" + HoraTemp.Hour.ToString + ":0" + HoraTemp.Minute.ToString
                    End If

                    Coincide = ListaHoras.IndexOf(Horafin)
                    If Coincide >= 0 Then
                        ListaHoras.RemoveAt(Coincide)
                    End If
                Next
            End If
        Next

        For Each C As String In ListaHoras
            CBHora.Items.Add(C)
        Next
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

    ''' <summary>
    '''ListadoCitas_RowEnter
    '''Función encargada de rellenar el ComboBox de horas únicamente con las horas disponibles para un día y una cola en concreto al cambiar de cita.
    ''' </summary>
    Private Sub ListadoCitas_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ListadoCitas.RowEnter

        If e.RowIndex >= 0 Then
            Fila = e.RowIndex
        End If
        Dim Fecha As Date = CDate(ListadoCitas.Rows(Fila).Cells("Fecha").Value.ToString)
        Dim Cola As Integer = CType(ListadoCitas.Rows(e.RowIndex).Cells("Cola_Id").Value.ToString, Integer)
        Rellenahoras(Fecha, Cola)
    End Sub

    ''' <summary>
    '''CBHora_SelectedIndexChanged
    '''Función encargada de actualizar la hora del datagrid al cambiar de hora en el combobox
    ''' </summary>
    Private Sub CBHora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBHora.SelectedIndexChanged
        If Fila >= 0 Then
            ListadoCitas.Rows.Item(Fila).Cells.Item("Hora").Value = CBHora.Text
            CBHora.SelectedText = ""
        End If
    End Sub

    ''' <summary>
    '''DPFecha_ValueChanged
    '''Función encargada de actualizar datagridview con las citas del médico al cambiar de fecha en el combobox
    ''' </summary>
    Private Sub DPFecha_ValueChanged(sender As Object, e As EventArgs) Handles DPFecha.ValueChanged

        ListadoCitas.DataSource = _Negocio.ConsultarCitasMedico(Id, DPFecha.Value)
        Resetear()
    End Sub

    ''' <summary>
    '''Button1_Click
    '''Función encargada de pasar los datos del datagridview al Reportviewer del formulario ListadoCitasMedico
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

            Dim Citas As New List(Of CitasMedico)
        For Each Row As DataGridViewRow In ListadoCitas.Rows
            Dim Cita As New CitasMedico()
            

            Cita.Id = CInt(Row.Cells("Id").Value)
            Cita.Fecha = CDate(Row.Cells("Fecha").Value)
            Cita.Hora = CStr(Row.Cells("Hora").Value)
            Cita.Duracion = CInt(Row.Cells("Duracion").Value)
            Cita.Terminada = CInt(Row.Cells("Terminada").Value)
            Cita.TipoCita = CInt(Row.Cells("TipoCita").Value)
            Cita.Cola_Id = CInt(Row.Cells("Cola_Id").Value)
            Cita.Paciente_Id = CInt(Row.Cells("Paciente_Id").Value)
            Cita.Nombre = CStr(Row.Cells("Nombre").Value)
            Cita.Apellidos = CStr(Row.Cells("Apellidos").Value)
            Cita.Telefono = CStr(Row.Cells("Telefono").Value)
            Citas.Add(Cita)
        Next

  
        Dim frm As New ListadoCitasMedico()
        frm.Citas = Citas
        frm.NombreMedico = NombreMedico

        frm.MdiParent = Mostrador
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
End Class