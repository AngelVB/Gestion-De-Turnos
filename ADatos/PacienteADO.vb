Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' PacienteADO.vb
''' Contiene la clase PacienteADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' los pacientes de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class PacienteADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor PacienteADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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
    '''Función Insertar. Encargada de insertar un nuevo paciente en nuestra base de datos.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
    ''' <returns>(Integer) Inserciones. Número de pacientes insertados en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PId As Integer, ByVal PSip As ULong) As Integer
        Dim Inserciones As Integer
        Dim SQL As String

        SQL = "INSERT INTO pacientes (SIP, Id) VALUES ( """ & PSip & """ , " & PId & ")"

        Inserciones = EjecutarCUD(SQL)
        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un paciente de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
    ''' <returns>(Integer) Updates. Número de pacientes modificados en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PSip As ULong) As Integer

        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE pacientes SET SIP =  """ & PSip & """ WHERE id= " & PId
        Updates = EjecutarCUD(SQL)
        If Updates = 0 Then
            SQL = "INSERT INTO pacientes (SIP, Id) VALUES ( """ & PSip & """ , " & PId & ")"
            Updates = EjecutarCUD(SQL)

        End If

        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar un paciente de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <returns>(Integer) Deletes. Número de pacientes borrados en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM pacientes WHERE id= " & PId
        Deletes = EjecutarCUD(SQL)
        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los pacientes de nuestra base de datos.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todas los pacientes de nuestra base de datos.</returns> 
    Public Function Consultar() As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable
        SQL = "SELECT id, SIP FROM pacientes"

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un paciente determinado por su ID.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Paciente.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos del paciente devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PId As Integer) As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable

        SQL = "Select personas.id AS id, Nombre, Apellidos, Telefono, Baja, NIF, Email, SIP, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal from personas, pacientes,direcciones WHERE pacientes.Id=personas.id AND personas.id=direcciones.PersonaId AND pacientes.Id= " & PId

        Tabla = EjecutarSelect(SQL)

        Return Tabla
    End Function

    ''' <summary>
    ''' Buscar. Permite consultar todos los datos de todos los pacientes de nuestra base de datos determinados por él formulario de búsqueda.
    ''' </summary>
    ''' <param name="PBusqueda ">(String)Cadena de búsqueda de nuestro formulario de búsqueda.</param>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todos los pacientes de nuestra base de datos.</returns> 
    Public Function Buscar(ByVal PBusqueda As String) As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable

        SQL = "Select personas.id, Nombre, Apellidos, Telefono, Baja, NIF, Email, SIP, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal from personas, pacientes,direcciones where personas.Id in (select id from pacientes) AND (Nombre like '%" & PBusqueda & "%' or Apellidos like '%" & PBusqueda & "%' or NIF like '%" & PBusqueda & "%' or SIP like '%" & PBusqueda & "%') AND personas.id=pacientes.Id AND personas.id=direcciones.PersonaId"

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un paciente determinado por su SIP.
    ''' </summary>
    ''' <param name="PSip">(Integer)SIP Paciente.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los todos los datos del paciente devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PSip As ULong) As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable

        SQL = "SELECT personas.id, Nombre, Apellidos, Telefono, Baja, NIF, Email, SIP FROM pacientes, personas WHERE pacientes.Id=personas.id AND SIP= """ & PSip & """"

        Tabla = EjecutarSelect(SQL)

        Return Tabla
    End Function

    ''' <summary>
    ''' Existe. Permite consultar si existe el paciente a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Integer) Id.</returns> 
    Public Function Existe(ByVal PSIP As ULong) As Integer
        Dim SQL As String
        Dim Id As Integer

        SQL = "SELECT 1 FROM pacientes WHERE SIP= " & PSIP

        Try
            _BD.Abrir()
            Id = _BD.EjecutarDMLEscalar(SQL)
        Finally
            _BD.Cerrar()
        End Try
        Return Id
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
