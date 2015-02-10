Option Explicit On
Option Strict On
Imports ADatos
Imports System.Data.SQLite

Public Class NegocioSiguiente

    ''' <summary>
    ''' ConsultarLogin. Valida los datos de acceso a la aplicación.
    ''' </summary>
    ''' <param name="PNumColegiado ">(String)Número Colegiado.</param>
    ''' <param name="PPassword ">(String)Fecha.</param>
    ''' <returns>(DataTable). DataTable con todos los datos de todos las citas de un médico en un día determinado</returns>
    Public Function ConsultarLogin(ByRef PNumColegiado As String, ByRef PPassword As String) As Boolean
        Dim Medico As New Medico
        If Medico.Validar(PNumColegiado, PPassword) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' ConsultarCitasMedico. Consulta los datos de las citas de un médico en un día.
    ''' </summary>
    ''' <param name="PId ">(String)Número Colegiado.</param>
    ''' <param name="Pfecha ">(String)Fecha.</param>
    ''' <param name="IdCola ">(Integer)IdCola.</param>
    ''' <returns>( SQLiteDataAdapter).SQLiteDataAdapter con todos los datos de todos las citas de un médico en un día determinado</returns>
    Public Function ConsultarCitasMedico(ByVal PId As String, ByVal Pfecha As Date, ByVal IdCola As Integer) As SQLiteDataAdapter

        Dim Cita As New Cita
        Try
            Dim Adapter As SQLiteDataAdapter

            Adapter = Cita.ConsultarDa(PId, Pfecha, IdCola)

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
    ''' TerminarCita. Función encargada de marcar una cita determinada por su Id.
    ''' </summary>
    ''' <param name="Id ">(Integer)Id de la cita.</param>
    ''' <returns>( Boolean)</returns>
    Public Function TerminarCita(ByRef Id As Integer) As Boolean
        Dim Cita As New Cita
        If Cita.TerminarCita(Id) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' ConsultarColas. Consulta los datos de las Colas.
    ''' </summary>
    ''' <returns>(DataTable). DataTable con todos los datos de todos las colas.</returns>
    Public Function ConsultarColas(ByRef PNumColegiado As String) As DataTable
        Dim Cola As New Cola
        Try
            Dim Tabla As New DataTable
            Tabla = Cola.ConsultarTodosPorMedico(PNumColegiado)

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            MsgBox(Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            MsgBox(SqlExc.ErrorCode)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            MsgBox(Ex1.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' AsignarMedico. Asigna un médico a la cola seleccionada.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id de la cola.</param>
    ''' <param name="PNumColegiado ">(String)Número de colegiado.</param>
    ''' <returns>(Boolean)</returns>
    Public Function AsignarMedico(ByRef Pid As Integer, ByRef PNumColegiado As String) As Boolean
        Dim Cola As New Cola
        Try

            Dim Updates As Integer
            Updates = Cola.AsignarMedico(Pid, PNumColegiado)

            If (Updates > 0) Then
                Return True
            Else
                Return False
            End If

        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            MsgBox(Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            MsgBox(SqlExc.ErrorCode)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            MsgBox(Ex1.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' ModificarMesa. Modifica el nombre de una consulta.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id de la cola.</param>
    ''' <param name="PMesa">(String)Nombre de la consulta.</param>
    ''' <returns>(Boolean)</returns>
    Public Function ModificarMesa(ByRef Pid As Integer, ByRef PMesa As String) As Boolean
        Dim Cola As New Cola
        Try
            Dim Updates As Integer
            Updates = Cola.ModificarMesa(Pid, PMesa)
            If (Updates > 0) Then
                Return True
            Else
                Return False
            End If
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            MsgBox(Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            MsgBox(SqlExc.ErrorCode)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            MsgBox(Ex1.Message)
            Return Nothing
        End Try
    End Function
End Class
