Option Explicit On
Option Strict On

''' <summary>
''' Persona.vb
''' Contiene la clase Persona. 
''' Encargada de crear, modificar, consultar y eliminar personas de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author> 
Public Class Persona
    
    Private _Id As Integer
    Private _Nombre As String
    Private _Apellidos As String
    Private _Nif As String
    Private _Email As String
    Private _Telefono As String
    Private _Baja As Integer

    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As PersonaADO

    '''<summary>
    '''Constructor Persona.
    ''' </summary>
    Public Sub New()

        _Nombre = ""
        _Apellidos = ""
        _Nif = ""
        _Email = ""
        _Telefono = ""
        _Baja = 0


    End Sub

    ''' <summary>
    '''Constructor Persona.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Sub New(ByRef PId As Integer, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        Dim Inserciones As Integer = 0
        Nombre = PNombre
        Apellidos = PApellidos
        Nif = PNif
        Email = PEmail
        Telefono = PTelefono
        Baja = PBaja
        _ADO = New PersonaADO
        Try
            Inserciones = _ADO.Insertar(Nombre, Apellidos, Nif, Email, Telefono, Baja)
        Finally
            PId = Existe(PNif)
        End Try
    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una persona determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Sub Modificar(ByRef PId As Integer, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        Dim Updates As Integer = 0
        Id = PId
        Nombre = PNombre
        Apellidos = PApellidos
        Nif = PNif
        Email = PEmail
        Telefono = PTelefono
        Baja = PBaja
        _ADO = New PersonaADO
        Updates = _ADO.Modificar(Id, Nombre, Apellidos, Nif, Email, Telefono, Baja)


    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar una persona determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    Public Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        Id = PId
        _ADO = New PersonaADO
        _ADO.Borrar(Id)
        
    End Sub

    ''' <summary>
    ''' ConsultarId. Permite consultar la id de la última persona insertada.
    ''' Utilizaremos este método para poder insertar pacientes, médicos o direcciones con la Id de persona correcta.
    ''' </summary>
    ''' <returns>(Integer) UltimaId. Id de la última persona insertada.</returns> 
    Public Function ConsultarId() As Integer
        Dim UltimaId As Integer
        _ADO = New PersonaADO
        UltimaId = _ADO.ConsultarId
        Return UltimaId
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las direcciones.
    ''' </summary>
    ''' <returns>(List(Of Direccion)) Direccion. Lista de direcciones con todos los datos de todas las direcciones de nuestra base de datos.</returns> 
    Public Overloads Function Consultar() As List(Of Persona)
        Dim Result As New DataTable
        Dim Personas As New List(Of Persona)
        _ADO = New PersonaADO
        Result = _ADO.Consultar()

        For Each Row As DataRow In Result.Rows
            Dim P As New Persona
            P.Id = CInt(Row("Id"))
            P.Nombre = CStr(Row("Nombre"))
            P.Apellidos = CStr(Row("Apellidos"))
            P.Telefono = CStr(Row("Telefono"))
            P.Baja = CInt(Row("Baja"))
            P.Nif = CStr(Row("NIF"))
            P.Email = CStr(Row("Email"))
            Personas.Add(P)
        Next

        Return Personas
    End Function



    ''' <summary>
    ''' Existe. Permite consultar si existe la persona a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Boolean) Existe. Id de la última persona insertada.</returns> 
    Public Function Existe(ByRef PNIF As String) As Integer
        Dim Pid As Integer = 0
        Nif = PNIF
        _ADO = New PersonaADO
        Pid = _ADO.Existe(Nif)
        Return Pid
    End Function

    ''' <summary>
    ''' Baja. Permite modificar el valor del atributo Baja por el Id de persona.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Sub UpdateBaja(ByRef PId As Integer, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        Dim Updates As Integer = 0
        Id = PId
        Nombre = PNombre
        Apellidos = PApellidos
        Nif = PNif
        Email = PEmail
        Telefono = PTelefono
        Baja = PBaja
        _ADO = New PersonaADO
        Updates = _ADO.UpdateBaja(Id, Baja)
        If (Updates) = 0 Then
            Throw New DuplicateNameException("Error modificando el estado de baja de persona.")
        End If

    End Sub


    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla personas.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-PER0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Nombre (String) 20 caracteres.
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(Value As String)
            If Value.Length > 30 Then
                Throw New DuplicateNameException("ERR-PER0002: El Nombre no debe de exceder de 30 caracteres")
            Else
                _Nombre = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Apellidos (String) 50 caracteres.
    ''' </summary>
    Public Property Apellidos As String
        Get
            Return _Apellidos
        End Get
        Set(Value As String)
            If Value.Length > 50 Then
                Throw New DuplicateNameException("ERR-PER0003: Los Apellidos no deben exceder de 50 caracteres")
            Else
                _Apellidos = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Nif (String) 9 caracteres.
    ''' </summary>
    Public Property Nif As String
        Get
            Return _Nif
        End Get
        Set(Value As String)
            If Value.Length <> 9 Then
                Throw New DuplicateNameException("ERR-PER0004: El NIF debe tener 9 caracteres")
            Else
                _Nif = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Email (String) 50 caracteres.
    ''' </summary>
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(Value As String)
            If Value.Length > 50 Then
                Throw New DuplicateNameException("ERR-PER0005: El E-mail no debe exceder de 50 caracteres")
            Else
                _Email = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Telefono (String) 12 caracteres.
    ''' </summary>
    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(Value As String)
            If Value.Length > 12 Then
                Throw New DuplicateNameException("ERR-PER0006: El teléfono debe contener valor y no superar los 12 caracteres")
            Else
                _Telefono = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Baja (Boolean).
    ''' </summary>
    Public Property Baja As Integer
        Get
            Return _Baja
        End Get
        Set(Value As Integer)
            _Baja = Value
        End Set
    End Property

     ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _Nombre = ""
        _Apellidos = ""
        _Nif = ""
        _Email = ""
        _Telefono = ""
        _Baja = 0
        _ADO.dispose()
    End Sub
End Class
