Option Explicit On
Option Strict On
Imports ADatos
Imports System.Data.SQLite
Public Class NegocioPanel
    ''' <summary>
    ''' ConsultarActuales. Consulta los datos de las citas actuales.
    ''' </summary>
    ''' <returns>(SQLiteDataAdapter). SQLiteDataAdapter con  los datos de las citas actuales</returns> 
    Public Function ConsultarActuales() As SQLiteDataAdapter
        Dim Cita As New Cita
        Try
            Dim Adapter As SQLiteDataAdapter
            Adapter = Cita.ConsultarActuales()
            Return Adapter
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' ConsultarTerminadas. Consulta los datos de las citas terminadas para cada una de las colas.
    ''' </summary>
    ''' <returns>(List(Of SQLiteDataAdapter)).Consulta los datos de las citas terminadas para cada una de las colas.</returns> 
    Public Function ConsultarTerminadas() As List(Of SQLiteDataAdapter)
        Dim Cita As New Cita
        Try
            Dim Adapters As New List(Of SQLiteDataAdapter)
            Dim Adapter As SQLiteDataAdapter
            For i = 1 To 5
                Adapter = Cita.ConsultarTerminadas(i)
                Adapters.Add(Adapter)
            Next
            Return Adapters
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' ConsultarColas. Consulta los datos de las colas
    ''' </summary>
    ''' <returns>(DataTable). DataTable con los datos de las colas</returns> 
    Public Function ConsultarColas() As DataTable
        Dim Cola As New Cola
        Try
            Dim Tabla As DataTable
            Tabla = Cola.ConsultarTodos()
            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function
End Class
