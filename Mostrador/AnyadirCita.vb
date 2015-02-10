Option Explicit On
Option Strict On

Imports System.Drawing.Printing

''' <summary>
''' AnyadirCita.vb
'''Formulario para añadir citas.
''' </summary>
''' <author> Ángel Valera</author>
Public Class AnyadirCita
    ReadOnly _Negocio As New Negocio.NegocioMostrador
    Dim Id As Integer = 0

    ''' <summary>
    '''Domingos
    ''' Calculamos el primer domingo desde la fecha actual y llamamos a la función MarcarDomingos.
    ''' </summary>
    Private Sub Domingos()
        'Integer para los dias
        Dim Dia As Date = DateTime.Today
        Select Case Dia.DayOfWeek
            Case DayOfWeek.Sunday
                MarcarDomingos(Dia)
            Case DayOfWeek.Monday
                Dia = Dia.AddDays(6)
                MarcarDomingos(Dia)
            Case DayOfWeek.Tuesday
                Dia = Dia.AddDays(5)
                MarcarDomingos(Dia)
            Case DayOfWeek.Wednesday
                Dia = Dia.AddDays(4)
                MarcarDomingos(Dia)
            Case DayOfWeek.Thursday
                Dia = Dia.AddDays(3)
                MarcarDomingos(Dia)
            Case DayOfWeek.Friday
                Dia = Dia.AddDays(2)
                MarcarDomingos(Dia)
            Case DayOfWeek.Saturday
                Dia = Dia.AddDays(1)
                MarcarDomingos(Dia)
        End Select
    End Sub

    ''' <summary>
    ''' MarcarDomingos. Marca en negrita todos los domingos del calendario.
    ''' </summary>
    ''' <param name="Inicio">(Date)Primer Domingo.</param>
    Private Sub MarcarDomingos(ByVal Inicio As Date)
        Dim final As Date = New DateTime(Now.Year, 12, 31)
        While inicio <= final
            MonthCalendar1.AddBoldedDate(inicio)
            inicio = inicio.AddDays(7)
        End While

    End Sub

    ''' <summary>
    '''MarcarFestivos
    ''' Marca en negrita todos los días festivos introducidos en el sistema.
    ''' </summary>
    Private Sub MarcarFestivos()

        Dim festivos As DataTable = _Negocio.ConsultarFestivos()
        For Each row As DataRow In festivos.Rows
            MonthCalendar1.AddBoldedDate(CDate(row("FechaFestivo")))
        Next

        Domingos()
        MonthCalendar1.UpdateBoldedDates()
    End Sub

    ''' <summary>
    '''AnyadirCita_Enters
    '''Preparamos el formulario para añadir citas.
    ''' </summary>
    Private Sub AnyadirCita_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Dim NumFila As Integer = -1
        Resetear()
        NumFila = ResultBusqueda.FilaSeleccionada
        Dim Fila As DataGridViewRow
        '' DPFecha.MinDate = Now.AddDays(1)
        ''DPFecha.MaxDate = New DateTime(Now.Year, 12, 31)
        MonthCalendar1.MinDate = Now.AddDays(1)
        MonthCalendar1.MaxDate = New DateTime(Now.Year, 12, 31)
        MarcarFestivos()
        If NumFila = -1 Then

        Else
            Fila = ResultBusqueda.ListadoBusq.Rows(NumFila)
            Id = CInt(Fila.Cells("Id").Value)
            TBSIP.Text = Fila.Cells("SIP").Value.ToString
            TBNombre.Text = Fila.Cells("Nombre").Value.ToString
            TBApellidos.Text = Fila.Cells("Apellidos").Value.ToString
            ResultBusqueda.Close()
            NumFila = -1
            With CBCola
                .DisplayMember = "NumMesa"
                .ValueMember = "Id"
                .DataSource = _Negocio.ConsultarColas
                .Text = ""
            End With
            If CBCola.Items.Count > 0 Then
                CBCola.SelectedItem = 0
            End If
        End If
    End Sub

    ''' <summary>
    '''Resetear
    ''' Resetea las propiedades de los campos del formulario.
    ''' </summary>
    Public Sub Resetear()

        CBCola.Text = ""
        CBHora.Text = ""
        TBApellidos.Text = ""
        TBNombre.Text = ""
        TBDuracion.Text = ""
        TBSIP.Text = ""
        TipoCita.Checked = False
    End Sub

    ''' <summary>
    '''Button1_Click
    '''Validamos datos e intentamos introducir una cita en la base de datos.
    ''' Muestra el ticket si la cita se ha añadido con éxito.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTAnyadir.Click

        Dim PCita As Integer

        If CStr(CBCola.Text) = "" Then
            MsgBox("Debe seleccionar una consulta.")
        ElseIf CStr(CBHora.Text) = "" Then
            MsgBox("Debe introducir una hora")
        ElseIf CStr(TBDuracion.Text) = "" Then
            MsgBox("Debe introducir una duración entre 15 y 59 minutos")
        ElseIf CInt(TBDuracion.Text) < 15 Or CInt(TBDuracion.Text) > 59 Then
            MsgBox("Debe introducir una duración entre 15 y 59 minutos")

        Else
            If TipoCita.Checked Then
                PCita = 1
            Else
                PCita = 0
            End If
            Dim PFecha As DateTime
            If TipoCita.Checked Then ''Cita Inmediata
                PFecha = New DateTime(Now.Year, Now.Month, Now.Day, CInt(CBHora.Text.Substring(0, 2)), CInt(CBHora.Text.Substring(3, 2)), 0)
            Else
                PFecha = New DateTime(MonthCalendar1.SelectionStart.Year, MonthCalendar1.SelectionStart.Month, MonthCalendar1.SelectionStart.Day, CInt(CBHora.Text.Substring(0, 2)), CInt(CBHora.Text.Substring(3, 2)), 0)
            End If
            If ComprobarFestivo(PFecha) = False Then


                Dim Result As Integer = _Negocio.InsertarCita(PFecha, CInt(TBDuracion.Text), 0, PCita, CInt(CBCola.SelectedValue), Id)
                If Result = 1 Then

                    MsgBox("Cita insertada con éxito")

                    ''Muestro la vista previa antes de imprimir para que sea más útil a la hora de corregir, 
                    ''Pero creo que a la hora de trabajar con el programa, lo lógico es que imprimiera directamente.
                    VistaPrevia()
                    Rellenahoras()
                    CBCola.Text = ""
                    CBHora.Text = ""
                    TBDuracion.Text = ""
                ElseIf Result = 2 Then
                    MsgBox("Error creando Cita. Ya hay una cita durante ese periodo de tiempo.")
                Else
                    MsgBox("Error creando cita.")
                End If
            Else
                MsgBox("Este día es festivo, seleccione otra fecha.")
                MonthCalendar1.Focus()
            End If
        End If
    End Sub

    ''' <summary>
    '''TipoCita_CheckedChanged
    '''Ocultamos el calendario en caso de marcar cita inmediata.
    ''' </summary>
    Private Sub TipoCita_CheckedChanged(sender As Object, e As EventArgs) Handles TipoCita.CheckedChanged
        If TipoCita.Checked Then
            MonthCalendar1.Visible = False
            Label4.Visible = False
        Else
            Label4.Visible = True
            MonthCalendar1.Visible = True
            MonthCalendar1.MinDate = Now.AddDays(1)
        End If
        Rellenahoras()
    End Sub

    ''' <summary>
    '''ComprobarFestivo
    '''Comprobamos si la fecha seleccionada es Festivo
    ''' <param name="PFestivo">(Date)Fecha seleccionada.</param>
    ''' </summary>
    Private Function ComprobarFestivo(ByVal PFestivo As Date) As Boolean
        Dim result As Integer
        result = _Negocio.ConsultarFestivo(PFestivo)
        If result = 1 Or PFestivo.DayOfWeek = DayOfWeek.Sunday Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    '''Rellenahoras
    '''Función encargada de rellenar el ComboBox de horas únicamente con las horas disponibles para un día y una cola en concreto.
    ''' </summary>
    Private Sub Rellenahoras()

        ''Comprobamos las horas ya ocupadas con ese día en la cita seleccionada.
        Dim PFecha As DateTime
        If TipoCita.Checked Then ''Cita Inmediata
            PFecha = New DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 0)

        Else
            PFecha = New DateTime(MonthCalendar1.SelectionStart.Year, MonthCalendar1.SelectionStart.Month, MonthCalendar1.SelectionStart.Day)
        End If

        If ComprobarFestivo(PFecha) Then

            MsgBox("Este día es festivo, seleccione otra fecha.")
            MonthCalendar1.Focus()
            CBHora.Items.Clear()
        Else
            ''Rellenamos ComboBox con todas las horas
            Dim hora As String
            CBHora.Items.Clear()

            ''borramos las horas ya transcurridas en el caso de cita inmediata.
            If TipoCita.Checked Then ''Cita Inmediata
                For i As Integer = 8 To 14

                    For j As Integer = 0 To 45 Step 15

                        If PFecha.Hour <= i Then

                            If (PFecha.Hour < i) Or (PFecha.Hour = i And PFecha.Minute < j) Then

                                If i <= 9 And j <= 9 Then
                                    hora = "0" + i.ToString + ":0" + j.ToString
                                ElseIf i <= 9 And j > 9 Then
                                    hora = "0" + i.ToString + ":" + j.ToString
                                ElseIf i > 9 And j <= 9 Then
                                    hora = i.ToString + ":0" + j.ToString
                                Else
                                    hora = i.ToString + ":" + j.ToString
                                End If
                                CBHora.Items.Add(hora)
                            End If
                        End If
                    Next

                Next
            Else
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
                        CBHora.Items.Add(hora)
                    Next
                Next
            End If


            Dim Horas As DataTable = _Negocio.ListadoHoras(PFecha, CInt(CBCola.SelectedValue))
            Dim Coincide As Integer = -1

            Dim Horafin As String
            Dim Veces As Integer = 0

            ''recorremos la lista de citas devuelta
            For Each Row As DataRow In Horas.Rows


                ''Comprobamos hora inicio

                Coincide = CBHora.FindStringExact(CStr(Row("Hora")))
                If Coincide >= 0 Then
                    CBHora.Items.RemoveAt(Coincide)
                End If

                ''Comprobamos hora fin cita y borramos los periodos intermedios.

                Dim HoraTemp As DateTime = New DateTime(MonthCalendar1.SelectionStart.Year, MonthCalendar1.SelectionStart.Month, MonthCalendar1.SelectionStart.Day, CInt(CStr(Row("Hora")).Substring(0, 2)), CInt(CStr(Row("Hora")).Substring(3, 2)), 0)

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

                        Coincide = CBHora.FindStringExact(Horafin)
                        If Coincide >= 0 Then
                            CBHora.Items.RemoveAt(Coincide)
                        End If
                    Next
                End If
            Next
            Veces = 0
            CBHora.SelectedIndex = -1
            CBHora.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' CBCola_SelectedIndexChanged
    '''Actualizamos el combobox de hora al cambiar de Cola.
    ''' </summary>
    Private Sub CBCola_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBCola.SelectedIndexChanged
        Rellenahoras()
    End Sub

    ''' <summary>
    ''' Button2_Click
    '''Cierra el formulario
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BTCancelar.Click
        Close()
    End Sub

    ''' <summary>
    ''' Button4_Click
    '''Abre el cuadro de diálogo de configuración de página para imprimir el ticket.
    ''' </summary>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim MiConfiguracion As PageSettings = New PageSettings
        PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
        PageSetupDialog1.ShowDialog()
        MiConfiguracion = PageSetupDialog1.PageSettings
        PrintDocument1.DefaultPageSettings = MiConfiguracion
    End Sub

    ''' <summary>
    ''' Button4_Click
    '''Abre el cuadro de diálogo de configuración de impresora para imprimir el ticket.
    ''' </summary>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Respuesta As DialogResult
        PrintDialog1.Document = PrintDocument1
        Respuesta = PrintDialog1.ShowDialog()
        If (Respuesta = DialogResult.OK) Then
            PrintDocument1.Print()
        End If
    End Sub

    ''' <summary>
    ''' PrintDocument1_PrintPage
    '''Diseño de nuestro ticket de cita.
    ''' </summary>
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim pen1 As New Pen(Color.Black, 1)
        Dim xPos As Single = e.MarginBounds.Left
        Dim prFont As New Font("Arial", 10, FontStyle.Bold)
        Dim yPos As Single = prFont.GetHeight(e.Graphics)

        e.Graphics.DrawString("Centro Especialidades Ángel Valera", prFont, Brushes.Black, xPos, yPos)

        e.Graphics.DrawLine(pen1, xPos, yPos + 30, xPos + 300, yPos + 30)

        prFont = New Font("Arial", 18, FontStyle.Bold)
        Dim fecha As String = ""
        If TipoCita.Checked Then
            fecha = Now.ToString("dd-MM-yyyy")
        Else
            fecha = MonthCalendar1.SelectionStart.ToString("dd-MM-yyyy")
        End If
        e.Graphics.DrawString(fecha, prFont, Brushes.Black, xPos + 80, yPos + 45)

        prFont = New Font("Arial", 24, FontStyle.Bold)
        e.Graphics.DrawString(CBHora.Text, prFont, Brushes.Black, xPos + 100, yPos + 70)
        prFont = New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString("Consulta: " + CBCola.Text, prFont, Brushes.Black, xPos + 40, yPos + 105)

        e.Graphics.DrawLine(pen1, xPos, yPos + 144, xPos + 300, yPos + 144)

        prFont = New Font("Arial", 8, FontStyle.Regular)
        e.Graphics.DrawString("Esté atento a su turno en el monitor de la sala de espera", prFont, Brushes.Black, xPos, yPos + 150)

        e.Graphics.DrawLine(pen1, xPos, yPos + 170, xPos + 300, yPos + 170)
        e.Graphics.DrawString(Now.ToString("dd-MM-yyyy    HH:mm:ss"), prFont, Brushes.Black, xPos + 180, yPos + 180)
        e.HasMorePages = False

    End Sub

    ''' <summary>
    ''' VistaPrevia
    '''Muestra la Vista Previa del ticket de cita.
    ''' </summary>
    Private Sub VistaPrevia()
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    ''' <summary>
    ''' MonthCalendar1_DateChanged
    '''Actualizamos el combobox de horas al actualizar la fecha.
    ''' </summary>
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Rellenahoras()
    End Sub

End Class