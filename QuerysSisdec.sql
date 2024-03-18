CREATE TABLE ACCIONES (
    Id INT PRIMARY KEY IDENTITY,
    Accion NVARCHAR(50) NOT NULL
);

CREATE TABLE ESTADOS (
    Id INT PRIMARY KEY IDENTITY,
    Estado NVARCHAR(50) NOT NULL
);

CREATE TABLE GENEROS (
    Id INT PRIMARY KEY IDENTITY,
    Genero NVARCHAR(50) NOT NULL,
    Abreviacion NVARCHAR(5) NOT NULL
);

CREATE TABLE ROLES (
    Id INT PRIMARY KEY IDENTITY,
    Rol NVARCHAR(50) NOT NULL
);

CREATE TABLE TIPOSDOCUMENTO (
    Id INT PRIMARY KEY IDENTITY,
    TipoDocumento NVARCHAR(50) NOT NULL,
    Abreviacion NVARCHAR(5) NOT NULL
);

CREATE TABLE Logs (
    Id INT PRIMARY KEY IDENTITY,
    IdAccion INT NOT NULL,
    Descripcion NVARCHAR(50) NOT NULL,
    DateLog DATETIME NOT NULL,
    FOREIGN KEY (IdAccion) REFERENCES ACCIONES(Id)
);

CREATE TABLE USUARIOS (
    Id INT PRIMARY KEY IDENTITY,
    PrimerNombre NVARCHAR(50) NOT NULL,
    SegundoNombre NVARCHAR(50) NOT NULL,
    PrimerApellido NVARCHAR(50) NOT NULL,
    SegundoApellido NVARCHAR(50),
    IdTipoDocumento INT NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    IdGenero INT NOT NULL,
    Telefono NVARCHAR(50) NOT NULL,
    Correo NVARCHAR(50) NOT NULL,
    Contraseña NVARCHAR(50) NOT NULL,
    IdRol INT NOT NULL,
    IdEstado INT NOT NULL,
    FOREIGN KEY (IdTipoDocumento) REFERENCES TIPOSDOCUMENTO(Id),
    FOREIGN KEY (IdGenero) REFERENCES GENEROS(Id),
    FOREIGN KEY (IdRol) REFERENCES ROLES(Id),
    FOREIGN KEY (IdEstado) REFERENCES ESTADOS(Id)
);
CREATE TABLE SOPORTES (
    Id INT PRIMARY KEY IDENTITY,
    Asunto NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    IdUsuario INT NOT NULL,
    Fecha DATETIME NOT NULL,
    IdEstado INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (IdEstado) REFERENCES Estados(Id)
);
CREATE TABLE PlanAccionAcademico (
    Id INT IDENTITY PRIMARY KEY,
    Programa NVARCHAR(MAX),
    Fecha NVARCHAR(MAX),
    Director NVARCHAR(MAX),
    FechaDos NVARCHAR(MAX),
    Actividad NVARCHAR(MAX),
    Descripcion NVARCHAR(MAX),
    Duracion NVARCHAR(MAX),
    Lugar NVARCHAR(MAX),
    HoraInicio NVARCHAR(MAX),
    HoraFin NVARCHAR(MAX),
    Responsable NVARCHAR(MAX),
    Participantes NVARCHAR(MAX),
    Evidencias NVARCHAR(MAX),
	IdUsuario INT FOREIGN KEY REFERENCES USUARIOS(Id)
);
CREATE TABLE PracticaPorAsignatura (
    Id INT IDENTITY PRIMARY KEY,
    Programa VARCHAR(MAX),
    Director VARCHAR(MAX),
    Semestre VARCHAR(MAX),
    NombrePractica VARCHAR(MAX),
    NumeroPractica VARCHAR(MAX),
    Lugar VARCHAR(MAX),
    Horas VARCHAR(MAX),
    Observaciones VARCHAR(MAX),
    Introduccion VARCHAR(MAX),
    ObjetivoGeneral VARCHAR(MAX),
    ObjetivosEspecificos VARCHAR(MAX),
    EvidenciasActividades VARCHAR(MAX),
    ObjetosUsados VARCHAR(MAX),
    ResultadoAprendizaje VARCHAR(MAX),
    EvaluacionPractica VARCHAR(MAX),
    IdUsuario INT FOREIGN KEY REFERENCES USUARIOS(Id)
);
CREATE TABLE AtencionEstudiantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Programa NVARCHAR(MAX),
    Director NVARCHAR(MAX),
    Modulo NVARCHAR(MAX),
    Fecha NVARCHAR(MAX),
    Hora NVARCHAR(MAX),
    Semestre NVARCHAR(MAX),
    Grupo NVARCHAR(MAX),
    Jornada NVARCHAR(MAX),
    Motivo NVARCHAR(MAX),
    Observaciones NVARCHAR(MAX),
    AprobacionEstudiante NVARCHAR(MAX),
    IdUsuario INT FOREIGN KEY REFERENCES USUARIOS(Id)
);