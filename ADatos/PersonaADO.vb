Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' PersonaADO.vb
''' Contiene la clase PersonaADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' las personas de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class PersonaADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor PersonaADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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
    '''Función Insertar. Encargada de insertar una nueva persona en nuestra base de datos.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <returns>(Integer) Inserciones. Número de personas insertadas en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer) As Integer
        Dim Inserciones As Integer
        Dim SQL As String

        SQL = "INSERT INTO personas (Nombre,Apellidos,NIF,Email,Telefono,Baja) VALUES ( """ & PNombre & """ , """ & PApellidos & """, """ & PNif & """, """ & PEmail & """, """ & PTelefono & """, """ & PBaja & """)"

        Inserciones = EjecutarCUD(SQL)

        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una persona de nuestra base de datosdeterminada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <returns>(Integer) Updates. Número de personas modificadas en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer) As Integer
        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE personas SET Nombre =  """ & PNombre & """, Apellidos = """ & PApellidos & """, NIF=""" & PNif & """, Email=""" & PEmail & """, Telefono=""" & PTelefono & """,Baja= """ & PBaja & """ WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una persona de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <returns>(Integer) Deletes. Número de personas borradas en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM personas WHERE id= " & PId
        Deletes = EjecutarCUD(SQL)
        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las personas.
    ''' </summary>
    ''' <returns>(List(Of Persona)) Prsona. Lista de personas con todos los datos de todas las direcciones de nuestra base de datos.</returns> 
    Public Function Consultar() As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT Id, Nombre, Apellidos, Telefono, Baja, NIF, Email FROM personas"

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function


    ''' <summary>
    ''' ConsultarId. Permite consultar la id de la última persona insertada.
    ''' Utilizaremos este método para poder insertar pacientes, médicos o direcciones con la Id de persona correcta.
    ''' </summary>
    ''' <returns>(Integer) Id.</returns> 
    Public Function ConsultarId() As Integer
        Dim SQL As String
        Dim Id As Integer

        SQL = "SELECT seq FROM SQLITE_SEQUENCE WHERE name='personas'"
        Try
            _BD.Abrir()
            Id = _BD.EjecutarDMLEscalar(SQL)
        Finally
            _BD.Cerrar()
        End Try

        Return Id
    End Function

    ''' <summary>
    ''' Existe. Permite consultar si existe la persona a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Integer) Id.</returns> 
    Public Function Existe(ByVal PNIF As String) As Integer
        Dim SQL As String
        Dim Id As Integer

        SQL = "SELECT id FROM personas WHERE NIF= """ & PNIF & """"

        Try
            _BD.Abrir()
            Id = _BD.EjecutarDMLEscalar(SQL)
        Finally
            _BD.Cerrar()
        End Try

        Return Id
    End Function

    ''' <summary>
    ''' UpdateBaja. Permite modificar el valor del atributo Baja por el Id de persona.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <returns>(Integer) Updates. Número de personas modificadas en nuestra base de datos</returns> 
    Public Function UpdateBaja(ByVal PId As Integer, ByVal PBaja As Integer) As Integer
        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE personas SET Baja= """ & PBaja & """ WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que cierre la base de datos.
    ''' </summary>
    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.Cerrar()
        End If
    End Sub

End Class
