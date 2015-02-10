Option Explicit On
Option Strict On

''' <summary>
''' Direccion.vb
''' Contiene la clase Direccion.
''' Encargada de crear, modificar, consultar y eliminar las direcciones de las personas de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Direccion
    Private _Id As Integer
    Private _TipoVia As String '10
    Private _Via As String '50
    Private _Numero As String '5
    Private _Kilometro As Integer
    Private _Hectometro As Integer
    Private _Bloque As String '3
    Private _Portal As String '3
    Private _Escalera As String '2
    Private _Planta As String '5
    Private _Puerta As String '2
    Private _Localidad As String '50
    Private _Municipio As String '50
    Private _Provincia As String '30
    Private _CodPostal As String '5
    Private _PersonaId As Integer

    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As DireccionADO

    ''' <summary>
    '''Constructor Direccion.
    ''' </summary>   
    Public Sub New()

        _TipoVia = ""
        _Via = ""
        _Numero = ""
        _Kilometro = 0
        _Hectometro = 0
        _Bloque = ""
        _Portal = ""
        _Escalera = ""
        _Planta = ""
        _Puerta = ""
        _Localidad = ""
        _Municipio = ""
        _Provincia = ""
        _CodPostal = ""
        _PersonaId = 0

    End Sub

    ''' <summary>
    '''Constructor Direccion.
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
    Public Sub New(ByRef PTipoVia As String, ByRef PVia As String, ByRef PNumero As String, ByRef PKilometro As Integer, ByRef PHectometro As Integer, ByRef PBloque As String, ByRef PPortal As String, ByRef PEscalera As String, ByRef PPlanta As String, ByRef PPuerta As String, ByRef PLocalidad As String, ByRef PMunicipio As String, ByRef PProvincia As String, ByRef PCodPostal As String, ByRef PPersonaId As Integer)
        Dim Inserciones As Integer = 0
        _TipoVia = PTipoVia
        _Via = PVia
        _Numero = PNumero
        _Kilometro = PKilometro
        _Hectometro = PHectometro
        _Bloque = PBloque
        _Portal = PPortal
        _Escalera = PEscalera
        _Planta = PPlanta
        _Puerta = PPuerta
        _Localidad = PLocalidad
        _Municipio = PMunicipio
        _Provincia = PProvincia
        _CodPostal = PCodPostal
        _PersonaId = PPersonaId

        'Lo insertamos en la BD
        _ADO = New DireccionADO
        Inserciones = _ADO.Insertar(TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Escalera, Planta, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId)
        
    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una dirección determinada por su Id.
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
    Public Sub Modificar(ByRef PTipoVia As String, ByRef PVia As String, ByRef PNumero As String, ByRef PKilometro As Integer, ByRef PHectometro As Integer, ByRef PBloque As String, ByRef PPortal As String, ByRef PEscalera As String, ByRef PPlanta As String, ByRef PPuerta As String, ByRef PLocalidad As String, ByRef PMunicipio As String, ByRef PProvincia As String, ByRef PCodPostal As String, ByRef PPersonaId As Integer)
        Dim Updates As Integer = 0
        _Via = PVia
        _Numero = PNumero
        _Kilometro = PKilometro
        _Hectometro = PHectometro
        _Bloque = PBloque
        _Portal = PPortal
        _Escalera = PEscalera
        _Planta = PPlanta
        _Puerta = PPuerta
        _Localidad = PLocalidad
        _Municipio = PMunicipio
        _Provincia = PProvincia
        _CodPostal = PCodPostal
        _PersonaId = PPersonaId
        _ADO = New DireccionADO
        Updates = _ADO.Modificar(TipoVia, Via, Numero, Kilometro, Hectometro, Bloque, Portal, Escalera, Planta, Puerta, Localidad, Municipio, Provincia, CodPostal, PersonaId)

    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar una dirección determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Dirección.</param>
    Public Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        _Id = PId
        _ADO = New DireccionADO
        Deletes = _ADO.Borrar(Id)
        
    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las direcciones.
    ''' </summary>
    ''' <returns>(List(Of Direccion)) Direccion. Lista de direcciones con todos los datos de todas las direcciones de nuestra base de datos.</returns> 
    Public Overloads Function Consultar() As List(Of Direccion)
        Dim Result As New DataTable
        Dim Direcciones As New List(Of Direccion)
        _ADO = New DireccionADO
        Result = _ADO.Consultar()

        For Each Row As DataRow In Result.Rows
            Dim D As New Direccion
            D.Id = CInt(Row("Id"))
            D.TipoVia = CStr(Row("TipoVia"))
            D.Via = CStr(Row("Via"))
            D.Numero = CStr(Row("Numero"))
            If CStr(Row("Kilometro")) = "" Then
                D.Kilometro = -1
            Else
                D.Kilometro = CInt(Row("Kilometro"))
            End If
            If CStr(Row("Hectometro")) = "" Then
                D.Hectometro = -1
            Else
                D.Hectometro = CInt(Row("Hectometro"))
            End If

            D.Bloque = CStr(Row("Bloque"))
            D.Portal = CStr(Row("Portal"))
            D.Escalera = CStr(Row("Escalera"))
            D.Planta = CStr(Row("Planta"))
            D.Puerta = CStr(Row("Puerta"))
            D.Localidad = CStr(Row("Localidad"))
            D.Municipio = CStr(Row("Municipio"))
            D.Provincia = CStr(Row("Provincia"))
            D.CodPostal = CStr(Row("CodPostal"))
            D.PersonaId = CInt(Row("PersonaId"))
            Direcciones.Add(D)
        Next

        Return Direcciones
    End Function


    ''' <summary>
    ''' Consultar. Permite consultar los datos de una dirección determinada por el Id de Person.
    ''' </summary>
    ''' <param name="PId  ">(Integer)Id de dirección a consultar.</param>
    ''' <returns>(Direccion) Dir. Objeto Dirección con los datos de la dirección devuelta por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PId As Integer) As Direccion
        Dim Result As New DataTable
        Dim Dir As New Direccion
        _ADO = New DireccionADO
        Id = PId
        Result = _ADO.Consultar(Id)

        For Each Row As DataRow In Result.Rows

            Dir.Id = CInt(Row("Id"))
            Dir.TipoVia = CStr(Row("TipoVia"))
            Dir.Via = CStr(Row("Via"))
            Dir.Numero = CStr(Row("Numero"))
            Dir.Kilometro = CInt(Row("Kilometro"))
            Dir.Hectometro = CInt(Row("Hectometro"))
            Dir.Bloque = CStr(Row("Bloque"))
            Dir.Portal = CStr(Row("Portal"))
            Dir.Escalera = CStr(Row("Escalera"))
            Dir.Planta = CStr(Row("Planta"))
            Dir.Puerta = CStr(Row("Puerta"))
            Dir.Localidad = CStr(Row("Localidad"))
            Dir.Municipio = CStr(Row("Municipio"))
            Dir.Provincia = CStr(Row("Provincia"))
            Dir.CodPostal = CStr(Row("CodPostal"))
            Dir.PersonaId = CInt(Row("PersonaId"))

        Next
        Return Dir
    End Function



    ''' <summary>
    ''' Consultar. Permite consultar los datos de una dirección determinada por el Id de Person.
    ''' </summary>
    ''' <param name="PPersonaId ">(Integer)Id de persona a consultar.</param>
    ''' <returns>(Direccion) Dir. Objeto Dirección con los datos de la dirección devuelta por la consulta.</returns> 
    Public Overloads Function ConsultarPorPersona(ByRef PPersonaId As Integer) As Direccion
        Dim Result As New DataTable
        Dim Dir As New Direccion
        _ADO = New DireccionADO
        PersonaId = PPersonaId
        Result = _ADO.ConsultarPorPersona(PersonaId)
        For Each Row As DataRow In Result.Rows

            Dir.Id = CInt(Row("Id"))
            Dir.TipoVia = CStr(Row("TipoVia"))
            Dir.Via = CStr(Row("Via"))
            Dir.Numero = CStr(Row("Numero"))
            Dir.Kilometro = CInt(Row("Kilometro"))
            Dir.Hectometro = CInt(Row("Hectometro"))
            Dir.Bloque = CStr(Row("Bloque"))
            Dir.Portal = CStr(Row("Portal"))
            Dir.Escalera = CStr(Row("Escalera"))
            Dir.Planta = CStr(Row("Planta"))
            Dir.Puerta = CStr(Row("Puerta"))
            Dir.Localidad = CStr(Row("Localidad"))
            Dir.Municipio = CStr(Row("Municipio"))
            Dir.Provincia = CStr(Row("Provincia"))
            Dir.CodPostal = CStr(Row("CodPostal"))
            Dir.PersonaId = CInt(Row("PersonaId"))

        Next
        Return Dir
    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla direcciones.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-DIR0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad TipoVía(String)Tipo Vía.
    '''</summary>
    Public Property TipoVia As String
        Get
            Return _TipoVia
        End Get
        Set(Value As String)
            If Value.Length > 10 Then
                Throw New DuplicateNameException("ERR-DIR0002: El Tipo de Vía no debe exceder de 10 caracteres")
            Else
                _TipoVia = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Vía (String)Nombre Vía.
    '''</summary>
    Public Property Via As String
        Get
            Return _Via
        End Get
        Set(Value As String)
            If Value.Length > 50 Then
                Throw New DuplicateNameException("ERR-DIR0003: La Vía no debe exceder de 50 caracteres")
            Else
                _Via = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Numero (String) Número Vía.
    '''</summary>
    Public Property Numero As String
        Get
            Return _Numero
        End Get
        Set(Value As String)
            If Value.Length > 5 Then
                Throw New DuplicateNameException("ERR-DIR0004: El número no debe exceder de 5 caracteres")
            Else
                _Numero = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Kilometro (Integer) Kilómetro vía.
    '''</summary>
    Public Property Kilometro As Integer
        Get
            Return _Kilometro
        End Get
        Set(Value As Integer)

                _Kilometro = Value
        End Set
    End Property

    '''<summary>
    '''Propiedad Hectómetro (Integer) Hectómetro vía.
    '''</summary>
    Public Property Hectometro As Integer
        Get
            Return _Hectometro
        End Get
        Set(Value As Integer)
            _Hectometro = Value
        End Set
    End Property

    '''<summary>
    '''Propiedad Bloque (String) Bloque vía.
    '''</summary>
    Public Property Bloque As String
        Get
            Return _Bloque
        End Get
        Set(Value As String)
            If Value.Length > 3 Then
                Throw New DuplicateNameException("ERR-DIR0005: El Bloque no debe exceder de 3 caracteres")
            Else
                _Bloque = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Portal (Integer) Portal dirección.
    '''</summary>
    Public Property Portal As String
        Get
            Return _Portal
        End Get
        Set(Value As String)
            If Value.Length > 3 Then
                Throw New DuplicateNameException("ERR-DIR0006: El Portal no debe exceder de 3 caracteres")
            Else
                _Portal = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Escalera (String) Escalera dirección.
    '''</summary>
    Public Property Escalera As String
        Get
            Return _Escalera
        End Get
        Set(Value As String)
            If Value.Length > 2 Then
                Throw New DuplicateNameException("ERR-DIR0007: la Escalera a no debe exceder de 2 caracteres")
            Else
                _Escalera = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Planta (String) Planta dirección.
    '''</summary>
    Public Property Planta As String
        Get
            Return _Planta
        End Get
        Set(Value As String)
            If Value.Length > 5 Then
                Throw New DuplicateNameException("ERR-DIR0008: La Planta no debe exceder de 5 caracteres")
            Else
                _Planta = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Puerta (String) Puerta dirección.
    '''</summary>
    Public Property Puerta As String
        Get
            Return _Puerta
        End Get
        Set(Value As String)
            If Value.Length > 2 Then
                Throw New DuplicateNameException("ERR-DIR0009: La Puerta no debe exceder de 2 caracteres")
            Else
                _Puerta = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Localidad (String) Localidad dirección.
    '''</summary>
    Public Property Localidad As String
        Get
            Return _Localidad
        End Get
        Set(Value As String)
            If Value.Length > 50 Then
                Throw New DuplicateNameException("ERR-DIR0010: La Localidad no debe exceder de 50 caracteres")
            Else
                _Localidad = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Municipio (String) Municipio dirección.
    '''</summary>
    Public Property Municipio As String
        Get
            Return _Municipio
        End Get
        Set(Value As String)
            If Value.Length > 50 Then
                Throw New DuplicateNameException("ERR-DIR0011: El Municipio a no debe exceder de 50 caracteres")
            Else
                _Municipio = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Provincia (String) Provincia dirección.
    '''</summary>
    Public Property Provincia As String
        Get
            Return _Provincia
        End Get
        Set(Value As String)
            If Value.Length > 30 Then
                Throw New DuplicateNameException("ERR-DIR0012: La Provincia a no debe exceder de 30 caracteres")
            Else
                _Provincia = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad CodPostal (String) Código Postal dirección.
    '''</summary>
    Public Property CodPostal As String
        Get
            Return _CodPostal
        End Get
        Set(Value As String)
            If Value.Length > 5 Then
                Throw New DuplicateNameException("ERR-DIR0013: El Código Postal no debe exceder de 5 caracteres")
            Else
                _CodPostal = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad PersonaId (Integer) Id de la Persona que vive en esta dirección.
    '''</summary>
    Public Property PersonaId As Integer
        Get
            Return _PersonaId
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-DIR0014: El Id de Persona no puede ser 0 o nulo.")
            Else
                _PersonaId = Value
            End If
        End Set
    End Property

     ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _TipoVia = ""
        _Via = ""
        _Numero = ""
        _Kilometro = 0
        _Hectometro = 0
        _Bloque = ""
        _Portal = ""
        _Escalera = ""
        _Planta = ""
        _Puerta = ""
        _Localidad = ""
        _Municipio = ""
        _Provincia = ""
        _CodPostal = ""
        _PersonaId = 0
        _ADO.dispose()
    End Sub
End Class
