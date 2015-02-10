<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnyadirCita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnyadirCita))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBSIP = New System.Windows.Forms.TextBox()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.TBApellidos = New System.Windows.Forms.TextBox()
        Me.TipoCita = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBHora = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBCola = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBDuracion = New System.Windows.Forms.TextBox()
        Me.BTAnyadir = New System.Windows.Forms.Button()
        Me.BTCancelar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apellidos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sip"
        '
        'TBSIP
        '
        Me.TBSIP.Location = New System.Drawing.Point(72, 44)
        Me.TBSIP.Name = "TBSIP"
        Me.TBSIP.ReadOnly = True
        Me.TBSIP.Size = New System.Drawing.Size(100, 20)
        Me.TBSIP.TabIndex = 3
        '
        'TBNombre
        '
        Me.TBNombre.Location = New System.Drawing.Point(72, 70)
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.ReadOnly = True
        Me.TBNombre.Size = New System.Drawing.Size(100, 20)
        Me.TBNombre.TabIndex = 4
        '
        'TBApellidos
        '
        Me.TBApellidos.Location = New System.Drawing.Point(72, 96)
        Me.TBApellidos.Name = "TBApellidos"
        Me.TBApellidos.ReadOnly = True
        Me.TBApellidos.Size = New System.Drawing.Size(169, 20)
        Me.TBApellidos.TabIndex = 5
        '
        'TipoCita
        '
        Me.TipoCita.AutoSize = True
        Me.TipoCita.Location = New System.Drawing.Point(218, 135)
        Me.TipoCita.Name = "TipoCita"
        Me.TipoCita.Size = New System.Drawing.Size(93, 17)
        Me.TipoCita.TabIndex = 6
        Me.TipoCita.Text = "Cita Inmediata"
        Me.TipoCita.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha"
        '
        'CBHora
        '
        Me.CBHora.FormattingEnabled = True
        Me.CBHora.Items.AddRange(New Object() {"08:00", "08:15", "08:30", "08:45", "09:00", "09:15", "09:30", "09:45", "10:00", "10:15", "10:30", "10:45", "11:00", "11:15", "11:30", "11:45", "12:00", "12:15", "12:30", "12:45", "13:00", "13:15", "13:30", "13:45", "14:00", "14:15", "14:30", "14:45", "15:00"})
        Me.CBHora.Location = New System.Drawing.Point(345, 160)
        Me.CBHora.Name = "CBHora"
        Me.CBHora.Size = New System.Drawing.Size(82, 21)
        Me.CBHora.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(290, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Hora"
        '
        'CBCola
        '
        Me.CBCola.FormattingEnabled = True
        Me.CBCola.Location = New System.Drawing.Point(72, 131)
        Me.CBCola.Name = "CBCola"
        Me.CBCola.Size = New System.Drawing.Size(128, 21)
        Me.CBCola.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Consulta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(292, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Duración"
        '
        'TBDuracion
        '
        Me.TBDuracion.Location = New System.Drawing.Point(347, 187)
        Me.TBDuracion.Name = "TBDuracion"
        Me.TBDuracion.Size = New System.Drawing.Size(33, 20)
        Me.TBDuracion.TabIndex = 14
        '
        'BTAnyadir
        '
        Me.BTAnyadir.Location = New System.Drawing.Point(406, 316)
        Me.BTAnyadir.Name = "BTAnyadir"
        Me.BTAnyadir.Size = New System.Drawing.Size(75, 23)
        Me.BTAnyadir.TabIndex = 15
        Me.BTAnyadir.Text = "Añadir"
        Me.BTAnyadir.UseVisualStyleBackColor = True
        '
        'BTCancelar
        '
        Me.BTCancelar.Location = New System.Drawing.Point(325, 316)
        Me.BTCancelar.Name = "BTCancelar"
        Me.BTCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BTCancelar.TabIndex = 16
        Me.BTCancelar.Text = "Cerrar"
        Me.BTCancelar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(416, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(65, 35)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Configurar Impresora"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(345, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(65, 35)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Configurar Página"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(72, 160)
        Me.MonthCalendar1.MaxSelectionCount = 1
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 19
        '
        'AnyadirCita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 348)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.BTCancelar)
        Me.Controls.Add(Me.BTAnyadir)
        Me.Controls.Add(Me.TBDuracion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBCola)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CBHora)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TipoCita)
        Me.Controls.Add(Me.TBApellidos)
        Me.Controls.Add(Me.TBNombre)
        Me.Controls.Add(Me.TBSIP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AnyadirCita"
        Me.Text = "Nueva Cita"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TBSIP As System.Windows.Forms.TextBox
    Friend WithEvents TBNombre As System.Windows.Forms.TextBox
    Friend WithEvents TBApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TipoCita As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBHora As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBCola As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TBDuracion As System.Windows.Forms.TextBox
    Friend WithEvents BTAnyadir As System.Windows.Forms.Button
    Friend WithEvents BTCancelar As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
End Class
