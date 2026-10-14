# Galería de Artes (BARTOPI)

Aplicación de escritorio en **WPF (.NET 6)** para explorar, valorar y guardar obras de **música, pintura, cine y libros** obtenidas de APIs públicas. Cada usuario puede opinar, marcar "me gusta"/"no me gusta" y consultar su galería personal. Los datos se guardan en una base de datos **SQLite** local.

- Solución: `Galeria_de_Artes.sln`
- Proyecto: `Galeria_de_Artes/Galeria_de_Artes.csproj` (nombre de ensamblado: **BARTOPI**)
- Plataforma: `net6.0-windows` (solo Windows, ya que usa WPF)

---

## Requisitos

- Windows 10/11.
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (para compilar) o solo el runtime .NET 6 Desktop si usas el instalador.
- Visual Studio 2022 con la carga de trabajo **.NET desktop development** (recomendado para abrir la solución y el proyecto de instalador).

---

## Instalación y uso

### Opción 1 — Ejecutar desde Visual Studio

1. Abre `Galeria_de_Artes.sln`.
2. Selecciona el proyecto **Galeria_de_Artes** como proyecto de inicio.
3. Pulsa **F5** (Debug) o **Ctrl+F5** (sin debugger).

### Opción 2 — Compilar con la CLI

```bash
dotnet build Galeria_de_Artes.sln
dotnet run --project Galeria_de_Artes/Galeria_de_Artes.csproj
```

### Opción 3 — Instalador

En `Setup/Debug/` se encuentran `setup.exe` y `Setup.msi` (proyecto `Setup/Setup.vdproj`, versión 1.0.0). Ejecuta `setup.exe` y sigue el asistente; la aplicación se instala en `Archivos de programa`.

> Nota: la base de datos `Resources/Galeria.db` se copia junto al ejecutable en cada compilación, por lo que los cambios realizados al ejecutar en Debug no se conservan en la fuente si se vuelve a compilar.

---

## Usuarios por defecto

| Id | Usuario   | Contraseña | Rol           |
|----|-----------|------------|---------------|
| 1  | Felipe    | 1234       | Administrador |
| 2  | Nacho     | 0000       | Administrador |
| 4  | Viviana   | 0000       | Usuario       |

Cualquier visitante puede registrarse desde la pantalla de inicio de sesión ("Nuevo usuario" o tecla **Esc**); siempre se crea con rol **Usuario**.

---

## Funcionalidad

### 1. Inicio de sesión
- Introduce usuario y contraseña y pulsa **Comprobar** (o tecla **Tab**).
- Dos roles: **Administrador (1)** y **Usuario (2)**. El rol determina si aparece el menú *Administrar*.
- *Nuevo usuario* permite darse de alta. *Cerrar sesión* (o **Esc** desde la pantalla principal) vuelve al login.

### 2. Menú principal
Cuatro accesos con efecto zoom al pasar el ratón: **Películas**, **Música**, **Libros** y **Pinturas**. Además:
- **Galería** → "Mi galería".
- **?** → Ayuda.
- **Administrar** → solo visible para administradores.

### 3. Secciones de arte (todas con la misma mecánica)

