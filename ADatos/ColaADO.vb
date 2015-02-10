Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' ColaADO.vb
''' Contiene la clase ColaADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' las colas de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class ColaADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor ColaADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
    ''' </summary>
    Public Sub New()
        _BD = New ADatos.BDSQLite
    End Sub

    '''<summary>
    '''EjecutarCUD. Ejecuta los comandos Insert, Update, Delete en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(Integer) Result. Número de filas afectadas en nuestra base de datos</returns>
    Public Function EjecutarCUD(ByVal PSQL As String) As Integer
        Dim Result As Integer

        Try
            _BD.Abrir()
            Result = _BD.EjecutarDDL(PSQL)
        Finally
            _BD.Cerrar()
        End Try

        Return Result
    End Function

    '''<summary>
    '''EjecutarSelect. Ejecuta los comandos Select en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(DataTable) Result. DataTable conlos datos pedidos a nuestra base de datos</returns>
    Public Function EjecutarSelect(ByVal PSQL As String) As DataTable
        Dim Result As New DataTable
        Dim Lector As SQLiteDataReader
        Try
            _BD.Abrir()
            Lector = _BD.EjecutarDML(PSQL)
            Result.Load(Lector)
        Finally
            _BD.Cerrar()
        End Try
        Return Result
    End Function

    ''' <summary>
    '''Función Insertar. Encargada de insertar una nueva cola en nuestra base de datos.
    ''' </summary>
    ''' <param name="PNumeroCola">(Integer)Numero de cola.</param>
    ''' <param name="PMesa">(String)Nombre de mesa.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    ''' <returns>(Integer) Inserciones. Número de colas insertadas en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PnumeroCola As Integer, ByVal PMesa As String, ByVal PMedicoId As Integer) As Integer
        Dim Inserciones As Integer
        Dim SQL As String

        SQL = "INSERT INTO colas (NumCola, NumMesa,MedicoId) VALUES ( " & PnumeroCola & " , """ & PMesa & """ , " & PMedicoId & ")"

        Try
            _BD.Abrir()
            Inserciones = _BD.EjecutarDDL(SQL)
        Finally
            _BD.Cerrar()
        End Try

        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una cola de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PNumeroCola">(Integer)Numero de cola.</param>
    ''' <param name="PMesa">(String)Nombre de mesa.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    ''' <returns>(Integer) Updates. Número de citas modificadas en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PnumeroCola As Integer, ByVal PMesa As String, ByVal PMedicoId As Integer) As Integer

        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE colas SET NumCola =  " & PnumeroCola & ",  NumMesa =  """ & PMesa & """,  MedicoId =  " & PMedicoId & " WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' ModificarMesa. Permite modificar el nombre de la mesa de una cola por su id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PMesa">(String)Nombre de mesa.</param>
    ''' <returns>(Integer) Updates. Número de citas modificadas en nuestra base de datos</returns> 
    Public Function ModificarMesa(ByVal PId As Integer, ByVal PMesa As String) As Integer

        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE colas SET NombreConsulta =  """ & PMesa & """ WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function


    ''' <summary>
    ''' AsignarMedico. Permite modificar los datos de una cola de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    ''' <returns>(Integer) Updates. Número de citas modificadas en nuestra base de datos</returns> 
    Public Function AsignarMedico(ByVal PId As Integer, ByVal PNumColegiado As String) As Integer

        Dim Updates As Integer
        Dim SQL As String

        If (PNumColegiado = "-1") Then
            SQL = "UPDATE colas SET  MedicoId = -1 WHERE Id= " & PId

        Else
            SQL = "UPDATE colas SET  MedicoId =  (Select Id from medicos WHERE NumColegiado=" & PNumColegiado & ") WHERE Id= " & PId
        End If
        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una cola de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cola.</param>
    ''' <returns>(Integer) Deletes. Número de colas borradas en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM colas WHERE id= " & PId
        Deletes = EjecutarCUD(SQL)
        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las colas.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de todas las colas devueltas por la consulta.</returns> 
    Public Function Consultar() As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT Id, NumCola, NumMesa, MedicoId, NombreConsulta FROM colas ORDER BY NumCola"

        Tabla = EjecutarSelect(SQL)
        Return Tabla

    End Function


    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las colas.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de todas las colas devueltas por la consulta.</returns> 
    Public Function ConsultarMedico(ByVal PNumColegiado As String) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT colas.Id, NumCola, NumMesa, MedicoId,NombreConsulta FROM colas, medicos WHERE MedicoId=-1 OR (medicos.Id=colas.MedicoId AND NumColegiado=" & PNumColegiado & ") ORDER BY NumCola"

        Tabla = EjecutarSelect(SQL)
        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de una cola determinada por si Id.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de la cola devuelta por la consulta determinada por su Id.</returns> 
    Public Function Consultar(ByVal Pid As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT Id, NumCola, NumMesa, MedicoId,NombreConsulta  FROM colas WHERE Id=" & Pid

         Tabla = EjecutarSelect(SQL)
        Return Tabla


    End Function

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que cierre la base de datos.
    ''' </summary>
    Public Sub dispose()
        If (Not _BD Is Nothing) Then
            _BD.Cerrar()
        End If
    End Sub

End Class
