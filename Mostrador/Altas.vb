Option Explicit On
Option Strict On

Imports System.Text

''' <summary>
''' Altas.vb
''' Formulario de altas y modificaciones de personas.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class Altas

    ReadOnly _Negocio As New Negocio.NegocioMostrador
    Dim _Update As Boolean = False
    Private _IdSelec As Integer = 0

    ''' <summary>
    '''Button1_Click
    ''' Validamos e insertamos/modificamos los datos de personas introducidos.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PKilometro As Integer
        Dim PHectometro As Integer
        Dim PBaja As Integer = 0
        Dim kmOk As Integer = 0
        Dim hmOk As Integer = 0

        If Kilometro.Text = "" Then
            PKilometro = -1
            kmOk = 1
        ElseIf IsNumeric(Kilometro.Text) Then
            PKilometro = CInt(Kilometro.Text)
            kmOk = 1
        Else
            MsgBox("El campo Kilómetro debe contener un número.")
            kmOk = 0
        End If
        If Hectometro.Text = "" Then
            PHectometro = -1
            hmOk = 1
        ElseIf IsNumeric(Hectometro.Text) Then
            PHectometro = CInt(Hectometro.Text)
            hmOk = 1
        Else
            MsgBox("El campo Hectómetro debe contener un número.")
            hmOk = 0
        End If
        If kmOk = 1 And hmOk = 1 Then

            If Baja.Checked Then
                PBaja = 1
            Else
                PBaja = 0
            End If

            If Verificar_NIF(DNI.Text) Then
                If SIP.Text.Length = 10 AndAlso IsNumeric(SIP.Text) Then
                    If _Update = False Then
                        Select Case Mostrador.MenuSelec
                            Case 5 ''Alta Paciente

                                Dim Result As Integer = _Negocio.InsertarPaciente(Nombre.Text, Apellidos.Text, DNI.Text, Email.Text, Telefono.Text, PBaja, CULng(SIP.Text), TipoVia.Text, Via.Text, Numero.Text, PKilometro, PHectometro, Bloque.Text, Portal.Text, Escalera.Text, Planta.Text, Puerta.Text, Poblacion.Text, Municipio.Text, Provincia.Text, CodPostal.Text)

                                If Result = 1 Then
                                    MsgBox("Paciente Insertado con éxito.")
                                    Resetear()
                                Else
                                    MsgBox("Error Insertando paciente.")
                                End If
                            Case 6 ''Alta Médico 
                                If Password.Text.Length >= 6 And Password.Text.Length <= 20 Then
                                    If Password.Text = Password2.Text Then

                                        Dim Result As Integer = _Negocio.InsertarMedico(Nombre.Text, Apellidos.Text, DNI.Text, Email.Text, Telefono.Text, PBaja, SIP.Text, Password.Text, TipoVia.Text, Via.Text, Numero.Text, PKilometro, PHectometro, Bloque.Text, Portal.Text, Escalera.Text, Planta.Text, Puerta.Text, Poblacion.Text, Municipio.Text, Provincia.Text, CodPostal.Text)
                                        If Result = 1 Then
                                            MsgBox("Médico Insertado con éxito.")
                                            Resetear()
                                        Else
                                            MsgBox("Error Insertando médico.")
                                        End If
                                    Else
                                        MsgBox("Las contraseñas no coinciden.")
                                        Password.Text = ""
                                        Password.BackColor = Color.LightCoral
                                        Password.SelectionLength = 0
                                        Password2.Text = ""
                                        Password2.BackColor = Color.LightCoral
                                        Password2.SelectionLength = 0
                                        Password.Focus()
                                    End If
                                Else
                                    MsgBox("La contraseña de Colegiado debe tener entre 6 y 20 caracteres")
                                    Password.Text = ""
                                    Password.BackColor = Color.LightCoral
                                    Password.SelectionLength = 0
                                    Password2.Text = ""
                                    Password2.BackColor = Color.LightCoral
                                    Password2.SelectionLength = 0
                                End If
                        End Select
                    Else
                        Select Case Mostrador.MenuSelec
                            Case 5 'Update Paciente

                                Dim Result As Integer = _Negocio.UpdatePaciente(IdSelec, Nombre.Text, Apellidos.Text, DNI.Text, Email.Text, Telefono.Text, PBaja, CULng(SIP.Text), TipoVia.Text, Via.Text, Numero.Text, PKilometro, PHectometro, Bloque.Text, Portal.Text, Escalera.Text, Planta.Text, Puerta.Text, Poblacion.Text, Municipio.Text, Provincia.Text, CodPostal.Text)
                                If Result = 1 Then
                                    MsgBox("Paciente modificado con éxito.")
                                    Resetear()
                                    _Update = False
                                Else
                                    MsgBox("Error modificando paciente.")
                                End If
                            Case 6 ''Update Médico   
                                If Password.Text.Length >= 6 And Password.Text.Length <= 20 Then
                                    If Password.Text = Password2.Text Then
                                        Dim Result As Integer = _Negocio.UpdateMedico(IdSelec, Nombre.Text, Apellidos.Text, DNI.Text, Email.Text, Telefono.Text, PBaja, SIP.Text, Password.Text, TipoVia.Text, Via.Text, Numero.Text, PKilometro, PHectometro, Bloque.Text, Portal.Text, Escalera.Text, Planta.Text, Puerta.Text, Poblacion.Text, Municipio.Text, Provincia.Text, CodPostal.Text)
                                        If Result = 1 Then
                                            MsgBox("Médico modificado con éxito.")
                                            Resetear()
                                            _Update = False
                                        Else
                                            MsgBox("Error modificando médico.")
                                        End If
                                    Else
                                        MsgBox("Las contraseñas no coinciden.")
                                        Password.Text = ""
                                        Password.BackColor = Color.LightCoral
                                        Password.SelectionLength = 0
                                        Password2.Text = ""
                                        Password2.BackColor = Color.LightCoral
                                        Password2.SelectionLength = 0
                                        Password.Focus()
                                    End If
                                Else
                                    MsgBox("La contraseña de Colegiado debe tener entre 6 y 20 caracteres")
                                    Password.Text = ""
                                    Password.BackColor = Color.LightCoral
                                    Password.SelectionLength = 0
                                    Password2.Text = ""
                                    Password2.BackColor = Color.LightCoral
                                    Password2.SelectionLength = 0
                                End If
                        End Select
                    End If
                Else
                    If Mostrador.MenuSelec = 6 Then ''Datos Médico
                        MsgBox("El nº de colegiado debe ser numérico y tener 10 cifras.")
                    End If
                    If Mostrador.MenuSelec = 5 Then ''Datos Paciente
                        MsgBox("El nº SIP debe ser numérico y tener 10 cifras.")
                    End If

                    SIP.BackColor = Color.LightCoral
                    SIP.SelectionLength = 0
                    SIP.Focus()
                End If
            Else
                MsgBox("Introduzca un DNI válido")
                DNI.SelectionLength = 0
                DNI.BackColor = Color.LightCoral
                DNI.Focus()
            End If
        End If
    End Sub


    ''' <summary>
    '''AltaPaciente_Enter
    ''' Evento OnEnter. Preparamos el formulario y Cargamos datos en caso de venir desde una búsqueda.
    ''' </summary>
    Private Sub AltaPaciente_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Dim NumFila As Integer = -1
        Resetear()
        NumFila = ResultBusqueda.FilaSeleccionada

        Dim Fila As DataGridViewRow

        If Mostrador.MenuSelec = 6 Then
            Text = "Alta Médico"
            Labelpass.Visible = True
            Password.Visible = True
            Labelpass2.Visible = True
            Password2.Visible = True
            LabelSIP.Text = "Nº Colegiado"
        End If
        If Mostrador.MenuSelec = 5 Then
            Text = "Alta Paciente"
            Labelpass.Visible = False
            Password.Visible = False
            Labelpass.Visible = False
            Password.Visible = False
            LabelSIP.Text = "SIP"

        End If
        ''Comprobamos si venimos del formulario de búsqueda.
        If NumFila = -1 Then
            DNI.Enabled = True
            DNI.ReadOnly = False
            Limpiar()

        Else
            Fila = ResultBusqueda.ListadoBusq.Rows(NumFila)

            Dim R As DataRowView = DirectCast(Fila.DataBoundItem, DataRowView)
            Dim Dr As DataRow = R.Row

            Labelpass.Visible = False
            Password.Visible = False
            Labelpass2.Visible = False
            Password2.Visible = False

            If Mostrador.MenuSelec = 1 Then ''Datos Médico
                Text = "Datos Médico"
                SIP.Text = Fila.Cells("NumColegiado").Value.ToString
                LabelSIP.Text = "Nº Colegiado"
            End If
            If Mostrador.MenuSelec = 2 Then ''Datos Paciente
                Text = "Datos Paciente"
                SIP.Text = Fila.Cells("SIP").Value.ToString
                LabelSIP.Text = "SIP"
            End If
            PanelDatos.Enabled = True
            PanelDirec.Enabled = True
            ResultBusqueda.Close()
            RellenarCampos(Dr)

            ''Bloqueamos los controles
            Bloquear(True)
            ''Ocultamos el botón de añadir
            Button1.Hide()
            NumFila = -1
            ''Reseteamos la variable que almacena la fila seleccionada en el formulario de búsqueda

        End If
    End Sub

    ''' <summary>
    '''Bloquear
    ''' Pone todos los controles del formulario como solo lectura.
    ''' </summary>
    Public Sub Bloquear(ByRef Op As Boolean)
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is GroupBox Then
                For Each ctrl2 As Control In ctrl.Controls
                    If TypeOf ctrl2 Is TextBox Then

                        Dim tbx As TextBox = CType(ctrl2, TextBox)
                        tbx.ReadOnly = Op
                    ElseIf TypeOf ctrl2 Is ComboBox Then
                        Dim tbx As ComboBox = CType(ctrl2, ComboBox)
                        If Op Then
                            tbx.Enabled = False
                        Else
                            tbx.Enabled = True
                        End If

                    End If
                Next
            ElseIf TypeOf ctrl Is TextBox Then
                Dim tbx As TextBox = CType(ctrl, TextBox)
                tbx.ReadOnly = Op
            ElseIf TypeOf ctrl Is CheckBox Then
                Dim tbx As CheckBox = CType(ctrl, CheckBox)
                If Op Then
                    tbx.Enabled = False
                Else
                    tbx.Enabled = True
                End If
            End If
        Next


    End Sub

    ''' <summary>
    '''Limpiar
    ''' Vacía los datos de todos los controles del formulario
    ''' </summary>
    Public Sub Limpiar()
        For Each ctrl As Control In Controls
            If TypeOf ctrl Is GroupBox Then
                For Each ctrl2 As Control In ctrl.Controls
                    If TypeOf ctrl2 Is TextBox Then
                        Dim tbx As TextBox = CType(ctrl2, TextBox)
                        tbx.Clear()
                    ElseIf TypeOf ctrl2 Is ComboBox Then
                        Dim tbx As ComboBox = CType(ctrl2, ComboBox)
                        tbx.ResetText()
                    End If
                Next
            ElseIf TypeOf ctrl Is TextBox Then
                Dim tbx As TextBox = CType(ctrl, TextBox)
                tbx.Clear()
            ElseIf TypeOf ctrl Is CheckBox Then
                Dim tbx As CheckBox = CType(ctrl, CheckBox)
                tbx.Checked = False
            End If
        Next
    End Sub

    ''' <summary>
    '''DNI_KeyPress
    ''' Evento KeyPress de DNI. Comprueba si existe o no una persona en nuestra base de datos, dándonos opción de cargar los datos.
    ''' </summary>
    Private Sub DNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DNI.KeyPress
        If e.KeyChar = CChar(ChrW(13)) Or e.KeyChar = CChar(ChrW(11)) Then
            DNI.Text = DNI.Text.ToUpper
            If Verificar_NIF(DNI.Text) = True Then
                Dim Tabla As New DataTable

                Tabla = _Negocio.ConsultarPersona(DNI.Text)
                If Tabla.Rows.Count > 0 Then

                    Dim Result As MsgBoxResult = MsgBox("El NIF ya existe en la base de datos, ¿Desea cargar los datos relacionados?", MsgBoxStyle.YesNo)
                    If Result = MsgBoxResult.Yes Then
                        _Update = True
                        Dim Dr As DataRow = Tabla.Rows(0)
                        IdSelec = CInt(Dr.Item("id").ToString)
                        RellenarCampos(Dr)

                        If Mostrador.MenuSelec = 1 Then ''Datos Médico
                            SIP.Text = Dr.Item("NumColegiado").ToString
                        End If
                        If Mostrador.MenuSelec = 2 Then ''Datos Paciente
                            SIP.Text = Dr.Item("SIP").ToString
                        End If
                        Bloquear(False)
                    Else
                        DNI.Text = ""
                        _Update = False
                    End If

                End If
                PanelDatos.Enabled = True
                PanelDirec.Enabled = True
                Button1.Enabled = True
                Baja.Enabled = True
                Bloquear(False)
                SIP.BackColor = Color.LightCoral
                Password.BackColor = Color.LightCoral
                Password2.BackColor = Color.LightCoral

            Else
                MsgBox("Introduzca un DNI válido")
                DNI.SelectionLength = 0
            End If
        End If
    End Sub

    ''' <summary>
    '''RellenarCampos
    ''' Rellena los controles con los datos de la persona buscada.
    ''' </summary>
    Public Sub RellenarCampos(ByRef Fila As DataRow)
        Nombre.Text = Fila.Item("Nombre").ToString
        Apellidos.Text = Fila.Item("Apellidos").ToString
        DNI.Text = Fila.Item("Nif").ToString
        Telefono.Text = Fila.Item("Telefono").ToString
        Email.Text = Fila.Item("Telefono").ToString
        If CBool(Fila.Item("Baja")) = True Then
            Baja.Checked = True
        End If
        TipoVia.Text = Fila.Item("TipoVia").ToString
        Via.Text = Fila.Item("Via").ToString
        Numero.Text = Fila.Item("Numero").ToString
        Kilometro.Text = Fila.Item("Kilometro").ToString
        Hectometro.Text = Fila.Item("Hectometro").ToString
        Bloque.Text = Fila.Item("Bloque").ToString
        Portal.Text = Fila.Item("Portal").ToString
        Escalera.Text = Fila.Item("Escalera").ToString
        Planta.Text = Fila.Item("Planta").ToString
        Puerta.Text = Fila.Item("Puerta").ToString
        CodPostal.Text = Fila.Item("CodPostal").ToString
        Municipio.Text = Fila.Item("Municipio").ToString
        Poblacion.Text = Fila.Item("Localidad").ToString
        Provincia.Text = Fila.Item("Provincia").ToString



    End Sub

    ''' <summary>
    ''' Comprueba si es un NIF válido
    ''' No usar espacios ni separadores para la letra
    ''' Devuelve True si es correcto
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function Verificar_NIF(ByVal valor As String) As Boolean
        If Not valor = "" Then
            Dim aux As String

            valor = valor.ToUpper ' ponemos la letra en mayúscula
            aux = valor.Substring(0, valor.Length - 1) ' quitamos la letra del NIF

            If aux.Length >= 7 AndAlso IsNumeric(aux) Then
                aux = CalculaNIF(aux) ' calculamos la letra del NIF para comparar con la que tenemos
            Else
                Return False
            End If

            If valor <> aux Then ' comparamos las letras
                Return False
            End If

            Return True
        Else
            Return False

        End If

    End Function

    Private Function CalculaNIF(ByVal strA As String) As String
        Const cCADENA As String = "TRWAGMYFPDXBNJZSQVHLCKE"
        Const cNUMEROS As String = "0123456789"
        Dim a, b, c, NIF As Integer
        Dim sb As New StringBuilder

        strA = Trim(strA)
        If Len(strA) = 0 Then Return ""

        ' Dejar sólo los números
        For i As Integer = 0 To strA.Length - 1
            If cNUMEROS.IndexOf(strA(i)) > -1 Then
                sb.Append(strA(i))
            End If
        Next

        strA = sb.ToString
        a = 0
        NIF = CInt(Val(strA))
        Do
            b = CInt(Int(NIF / 24))
            c = NIF - (24 * b)
            a = a + c
            NIF = b
        Loop While b <> 0
        b = CInt(Int(a / 23))
        c = a - (23 * b)

        Return strA & Mid(cCADENA, CInt(c + 1), 1)
    End Function

    ''' <summary>
    '''Resetear
    ''' Resetea las propiedades de los campos del formulario.
    ''' </summary>
    Public Sub Resetear()
        Bloquear(True)
        DNI.ReadOnly = False
        Limpiar()
        DNI.Focus()
        Button1.Visible = True
        SIP.BackColor = DefaultBackColor
        PanelDatos.Enabled = False
        PanelDirec.Enabled = False
        Button1.Enabled = False
        Baja.Enabled = False
        Select Case Mostrador.MenuSelec

            Case 6
                Text = "Alta Médico"
                Labelpass.Visible = True
                Labelpass2.Visible = True
                Password.Visible = True
                Password2.Visible = True
                LabelSIP.Text = "Nº Colegiado"
                Password.BackColor = DefaultBackColor
                Password2.BackColor = DefaultBackColor
            Case Else
                Text = "Alta Paciente"
                Labelpass.Visible = False
                Labelpass2.Visible = False
                Password.Visible = False
                Password2.Visible = False
                LabelSIP.Text = "SIP"
        End Select
    End Sub

    ''' <summary>
    '''SIP_TextChanged
    ''' Cambia el color del campo SIP.
    ''' </summary>
    Private Sub SIP_TextChanged(sender As Object, e As EventArgs) Handles SIP.TextChanged
        If SIP.BackColor = Color.LightCoral Then
            SIP.BackColor = Color.White
        End If
    End Sub

    ''' <summary>
    '''Password_TextChanged
    ''' Cambia el color del campo Password y Password2.
    ''' </summary>
    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged, Password2.TextChanged
        If Password.BackColor = Color.LightCoral Then
            Password.BackColor = Color.White
        End If
        If Password2.BackColor = Color.LightCoral Then
            Password2.BackColor = Color.White
        End If
    End Sub

    ''' <summary>
    '''DNI_TextChanged
    ''' Cambia el color del campo DNI.
    ''' </summary>
    Private Sub DNI_TextChanged(sender As Object, e As EventArgs) Handles DNI.TextChanged
        If DNI.BackColor = Color.LightCoral Then
            DNI.BackColor = Color.White
        End If
    End Sub

    ''' <summary>
    ''' Button2_Click
    '''Cierra la ventana.
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    ''' <summary>
    ''' AltaPaciente_FormClosing
    '''Evento FormClosing. Llama a la función Salir del mostrador.
    ''' </summary>
    Private Sub AltaPaciente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Mostrador.Salir(e)
    End Sub

    ''' <summary>
    ''' IdSelec
    '''Id persona seleccionada al cargar datos por DNI existente..
    ''' </summary>
    Public Property IdSelec As Integer
        Get
            Return _IdSelec
        End Get
        Set(value As Integer)
            _IdSelec = value
        End Set
    End Property



End Class
