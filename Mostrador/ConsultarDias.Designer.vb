<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarDias
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListadoFestivos = New System.Windows.Forms.DataGridView()
        Me.NegocioMostradorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtCerrar = New System.Windows.Forms.Button()
        CType(Me.ListadoFestivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NegocioMostradorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListadoFestivos
        '
        Me.ListadoFestivos.AllowUserToAddRows = False
        Me.ListadoFestivos.AllowUserToResizeColumns = False
        Me.ListadoFestivos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.ListadoFestivos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListadoFestivos.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.ListadoFestivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListadoFestivos.Location = New System.Drawing.Point(-1, 0)
        Me.ListadoFestivos.MultiSelect = False
        Me.ListadoFestivos.Name = "ListadoFestivos"
        Me.ListadoFestivos.ReadOnly = True
        Me.ListadoFestivos.Size = New System.Drawing.Size(498, 186)
        Me.ListadoFestivos.TabIndex = 0
        '
        'NegocioMostradorBindingSource
        '
        Me.NegocioMostradorBindingSource.DataSource = GetType(Negocio.NegocioMostrador)
        '
        'BtCerrar
        '
        Me.BtCerrar.Location = New System.Drawing.Point(407, 226)
        Me.BtCerrar.Name = "BtCerrar"
        Me.BtCerrar.Size = New System.Drawing.Size(75, 23)
        Me.BtCerrar.TabIndex = 1
        Me.BtCerrar.Text = "Cerrar"
        Me.BtCerrar.UseVisualStyleBackColor = True
        '
        'ConsultarDias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 261)
        Me.Controls.Add(Me.BtCerrar)
        Me.Controls.Add(Me.ListadoFestivos)
        Me.Name = "ConsultarDias"
        Me.Text = "Consultar Festivos"
        CType(Me.ListadoFestivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NegocioMostradorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListadoFestivos As System.Windows.Forms.DataGridView
    Friend WithEvents NegocioMostradorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtCerrar As System.Windows.Forms.Button
End Class
