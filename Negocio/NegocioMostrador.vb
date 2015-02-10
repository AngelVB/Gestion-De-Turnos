Option Explicit On
Option Strict On
Imports ADatos
Imports System.IO
Imports System.Text

''' <summary>
''' NegocioMostrador.vb
''' Contiene la capa de negocio del proyecto Mostrador
''' Encargada de hacer peticiones a la capa de datos y devolver la información a presentación
''' </summary>
''' <author> Ángel Valera</author> 
Public Class NegocioMostrador
    Public Sub New()
    End Sub
#Region "Personas"

    ''' <summary>
    ''' ConsultarPersona. Consulta si una persona existe en nuestra base de datos.
    ''' </summary>
    ''' <param name="PNif">(String)Nif Persona.</param>
    ''' <returns>(DataTable) Result. DataTable con todos los datos de la persona devuelto por la consulta.</returns> 
    Public Function ConsultarPersona(ByRef PNif As String) As DataTable
        Dim Tabla As New DataTable
        Dim Id As Integer = 0
        Dim Persona As New Persona
        Persona.Nif = PNif
        Id = Persona.Existe(Persona.Nif)
        If Not Id = 0 Then
            Dim Medico As New Medico
            Tabla = Medico.Consultar(Id)

            If Tabla.Rows.Count = 0 Then
                Dim Paciente As New Paciente
                Tabla = Paciente.Consultar(Id)
            End If
        End If
        Return Tabla
    End Function

#End Region

#Region "Festivos"

    ''' <summary>
    ''' InsertarFestivo. Inserta los datos de un festivo.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param> 
    ''' <param name="PFecha ">(String)Municipio.</param>
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function InsertarFestivo(ByVal PFecha As Date, ByVal PNombre As String) As Integer

        Dim Festivo As Festivo
        Try
            Festivo = New Festivo(PFecha, PNombre)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' ConsultarFestivo. Consulta los datos de los festivo.
    ''' </summary>
    ''' <returns>(DataTable). DataTable con todos los datos de todos los festivos del año actual</returns> 
    Public Function ConsultarFestivos() As DataTable

        Dim Festivo As New Festivo
        Try

            Dim Tabla As New DataTable
            Tabla = Festivo.Consultar(CStr(Now.Year))

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' ConsultarFestivo. Consulta los datos de los festivo.
    ''' </summary>
    ''' <returns>(DataTable). DataTable con todos los datos de todos los festivos del año actual</returns> 
    Public Function ConsultarFestivo(ByVal PDia As Date) As Integer

        Dim Festivo As New Festivo

        Try
            If Festivo.Consultar(PDia) = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 2
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 2
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 2
        End Try

    End Function

    ''' <summary>
    ''' EliminarFestivo. Elimina un festivo determinado por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id Festivo.</param> 
    ''' <returns>(Integer) Integer. 1 indica que la eliminación ha sido correcta, 0 Incorrecta.</returns> 
    Public Function EliminarFestivo(ByVal PId As Integer) As Integer
        Dim Festivo As New Festivo
        Try
            Festivo.Borrar(PId)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function
#End Region

#Region "Pacientes"

    ''' <summary>
    ''' UpdatePaciente. Actualiza los datos de un paciente.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
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
    ''' <param name="PId ">(Integer)Id Persona.</param>
    ''' <returns>(Integer) Integer. 1 indica que el update ha sido correcto, 0 Incorrecto.</returns> 
    Public Function UpdatePaciente(ByVal PId As Integer, ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer, ByVal PSip As ULong, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String) As Integer

        Dim Paciente As New Paciente
        Try
            Paciente.Modificar(PId, PSip, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
            UpdateDireccion(PId, PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal)
            ''Paciente.Modificar(1, 234535467, "jorge", "Valera Bascu", "65476521E", "angel@reinventa.es", "610708126", False)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ResultCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' InsertarPaciente. Inserta los datos de un paciente.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <param name="PSip">(ULong)SIP paciente.</param>
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
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function InsertarPaciente(ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer, ByVal PSip As ULong, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String) As Integer

        Dim Paciente As Paciente
        Dim PId As Integer = 0
        Try
            Paciente = New Paciente(PId, PSip, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
            InsertarDireccion(PId, PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal)
            ''Paciente.Modificar(1, 234535467, "jorge", "Valera Bascu", "65476521E", "angel@reinventa.es", "610708126", False)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ResultCode) + " Mensaje:" + SqlExc.Message)
            Dim P As New Persona ''En caso de que la inserción de médico dé un error, borro la persona insertada.
            P.Borrar(PId)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' BuscarPacientes. Busca los datos de pacientes.
    ''' </summary>
    ''' <param name="PBusqueda">(String)Cadena de búsqueda.</param>
    ''' <returns>(DataTable). DataTable con todos los datos de los pacientes que coincidan con el criterio de búsqueda.</returns> 
    Public Function BuscarPacientes(ByRef PBusqueda As String) As DataTable
        Dim Paciente As New Paciente
        Try
            Dim Tabla As New DataTable
            Tabla = Paciente.Buscar(PBusqueda)

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Médicos"

    ''' <summary>
    ''' InsertarMedico. Inserta los datos de un médico.
    ''' </summary>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <param name="PNumColegiado ">(ULong)Nº Colegiado del médico.</param>
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
    ''' <param name="PPassword ">(String)Password Médico.</param>
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function InsertarMedico(ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer, ByVal PNumColegiado As String, ByVal PPassword As String, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String) As Integer

        Dim Medico As Medico
        Dim PId As Integer = 0
        Try
            Medico = New Medico(PId, PNumColegiado, PPassword, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
            InsertarDireccion(PId, PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Dim P As New Persona ''En caso de que la inserción de médico dé un error, borro la persona insertada.
            P.Borrar(PId)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' UpdateMedico. Inserta los datos de un médico.
    ''' </summary>
    ''' <param name="PId">(Integer)Id Médico.</param>
    ''' <param name="PNombre">(String)Nombre Persona.</param>
    ''' <param name="PApellidos">(String)Apellidos Persona.</param>
    ''' <param name="PNif ">(String)NIF Persona.</param>
    ''' <param name="PEmail ">(String)Email Persona.</param>
    ''' <param name="PTelefono ">(String)Teléfono Persona.</param>
    ''' <param name="PBaja ">(Boolean)Situación Baja de Persona.</param>
    ''' <param name="PNumColegiado ">(ULong)Nº Colegiado del médico.</param>
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
    ''' <param name="PPassword ">(String)Password Médico.</param>
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function UpdateMedico(ByVal PId As Integer, ByVal PNombre As String, ByVal PApellidos As String, ByVal PNif As String, ByVal PEmail As String, ByVal PTelefono As String, ByVal PBaja As Integer, ByVal PNumColegiado As String, ByVal PPassword As String, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String) As Integer

        Dim Medico As New Medico

        Try
            Medico.Modificar(PId, PNumColegiado, PPassword, PNombre, PApellidos, PNif, PEmail, PTelefono, PBaja)
            UpdateDireccion(PId, PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)

            Return 0

        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' BuscarMedicos. Busca los datos de médicos.
    ''' </summary>
    ''' <param name="PBusqueda">(String)Cadena de búsqueda.</param>
    ''' <returns>(DataTable). DataTable con todos los datos de los médicos que coincidan con el criterio de búsqueda.</returns>
    Public Function BuscarMedicos(ByRef PBusqueda As String) As DataTable
        Dim Medico As New Medico
        Try
            Dim Tabla As New DataTable
            Tabla = Medico.Buscar(PBusqueda)

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' ListarMedicos. Busca los datos de médicos.
    ''' </summary>
    ''' <returns>(DataTable). DataTable con todos los datos de los médicos que coincidan con el criterio de búsqueda.</returns>
    Public Function ListarMedicos() As DataTable
        Dim Medico As New Medico
        Try
            Dim Tabla As New DataTable
            Tabla = Medico.ConsultarCompleto()
            Tabla.Columns.Add("Nombre Completo", GetType(String), "[Nombre] + ' ' +[Apellidos]")

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Direcciones"

    ''' <summary>
    ''' InsertarDireccion. Inserta los datos de dirección de un paciente o médico.
    ''' </summary>
    ''' <param name="Pid">(String)Id Persona.</param>
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
    Public Sub InsertarDireccion(ByVal Pid As Integer, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String)
        Dim Direccion As Direccion
        Direccion = New Direccion(PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal, Pid)
    End Sub

    ''' <summary>
    ''' UpdateDireccion. Actualiza los datos de dirección de un paciente o médico.
    ''' </summary>
    ''' <param name="Pid">(String)Id Persona.</param>
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
    Public Sub UpdateDireccion(ByVal Pid As Integer, ByVal PTipoVia As String, ByVal PVia As String, ByVal PNumero As String, ByVal PKilometro As Integer, ByVal PHectometro As Integer, ByVal PBloque As String, ByVal PPortal As String, ByVal PEscalera As String, ByVal PPlanta As String, ByVal PPuerta As String, ByVal PLocalidad As String, ByVal PMunicipio As String, ByVal PProvincia As String, ByVal PCodPostal As String)
        Dim Direccion As New Direccion
        Direccion.Modificar(PTipoVia, PVia, PNumero, PKilometro, PHectometro, PBloque, PPortal, PEscalera, PPlanta, PPuerta, PLocalidad, PMunicipio, PProvincia, PCodPostal, Pid)
    End Sub
#End Region

#Region "Copias Seguridad"

    ''' <summary>
    ''' CopiaSeguridad. Realiza una copia de seguridad en formato XML con todos los datos de la base de datos.
    ''' </summary>
    Public Function CopiaSeguridad() As Boolean
        Dim Sb As New StringBuilder()

        Dim Direccion As New Direccion

        Sb.AppendLine("<Table id=""direcciones"">")

        For Each Direccion1 As Direccion In Direccion.Consultar()

            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Direccion1.Id) + "," + Direccion1.TipoVia + "," + Direccion1.Via + "," + Direccion1.Numero + "," + CStr(Direccion1.Kilometro) + "," + CStr(Direccion1.Hectometro) + "," + Direccion1.Bloque + "," + Direccion1.Portal + "," + Direccion1.Planta + "," + Direccion1.Escalera + "," + Direccion1.Puerta + "," + Direccion1.Localidad + "," + Direccion1.Municipio + "," + Direccion1.Provincia + "," + Direccion1.CodPostal + "," + CStr(Direccion1.PersonaId))
            Sb.AppendLine("</Fila>")

        Next
        Sb.AppendLine("</Table>")

        Dim Persona As New Persona

        Sb.AppendLine("<Table id=""personas"">")
        For Each Persona1 As Persona In Persona.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Persona1.Id) + "," + Persona1.Nombre + "," + Persona1.Apellidos + "," + Persona1.Telefono + "," + CStr(Persona1.Baja) + "," + Persona1.Nif + "," + Persona1.Email)
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Dim Paciente As New Paciente

        Sb.AppendLine("<Table id=""pacientes"">")
        For Each Paciente1 As Paciente In Paciente.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Paciente1.Id) + "," + CStr(Paciente1.Sip))
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Dim Medico As New Medico

        Sb.AppendLine("<Table id=""medicos"">")
        For Each Medico1 As Medico In Medico.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Medico1.Id) + "," + Medico1.NumColegiado + "," + Medico1.Password)
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Dim Festivo As New Festivo

        Sb.AppendLine("<Table id=""festivos"">")
        For Each Festivo1 As Festivo In Festivo.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Festivo1.Id) + "," + CStr(Festivo1.FechaFestivo) + "," + Festivo1.NombreFestivo)
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Dim Cita As New Cita

        Sb.AppendLine("<Table id=""citas"">")
        For Each Cita1 As Cita In Cita.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Cita1.Id) + "," + CStr(Cita1.Fecha) + "," + Cita1.Hora + "," + CStr(Cita1.Duracion) + "," + CStr(Cita1.Terminada) + "," + CStr(Cita1.TipoCita) + "," + CStr(Cita1.ColaId) + "," + CStr(Cita1.PacienteId))
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Dim Cola As New Cola

        Sb.AppendLine("<Table id=""colas"">")
        For Each Cola1 As Cola In Cola.Consultar()
            Sb.Append(vbTab + "<Fila>")
            Sb.Append(CStr(Cola1.Id) + "," + CStr(Cola1.NumeroCola) + "," + Cola1.Mesa + "," + CStr(Cola1.MedicoId))
            Sb.AppendLine("</Fila>")
        Next
        Sb.AppendLine("</Table>")

        Using Outfile As New StreamWriter("CopiaSeg.xml")
            Outfile.Write(Sb.ToString())
        End Using

        Return True
    End Function

