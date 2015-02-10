<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarColas
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
        Me.ListadoColas = New System.Windows.Forms.DataGridView()
        Me.BtCerrar = New System.Windows.Forms.Button()
        CType(Me.ListadoColas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListadoColas
        '
        Me.ListadoColas.AllowUserToAddRows = False
        Me.ListadoColas.AllowUserToResizeColumns = False
        Me.ListadoColas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.ListadoColas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListadoColas.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.ListadoColas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListadoColas.Location = New System.Drawing.Point(-1, 0)
        Me.ListadoColas.MultiSelect = False
        Me.ListadoColas.Name = "ListadoColas"
        Me.ListadoColas.Size = New System.Drawing.Size(498, 186)
        Me.ListadoColas.TabIndex = 0
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
        'ConsultarColas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 261)
        Me.Controls.Add(Me.BtCerrar)
        Me.Controls.Add(Me.ListadoColas)
        Me.Name = "ConsultarColas"
        Me.Text = "Consultar Colas"
        CType(Me.ListadoColas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListadoColas As System.Windows.Forms.DataGridView
    Friend WithEvents BtCerrar As System.Windows.Forms.Button
End Class