| Sección   | API utilizada | Qué se puede hacer |
|-----------|---------------|--------------------|
| Películas | [The Movie DB](https://developer.themoviedb.org/) | Ver las películas populares, cartel, actores y directores; buscar por palabras clave; elegir género. |
| Música    | [Deezer](https://developers.deezer.com/api/search) | Explorar artistas, álbumes y canciones; búsqueda cruzada (artista → sus álbumes/canciones); **reproducir el preview de 30 s** de la canción seleccionada (botón ‖ para pausar). |
| Libros    | [Open Library](https://openlibrary.org/developers/api) | Explorar libros y autores; buscar por autor o por título. |
| Pinturas  | [Art Institute of Chicago](https://api.artic.edu/docs/) | Ver 100 obras y sus autores; filtrar por autor; mostrar la imagen en alta resolución (IIIF). |

En las cuatro secciones puedes:
1. Seleccionar una obra de los desplegables o buscarla.
2. Escribir una **opinión** en texto.
3. Marcar **Me gusta** / **No me gusta**.
4. Pulsar **Guardar**: si la obra no estaba en la base de datos se crea; después se guarda/actualiza tu opinión y tu valoración. *Nueva búsqueda* limpia el formulario.

### 4. Mi galería
- **RadioButtons** (Música, Películas, Pinturas, Libros) para elegir el tipo de obra.
- Muestra el listado de obras guardadas en la base de datos y permite **ver la imagen** o **reproducir la canción** con los botones `|>` (play) y `=` (stop).
- Menú **Me gustan**: lista solo las obras que **tú** has marcado con "me gusta".

### 5. Ayuda (?)
Tres páginas explicativas: botones de arte, Mi galería y Galería de arte, con botón *Volver*.

### 6. Administrar (solo rol Administrador)
Consola CRUD sobre todas las tablas de la base de datos. Pasos:
1. **Acción**: Eliminar / Agregar / Editar / Mostrar datos.
2. **Tabla**: Obras / Usuarios / Opiniones / Opiniones de usuario.
3. Si es *Obras*, elegir el tipo: Música / Películas / Pinturas / Libros.

Permite, por ejemplo, crear usuarios administradores (Rol = 1), corregir contraseñas o borrar obras y opiniones. El botón *Volver a buscar* reinicia el formulario.

### Atajos de teclado

| Tecla | Pantalla        | Acción            |
|-------|-----------------|-------------------|
| Tab   | Inicio de sesión | Comprobar login  |
| Esc   | Inicio de sesión | Nuevo usuario     |
| Tab   | Principal       | Mi galería        |
| Esc   | Principal       | Cerrar sesión     |

---

## Base de datos

SQLite en `Galeria_de_Artes/Resources/Galeria.db` (paquete NuGet `System.Data.SQLite 1.0.117`). Todas las consultas usan **parámetros parametrizados** para evitar SQL Injection.

```sql
Usuarios        (IdUsuario PK, Nombre, Contraseña, Rol)          -- Rol: 1=Admin, 2=Usuario
Musicas         (IdCancion PK, IdCancionApi, Nombre, Cancion)    -- Cancion = URL preview Deezer
Pinturas        (IdPintura PK, IdPinturaApi, Nombre, Genero, IdImagen)  -- IdImagen = image_id IIIF
Peliculas       (IdPelicula PK, IdPeliculaApi, Nombre, Genero, IdImagen)-- IdImagen = poster_path TMDB
Libro           (IdLibro PK, IdLibroApi, Nombre)
Opiniones       (IdOpinion PK, IdObra, Opinion, IdUsuario)
Opinion_Usuario (Id PK, IdObra, TipoObra, IdUsuario, LikeODislike)      -- 1=like, -1=dislike
Opiniones_App   (Id PK, IdObra, ContLikes, ContDislikes)
```

Códigos de `TipoObra`: **1 = Música, 2 = Pinturas, 3 = Películas, 4 = Libros**. Las obras se identifican por su **id en la API** (por ejemplo, el id de TMDB o `/works/OL...` de Open Library).

---

## Estructura del proyecto

```
Proyecto_Final_Galeria_DAM/
├── Galeria_de_Artes.sln
├── README.md
├── Galeria_de_Artes/
│   ├── App.xaml                    # Startup → MainWindow (NavigationWindow)
│   ├── VistaControlador/
│   │   ├── Ventanas/               # Páginas: InicioSesion, Principal, Peliculas,
│   │   │                           # Musica, libros, Pinturas, Mi_galeria,
│   │   │                           # NuevoUsuario, Pregunta, PregGalerias, MainWindow
│   │   └── User_control/           # administrar (CRUD admin), Megustan (favoritos)
│   ├── Modelo/
│   │   ├── Apis/                   # ApiCine, ApiMusica, ApiLibros, ApiChicago
│   │   ├── Bases Datos/CRUD.cs     # Acceso a SQLite (usuarios, obras, opiniones, likes)
│   │   └── Clases/                 # Modelos: Usuarios, obras, Pelicula, Libros, Canciones...
│   └── Resources/                  # Imágenes, GIFs y Galeria.db
├── Documentacion/                  # Documentación Sandcastle (Documentacion.shfbproj)
└── Setup/                          # Instalador Visual Studio (setup.exe, Setup.msi)
```

---

## Notas

- Las llamadas a las APIs se realizan con `HttpClient` y se parsean con `JsonDocument`; se necesita **conexión a internet** para explorar las secciones de arte.
- La API key de The Movie DB está embebida en `Modelo/Apis/ApiCine.cs`.
- El acceso a *Administrar* se oculta visualmente para usuarios no administradores.
- La documentación XML de la API se genera automáticamente (`GenerateDocumentationFile=True`) y se puede compilar con Sandcastle desde `Documentacion/Documentacion.shfbproj`.
