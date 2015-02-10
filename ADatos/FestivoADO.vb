Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' FestivoADO.vb
''' Contiene la clase FestivoADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' los días festivos de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class FestivoADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor FestivoADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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
    '''Función Insertar. Encargada de insertar un nuevo festivo en nuestra base de datos.
    ''' </summary>
    ''' <param name="PFechaFestivo">(Date)Fecha Festivo.</param>
    ''' <param name="PNombreFestivo ">(Date)Nombre Festivo.</param>
    ''' <returns>(Integer) Inserciones. Número de festivos insertados en nuestra base de datos</returns>
    Public Function Insertar(ByVal PFechaFestivo As Date, ByVal PNombreFestivo As String) As Integer
        Dim Inserciones As Integer
        Dim SQL As String

        Dim Fecha As String = PFechaFestivo.ToString("yyyy-MM-dd")
        SQL = "INSERT INTO festivos (FechaFestivo, NombreFestivo) VALUES ( """ & Fecha & """ , """ & PNombreFestivo & """)"

        Inserciones = EjecutarCUD(SQL)
        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un festivo de nuestra base de datos determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PFechaFestivo">(Date)Fecha Festivo.</param>
    ''' <param name="PNombreFestivo ">(Date)Nombre Festivo.</param>
    ''' <returns>(Integer) Updates. Número de festivos modificados en nuestra base de datos</returns> 
    Public Function Modificar(ByVal PId As Integer, ByVal PFechaFestivo As Date, ByVal PNombreFestivo As String) As Integer

        Dim Updates As Integer
        Dim SQL As String
        Dim Fecha As String = PFechaFestivo.ToString("yyyy-MM-dd")

        SQL = "UPDATE festivos SET FechaFestivo =  """ & Fecha & """,  NombreFestivo =  """ & PNombreFestivo & """ WHERE id= " & PId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar un festivo determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo.</param>
    ''' <returns>(Integer) Deletes. Número de festivos borrados en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM festivos WHERE id= " & PId
        Deletes = EjecutarCUD(SQL)

        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los festivos.
    ''' </summary>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todas los festivos de nuestra base de datos.</returns> 
    Public Function Consultar() As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT Id, FechaFestivo, NombreFestivo FROM festivos"

        Tabla = EjecutarSelect(SQL)
        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un festivo de nuestra base de datos determinados por su Id
    ''' </summary>
    ''' <param name="PId ">(Integer)Id de festivo.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos del festivo devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PId As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT Id, FechaFestivo, NombreFestivo FROM festivos WHERE Id=  " & PId

       Tabla = EjecutarSelect(SQL)
        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un festivo de nuestra base de datos determinados por una Fecha
    ''' </summary>
    ''' <param name="PFecha  ">(Date)Fecha de festivo.</param>
    ''' <returns>(DataTable) Tabla. DataTable con los datos del festivo devuelto por la consulta.</returns> 
    Public Function Consultar(ByVal PFecha As Date) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Fecha As String = PFecha.ToString("yyyy-MM-dd")
        SQL = "SELECT Id, FechaFestivo, NombreFestivo FROM festivos WHERE FechaFestivo= '" & Fecha & "'"

        Tabla = EjecutarSelect(SQL)
        Return Tabla
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los festivos de nuestra base de datos en un año determinado.
    ''' </summary>
    ''' <param name="Anyo">(Integer)Año a consultar.</param>
    ''' <returns>(DataTable) Tabla. DataTable con todos los datos de todas los festivos de nuestra base de datos en el año especificado.</returns> 
    Public Function Consultar(Anyo As String) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String


        SQL = "SELECT  Id, FechaFestivo, NombreFestivo FROM festivos WHERE FechaFestivo BETWEEN date('" & Anyo & "-01-01') AND date('" & Anyo & "-12-31') "

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
