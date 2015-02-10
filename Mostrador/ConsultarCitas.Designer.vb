<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCitas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListadoCitas = New System.Windows.Forms.DataGridView()
        Me.BtCerrar = New System.Windows.Forms.Button()
        Me.CBHora = New System.Windows.Forms.ComboBox()
        Me.LabelHora = New System.Windows.Forms.Label()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.DPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.ListadoCitas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListadoCitas
        '
        Me.ListadoCitas.AllowUserToAddRows = False
        Me.ListadoCitas.AllowUserToResizeColumns = False
        Me.ListadoCitas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.ListadoCitas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListadoCitas.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.ListadoCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListadoCitas.Location = New System.Drawing.Point(4, -1)
        Me.ListadoCitas.MultiSelect = False
        Me.ListadoCitas.Name = "ListadoCitas"
        Me.ListadoCitas.Size = New System.Drawing.Size(622, 286)
        Me.ListadoCitas.TabIndex = 0
        '
        'BtCerrar
        '
        Me.BtCerrar.Location = New System.Drawing.Point(551, 350)
        Me.BtCerrar.Name = "BtCerrar"
        Me.BtCerrar.Size = New System.Drawing.Size(75, 23)
        Me.BtCerrar.TabIndex = 1
        Me.BtCerrar.Text = "Cerrar"
        Me.BtCerrar.UseVisualStyleBackColor = True
        '
        'CBHora
        '
        Me.CBHora.FormattingEnabled = True
        Me.CBHora.Location = New System.Drawing.Point(171, 290)
        Me.CBHora.Name = "CBHora"
        Me.CBHora.Size = New System.Drawing.Size(121, 21)
        Me.CBHora.TabIndex = 2
        '
        'LabelHora
        '
        Me.LabelHora.AutoSize = True
        Me.LabelHora.Location = New System.Drawing.Point(4, 298)
        Me.LabelHora.Name = "LabelHora"
        Me.LabelHora.Size = New System.Drawing.Size(161, 13)
        Me.LabelHora.TabIndex = 3
        Me.LabelHora.Text = "Modificar Hora día seleccionado"
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Location = New System.Drawing.Point(8, 298)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(37, 13)
        Me.LabelFecha.TabIndex = 10
        Me.LabelFecha.Text = "Fecha"
        '
        'DPFecha
        '
        Me.DPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DPFecha.Location = New System.Drawing.Point(65, 291)
        Me.DPFecha.MinDate = New Date(2014, 1, 1, 0, 0, 0, 0)
        Me.DPFecha.Name = "DPFecha"
        Me.DPFecha.Size = New System.Drawing.Size(100, 20)
        Me.DPFecha.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Imprimir Listado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConsultarCitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 383)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelFecha)
        Me.Controls.Add(Me.DPFecha)
        Me.Controls.Add(Me.LabelHora)
        Me.Controls.Add(Me.CBHora)
        Me.Controls.Add(Me.BtCerrar)
        Me.Controls.Add(Me.ListadoCitas)
        Me.Name = "ConsultarCitas"
        Me.Text = "Consultar Citas"
        CType(Me.ListadoCitas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListadoCitas As System.Windows.Forms.DataGridView
    Friend WithEvents BtCerrar As System.Windows.Forms.Button
    Friend WithEvents CBHora As System.Windows.Forms.ComboBox
    Friend WithEvents LabelHora As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents DPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
