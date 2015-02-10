Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' CitaADO.vb
''' Contiene la clase CitaADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' las citas de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class CitaADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor CitaADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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

    '''<summary>
    '''EjecutarSelect. Ejecuta los comandos Select en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(DataTable) Result. DataTable conlos datos pedidos a nuestra base de datos</returns>
    Public Function EjecutarSelectDA(ByVal PSQL As String) As SQLiteDataAdapter

        Dim Lector As SQLiteDataAdapter

        Try
            _BD.Abrir()
            _BD.EjecutarDMLDA(PSQL)
            Lector = _BD.EjecutarDMLDA(PSQL)


        Finally
            _BD.Cerrar()
        End Try
        Return Lector
    End Function

    ''' <summary>
    '''Función Insertar. Encargada de insertar una nueva cita en nuestra base de datos.
    ''' </summary>
    ''' <param name="PHora">(String)Hora de la cita.</param>
    ''' <param name="PFecha">(Date)Fecha de la cita.</param>
    ''' <param name="PDuracion">(Integer)Duración de la cita.</param>
    ''' <param name="PTerminada">(Boolean)Cita terminada.</param>
    ''' <param name="PTipoCita">(Boolean)Tipo de cita (True=Inmediata False=Programada).</param>
    ''' <param name="PColaId">(Integer)Id de cola a la que pertenece la cita.</param>
    ''' <param name="PPacienteId">(Integer)Id del paciente de la cita.</param>
    ''' <returns>(Integer) Inserciones. Número de citas insertadas en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PFecha As Date, ByVal PDuracion As Integer, ByVal PTerminada As Integer, ByVal PTipoCita As Integer, ByVal PColaId As Integer, ByVal PPacienteId As Integer) As Integer
        Dim Inserciones As Integer
        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")
        Dim Hora As String = PFecha.ToString("HH:mm")

        SQL = "INSERT INTO citas (Fecha, Hora, Duracion, Terminada, TipoCita, Cola_Id, Paciente_Id) VALUES ( """ & Fecha & """ , """ & Hora & """,""" & PDuracion & """,""" & PTerminada & """, """ & PTipoCita & """, """ & PColaId & """, """ & PPacienteId & """)"

        Inserciones = EjecutarCUD(SQL)
        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una cita de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita PK.</param>
    ''' <param name="PHora">(String)Hora de la cita.</param>
    ''' <param name="PFecha">(Date)Fecha de la cita.</param>
    ''' <param name="PDuracion">(Integer)Duración de la cita.</param>
    ''' <param name="PTerminada">(Boolean)Cita terminada.</param>
    ''' <param name="PTipoCita">(Boolean)Tipo de cita (True=Inmediata False=Programada).</param>
    ''' <param name="PColaId">(Integer)Id de cola a la que pertenece la cita.</param>
    ''' <param name="PPacienteId">(Integer)Id del paciente de la cita.</param>
    ''' <returns>(Integer) Updates. Número de citas modificadas en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PFecha As Date, ByVal PHora As String, ByVal PDuracion As Integer, ByVal PTerminada As Integer, ByVal PTipoCita As Integer, ByVal PColaId As Integer, ByVal PPacienteId As Integer) As Integer

        Dim Updates As Integer
        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")
        SQL = "UPDATE citas SET Fecha =  """ & Fecha & """,  Hora =  """ & PHora & """,  Duracion =  " & PDuracion & ",  Terminada =  """ & PTerminada & """,  TipoCita =  """ & PTipoCita & """,  Cola_Id =  " & PColaId & ",  Paciente_Id =  " & PPacienteId & " WHERE id= " & PId

        Updates = EjecutarCUD(SQL)

        Return Updates
    End Function


    ''' <summary>
    ''' TerminarCita. Permite terminar la cita de un paciente de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita PK.</param>
    ''' <returns>(Integer) Updates. Número de citas modificadas en nuestra base de datos</returns> 
    Public Function TerminarCita(ByVal PId As Integer) As Integer

        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE citas SET Terminada = 1 WHERE id= " & PId

        Updates = EjecutarCUD(SQL)

        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una cita de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita.</param>
    ''' <returns>(Integer) Deletes. Número de citas borradas en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM citas WHERE id= " & PId
       
            Deletes = EjecutarCUD(SQL)
      
        Return Deletes
    End Function


    ''' <summary>
    ''' Borrar. Permite borrar una cita de nuestra base de datos determinado por su Id_Cola.
    ''' </summary>
    ''' <param name="PColaId">(Integer)Id Cita.</param>
    ''' <returns>(Integer) Deletes. Número de citas borradas en nuestra base de datos</returns> 
    Public Function BorrarPorCola(ByVal PColaId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM citas WHERE Cola_Id= " & PColaId

        Deletes = EjecutarCUD(SQL)

        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las citas de nuestra base de datos.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar() As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT * FROM citas"
            Tabla = EjecutarSelect(SQL)

        Return Tabla
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar una citas en nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id Cita.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de la cita devuelta por la consulta.</returns> 
    Public Function Consultar(ByVal PId As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String

        SQL = "SELECT * FROM citas WHERE Id= " & PId

         Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las citas de nuestra base de datos en una fecha determinada.
    ''' </summary>
    ''' <param name="PFecha">(Fecha)Fecha de la cita.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar(ByVal PFecha As Date, ByVal PColaId As Integer) As DataTable

        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")

        SQL = "SELECT * FROM citas WHERE Cola_Id=""" & PColaId & """ AND Fecha='" & Fecha & "'"

        Tabla = EjecutarSelect(SQL)

        Return Tabla
    End Function

    ''' <summary>
    ''' ConsultarCola. Permite consultar las citas de una cola determinada por su Id.
    ''' </summary>
    ''' <param name="PColaId  ">(Integer)Id Cola.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarCola(ByVal PColaId As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT * FROM citas WHERE Cola_Id= " & PColaId

         Tabla = EjecutarSelect(SQL)

        Return Tabla
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar las citas de un paciente en nuestra base de datos determinado por su SIP.
    ''' </summary>
    ''' <param name="PSip">(Integer)SIP Paciente.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de la cita devuelta por la consulta.</returns> 
    Public Function Consultar(ByVal PSip As UInteger) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT citas.Id,Fecha,Hora,Duracion,Terminada,TipoCita,Cola_Id,Paciente_Id FROM citas,pacientes WHERE citas.Paciente_Id=pacientes.Id AND pacientes.SIP= """ & PSip & """ORDER BY Fecha, Hora ASC"

          Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar las citas de un médico en nuestra base de datos determinado por su Nº Colegiado y una fecha concreta.
    ''' </summary>
    ''' <param name="PNumColegiado">(Integer)SIP Paciente.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar(ByVal PNumColegiado As String, ByVal PFecha As Date) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")

        SQL = "SELECT citas.Id, citas.Fecha, citas.Hora, citas.Duracion, citas.Terminada, citas.TipoCita, citas.Cola_Id, citas.Paciente_Id, Personas.Nombre, Personas.Apellidos, Personas.Telefono FROM citas,colas,medicos,personas WHERE colas.Id=citas.Cola_Id AND citas.Paciente_Id=Personas.Id AND colas.MedicoId=medicos.Id AND medicos.NumColegiado= " & PNumColegiado & "  AND citas.Fecha='" & Fecha & "' ORDER BY Hora ASC"


        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' ConsultarDa. Permite consultar las citas de un médico en nuestra base de datos determinado por su Nº Colegiado y una fecha concreta.
    ''' </summary>
    ''' <param name="PNumColegiado">(Integer)SIP Paciente.</param>
    ''' <returns>(DataAdapter) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarDa(ByVal PNumColegiado As String, ByVal PFecha As Date, ByVal ColaId As Integer) As SQLiteDataAdapter

        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")
        SQL = "SELECT citas.Id, citas.Fecha, citas.Hora, citas.Duracion, citas.Terminada, citas.TipoCita, citas.Cola_Id, citas.Paciente_Id, Personas.Nombre, Personas.Apellidos, Personas.Telefono, pacientes.SIP FROM citas,pacientes,colas,medicos,personas WHERE pacientes.Id=citas.Paciente_Id AND colas.Id=citas.Cola_Id AND citas.Paciente_Id=Personas.Id AND colas.MedicoId=medicos.Id AND medicos.NumColegiado= " & PNumColegiado & " AND citas.Cola_Id= " & ColaId & "  AND citas.Fecha='" & Fecha & "' ORDER BY Hora ASC"

        Dim Adapter As SQLiteDataAdapter = EjecutarSelectDA(SQL)
        Return Adapter

    End Function


    ''' <summary>
    ''' ConsultarActuales. Permite consultar las citas de un médico en nuestra base de datos determinado por su Nº Colegiado y una fecha concreta.
    ''' </summary>
    ''' <returns>(DataAdapter) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarActuales() As SQLiteDataAdapter
        Dim SQL As String
        Dim Fecha As String = Now.ToString("yyyy-MM-dd")

        SQL = "SELECT c.Terminada, c.Id, c.Fecha, MIN(c.Hora) Hora, co.NumMesa, co.NombreConsulta, co.NumCola FROM citas c, colas co WHERE c.Cola_Id = co.Id AND c.Fecha='" & Fecha & "' AND Terminada=0 GROUP BY c.Terminada, c.Fecha, co.NombreConsulta ORDER BY co.NumCola"
        Dim Adapter As SQLiteDataAdapter = EjecutarSelectDA(SQL)
        Return Adapter
    End Function

    ''' <summary>
    ''' ConsultarTerminadas. Permite consultar las citas de un médico en nuestra base de datos determinado por su Nº Colegiado y una fecha concreta.
    ''' </summary>
    ''' <returns>(DataAdapter) Tabla. DataTable con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarTerminadas(ByVal NumCola As Integer) As SQLiteDataAdapter
        Dim SQL As String
        Dim Fecha As String = Now.ToString("yyyy-MM-dd")

        SQL = "SELECT c.Terminada, c.Id, c.Fecha, c.Hora, co.NumMesa, co.NombreConsulta, co.NumCola FROM citas c, colas co WHERE c.Cola_Id = co.Id AND co.NumCola=" & NumCola & " AND c.Fecha='" & Fecha & "' AND Terminada=1 ORDER BY c.Hora DESC"
        Dim Adapter As SQLiteDataAdapter = EjecutarSelectDA(SQL)
        Return Adapter
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
