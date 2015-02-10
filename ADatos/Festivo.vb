Option Explicit On
Option Strict On

''' <summary>
''' Festivo.vb
''' Contiene la clase Festivo.
''' Encargada de crear, modificar, consultar y eliminar los festivos de nuestra aplicación.
''' </summary>
''' <author> Ángel Valera</author>
Public Class Festivo
    Private _Id As Integer
    Private _FechaFestivo As Date 'DUDA TIPO
    Private _NombreFestivo As String '40

    '''<summary>
    '''Propiedad _ADO (PersonaADO). Objeto para acceder a BD.
    ''' </summary>
    Private _ADO As FestivoADO

    '''<summary>
    '''Constructor Festivo.
    ''' </summary>
    Public Sub New()

        _FechaFestivo = Nothing
        _NombreFestivo = ""


    End Sub

    ''' <summary>
    '''Constructor Festivo.
    ''' </summary>
    ''' <param name="PFechaFestivo">(Date)Fecha Festivo.</param>
    ''' <param name="PNombreFestivo ">(Date)Nombre Festivo.</param>
    Public Sub New(ByRef PFechaFestivo As Date, ByRef PNombreFestivo As String)
        Dim Inserciones As Integer = 0
        FechaFestivo = PFechaFestivo
        NombreFestivo = PNombreFestivo

        'Lo insertamos en la BD
        _ADO = New FestivoADO
        Inserciones = _ADO.Insertar(FechaFestivo, NombreFestivo)
       
    End Sub

    ''' <summary>
    ''' Modificar. Permite modificar los datos de un festivo determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo PK.</param>
    ''' <param name="PFechaFestivo">(Date)Fecha Festivo.</param>
    ''' <param name="PNombreFestivo ">(Date)Nombre Festivo.</param>
    Public Sub Modificar(ByRef PId As Integer, ByRef PFechaFestivo As Date, ByRef PNombreFestivo As String)
        Dim Updates As Integer = 0
        Id = PId
        FechaFestivo = PFechaFestivo
        NombreFestivo = PNombreFestivo

        _ADO = New FestivoADO
        Updates = _ADO.Modificar(Id, FechaFestivo, NombreFestivo)
       

    End Sub

    ''' <summary>
    ''' Borrar. Permite borrar un festivo determinado por su Id.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Festivo.</param>
    Public Sub Borrar(ByRef PId As Integer)
        Dim Deletes As Integer = 0
        _Id = PId
        _ADO = New FestivoADO
        Deletes = _ADO.Borrar(Id)
        
    End Sub

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los festivos.
    ''' </summary>
    ''' <returns>(List(Of Festivo)) Festivos. Lista de festivos con todos los datos de todas los festivos de nuestra base de datos.</returns> 
    Public Overloads Function Consultar() As List(Of Festivo)
        Dim Result As DataTable
        Dim Festivos As New List(Of Festivo)
        _ADO = New FestivoADO
        Result = _ADO.Consultar()

        For Each Row As DataRow In Result.Rows
            Dim Fes As New Festivo
            Fes.Id = CInt(Row("Id"))
            Fes.FechaFestivo = CType(CStr(Row("FechaFestivo")), Date)
            Fes.NombreFestivo = CStr(Row("NombreFestivo"))
            Festivos.Add(Fes)
        Next

        Return Festivos
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un festivo de nuestra base de datos determinados por su Id
    ''' </summary>
    ''' <param name="PId ">(Integer)Id de festivo.</param>
    ''' <returns>(Festivo) Fes. Objeto Festivo con los datos del festivo devuelto por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PId As Integer) As Festivo
        Dim Result As DataTable
        Dim Fes As New Festivo
        Id = PId
        _ADO = New FestivoADO
        Result = _ADO.Consultar(Id)

        For Each Row As DataRow In Result.Rows

            Fes.Id = CInt(Row("Id"))
            Fes.FechaFestivo = CType(CStr(Row("FechaFestivo")), Date)
            Fes.NombreFestivo = CStr(Row("NombreFestivo"))

        Next

        Return Fes
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de un festivo de nuestra base de datos determinados por una Fecha
    ''' </summary>
    ''' <param name="PFecha ">(Date)Fecha de festivo.</param>
    ''' <returns>(Festivo) Fes. Objeto Festivo con los datos del festivo devuelto por la consulta.</returns> 
    Public Overloads Function Consultar(ByRef PFecha As Date) As Integer
        Dim Result As DataTable
        Dim Fes As New Festivo
        FechaFestivo = PFecha
        _ADO = New FestivoADO
        Result = _ADO.Consultar(FechaFestivo)

        '' For Each Row As DataRow In Result.Rows

        ''  Fes.Id = CInt(Row("Id"))
        ''    Fes.FechaFestivo = CType(CStr(Row("FechaFestivo")), Date)
        ''    Fes.NombreFestivo = CStr(Row("NombreFestivo"))

        ''   Next
        Return Result.Rows.Count
    End Function

    ''' <summary>
    ''' Consultar. Permite consultar los datos de todos los festivos de un año determinado.
    ''' </summary>
    ''' <param name="PAnyo">(String)Año a consultar.</param>
    ''' <returns>(List(Of Festivo)) Festivos. Lista de festivos con todos los datos de todas los festivos de nuestra base de datos.</returns> 
    Public Overloads Function Consultar(ByRef PAnyo As String) As DataTable
        Dim Result As DataTable
        _ADO = New FestivoADO
        Result = _ADO.Consultar(PAnyo)
        Return Result
    End Function

    '''<summary>
    '''Propiedad Id (Integer) Clave primaria en tabla festivos.
    '''</summary>
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(Value As Integer)
            If Value = 0 Then
                Throw New DuplicateNameException("ERR-FES0001: El Id no puede ser 0 o nulo.")
            Else
                _Id = Value
            End If
        End Set
    End Property

    '''<summary>
    '''Propiedad FechaFestivo (Date) Fecha festivo.
    '''</summary>
    Public Property FechaFestivo As Date
        Get
            Return _FechaFestivo
        End Get
        Set(Value As Date)
            If Format(Value, "dd/mm/yyyy") = "01/01/0001" Then
                Throw New DuplicateNameException("ERR-FES0002: Debe asignar una fecha")
            Else
                _FechaFestivo = Value
            End If

        End Set
    End Property

    '''<summary>
    '''Propiedad NombreFestivo (String) Nombre festivo.
    '''</summary>
    Public Property NombreFestivo As String
        Get
            Return _NombreFestivo
        End Get
        Set(Value As String)
            If Value.Length <= 0 Or Value.Length > 40 Then
                Throw New DuplicateNameException("ERR-FES0003: El nombre del festivo no puede estar vacío ni superar los 40 caracteres.")
            Else
                _NombreFestivo = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Dispose. Encargada de decirle al recolector de basura que resetee los atributos de nuestra clase.
    ''' </summary>
    Public Sub Dispose()
        _FechaFestivo = Nothing
        _NombreFestivo = ""
        _ADO.dispose()
    End Sub
End Class
