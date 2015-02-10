<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultBusqueda
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
        Me.ListadoBusq = New System.Windows.Forms.DataGridView()
        CType(Me.ListadoBusq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListadoBusq
        '
        Me.ListadoBusq.AllowUserToAddRows = False
        Me.ListadoBusq.AllowUserToDeleteRows = False
        Me.ListadoBusq.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.ListadoBusq.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListadoBusq.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.ListadoBusq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListadoBusq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListadoBusq.Location = New System.Drawing.Point(0, 0)
        Me.ListadoBusq.Name = "ListadoBusq"
        Me.ListadoBusq.ReadOnly = True
        Me.ListadoBusq.Size = New System.Drawing.Size(706, 261)
        Me.ListadoBusq.TabIndex = 0
        '
        'ResultBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 261)
        Me.Controls.Add(Me.ListadoBusq)
        Me.Name = "ResultBusqueda"
        Me.Text = "ListadoMedicos"
        CType(Me.ListadoBusq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListadoBusq As System.Windows.Forms.DataGridView
End Class
