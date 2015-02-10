Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' MedicoADO.vb
''' Contiene la clase MedicoADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' los médicos de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class MedicoADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor MedicoADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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
    '''Función Insertar. Encargada de insertar un nuevo médico en nuestra base de datos.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PNumColegiado">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword ">(String)Contraseña médico.</param>
    ''' <returns>(Integer) Inserciones. Número de médicos insertados en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PId As Integer, ByVal PNumColegiado As String, ByVal PPassword As String) As Integer
        Dim Inserciones As Integer
        Dim SQL As String

        SQL = "INSERT INTO medicos (NumColegiado, Id, Password) VALUES ( """ & PNumColegiado & """ , " & PId & " , """ & PPassword & """)"

        Inserciones = EjecutarCUD(SQL)
        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un médico de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PNumColegiado">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword ">(String)Contraseña médico.</param>
    ''' <returns>(Integer) Updates. Número de médicos modificados en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PNumColegiado As String, ByVal PPassword As String) As Integer

        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE medicos SET NumColegiado =  """ & PNumColegiado & """ , Password=  """ & PPassword & """ WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        If Updates = 0 Then
            SQL = "INSERT INTO medicos (NumColegiado, Id, Password) VALUES ( """ & PNumColegiado & """ , " & PId & " , """ & PPassword & """)"
            Updates = EjecutarCUD(SQL)

        End If
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar un médico de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Médico.</param>
    ''' <returns>(Integer) Deletes. Número de médicos borrados en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM medicos WHERE id= " & PId
        Deletes = EjecutarCUD(SQL)
        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los médicos de nuestra base de datos.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todos los médicos de nuestra base de datos.</returns> 
    Public Function Consultar() As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable

        SQL = "SELECT Id, NumColegiado, Password FROM medicos"

        Tabla = EjecutarSelect(SQL)

        Return Tabla


    End Function

    ''' <summary>
    ''' Buscar. Permite consultar todos los datos de todos los médicos de nuestra base de datos determinados por él formulario de búsqueda.
    ''' </summary>
    ''' <param name="PBusqueda ">(String)Cadena de búsqueda de nuestro formulario de búsqueda.</param>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todos los médicos de nuestra base de datos.</returns> 
    Public Function Buscar(ByVal PBusqueda As String) As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable
        SQL = "Select personas.id, Nombre, Apellidos, Telefono, Baja, NIF, Email, NumColegiado, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal from personas, medicos,direcciones where personas.Id in (select id from medicos) AND (Nombre like '%" & PBusqueda & "%' or Apellidos like '%" & PBusqueda & "%' or NIF like '%" & PBusqueda & "%' or NumColegiado like '%" & PBusqueda & "%') AND personas.id=medicos.Id AND personas.id=direcciones.PersonaId"

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un médico determinado por su Nº Colegiado.
    ''' </summary>
    ''' <param name="PNumColegiado">(String)Nº Colegiado médico.</param>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos del médico devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PNumColegiado As String) As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable
        SQL = "SELECT personas.id, Nombre, Apellidos, Telefono, Baja, NIF, Email, NumColegiado FROM medicos,personas WHERE personas.id=medicos.Id AND NumColegiado= """ & PNumColegiado & """"

        Tabla = EjecutarSelect(SQL)

        Return Tabla


    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un médico determinado por su Nº Colegiado.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos del médico devuelto por la consulta.</returns> 
    Public Function ConsultarCompleto() As DataTable
        Dim SQL As String
        Dim Tabla As New DataTable
        SQL = "SELECT personas.id, Nombre, Apellidos, Telefono, Baja, NIF, Email, NumColegiado FROM medicos,personas WHERE personas.id=medicos.Id "

        Tabla = EjecutarSelect(SQL)

        Return Tabla


    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un médico determinado por su Id
    ''' </summary>
    ''' <param name="PId ">(String)Nº Colegiado médico.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos del médico devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PId As Integer) As DataTable
        Dim SQL As String

        Dim Tabla As New DataTable
        SQL = "Select personas.id AS id, Nombre, Apellidos, Telefono, Baja, NIF, Email, NumColegiado, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal from personas, medicos,direcciones WHERE medicos.Id=personas.id AND personas.id=direcciones.PersonaId AND medicos.Id= " & PId
        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Existe. Permite consultar si existe el paciente a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Integer) Id.</returns> 
    Public Function Existe(ByVal PNumColegiado As String) As Integer
        Dim SQL As String
        Dim Id As Integer

        SQL = "SELECT 1 FROM medicos WHERE NumColegiado= """ & PNumColegiado & """"

        Try
            _BD.Abrir()
            Id = _BD.EjecutarDMLEscalar(SQL)
        Finally
            _BD.Cerrar()
        End Try

        Return Id
    End Function

    ''' <summary>
    ''' Validar. Valida los datos de un médico para que pueda acceder al sistema
    ''' </summary>
    ''' <param name="PNumColegiado ">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword">(String)Password médico.</param>
    ''' <returns>(Boolean) Devuelve True si existe un médico con esa contraseña en la base de datos.</returns> 
    Public Function Validar(ByVal PNumColegiado As String, ByVal PPassword As String) As Boolean
        Dim SQL As String
        Dim Lector As Integer
        SQL = "SELECT 1 FROM medicos WHERE NumColegiado= """ & PNumColegiado & """ AND Password=""" & PPassword & """"

        Try
            _BD.Abrir()
            Lector = _BD.EjecutarDMLEscalar(SQL)
        Finally
            _BD.Cerrar()
        End Try


        If Lector <> 1 Then
            Return False
        Else
            Return True
        End If
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
