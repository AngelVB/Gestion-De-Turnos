Option Explicit On
Option Strict On

''' <summary>
''' Mostrador.vb
''' Formulario Principal de Mostrador
''' </summary>
''' <author> Ángel Valera</author> 
Public Class Mostrador

    Private _MenuSelec As Integer = 0
    ReadOnly _MdiChildForm As New Form
    ReadOnly _Negocio As New Negocio.NegocioMostrador

    ''' <summary>
    ''' SalirToolStripMenuItem_Click.
    ''' Opción Salir. Cierra la aplicación
    ''' </summary>
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ''' <summary>
    ''' ConsultarDíasToolStripMenuItem_Click
    '''Abre el formulario Consultar Días.
    ''' </summary>
    Private Sub ConsultarDíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarDíasToolStripMenuItem.Click
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized

        End If
        ConsultarDias.MdiParent = Me
        ConsultarDias.WindowState = FormWindowState.Normal
        ConsultarDias.Show()
    End Sub

    ''' <summary>
    ''' Form1_Load
    '''Evento OnLoad. Convertimos el formulario en MDI.
    ''' </summary>
    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        IsMdiContainer = True
        _MdiChildForm.MdiParent = Me

        SetBackGroundColorOfMDIForm()
    End Sub

    ''' <summary>
    ''' SetBackGroundColorOfMDIForm
    '''Cambia el color del formulario.
    ''' </summary>
    Private Sub SetBackGroundColorOfMDIForm()
        Dim ctl As Control

        For Each ctl In Me.Controls
            If TypeOf (ctl) Is MdiClient Then

                ctl.BackColor = System.Drawing.Color.LightSkyBlue
            End If
        Next
    End Sub

    ''' <summary>
    ''' AñadirDiasToolStripMenuItem_Click
    '''Abre el formulario Añadir Días.
    ''' </summary>
    Private Sub AñadirDiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirDiasToolStripMenuItem.Click
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If
        AnyadirDias.MdiParent = Me
        AnyadirDias.WindowState = FormWindowState.Normal
        AnyadirDias.Show()
    End Sub

    ''' <summary>
    ''' AltaToolStripMenuItem_Click
    '''Abre el formulario Altas como Paciente.
    ''' </summary>
    Private Sub AltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem.Click
        MenuSelec = 5
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If

        Altas.MdiParent = Me

        Altas.WindowState = FormWindowState.Normal
        Altas.Show()
        Altas.Resetear()
    End Sub

    ''' <summary>
    ''' AltaToolStripMenuItem_Click
    '''Abre el formulario Altas como Médico.
    ''' </summary>
    Private Sub AltaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem1.Click
        MenuSelec = 6
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized

        End If
        Altas.MdiParent = Me

        Altas.WindowState = FormWindowState.Normal
        Altas.Show()
        Altas.Resetear()
    End Sub

    ''' <summary>
    ''' ConsultaToolStripMenuItem_Click
    '''Abre el formulario Buscar como Paciente.
    ''' </summary>
    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click
        MenuSelec = 2
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If
        Buscar.MdiParent = Me
        Buscar.WindowState = FormWindowState.Normal
        ResultBusqueda.Close()
        Buscar.Resetear()
        Buscar.Show()

    End Sub

    ''' <summary>
    ''' ConsultaToolStripMenuItem_Click
    '''Abre el formulario Buscar como Médico.
    ''' </summary>
    Private Sub ConsultaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem1.Click
        MenuSelec = 1
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized

        End If
        Buscar.MdiParent = Me
        Buscar.WindowState = FormWindowState.Normal
        ResultBusqueda.Close()
        Buscar.Resetear()
        Buscar.Show()
    End Sub

    ''' <summary>
    ''' PorPacienteToolStripMenuItem_Click
    '''Abre el formulario Buscar cita por Paciente.
    ''' </summary>
    Private Sub PorMédicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorMédicoToolStripMenuItem.Click
        MenuSelec = 3
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If
        Buscar.MdiParent = Me
        Buscar.WindowState = FormWindowState.Normal
        ResultBusqueda.Close()
        Buscar.Resetear()
        Buscar.Show()
    End Sub

    ''' <summary>
    ''' PorPacienteToolStripMenuItem_Click
    '''Abre el formulario Buscar cita por Paciente.
    ''' </summary>
    Private Sub PorPacienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorPacienteToolStripMenuItem.Click
        MenuSelec = 4
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If
        Buscar.MdiParent = Me
        Buscar.WindowState = FormWindowState.Normal
        ResultBusqueda.Close()
        Buscar.Resetear()
        Buscar.Show()

    End Sub

    ''' <summary>
    ''' AñadirColaToolStripMenuItem_Click
    '''Abre el formulario para añadir colas.
    ''' </summary>
    Private Sub AñadirColaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirColaToolStripMenuItem.Click
        MenuSelec = 7
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If

        AnyadirCola.MdiParent = Me

        AnyadirCola.WindowState = FormWindowState.Normal
        AnyadirCola.Show()

    End Sub

    ''' <summary>
    ''' MenuSelec. Opción seleccionado.
    ''' </summary>
    Public Property MenuSelec As Integer
        Get
            Return _MenuSelec
        End Get
        Set(value As Integer)
            _MenuSelec = value
        End Set
    End Property

    ''' <summary>
    ''' Form1_FormClosing
    '''Evento Closing. Llama a la función Salir().
    ''' </summary>
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Salir(e)
    End Sub

    ''' <summary>
    ''' Salir
    '''Cuadro de diálogo para cerrar aplicación.
    ''' </summary>
    Public Sub Salir(ByRef e As System.Windows.Forms.FormClosingEventArgs)
        'display message on form closing
        Dim Result As DialogResult
        Result = MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo)

        'if user clicked no, cancel form closing
        If Result = System.Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

    ''' <summary>
    ''' CrearToolStripMenuItem_Click
    '''Crea una copia de seguridad de la base de datos.
    ''' </summary>
    Private Sub CrearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearToolStripMenuItem.Click
        If (_Negocio.CopiaSeguridad()) Then
            MsgBox("Copia de Seguridad realizada con éxito")
        Else
            MsgBox("Error generando Copia de Seguridad")
        End If

    End Sub


    ''' <summary>
    ''' ConsultarColaToolStripMenuItem_Click
    '''Abre el formulario para consultar las colas.
    ''' </summary>
    Private Sub ConsultarColaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarColaToolStripMenuItem.Click
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized

        End If
        ConsultarColas.MdiParent = Me
        ConsultarColas.WindowState = FormWindowState.Normal
        ConsultarColas.Show()
    End Sub

    ''' <summary>
    ''' ConsultarColaToolStripMenuItem_Click
    '''Abre el formulario para búsqueda de pacientes para añadir citas.
    ''' </summary>
    Private Sub NuevaCitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaCitaToolStripMenuItem.Click
        MenuSelec = 8
        Dim F As Form = Me.ActiveMdiChild
        If Not F Is Nothing Then
            F.WindowState = FormWindowState.Minimized
        End If
        Buscar.MdiParent = Me
        Buscar.WindowState = FormWindowState.Normal
        ResultBusqueda.Close()
        Buscar.Resetear()
        Buscar.Show()
    End Sub


End Class

