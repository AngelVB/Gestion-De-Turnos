CREATE TABLE [personas] (
  [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL
  , [Nombre] varchar(30) NULL
  , [Apellidos] varchar(50) NULL
  , [Telefono] varchar(12) NULL
  , [Baja] boolean NULL
  , [NIF] varchar(9) NOT NULL UNIQUE
  , [Email] varchar(50) NULL
);
CREATE TABLE [direcciones] (
  [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  [TipoVia] varchar(10),
  [Via] varchar(50),
  [Numero] varchar(5),
  [Kilometro] varchar(10),
  [Hectometro] varchar(10),
  [Bloque] varchar(3),
  [Portal] varchar(3),
  [Escalera] varchar(2),
  [Planta] varchar(5),
  [Puerta] varchar(2),
  [Localidad] varchar(50),
  [Municipio] varchar(50),
  [Provincia] varchar(30),
  [CodPostal] varchar(5),
  [PersonaId] integer NOT NULL,
  FOREIGN KEY(PersonaId) REFERENCES personas(id)
);
CREATE TABLE [medicos] (
  [Id] integer NOT NULL
  , [NumColegiado] varchar(10) NOT NULL UNIQUE
  , [Password] varchar(20) NOT NULL
  , CONSTRAINT [sqlite_master_PK_medicos] PRIMARY KEY ([Id])
  , FOREIGN KEY ([Id]) REFERENCES [personas] ([id])
);
CREATE TABLE [pacientes] (
  [Id] integer NOT NULL
  , [SIP] numeric(10,0) NOT NULL UNIQUE
  , CONSTRAINT [sqlite_master_PK_pacientes] PRIMARY KEY ([Id])
);
CREATE TABLE [colas] (
  [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  [NumCola] integer NOT NULL UNIQUE,
  [NumMesa] varchar(20) NOT NULL,
  [MedicoId] integer,
  [NombreConsulta] varchar(50),
  CONSTRAINT [FK_colas_0_0] FOREIGN KEY ([MedicoId]) REFERENCES [medicos] ([Id]) MATCH NONE ON UPDATE NO ACTION ON DELETE NO ACTION
);
CREATE TABLE [citas] (
    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [Fecha] varchar(10) DEFAULT CURRENT_DATE,
    [Hora] varchar(5) DEFAULT CURRENT_TIME,
    [Duracion] integer,
    [Terminada] boolean,
    [TipoCita] boolean,
    [Cola_Id] integer NOT NULL,
    [Paciente_Id] integer NOT NULL,
    CONSTRAINT [FK_citas_0_0] FOREIGN KEY ([Cola_Id]) REFERENCES [colas] ([Id]) MATCH NONE ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT [FK_citas_1_0] FOREIGN KEY ([Paciente_Id]) REFERENCES [pacientes] ([Id]) MATCH NONE ON UPDATE NO ACTION ON DELETE NO ACTION
);
CREATE TABLE [festivos] (
    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [FechaFestivo] datetime NOT NULL UNIQUE,
    [NombreFestivo] varchar(40) NOT NULL
);
