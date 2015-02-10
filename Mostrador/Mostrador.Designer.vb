<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mostrador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaSeguridadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CiitasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaCitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarCitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorPacienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorMédicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AñadirColaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarColaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalendarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AñadirDiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarDíasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PacienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MédicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.CiitasToolStripMenuItem, Me.ColasToolStripMenuItem, Me.CalendarioToolStripMenuItem, Me.PersonalToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(715, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiaSeguridadToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'CopiaSeguridadToolStripMenuItem
        '
        Me.CopiaSeguridadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearToolStripMenuItem, Me.ImportarToolStripMenuItem})
        Me.CopiaSeguridadToolStripMenuItem.Name = "CopiaSeguridadToolStripMenuItem"
        Me.CopiaSeguridadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.CopiaSeguridadToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CopiaSeguridadToolStripMenuItem.Text = "Copia Seguridad"
        '
        'CrearToolStripMenuItem
        '
        Me.CrearToolStripMenuItem.Name = "CrearToolStripMenuItem"
        Me.CrearToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CrearToolStripMenuItem.Text = "Crear"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ImportarToolStripMenuItem.Text = "Importar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'CiitasToolStripMenuItem
        '
        Me.CiitasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaCitaToolStripMenuItem, Me.ConsultarCitaToolStripMenuItem})
        Me.CiitasToolStripMenuItem.Name = "CiitasToolStripMenuItem"
        Me.CiitasToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.CiitasToolStripMenuItem.Text = "&Citas"
        '
        'NuevaCitaToolStripMenuItem
        '
        Me.NuevaCitaToolStripMenuItem.Name = "NuevaCitaToolStripMenuItem"
        Me.NuevaCitaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.NuevaCitaToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.NuevaCitaToolStripMenuItem.Text = "Nueva Cita"
        '
        'ConsultarCitaToolStripMenuItem
        '
        Me.ConsultarCitaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorPacienteToolStripMenuItem, Me.PorMédicoToolStripMenuItem})
        Me.ConsultarCitaToolStripMenuItem.Name = "ConsultarCitaToolStripMenuItem"
        Me.ConsultarCitaToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ConsultarCitaToolStripMenuItem.Text = "Consultar Cita"
        '
        'PorPacienteToolStripMenuItem
        '
        Me.PorPacienteToolStripMenuItem.Name = "PorPacienteToolStripMenuItem"
        Me.PorPacienteToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PorPacienteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PorPacienteToolStripMenuItem.Text = "Por Paciente"
        '
        'PorMédicoToolStripMenuItem
        '
        Me.PorMédicoToolStripMenuItem.Name = "PorMédicoToolStripMenuItem"
        Me.PorMédicoToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.PorMédicoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PorMédicoToolStripMenuItem.Text = "Por Médico"
        '
        'ColasToolStripMenuItem
        '
        Me.ColasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AñadirColaToolStripMenuItem, Me.ConsultarColaToolStripMenuItem})
        Me.ColasToolStripMenuItem.Name = "ColasToolStripMenuItem"
        Me.ColasToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ColasToolStripMenuItem.Text = "C&olas"
        '
        'AñadirColaToolStripMenuItem
        '
        Me.AñadirColaToolStripMenuItem.Name = "AñadirColaToolStripMenuItem"
        Me.AñadirColaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.AñadirColaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AñadirColaToolStripMenuItem.Text = "Añadir Cola"
        '
        'ConsultarColaToolStripMenuItem
        '
        Me.ConsultarColaToolStripMenuItem.Name = "ConsultarColaToolStripMenuItem"
        Me.ConsultarColaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ConsultarColaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ConsultarColaToolStripMenuItem.Text = "Consultar Cola"
        '
        'CalendarioToolStripMenuItem
        '
        Me.CalendarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AñadirDiasToolStripMenuItem, Me.ConsultarDíasToolStripMenuItem})
        Me.CalendarioToolStripMenuItem.Name = "CalendarioToolStripMenuItem"
        Me.CalendarioToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.CalendarioToolStripMenuItem.Text = "C&alendario"
        '
        'AñadirDiasToolStripMenuItem
        '
        Me.AñadirDiasToolStripMenuItem.Name = "AñadirDiasToolStripMenuItem"
        Me.AñadirDiasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.AñadirDiasToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.AñadirDiasToolStripMenuItem.Text = "Añadir Dias"
        '
        'ConsultarDíasToolStripMenuItem
        '
        Me.ConsultarDíasToolStripMenuItem.Name = "ConsultarDíasToolStripMenuItem"
        Me.ConsultarDíasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ConsultarDíasToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ConsultarDíasToolStripMenuItem.Text = "Consultar Días"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PacienteToolStripMenuItem, Me.MédicoToolStripMenuItem})
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.PersonalToolStripMenuItem.Text = "&Personal"
        '
        'PacienteToolStripMenuItem
        '
        Me.PacienteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltaToolStripMenuItem, Me.ConsultaToolStripMenuItem})
        Me.PacienteToolStripMenuItem.Name = "PacienteToolStripMenuItem"
        Me.PacienteToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.PacienteToolStripMenuItem.Text = "Paciente"
        '
        'AltaToolStripMenuItem
        '
        Me.AltaToolStripMenuItem.Name = "AltaToolStripMenuItem"
        Me.AltaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.AltaToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AltaToolStripMenuItem.Text = "Alta"
        '
        'ConsultaToolStripMenuItem
        '
        Me.ConsultaToolStripMenuItem.Name = "ConsultaToolStripMenuItem"
        Me.ConsultaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ConsultaToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ConsultaToolStripMenuItem.Text = "Consulta"
        '
        'MédicoToolStripMenuItem
        '
        Me.MédicoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltaToolStripMenuItem1, Me.ConsultaToolStripMenuItem1})
        Me.MédicoToolStripMenuItem.Name = "MédicoToolStripMenuItem"
        Me.MédicoToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.MédicoToolStripMenuItem.Text = "Médico"
        '
        'AltaToolStripMenuItem1
        '
        Me.AltaToolStripMenuItem1.Name = "AltaToolStripMenuItem1"
        Me.AltaToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.AltaToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.AltaToolStripMenuItem1.Text = "Alta"
        '
        'ConsultaToolStripMenuItem1
        '
        Me.ConsultaToolStripMenuItem1.Name = "ConsultaToolStripMenuItem1"
        Me.ConsultaToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ConsultaToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.ConsultaToolStripMenuItem1.Text = "Consulta"
        '
        'Mostrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(715, 398)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "Mostrador"
        Me.Text = "Mostrador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiaSeguridadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CiitasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaCitaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarCitaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorPacienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorMédicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AñadirColaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarColaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalendarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarDíasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AñadirDiasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PacienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MédicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
