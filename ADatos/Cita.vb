Option Explicit On
Option Strict On

Imports System.Data.SQLite

''' <summary>
''' Cita.vb
''' Contiene la clase Cita.
''' Encargada de crear, modificar, consultar y eliminar las citas de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Cita
    Private _Id As Integer
    Private _Fecha As Date 'DUDA FORMATO
    Private _Hora As String  'DUDA TIPO
    Private _Duracion As Integer '9
    Private _Terminada As Integer
    Private _TipoCita As Integer '1=Inmediata, 0=Programada
    Private _ColaId As Integer
    Private _PacienteId As Integer


    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As CitaADO

    ''' <summary>
    '''Constructor Cita.
    ''' </summary>   
    Public Sub New()
        _Fecha = Nothing
        _Hora = ""
        _Duracion = 0
        _Terminada = 0
        _TipoCita = 0
        _ColaId = 0
        _PacienteId = 0

    End Sub

    ''' <summary>
    '''Constructor Cola.
    ''' </summary>
    ''' <param name="PHora">(Integer)Hora de la cita.</param>
    ''' <param name="PFecha">(Date)Fecha de la cita.</param>
    ''' <param name="PDuracion">(Integer)Duración de la cita.</param>
    ''' <param name="PTerminada">(Boolean)Cita terminada.</param>
    ''' <param name="PTipoCita">(Boolean)Tipo de cita (True=Inmediata False=Programada).</param>
    ''' <param name="PColaId">(Integer)Id de cola a la que pertenece la cita.</param>
    ''' <param name="PPacienteId">(Integer)Id del paciente de la cita.</param>
    Public Sub New(ByRef PFecha As Date, PDuracion As Integer, ByRef PTerminada As Integer, ByRef PTipoCita As Integer, ByRef PColaId As Integer, ByRef PPacienteId As Integer)
        Dim Inserciones As Integer = 0
        Fecha = PFecha
        Hora = PFecha.ToString("HH:mm")
        Duracion = PDuracion
        Terminada = PTerminada
        TipoCita = PTipoCita
        ColaId = PColaId
        PacienteId = PPacienteId
        'Lo insertamos en la BD
        _ADO = New CitaADO
        Inserciones = _ADO.Insertar(Fecha, Duracion, Terminada, TipoCita, ColaId, PacienteId)

    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de una cita determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita PK.</param>
    ''' <param name="PHora">(Integer)Hora de la cita.</param>
    ''' <param name="PFecha">(Date)Fecha de la cita.</param>
    ''' <param name="PDuracion">(Integer)Duración de la cita.</param>
    ''' <param name="PTerminada">(Boolean)Cita terminada.</param>
    ''' <param name="PTipoCita">(Boolean)Tipo de cita (True=Inmediata False=Programada).</param>
    ''' <param name="PColaId">(Integer)Id de cola a la que pertenece la cita.</param>
    ''' <param name="PPacienteId">(Integer)Id del paciente de la cita.</param>
    Public Sub Modificar(ByRef PId As Integer, ByRef PFecha As Date, ByRef PHora As String, ByRef PDuracion As Integer, ByRef PTerminada As Integer, ByRef PTipoCita As Integer, ByRef PColaId As Integer, ByRef PPacienteId As Integer)
        Dim Updates As Integer = 0
        Id = PId
        Fecha = PFecha
        Hora = PHora
        Duracion = PDuracion
        Terminada = PTerminada
        TipoCita = PTipoCita
        ColaId = PColaId
        PacienteId = PPacienteId

        _ADO = New CitaADO
        Updates = _ADO.Modificar(Id, Fecha, Hora, Duracion, Terminada, TipoCita, ColaId, PacienteId)


    End Sub

    ''' <summary>
    ''' TerminarCita. Permite modificar los datos de una cita determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita PK.</param>
    Public Function TerminarCita(ByRef PId As Integer) As Integer
        Dim Updates As Integer = 0
        Id = PId


        _ADO = New CitaADO
        Updates = _ADO.TerminarCita(Id)
        Return Updates
    End Function

    ''' <summary>
    ''' Borrar. Permite borrar una cita determinada por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita.</param>
    Public Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        _Id = PId
        _ADO = New CitaADO
        Deletes = _ADO.Borrar(Id)

    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar una cita determinada por su ID_Cola.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Cita.</param>
    Public Sub BorrarPorCola(ByRef PColaId As Integer)
        Dim Deletes As Integer = 0
        ColaId = PColaId
        _ADO = New CitaADO
        Deletes = _ADO.BorrarPorCola(ColaId)

    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todas las citas.
    ''' </summary> 
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar() As List(Of Cita)
        Dim Result As New DataTable
        Dim Citas As New List(Of Cita)
        _ADO = New CitaADO
        Result = _ADO.Consultar()
        For Each Row As DataRow In Result.Rows
            Dim C As New Cita
            C.Id = CInt(Row("Id"))
            C.Fecha = CType(CStr(Row("Fecha")), Date)
            C.Hora = CStr(Row("Hora"))
            C.Duracion = CInt(Row("Duracion"))
            C.Terminada = CInt(Row("Terminada"))
            C.TipoCita = CInt(Row("TipoCita"))
            C.ColaId = CInt(Row("Cola_Id"))
            C.PacienteId = CInt(Row("Paciente_Id"))
            Citas.Add(C)
        Next

        Return Citas
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de las citas determinadas por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id cita.</param>
    ''' <returns>(Cita). Cit. Objeto cita con los datos de la cita devueltas por la Select</returns> 
    Public Function Consultar(ByRef PId As Integer) As Cita
        Dim Result As New DataTable
        Dim Cit As New Cita
        Id = PId
        _ADO = New CitaADO
        Result = _ADO.Consultar(Id)
        For Each Row As DataRow In Result.Rows

            Cit.Id = CInt(Row("Id"))
            Cit.Fecha = CType(CStr(Row("Fecha")), Date)
            Cit.Hora = CStr(Row("Hora"))
            Cit.Duracion = CInt(Row("Duracion"))
            Cit.Terminada = CInt(Row("Terminada"))
            Cit.TipoCita = CInt(Row("TipoCita"))
            Cit.ColaId = CInt(Row("Cola_Id"))
            Cit.PacienteId = CInt(Row("Paciente_Id"))

        Next
        Return Cit
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las citas de nuestra base de datos en una fecha determinada.
    ''' </summary>
    ''' <param name="PFecha">(Fecha)Fecha de la cita.</param>
    ''' <param name="PColaId">Id de la Cola</param>
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar(ByRef Pfecha As Date, ByRef PColaId As Integer) As List(Of Cita)
        Dim Result As New DataTable
        Dim Citas As New List(Of Cita)

        _ADO = New CitaADO
        Result = _ADO.Consultar(Pfecha, PColaId)
        For Each Row As DataRow In Result.Rows
            Dim C As New Cita
            C.Id = CInt(Row("Id"))
            C.Fecha = CType(CStr(Row("Fecha")), Date)
            C.Hora = CStr(Row("Hora"))
            C.Duracion = CInt(Row("Duracion"))
            C.Terminada = CInt(Row("Terminada"))
            C.TipoCita = CInt(Row("TipoCita"))
            C.ColaId = CInt(Row("Cola_Id"))
            C.PacienteId = CInt(Row("Paciente_Id"))
            Citas.Add(C)
        Next
        Return Citas
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos las citas de nuestra base de datos en una fecha determinada.
    ''' </summary>
    ''' <param name="PFecha">(Fecha)Fecha de la cita.</param>
    ''' <param name="PColaId">Id de la Cola</param>
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarHoras(ByRef Pfecha As Date, ByRef PColaId As Integer) As DataTable
        Dim Result As New DataTable


        _ADO = New CitaADO
        Result = _ADO.Consultar(Pfecha, PColaId)

        Return Result
    End Function


    ''' <summary>
    ''' ConsultarCola. Permite consultar los datos de todas las citas de una cola determiada por su Id.
    ''' </summary> 
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarCola(ByRef PColaId As Integer) As DataTable
        Dim Result As New DataTable

        ColaId = PColaId
        _ADO = New CitaADO
        Result = _ADO.ConsultarCola(ColaId)

        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de las citas determinadas por la SIP de un paciente.
    ''' </summary>
    ''' <param name="PSip">(Integer)SIP paciente.</param>
    ''' <returns>(Cita). Cit. Objeto cita con los datos de la cita devueltas por la Select</returns> 
    Public Function Consultar(ByRef PSip As UInteger) As DataTable
        Dim Result As New DataTable

        _ADO = New CitaADO
        Result = _ADO.Consultar(PSip)

        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de las citas en una fecha de un médico determinado por su Nº de colegiado.
    ''' </summary>
    ''' <param name="PNumColegiado">(Integer)Nº Colegiado a consultar.</param>
    ''' <param name="PFecha ">(Integer)Fecha de la Cita.</param>
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function Consultar(ByRef PNumColegiado As String, ByRef PFecha As Date) As DataTable
        Dim Result As New DataTable

        _ADO = New CitaADO
        Fecha = PFecha
        Result = _ADO.Consultar(PNumColegiado, Fecha)

        Return Result
    End Function

    ''' <summary>
    ''' ConsultarActuales. Permite consultar los datos de las citas en una fecha de un médico determinado por su Nº de colegiado.
    ''' </summary>
    ''' <returns>SQLiteAdapter Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarActuales() As SQLiteDataAdapter
        Dim Result As New SQLiteDataAdapter

        _ADO = New CitaADO

        Result = _ADO.ConsultarActuales()

        Return Result
    End Function

    ''' <summary>
    ''' ConsultarActuales. Permite consultar los datos de las citas en una fecha de un médico determinado por su Nº de colegiado.
    ''' </summary>
    ''' <returns>SQLiteAdapter Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarTerminadas(ByRef Cola As Integer) As SQLiteDataAdapter
        Dim Result As New SQLiteDataAdapter

        _ADO = New CitaADO

        Result = _ADO.ConsultarTerminadas(Cola)

        Return Result
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de las citas en una fecha de un médico determinado por su Nº de colegiado.
    ''' </summary>
    ''' <param name="PNumColegiado">(Integer)Nº Colegiado a consultar.</param>
    ''' <param name="PFecha ">(Integer)Fecha de la Cita.</param>
    ''' <returns>(List of (Cita)). Citas. Lista de citas con los datos de las citas devueltas por la Select</returns> 
    Public Function ConsultarDa(ByRef PNumColegiado As String, ByRef PFecha As Date, ByRef ColaId As Integer) As SQLiteDataAdapter
        Dim Result As New SQLiteDataAdapter

        _ADO = New CitaADO
        Fecha = PFecha

        Result = _ADO.ConsultarDa(PNumColegiado, Fecha, ColaId)
        Return Result
    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla citas.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-CIT0001: El Id de la cita no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Fecha (Date) Fecha de la cita.
    '''</summary>
    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(Value As Date)
            '' If Format(Value, "dd/mm/yyyy") < Format(Today(), "dd/mm/yyyy") Then
            ''  Throw New DuplicateNameException("ERR-CIT0002: No se puede asignar una fecha inferior al día actual")
            '' Else
            _Fecha = Value
            ''End If

        End Set
    End Property

    '''<summary>
    '''Propiedad Hora (String) Hora de la cita.
    '''</summary>
    Public Property Hora As String
        Get
            Return _Hora
        End Get
        Set(Value As String)
            If Value.Length > 5 Then
                Throw New DuplicateNameException("ERR-CIT0003: La hora tiene que tener como mucho 5 caracteres")
            Else
                _Hora = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad Duracion (Integer) Duración de la cita.
    '''</summary>
    Public Property Duracion As Integer
        Get
            Return _Duracion
        End Get
        Set(Value As Integer)
            _Duracion = Value
        End Set
    End Property

    '''<summary>
    '''Propiedad Terminada (Boolean) Cita terminada.
    '''</summary>
    Public Property Terminada As Integer
        Get
            Return _Terminada
        End Get
        Set(Value As Integer)
            _Terminada = Value
        End Set
    End Property

    '''<summary> 
    '''Propiedad TipoCita (Boolean) Tipo de cita (True=Inmediata False=Programada). 
    '''</summary>
    Public Property TipoCita As Integer
        Get
            Return _TipoCita
        End Get
        Set(Value As Integer)
            _TipoCita = Value
        End Set
    End Property

    '''<summary>
    '''Propiedad ColaId (Integer)Id de cola a la que pertenece la cita.
    '''</summary>
    Public Property ColaId As Integer
        Get
            Return _ColaId
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-CIT0004: El Id de la cola no puede ser 0 o nulo.")
            Else
                _ColaId = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad PacienteId (Integer)Id del paciente al que pertenece la cita.
    '''</summary>
    Public Property PacienteId As Integer
        Get
            Return _PacienteId
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-CIT0005: El Id del paciente no puede ser 0 o nulo.")
            Else
                _PacienteId = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _Fecha = Nothing
        _Hora = ""
        _Duracion = 0
        _Terminada = 0
        _TipoCita = 0
        _ColaId = 0
        _PacienteId = 0
        _ADO.dispose()
    End Sub
End Class
