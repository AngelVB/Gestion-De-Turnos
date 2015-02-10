<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnyadirDias
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
        Me.NombreFestivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FechaFestivo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AnyadirFestivo = New System.Windows.Forms.Button()
        Me.CancelarFestivo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NombreFestivo
        '
        Me.NombreFestivo.Location = New System.Drawing.Point(72, 21)
        Me.NombreFestivo.MaxLength = 40
        Me.NombreFestivo.Name = "NombreFestivo"
        Me.NombreFestivo.Size = New System.Drawing.Size(169, 20)
        Me.NombreFestivo.TabIndex = 0
        Me.NombreFestivo.Tag = "Nombre Festivo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre"
        '
        'FechaFestivo
        '
        Me.FechaFestivo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaFestivo.Location = New System.Drawing.Point(72, 47)
        Me.FechaFestivo.MinDate = New Date(2014, 1, 1, 0, 0, 0, 0)
        Me.FechaFestivo.Name = "FechaFestivo"
        Me.FechaFestivo.Size = New System.Drawing.Size(169, 20)
        Me.FechaFestivo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha"
        '
        'AnyadirFestivo
        '
        Me.AnyadirFestivo.Location = New System.Drawing.Point(166, 73)
        Me.AnyadirFestivo.Name = "AnyadirFestivo"
        Me.AnyadirFestivo.Size = New System.Drawing.Size(75, 23)
        Me.AnyadirFestivo.TabIndex = 4
        Me.AnyadirFestivo.Text = "Añadir"
        Me.AnyadirFestivo.UseVisualStyleBackColor = True
        '
        'CancelarFestivo
        '
        Me.CancelarFestivo.Location = New System.Drawing.Point(182, 115)
        Me.CancelarFestivo.Name = "CancelarFestivo"
        Me.CancelarFestivo.Size = New System.Drawing.Size(75, 23)
        Me.CancelarFestivo.TabIndex = 5
        Me.CancelarFestivo.Text = "Cerrar"
        Me.CancelarFestivo.UseVisualStyleBackColor = True
        '
        'AnyadirDias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 154)
        Me.Controls.Add(Me.CancelarFestivo)
        Me.Controls.Add(Me.AnyadirFestivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FechaFestivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NombreFestivo)
        Me.Name = "AnyadirDias"
        Me.Text = "Añadir Festivo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NombreFestivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FechaFestivo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AnyadirFestivo As System.Windows.Forms.Button
    Friend WithEvents CancelarFestivo As System.Windows.Forms.Button
End Class
