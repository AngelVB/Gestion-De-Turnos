Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SQLite

''' <summary>
''' DireccionADO.vb
''' Contiene la clase DireccionADO.
''' Encargada de gestionar todos los métodos y funciones utilizados en la comunicación entre
''' las direcciones de las personas de nuestra aplicación y la base de datos.
''' </summary>
''' <author> Ángel Valera</author>
Public Class DireccionADO
    Private _BD As BDSQLite

    '''<summary>
    '''Constructor DireccionADO. Establece la conexión con la base de datos llamando al constructor de BDSQLite.
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
    ''' <param name="PTipoVia">(String)Tipo Vía.</param>
    ''' <param name="PVia">(String)Nombre Vía.</param>
    ''' <param name="PNumero">(String)Número Vía.</param>
    ''' <param name="PKilometro">(Integer)Kilómetro Vía.</param>
    ''' <param name="PHectometro">(Integer)Hectómetro Vía.</param>
    ''' <param name="PBloque">(String)Bloque Vía.</param> 
    ''' <param name="PPortal">(String)Portal Vía.</param>
    ''' <param name="PEscalera">(String)Escalera.</param>
    ''' <param name="Pplanta">(String)Planta.</param>
    ''' <param name="PPuerta">(String)Puerta.</param>
    ''' <param name="PLocalidad">(String)Localidad.</param>
    ''' <param name="PMunicipio">(String)Municipio.</param>
    ''' <param name="PProvincia">(String)Provincia.</param>
    ''' <param name="PCodPostal">(String)Código Postal.</param>
    ''' <param name="PPersonaId ">(Integer)Id Persona.</param>
    ''' <returns>(Integer) Inserciones. Número de direcciones insertadas en nuestra base de datos</returns> 
    Public Function Insertar(ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String, ByVal PPersonaId As Integer) As Integer
        Dim Inserciones As Integer
        Dim SQL As String
        Dim km As String = ""
        Dim hm As String = ""
        If PKilometro <> -1 Then
            km = CStr(PKilometro)
            If PHectometro <> -1 Then
                hm = CStr(PHectometro)
            End If

        End If
        SQL = "INSERT INTO direcciones (TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Escalera, Planta, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId) VALUES ( """ & PTipoVia & """ , """ & PVia & """, """ & PNumero & """, """ & km & """, """ & hm & """, """ & PBloque & """, """ & PPortal & """, """ & PEscalera & """, """ & PPlanta & """, """ & PPuerta & """, """ & PLocalidad & """, """ & PMunicipio & """, """ & PProvincia & """, """ & PCodPostal & """, """ & PPersonaId & """)"

        Inserciones = EjecutarCUD(SQL)
        Return Inserciones
    End Function

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una dirección de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Dirección PK.</param>
    ''' <param name="PTipoVia">(String)Tipo Vía.</param>
    ''' <param name="PVia">(String)Nombre Vía.</param>
    ''' <param name="PNumero">(String)Número Vía.</param>
    ''' <param name="PKilometro">(Integer)Kilómetro Vía.</param>
    ''' <param name="PHectometro">(Integer)Hectómetro Vía.</param>
    ''' <param name="PBloque">(String)Bloque Vía.</param> 
    ''' <param name="PPortal">(String)Portal Vía.</param>
    ''' <param name="PEscalera">(String)Escalera.</param>
    ''' <param name="Pplanta">(String)Planta.</param>
    ''' <param name="PPuerta">(String)Puerta.</param>
    ''' <param name="PLocalidad">(String)Localidad.</param>
    ''' <param name="PMunicipio">(String)Municipio.</param>
    ''' <param name="PProvincia">(String)Provincia.</param>
    ''' <param name="PCodPostal">(String)Código Postal.</param>
    ''' <param name="PPersonaId ">(Integer)Id Persona.</param> 
    ''' <returns>(Integer) Updates. Número de direcciones modificadas en nuestra base de datos</returns>
    Public Function Modificar(PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String, ByVal PPersonaId As Integer) As Integer
        Dim Updates As Integer
        Dim SQL As String

        SQL = "UPDATE direcciones SET TipoVia =  """ & PTipoVia & """, Via = """ & PVia & """, Numero=""" & PNumero & """, Kilometro=""" & PKilometro & """, Hectometro=""" & PHectometro & """, Bloque= """ & PBloque & """, Portal= """ & PPortal & """, Escalera= """ & PEscalera & """, Planta= """ & PPlanta & """, Puerta= """ & PPuerta & """, Localidad= """ & PLocalidad & """, Municipio= """ & PMunicipio & """, Provincia= """ & PProvincia & """, CodPostal= """ & PCodPostal & """ WHERE PersonaId= " & PPersonaId

        Updates = EjecutarCUD(SQL)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una dirección de nuestra base de datos determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Dirección.</param>
    ''' <returns>(Integer) Deletes. Número de direcciones borradas en nuestra base de datos</returns> 
    Public Function Borrar(ByVal PId As Integer) As Integer
        Dim Deletes As Integer
        Dim SQL As String

        SQL = "DELETE FROM direcciones WHERE id= """ & PId & """"

        Deletes = EjecutarCUD(SQL)
        Return Deletes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las direcciones.
    ''' </summary>
    ''' <returns>(List(Of Direccion)) Direccion. Lista de direcciones con todos los datos de todas las direcciones de nuestra base de datos.</returns> 
    Public Function Consultar() As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT Id, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId FROM direcciones"

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de una dirección determinada en nuestra base de datos por el Id de Persona.
    ''' </summary>
    ''' <param name="PPersonaId ">(Integer)Id de persona a consultar.</param>
    ''' <returns>(Direccion) Dir. Objeto Dirección con los datos de la dirección devuelta por la consulta.</returns> 
    Public Function ConsultarPorPersona(ByRef PPersonaId As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String
        Dim Lector As SQLiteDataReader

        SQL = "SELECT SELECT Id, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId  FROM direcciones WHERE PersonaId=  " & PPersonaId

        Tabla = EjecutarSelect(SQL)

        Return Tabla

    End Function


    ''' <summary>
    ''' Consultar. Permite consultar los datos de una dirección determinada en nuestra base de datos por su Id.
    ''' </summary>
    ''' <param name="PId  ">(Integer)Id de dirección a consultar.</param>
    ''' <returns>(Direccion) Dir. Objeto Dirección con los datos de la dirección devuelta por la consulta.</returns> 
    Public Function Consultar(ByRef PId As Integer) As DataTable
        Dim Tabla As New DataTable
        Dim SQL As String

        SQL = "SELECT SELECT Id, TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Planta, Escalera, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId  FROM direcciones WHERE Id=  " & PId

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
