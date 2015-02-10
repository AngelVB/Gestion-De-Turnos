Option Explicit On
Option Strict On

Imports Microsoft.Reporting.WinForms
Imports Mostrador.My

''' <summary>
''' ListadoCitasMedico.vb
'''Formulario para visualizar el listado de citas de un médico
''' </summary>
''' <author> Ángel Valera</author>
Public Class ListadoCitasMedico
    Public Citas As New List(Of CitasMedico)
    Public NombreMedico As String

    ''' <summary>
    ''' ListadoCitasMedico_Load. Cargamos el origen de datos y los parámetros a nuestro informe.
    ''' </summary>
    Private Sub ListadoCitasMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.LocalReport.DataSources.Clear()
     
        Dim parameters As ReportParameter = New ReportParameter("NombreMedico", NombreMedico)
       
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet2", Citas))
        
        ReportViewer1.LocalReport.SetParameters(parameters)
      
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class