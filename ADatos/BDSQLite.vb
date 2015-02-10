Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' BDSQLite.vb
''' Contiene la clase BDSQLite.
''' Encargada de gestionar todos los métodos y funciones utilizados para la comunicación con base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class BDSQLite
    Private _ConexionConBD As SQLiteConnection
    Private _Orden As SQLiteCommand
    Private _Lector As SQLiteDataReader
    Private _Escalar As Integer
    Shared _strConexion As String
    Private _Err As SQLiteErrorCode


    '''<summary>
    '''Constructor BDSQLite. Establece la conexión con la base de datos.
    ''' </summary>
    Public Sub New()
        _strConexion = "Data Source=|DataDirectory|/turnos.s3db;"
        ''_strConexion = "Data Source=c:\gturnos\turnos.s3db;"
        _ConexionConBD = Nothing
        _Orden = Nothing
        _Lector = Nothing

    End Sub

    Public ReadOnly Property Err As SQLiteErrorCode
        Get
            Return _Err
        End Get
    End Property

    '''<summary>
    '''Abrir. Abre la base de datos de nuestra aplicación
    ''' </summary>
    Public Sub Abrir()
        'Abrir la base de datos
        _ConexionConBD = New SQLiteConnection(_strConexion)
        _ConexionConBD.Open()

    End Sub

    '''<summary>
    '''Cerrar. Cierra la base de datos de nuestra aplicación
    ''' </summary>
    Public Sub Cerrar()
        ' Cerrar la conexión cuando ya no sea necesaria
        If (Not _Lector Is Nothing) Then
            _Lector.Close()
        End If
        If (Not _ConexionConBD Is Nothing) Then
            _ConexionConBD.Close()
        End If
    End Sub

    '''<summary>
    '''EjecutarDML. Ejecuta los comandos DML (Select) en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(SQLiteDataAdapter) _Lector. Data Reader con los datos devueltos por la consulta.</returns> 
    Public Function EjecutarDMLDA(ByRef SQL As String) As SQLiteDataAdapter
        ' Ejecutar DML
        _Orden = New SQLiteCommand(SQL, _ConexionConBD)
        Dim Adapter As New SQLiteDataAdapter(_Orden)
        Return Adapter
    End Function

    '''<summary>
    '''EjecutarDML. Ejecuta los comandos DML (Select) en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(SQLiteDataReader) _Lector. Data Reader con los datos devueltos por la consulta.</returns> 
    Public Function EjecutarDML(ByRef SQL As String) As SQLiteDataReader
        ' Ejecutar DML
        _Orden = New SQLiteCommand(SQL, _ConexionConBD)
        _Lector = _Orden.ExecuteReader()
        Return _Lector
    End Function

    '''<summary>
    '''EjecutarDDL. Ejecuta los comandos Insert, Update, Delete en nuestra aplicación.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(Integer) FilasAfectadas. Número de filas afectadas en nuestra base de datos</returns>
    Public Function EjecutarDDL(ByRef SQL As String) As Integer
        ' Ejecutar DDL
        Dim FilasAfectadas As Integer
        _Orden = New SQLiteCommand(SQL, _ConexionConBD)

        FilasAfectadas = _Orden.ExecuteNonQuery()

        Return FilasAfectadas
    End Function

     '''<summary>
    '''EjecutarDMLEscalar. Función utilizada para devolver la ID de nuestra última inserción y comprobar la validación de un médico en el sistema.
    ''' </summary>
    ''' <param name="SQL">(String) Comando SQL a enviar a la base de datos.</param>
    ''' <returns>(Integer) _Escalar.</returns>
    Public Function EjecutarDMLEscalar(ByRef SQL As String) As Integer
        ' Ejecutar DML
        _Orden = New SQLiteCommand(SQL, _ConexionConBD)

        _Escalar = CInt(_Orden.ExecuteScalar())
        Return _Escalar
    End Function

     ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que cierre la base de datos.
    ''' </summary>>
    Public Sub dispose()
        Me.Cerrar()
    End Sub
End Class
