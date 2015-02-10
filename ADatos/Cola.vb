Option Explicit On
Option Strict On

''' <summary>
''' Cola.vb
''' Contiene la clase Cola.
''' Encargada de crear, modificar, consultar y eliminar las colas de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Cola
    Private _Id As Integer
    Private _NumeroCola As Integer 'DUDA TIPO
    Private _Mesa As String '20
    Private _MedicoId As Integer
    Private _NombreConsulta As String

    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As ColaADO

    ''' <summary>
    '''Constructor Cola.
    ''' </summary>   
    Public Sub New()
        _NumeroCola = 0
        _Mesa = ""
        _MedicoId = 0
        NombreConsulta = ""
    End Sub

    ''' <summary>
    '''Constructor Cola.
    ''' </summary>  
    ''' <param name="PNumeroCola">(Integer)Numero de cola.</param>
    ''' <param name="PMesa">(String)Nombre de mesa.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    Public Sub New(ByRef PNumeroCola As Integer, ByRef PMesa As String, ByRef PMedicoId As Integer)
        Dim Inserciones As Integer = 0
        NumeroCola = PNumeroCola
        Mesa = PMesa
        MedicoId = PMedicoId

        'Lo insertamos en la BD
        _ADO = New ColaADO

        Inserciones = _ADO.Insertar(NumeroCola, Mesa, MedicoId)

    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un festivo determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PNumeroCola">(Integer)Numero de cola.</param>
    ''' <param name="PMesa">(String)Nombre de mesa.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    Public Sub Modificar(ByRef PId As Integer, ByRef PNumeroCola As Integer, ByRef PMesa As String, ByRef PMedicoId As Integer)
        Dim Updates As Integer = 0
        Id = PId
        NumeroCola = PNumeroCola
        Mesa = PMesa
        MedicoId = PMedicoId
        _ADO = New ColaADO
        Updates = _ADO.Modificar(Id, NumeroCola, Mesa, MedicoId)

    End Sub

    ''' <summary>
    ''' AsignarMedico. Permite modificar el médico asignado a una cola
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    Public Function AsignarMedico(ByRef PId As Integer, ByRef PNumColegiado As String) As Integer
        Dim Updates As Integer = 0
        Id = PId

        _ADO = New ColaADO
        Updates = _ADO.AsignarMedico(Id, PNumColegiado)
        Return Updates
    End Function

    ''' <summary>
    ''' ModificarMesa. Permite modificar el nombre de una cola.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PMedicoId">(Integer)Id de médico encargado de gestionar la cola.</param>
    Public Function ModificarMesa(ByRef PId As Integer, ByRef PMesa As String) As Integer
        Dim Updates As Integer = 0
        Id = PId
        NombreConsulta = PMesa
        _ADO = New ColaADO
        Updates = _ADO.ModificarMesa(Id, NombreConsulta)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una cola determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cola.</param>
    Public Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        _Id = PId
        _ADO = New ColaADO
        Deletes = _ADO.Borrar(Id)

    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las colas.
    ''' </summary>
    ''' <returns>(List of (Cola)) Colas. Lista con los datos de todas las colas devueltas por la consulta.</returns> 
    Public Overloads Function Consultar() As List(Of Cola)
        Dim Result As New DataTable
        Dim Colas As New List(Of Cola)
        _ADO = New ColaADO
        Result = _ADO.Consultar()
        For Each Row As DataRow In Result.Rows
            Dim Col As New Cola
            Col.Id = CInt(Row("Id"))
            Col.NumeroCola = CInt(Row("NumCola"))
            Col.Mesa = CStr(Row("NumMesa"))
            Col.MedicoId = CInt(Row("MedicoId"))
            Col.NombreConsulta = CStr(Row("NombreConsulta"))

            Colas.Add(Col)
        Next
        Return Colas
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las colas.
    ''' </summary>
    ''' <returns>(DataTable) Colas. Lista con los datos de todas las colas devueltas por la consulta.</returns> 
    Public Overloads Function ConsultarTodos() As DataTable
        Dim Result As New DataTable

        _ADO = New ColaADO
        Result = _ADO.Consultar()

        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las colas.
    ''' </summary>
    ''' <returns>(List of (Cola)) Colas. Lista con los datos de todas las colas devueltas por la consulta.</returns> 
    Public Overloads Function ConsultarTodosPorMedico(ByRef PNumColegiado As String) As DataTable
        Dim Result As New DataTable

        _ADO = New ColaADO
        Result = _ADO.ConsultarMedico(PNumColegiado)

        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de una cola determinada por su Id.
    ''' </summary>
    ''' <returns>(Cola) Col. Objeto Cola con los datos de la cola devuelta por la consulta determinada por su Id.</returns> 
    Public Overloads Function Consultar(ByRef Pid As Integer) As Cola
        Dim Result As New DataTable
        Dim Col As New Cola
        Id = Pid
        _ADO = New ColaADO
        Result = _ADO.Consultar(Id)
        For Each Row As DataRow In Result.Rows
            Col.Id = CInt(Row("Id"))
            Col.NumeroCola = CInt(Row("NumCola"))
            Col.Mesa = CStr(Row("NumMesa"))
            Col.MedicoId = CInt(Row("MedicoId"))
            Col.NombreConsulta = CStr(Row("NombreConsulta"))
        Next


        Return Col
    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla colas.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-COL0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''NumeroCola (Integer) Número de la cola.
    '''</summary>
    Public Property NumeroCola As Integer
        Get
            Return _NumeroCola
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-COL0002: El Número de cola no puede ser 0 o nulo.")
            Else
                _NumeroCola = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Mesa (String) Nombre de la mesa de la cola.
    '''</summary>
    Public Property Mesa As String
        Get
            Return _Mesa
        End Get
        Set(Value As String)
            If Value.Length > 20 Then
                Throw New DuplicateNameException("ERR-COL0003: El Nombre de la especialidad no debe exceder de 20 caracteres.")
            Else
                _Mesa = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad MedicoId (Integer) Id del médico.
    '''</summary>
    Public Property MedicoId As Integer
        Get
            Return _MedicoId
        End Get
        Set(Value As Integer)
            _MedicoId = Value

        End Set
    End Property

    Public Property NombreConsulta As String
        Get
            Return _NombreConsulta
        End Get
        Set(value As String)
            If value.Length > 50 Then
                Throw New DuplicateNameException("ERR-COL0004: El Nombre de la consulta no debe exceder de 50 caracteres.")
            Else
                _NombreConsulta = value
            End If

        End Set
    End Property

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _NumeroCola = 0
        _Mesa = ""
        _MedicoId = 0
        _ADO.dispose()
    End Sub
End Class
