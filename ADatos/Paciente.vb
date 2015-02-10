Option Explicit On
Option Strict On

''' <summary>
''' Paciente.vb
''' Contiene la clase Paciente. Hereda de Persona 
''' Encargada de crear, modificar, consultar y eliminar pacientes de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Paciente
    Inherits Persona

    Private _Id As Integer
    Private _SIP As ULong  '9

    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As PacienteADO

    '''<summary>
    '''Constructor Paciente.
    ''' </summary>
    Public Sub New()

        _SIP = Nothing
        _Id = Nothing

    End Sub

    ''' <summary>
    '''Constructor Paciente.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Sub New(ByRef PId As Integer, ByRef PSip As ULong, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        MyBase.New(PId, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
        Sip = PSip
        _ADO = New PacienteADO
        _ADO.Insertar(PId, Sip)
    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un paciente determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Overloads Sub Modificar(ByRef PId As Integer, ByRef PSip As ULong, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        Modificar(PId, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
        Dim Updates As Integer = 0
        Id = PId
        Sip = PSip

        _ADO = New PacienteADO
        Updates = _ADO.Modificar(Id, Sip)


    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar una persona determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    Public Overloads Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0

        _Id = PId
        _ADO = New PacienteADO
        Deletes = _ADO.Borrar(Id)

        MyBase.Borrar(Id)

    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los pacientes.
    ''' </summary>
    ''' <returns>(List(Of Paciente)) Pacientes. Lista de pacientes con todos los datos de todas los pacientes de nuestra base de datos.</returns> 
    Public Overloads Function Consultar() As List(Of Paciente)
        Dim Result As DataTable
        Dim Pacientes As New List(Of Paciente)
        _ADO = New PacienteADO
        Result = _ADO.Consultar()

        For Each Row As DataRow In Result.Rows
            Dim P As New Paciente
            P.Id = CInt(Row("Id"))
            P.Sip = CType(Row("SIP"), ULong)
            Pacientes.Add(P)
        Next

        Return Pacientes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un paciente determinados por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Paciente.</param>
    ''' <returns>(DataTable) Result. DataTable con los datos del paciente devuelto por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PId As Integer) As DataTable
        Dim Result As DataTable
        Id = PId
        _ADO = New PacienteADO
        Result = _ADO.Consultar(Id)
        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un paciente determinados por su SIP.
    ''' </summary>
    ''' <param name="PSip">(Integer)SIP Paciente.</param>
    ''' <returns>(Paciente) Pac. Objeto Paciente con los todos los datos del paciente devuelto por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PSip As ULong) As DataTable
        Dim Result As DataTable 
        Sip = PSip
        _ADO = New PacienteADO
        Result = _ADO.Consultar(Sip)

        Return Result
    End Function


    ''' <summary>
    ''' Existe. Permite consultar si existe el paciente a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Boolean) Existe. Id de la última persona insertada.</returns> 
    Public Overloads Function Existe(ByRef PSIP As ULong) As Boolean
        Dim ok As Integer
        Sip = PSIP
        _ADO = New PacienteADO
        ok = _ADO.Existe(Sip)
        If ok = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Buscar. Permite consultar todos los datos de todos los pacientes de nuestra base de datos determinados por él formulario de búsqueda.
    ''' </summary>
    ''' <param name="PBusqueda ">(String)Cadena de búsqueda de nuestro formulario de búsqueda.</param>
    ''' <returns>Datatable) Result. DataTable con todos los datos de todas los pacientes de nuestra base de datos.</returns> 
    Public Overloads Function Buscar(ByRef PBusqueda As String) As DataTable
        Dim Result As New DataTable

        _ADO = New PacienteADO

        Result = _ADO.Buscar(PBusqueda)



        Return Result

    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla pacientes, coincide con Id tabla Persona.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)

            If Value = 0 Then
                Throw New DuplicateNameException("ERR-PAC0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad SIP (ULong) Clave primaria en tabla personas.SIP Paciente.
    '''</summary>
    Public Property Sip As ULong
        Get
            Return _SIP
        End Get
        Set(Value As ULong)
            If Value < 1000000000 Or Value > 9999999999 Then
                Throw New DuplicateNameException("ERR-PAC0002: El nº SIP debe tener 10 Dígitos")
            End If
            _SIP = Value
        End Set
    End Property

     ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _SIP = Nothing
        _Id = Nothing
        _ADO.dispose()
    End Sub
End Class
