Option Explicit On
Option Strict On

''' <summary>
''' Medico.vb
''' Contiene la clase Medico. Hereda de Persona 
''' Encargada de crear, modificar, consultar y eliminar médicos de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Medico
    Inherits Persona

    Private _Id As Integer
    Private _NumColegiado As String '10
    Private _Password As String '20
    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As MedicoADO

    '''<summary>
    '''Constructor Médico.
    ''' </summary>
    Public Sub New()

        _NumColegiado = ""
        _Id = 0
        _Password = ""

    End Sub

    ''' <summary>
    '''Constructor Médico.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PNumColegiado">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword">(String)Contraseña médico.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Sub New(ByRef PId As Integer, ByRef PNumColegiado As String, ByRef PPassword As String, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        MyBase.New(PId, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
        _NumColegiado = PNumColegiado
        Password = PPassword
        _ADO = New MedicoADO
        _ADO.Insertar(PId, NumColegiado, Password)




    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un médico determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona PK.</param>
    ''' <param name="PNumColegiado">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword">(String)Contraseña médico.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    Public Overloads Sub Modificar(ByRef PId As Integer, ByRef PNumColegiado As String, ByRef PPassword As String, ByRef PNombre As String, ByRef PApellidos As String, ByRef PNif As String, ByRef PEmail As String, ByRef PTelefono As String, ByRef PBaja As Integer)
        Modificar(PId, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
        Dim Updates As Integer = 0
        Id = PId
        NumColegiado = PNumColegiado
        Password = PPassword
        _ADO = New MedicoADO
        Updates = _ADO.Modificar(Id, NumColegiado, Password)

    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar un médico determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Persona.</param>
    Public Overloads Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        Id = PId
        _ADO = New MedicoADO
        Deletes = _ADO.Borrar(Id)
        MyBase.Borrar(Id)

    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los médicos.
    ''' </summary>
    ''' <returns>(List(Of Medico)) Medicos. Lista de medicos con todos los datos de todos los médicos de nuestra base de datos.</returns> 
    Public Overloads Function Consultar() As List(Of Medico)
        Dim Result As DataTable
        Dim Medicos As New List(Of Medico)
        _ADO = New MedicoADO
        Result = _ADO.Consultar()

        For Each Row As DataRow In Result.Rows
            Dim Med As New Medico
            Med.Id = CInt(Row("Id"))
            Med.NumColegiado = CStr(Row("NumColegiado"))
            Med.Password = CStr(Row("Password"))
            Medicos.Add(Med)
        Next

        Return Medicos
    End Function

    ''' <summary>
    ''' Buscar. Permite consultar todos los datos de todos los médicos de nuestra base de datos determinados por él formulario de búsqueda.
    ''' </summary>
    ''' <param name="PBusqueda ">(String)Cadena de búsqueda de nuestro formulario de búsqueda.</param>
    ''' <returns>(List(Of Medico)) Medicos. Lista de Médicos con todos los datos de todos los médicos de nuestra base de datos.</returns> 
    Public Overloads Function Buscar(ByRef PBusqueda As String) As DataTable
        Dim Result As New DataTable

        _ADO = New MedicoADO

        Result = _ADO.Buscar(PBusqueda)



        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un médico determinados por su Nº de Colegiado.
    ''' </summary>
    ''' <returns>(DataTable) Result. DataTable con los datos del médico devuelto por la consulta.</returns> 
    Public Overloads Function ConsultarCompleto() As DataTable
        Dim Result As DataTable
        _ADO = New MedicoADO
        Result = _ADO.ConsultarCompleto()
        Return Result
    End Function


    ''' <summary>
    ''' Consultar. Permite consultar los datos de un médico determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id médico.</param>
    ''' <returns>(DataTable) Result. DataTable con los datos del médico devuelto por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PId As Integer) As DataTable
        Dim Result As DataTable
        Id = PId
        _ADO = New MedicoADO
        Result = _ADO.Consultar(Id)
       
        Return Result
    End Function

    ''' <summary>
    ''' Existe. Permite consultar si existe el médico a insertar.
    ''' Utilizaremos este método para antes de insertar pacientes o médicos, para comprobar si ya existe en la base de datos.
    ''' </summary>
    ''' <returns>(Boolean) Existe. Id de la última persona insertada.</returns> 
    Public Overloads Function Existe(ByRef PNumColegiado As String) As Boolean
        Dim ok As Integer
        NumColegiado = PNumColegiado
        _ADO = New MedicoADO
        ok = _ADO.Existe(NumColegiado)
        If ok = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Validar. Valida los datos de un médico para que pueda acceder al sistema
    ''' </summary>
    ''' <param name="PNumColegiado ">(String)Nº Colegiado médico.</param>
    ''' <param name="PPassword">(String)Password médico.</param>
    ''' <returns>(Boolean) Valido.</returns> 
    Public Function Validar(ByRef PNumColegiado As String, ByRef PPassword As String) As Boolean
        Dim Valido As Boolean
        NumColegiado = PNumColegiado
        Password = PPassword
        _ADO = New MedicoADO
        Valido = _ADO.Validar(NumColegiado, Password)
        Return Valido
    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla médicos, coincide con Id tabla Persona.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-MED0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad NumColegiado (String) Nº Colegiado Médico.
    '''</summary>
    Public Property NumColegiado As String
        Get
            Return _NumColegiado
        End Get
        Set(Value As String)
            If Value = "" Or Value.Length > 10 Then
                Throw New DuplicateNameException("ERR-MED0002: El número de Colegiado no puede estar vacío ni exceder de 10 caracteres")
            Else
                _NumColegiado = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Password (String) Contraseña Médico.
    '''</summary>
    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(Value As String)
            If Value.Length < 6 Or Value.Length > 20 Then
                Throw New DuplicateNameException("ERR-MED0003: La contraseña de Colegiado debe tener entre 6 y 20 caracteres")
            Else
                _Password = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _NumColegiado = Nothing
        _Id = Nothing
        _Password = ""
        _ADO.dispose()
    End Sub
End Class