#End Region

#Region "Colas"

    ''' <summary>
    ''' InsertarCola. Inserta los datos de una nueva cola.
    ''' </summary>
    ''' <param name="PNumCola">(String)Numero Cola.</param>
    ''' <param name="PNumMesa">(String)Nombre Mesa.</param>
    ''' <param name="PMedicoId ">(String)Id Médico.</param>
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function InsertarCola(ByVal PNumCola As Integer, ByVal PNumMesa As String, ByVal PMedicoId As Integer) As Integer

        Dim Cola As Cola
        Try
            Cola = New Cola(PNumCola, PNumMesa, PMedicoId)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ResultCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' ConsultarColas. Consulta los datos de las Colas.
    ''' </summary>
    ''' <returns>(DataTable). DataTable con todos los datos de todos las colas.</returns> 
    Public Function ConsultarColas() As DataTable

        Dim Cola As New Cola
        Try

            Dim Tabla As New DataTable
            Tabla = Cola.ConsultarTodos()

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            MsgBox(Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            MsgBox(SqlExc.ErrorCode)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            MsgBox(Ex1.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' EliminarCola. Elimina una cola determinado por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id Cola.</param> 
    ''' <returns>(Integer) Integer. 1 indica que la eliminación ha sido correcta, 0 Incorrecta.</returns> 
    Public Function EliminarCola(ByVal PId As Integer) As Integer
        Dim Cola As New Cola
        Try
            Cola.Borrar(PId)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' ActualizarCola. Actualiza una cola determinada por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id Cola.</param> 
    ''' <param name="PMedicoId">(Integer)Id Médico.</param> 
    ''' <param name="PNumeroCola">(Integer)Numero Cola.</param> 
    ''' <param name="PNumMesa">(String)Nombre Cola.</param> 
    ''' <returns>(Integer) Integer. 1 indica que la eliminación ha sido correcta, 0 Incorrecta.</returns> 
    Public Function ActualizarCola(ByVal PId As Integer, ByVal PNumeroCola As Integer, ByVal PNumMesa As String, ByVal PMedicoId As Integer) As Integer
        Dim Cola As New Cola
        Try
            Cola.Modificar(PId, PNumeroCola, PNumMesa, PMedicoId)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

#End Region

#Region "Citas"

    ''' <summary>
    ''' InsertaCita. Inserta los datos de una nueva cita.
    ''' </summary>
    ''' <param name="PFecha ">(Date)Numero cita.</param>
    ''' <param name="PDuracion ">(Integer)Duracion Cita.</param>
    ''' <param name="PTerminada ">(Integer)Cita Terminada.</param>
    ''' <param name="PTipoCita  ">(Integer)Tipo Cita.</param>
    ''' <param name="PColaId ">(Integer)Id Cola.</param>
    ''' <param name="PPacienteId ">(Integer)Id Paciente.</param>
    ''' <returns>(Integer) Integer. 1 indica que la inserción ha sido correcta, 0 Incorrecta.</returns> 
    Public Function InsertarCita(ByVal PFecha As Date, ByVal PDuracion As Integer, ByVal PTerminada As Integer, ByVal PTipoCita As Integer, ByVal PColaId As Integer, ByVal PPacienteId As Integer) As Integer

        Dim Cita As New Cita

        Dim Solapa As Boolean = False
        Dim FechaFin As DateTime = New DateTime
        FechaFin = PFecha
        FechaFin = FechaFin.AddMinutes(PDuracion)


        Dim ListaCitas As List(Of Cita) = Cita.Consultar(PFecha, PColaId)
        Try
            If ListaCitas.Count > 0 Then
                For Each Cita1 As Cita In ListaCitas
                    Dim Fecha1 As DateTime = New DateTime(Cita1.Fecha.Year, Cita1.Fecha.Month, Cita1.Fecha.Day, CInt(Cita1.Hora.Substring(0, 2)), CInt(Cita1.Hora.Substring(3, 2)), 0)
                    Dim FechaFin1 As DateTime = New DateTime
                    FechaFin1 = Fecha1
                    FechaFin1 = FechaFin1.AddMinutes(Cita1.Duracion)

                    ''Comprobamos solapamiento con cada una de las citas del día
                    If PFecha < FechaFin1 And Fecha1 < FechaFin Then
                        Solapa = True
                    End If
                Next

                If Solapa = False Then
                    Cita = New Cita(PFecha, PDuracion, PTerminada, PTipoCita, PColaId, PPacienteId)
                    Return 1
                Else
                    Solapa = False
                    Return 2

                End If
            Else
                Cita = New Cita(PFecha, PDuracion, PTerminada, PTipoCita, PColaId, PPacienteId)
                Return 1
            End If
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ResultCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' ListadoHoras. Consulta las citas por fecha y cola
    ''' </summary>
    ''' <param name="PFecha ">(Date)Fecha cita.</param>
    ''' <param name="PColaId ">(Integer)Id Cola.</param>
    ''' <returns>(DataTable) Datatable con todas las citas por fecha y cola.</returns> 
    Public Function ListadoHoras(ByVal PFecha As Date, ByVal PColaId As Integer) As DataTable

        Dim Cita As New Cita
        Dim ListaCitas As DataTable = Cita.ConsultarHoras(PFecha, PColaId)
        Return ListaCitas
    End Function

    ''' <summary>
    ''' ConsultarCitasPaciente. Consulta los datos de las citas de un paciente.
    ''' </summary>
    ''' <param name="PId ">(String)SIP Paciente.</param>
    ''' <returns>(DataTable). DataTable con todos los datos de todos las citas de un paciente</returns> 
    Public Function ConsultarCitasPaciente(ByVal PId As String) As DataTable

        Dim Cita As New Cita
        Try
            Dim Tabla As New DataTable

            Tabla = Cita.Consultar(CUInt(PId))

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' ConsultarCitasMedico. Consulta los datos de las citas de un médico en un día.
    ''' </summary>
    ''' <param name="PId ">(String)Número Colegiado.</param>
    ''' <param name="Pfecha ">(String)Fecha.</param>
    ''' <returns>(DataTable). DataTable con todos los datos de todos las citas de un médico en un día determinado</returns> 
    Public Function ConsultarCitasMedico(ByVal PId As String, ByVal Pfecha As Date) As DataTable

        Dim Cita As New Cita
        Try
            Dim Tabla As New DataTable

            Tabla = Cita.Consultar(PId, Pfecha)

            Return Tabla
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return Nothing
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return Nothing
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' EliminarCita. Elimina una cita determinado por su Id.
    ''' </summary>
    ''' <param name="PId ">(Integer)Id Cita.</param> 
    ''' <returns>(Integer) Integer. 1 indica que la eliminación ha sido correcta, 0 Incorrecta.</returns> 
    Public Function EliminarCita(ByVal PId As Integer) As Integer
        Dim Cita As New Cita
        Try
            Cita.Borrar(PId)
            Return 1
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' EliminarCitaPorCola. Elimina las citas determinadas por su Id de cola.
    ''' </summary>
    ''' <param name="PColaId ">(Integer)Id Cita.</param> 
    ''' <returns>(Integer) Integer. 1 indica que la eliminación ha sido correcta, 0 Incorrecta.</returns> 
    Public Function EliminarCitaPorCola(ByVal PcolaId As Integer) As Integer
        Dim Cita As New Cita
        Try
            Dim Tabla As New DataTable
            Tabla = Cita.ConsultarCola(PcolaId)
            Return Tabla.Rows.Count
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' ActualizarCita. Actualiza una cita.
    ''' </summary>
    ''' <param name="Fecha ">(Date)Numero cita.</param>
    ''' <param name="PHora ">(Date)Numero cita.</param>
    ''' <param name="PDuracion ">(Integer)Duracion Cita.</param>
    ''' <param name="PTerminada ">(Integer)Cita Terminada.</param>
    ''' <param name="PTipoCita  ">(Integer)Tipo Cita.</param>
    ''' <param name="PColaId ">(Integer)Id Cola.</param>
    ''' <param name="PPacienteId ">(Integer)Id Paciente.</param>
    ''' <returns>(Integer) Integer. 1 indica que la actualización ha sido correcta, 0 Incorrecta.</returns> 
    Public Function ActualizarCita(ByVal PId As Integer, ByVal Fecha As Date, ByVal PHora As String, ByVal PDuracion As Integer, ByVal PTerminada As Integer, ByVal PTipoCita As Integer, ByVal PColaId As Integer, ByVal PPacienteId As Integer) As Integer
        Dim Cita As New Cita

        Dim Solapa As Boolean = False
        Dim PFecha As DateTime = New DateTime
        PFecha = New DateTime(Fecha.Year, Fecha.Month, Fecha.Day, CInt(PHora.Substring(0, 2)), CInt(PHora.Substring(3, 2)), 0)
        Dim FechaFin As DateTime = New DateTime
        FechaFin = New DateTime(Fecha.Year, Fecha.Month, Fecha.Day, CInt(PHora.Substring(0, 2)), CInt(PHora.Substring(3, 2)), 0)
        FechaFin = FechaFin.AddMinutes(PDuracion)


        Dim ListaCitas As List(Of Cita) = Cita.Consultar(Fecha, PColaId)
        Try
            If ListaCitas.Count > 0 Then
                For Each Cita1 As Cita In ListaCitas
                    Dim Fecha1 As DateTime = New DateTime(Cita1.Fecha.Year, Cita1.Fecha.Month, Cita1.Fecha.Day, CInt(Cita1.Hora.Substring(0, 2)), CInt(Cita1.Hora.Substring(3, 2)), 0)
                    Dim FechaFin1 As DateTime = New DateTime
                    FechaFin1 = Fecha1
                    FechaFin1 = FechaFin1.AddMinutes(Cita1.Duracion)

                    ''Comprobamos solapamiento con cada una de las citas del día
                    If PFecha < FechaFin1 And Fecha1 < FechaFin Then
                        Solapa = True
                    End If
                Next

                If Solapa = False Then
                    Cita.Modificar(PId, PFecha, PHora, PDuracion, PTerminada, PTipoCita, PColaId, PPacienteId)
                    Return 1
                Else
                    Solapa = False
                    Return 2

                End If
            Else
                Cita.Modificar(PId, PFecha, PHora, PDuracion, PTerminada, PTipoCita, PColaId, PPacienteId)
                Return 1
            End If
        Catch Ex As DuplicateNameException ''Validación de atributos
            Debug.WriteLine("Mensaje: " + Ex.Message)
            Return 0
        Catch SqlExc As SQLite.SQLiteException ''Errores de base de datos.
            Debug.WriteLine("Código: " + CStr(SqlExc.ErrorCode) + " Mensaje:" + SqlExc.Message)
            Return 0
        Catch Ex1 As Exception ''Error general
            Debug.WriteLine("Mensaje: " + Ex1.Message)
            Return 0
        End Try
    End Function

#End Region

End Class
