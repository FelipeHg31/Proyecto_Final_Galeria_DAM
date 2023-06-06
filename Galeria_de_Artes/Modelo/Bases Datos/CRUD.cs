using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using Galeria_de_Artes.Modelo.Clases;

namespace Galeria_de_Artes.Modelo.Bases_Datos
{
    /// <summary>
    ///  Metodos de interacción con la base de datos
    /// </summary>
    public class CRUD
    {
        private SQLiteConnection con;
        private SQLiteDataReader lector;
        private SQLiteCommand comando;
        public String rol;

        public CRUD() { }


        /// <summary>
        /// busqueda dentro de los usuarios para hacer un inicio de sesion 
        /// </summary>

        public int IniciarSesion(string us, string cont)
        {
            int tipo = 0;

            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            con.Open();

            if ((us == "") && (cont == ""))
            {
                MessageBox.Show("Ingresar datos de ingreso porfavor");

            }
            else
            {
                //Para evita SQL Injections pasamos los strings como parametros
                string query = "SELECT * FROM Usuarios WHERE Nombre=@usuario and Contraseña=@contraseña";
                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@usuario", us);
                comando.Parameters.AddWithValue("@contraseña", cont);

                try
                {

                    lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        if (Int32.Parse(lector["Rol"].ToString()) == 1)
                        {
                            tipo = 1;
                            rol = "Administrador";
                        }
                        else if (Int32.Parse(lector["Rol"].ToString()) == 2)
                        {
                            tipo = 2;
                            rol = "Usuario";
                        }

                        UsuarioIngresado.id = Int32.Parse(lector["IdUsuario"].ToString());
                        UsuarioIngresado.tipo = Int32.Parse(lector["Rol"].ToString());
                        UsuarioIngresado.nombre = lector["Nombre"].ToString();
                    }

                }
                catch (SQLiteException e)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show("Error en inicio de sesion");
                }
            }
            con.Close();

            return tipo;
        }

       

        /// <summary>
        /// Metodos para la tabla de los Usuarios
        /// </summary>

        public void NuevoUsuario(string nom, string cont, int rol)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");

            using (con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;"))
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }


                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {

                    using (SQLiteCommand comando = new SQLiteCommand(con))
                    {
                        string query = "INSERT INTO Usuarios (Nombre, Contraseña, Rol) VALUES (@N, @C, @R)";
                        
                        comando.CommandText = query;

                        comando.Parameters.AddWithValue("@N", nom);
                        comando.Parameters.AddWithValue("@C", cont);
                        comando.Parameters.AddWithValue("@R", rol);
                        comando.ExecuteNonQuery();

                    }

                    transaction.Commit();
                }

                con.Close();

            }


        }

        public void EliminarUsuario(int id)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            string query = "DELETE FROM Usuarios WHERE IdUsuario=@I";
            
            comando = new SQLiteCommand(query, con);
            comando.Parameters.AddWithValue("@I", id);
            comando.ExecuteNonQuery();
            con.Close();
        }


        public void ActualizarUsuario(int id, double rol, string cont)
        {

            if ((rol != 0) && (cont == ""))
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                string query = "UPDATE Usuarios SET Rol=@Rol WHERE IdUsuario=@Id";
                comando = new SQLiteCommand(query, con);

                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Rol", rol);

                comando.ExecuteNonQuery();

                con.Close();
            }
            else if ((rol == 0) && (cont != ""))
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+"; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                string query = "UPDATE Usuarios SET Contraseña=@Contraseña WHERE IdUsuario=@Id";
                comando = new SQLiteCommand(query, con);

                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Contraseña", cont);

                comando.ExecuteNonQuery();
                con.Close();
            }
            else if((rol != 0) && (cont != ""))
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                string query = "UPDATE Usuarios SET Contraseña=@Contraseña WHERE IdUsuario=@Id";
                comando = new SQLiteCommand(query, con);
                comando.ExecuteNonQuery();

                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Contraseña", cont);


                query = "UPDATE Usuarios SET Rol=@Rol WHERE IdUsuario=@Id";
                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Rol", rol);

                comando.ExecuteNonQuery();
                con.Close();
            }
        }

        public void MostrarUsuarios(ComboBox c)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand("SELECT * FROM Usuarios", con);
            c.Items.Clear();
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Usuarios u = new Usuarios(Int32.Parse(lector["IdUsuario"].ToString()), lector["Nombre"].ToString(), lector["Contraseña"].ToString(), Int32.Parse(lector["rol"].ToString()));

                    c.Items.Add(u.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public int BuscarUsuario(int id)
        {
            int cant = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT COUNT(*) FROM Usuarios WHERE IdUsuario=@Id", con);
                comando.Parameters.AddWithValue("@Id", id);

                cant = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                cant = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return cant;
        }


        /// <summary>
        /// Metodos para la tabla de los distintos tipos de obras [ Musica | Pinturas | Peliculas | Libros ]
        /// </summary>

        public void NuevaObra(string nom, string api, int tipo, int genero, string media)
        {
            try
            {
                string query = "";

                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                switch (tipo)
                {
                    //Musica
                    case 1:

                        query = "INSERT INTO Musicas (IdCancionApi, Nombre, Cancion) VALUES (@Api, @Nombre, @Media)";
                        break;

                    //Pinturas
                    case 2:

                        query = "INSERT INTO Pinturas (IdPinturaApi, Nombre, Genero, IdImagen) VALUES (@Api, @Nombre, @Genero, @Media)";
                        break;

                    //Peliculas
                    case 3:

                        query = "INSERT INTO Peliculas (IdPeliculaApi, Nombre, Genero, IdImagen) VALUES (@Api, @Nombre, @Genero, @Media)";

                        break;

                    //Libros
                    case 4:

                        query = "INSERT INTO Libro (IdLibroApi, Nombre) VALUES (@Api, @Nombre)";

                        break;
                }

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                comando = new SQLiteCommand(query, con);

                comando.Parameters.AddWithValue("@Nombre", nom);
                comando.Parameters.AddWithValue("@Api", api);
                comando.Parameters.AddWithValue("@Genero", genero);
                comando.Parameters.AddWithValue("@Media", media);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void EliminarObra(int id, int tipo)
        {
            try
            {
                string query = "";

                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                switch (tipo)
                {
                    //Musica
                    case 1:

                        query = "DELETE FROM Musicas WHERE IdCancion=@Id";

                        break;

                    //Pinturas
                    case 2:

                        query = "DELETE FROM Pinturas WHERE IdPintura=@Id";
                        break;

                    //Peliculas
                    case 3:

                        query = "DELETE FROM Peliculas WHERE IdPelicula=@Id";

                        break;

                    //Libros
                    case 4:

                        query = "DELETE FROM Libro WHERE IdLibro=@Id";

                        break;
                }

                

                con.Open();

                VerificarTransaccionesActivas(con);

                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void ActualizarObra(int id, int tipo, int gen, string api)
        {
            try
            {
                string query = "";

                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");



                switch (tipo)
                {
                    //Musica
                    case 1:

                        query = "UPDATE Musicas SET IdMusicaApi=@Api WHERE IdCancion=@id";

                        break;

                    //Pinturas
                    case 2:

                        if ((api != "") && (gen == 0))
                        {
                            query = "UPDATE Pinturas SET IdPinturaApi=@Api WHERE IdPintura=@id";
                        }
                        else if ((gen != 0) && (api == ""))
                        {
                            query = "UPDATE Pinturas SET Genero=@Genero WHERE IdPintura=@id";
                        }
                        else
                        {
                            query = "UPDATE Pinturas SET IdPinturaApi=@Api, Genero=@Genero WHERE IdPintura=@id";
                        }

                        break;

                    //Peliculas
                    case 3:

                        if ((api != "") && (gen == 0))
                        {
                            query = "UPDATE Peliculas SET IdPeliculaApi=@Api WHERE IdPelicula=@id";
                        }
                        else if ((gen != 0) && (api == ""))
                        {
                            query = "UPDATE Peliculas SET Genero=@Genero WHERE IdPelicula=@id";
                        }
                        else
                        {
                            query = "UPDATE Peliculas SET IdPeliculaApi=@Api, IdPelicula=@Genero WHERE IdPelicula=@id";
                        }

                        break;

                    //Libros
                    case 4:

                        query = "UPDATE Libro SET IdLibroApi=@Api WHERE IdLibro=@id";

                        break;
                }

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@Api", api);
                comando.Parameters.AddWithValue("@Genero", gen);
                comando.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            con.Close();
        }

        public void MostrarObras(ComboBox c, int tipo)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            switch (tipo)
            {
                //Musica
                case 1:

                    comando = new SQLiteCommand("SELECT * FROM Musicas", con);

                    c.Items.Clear();
                    try
                    {
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            c.Items.Add(lector["IdCancion"] + "." + lector["Nombre"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Pinturas
                case 2:

                    comando = new SQLiteCommand("SELECT * FROM Pinturas", con);
                    c.Items.Clear();
                    try
                    {
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            c.Items.Add(lector["IdPintura"] + "." + lector["Nombre"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Peliculas
                case 3:

                    comando = new SQLiteCommand("SELECT * FROM Peliculas", con);

                    c.Items.Clear();
                    try
                    {
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            c.Items.Add(lector["IdPelicula"] + "." + lector["Nombre"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Libros
                case 4:

                    comando = new SQLiteCommand("SELECT * FROM Libro", con);
                    c.Items.Clear();
                    try
                    {
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            c.Items.Add(lector["IdLibro"] + "." + lector["Nombre"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

            }

        }

        /// <summary>
        /// Metodo para obtener los elementos de media de las obras guardadas en la base de datos
        /// </summary>

        public string ObtMedia(int id, int tipo)
        {
            string media = "";
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            switch (tipo)
            {
                //Musica
                case 1:

                    try
                    {
                        comando = new SQLiteCommand("SELECT * FROM Musicas WHERE IdCancion=@id", con);

                        comando.Parameters.AddWithValue("@id", id);

                        lector = comando.ExecuteReader();

                        lector.Read();

                        media = lector["Cancion"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Pinturas
                case 2:

                    try
                    {
                        comando = new SQLiteCommand("SELECT * FROM Pinturas WHERE IdPintura=@id", con);

                        comando.Parameters.AddWithValue("@id", id);

                        lector = comando.ExecuteReader();

                        lector.Read();

                        media = lector["IdImagen"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Peliculas
                case 3:

                    try
                    {
                        comando = new SQLiteCommand("SELECT * FROM Peliculas WHERE IdPelicula=@id", con);

                        comando.Parameters.AddWithValue("@id", id);

                        lector = comando.ExecuteReader();

                        lector.Read();

                        media = lector["IdImagen"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;
               
            }
           
            return media;

        }


        public int BuscarObras(string idApi, int tipo)
        {
            int cant = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            switch (tipo)
            {
                //Musica
                case 1:

                    try
                    {
                        comando = new SQLiteCommand("SELECT COUNT(*) FROM Musicas WHERE IdCancionApi=@Id", con);

                        comando.Parameters.AddWithValue("@Id", idApi);

                        cant = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception ex )
                    {
                        cant = 0;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Pinturas
                case 2:

                    try
                    {
                        comando = new SQLiteCommand("SELECT COUNT(*) FROM Pinturas  WHERE IdPinturaApi=@Id", con);

                        comando.Parameters.AddWithValue("@Id", idApi);

                        cant = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        cant = 0;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                
                    break;

                //Peliculas
                case 3:

                    try
                    {
                        comando = new SQLiteCommand("SELECT COUNT(*) FROM Peliculas  WHERE IdPeliculaApi=@Id", con);

                        comando.Parameters.AddWithValue("@Id", idApi);

                        cant = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        cant = 0;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    break;

                //Libros
                case 4:

                    try
                    {
                        comando = new SQLiteCommand("SELECT COUNT(*) FROM Libro  WHERE IdLibroApi=@Id", con);

                        comando.Parameters.AddWithValue("@Id", idApi);

                        cant = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        cant = 0;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    break;
            }

            return cant;


           // lector.Close();
           
        }

        public string ObtenerId(int id, int tipo)
        {
            string idApi = "";

            try
            {
                string query = "";

                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                switch (tipo)
                {
                    //Musica
                    case 1:

                        try
                        {
                            comando = new SQLiteCommand("SELECT * FROM Musicas WHERE IdCancion=@Id", con);

                            comando.Parameters.AddWithValue("@Id", id);

                            lector = comando.ExecuteReader();

                            idApi = lector["IdCancionApi"].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                        break;

                    //Pinturas
                    case 2:

                        try
                        {
                            comando = new SQLiteCommand("SELECT * FROM Pinturas WHERE IdPintura=@Id", con);

                            comando.Parameters.AddWithValue("@Id", id);

                            lector = comando.ExecuteReader();

                            lector.Read();

                            idApi = lector["IdPinturaApi"].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                        break;

                    //Peliculas
                    case 3:

                        try
                        {
                            comando = new SQLiteCommand("SELECT * FROM Peliculas WHERE WHERE IdPelicula=@Id", con);

                            comando.Parameters.AddWithValue("@Id", id);

                            lector = comando.ExecuteReader();

                            idApi = lector["IdPeliculaApi"].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                        break;

                    //Libros
                    case 4:

                        try
                        {
                            comando = new SQLiteCommand("SELECT * FROM Libro WHERE IdLibro=@Id", con);

                            comando.Parameters.AddWithValue("@Id", id);

                            lector = comando.ExecuteReader();

                            idApi = lector["IdLibroApi"].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;
                }

               

            }
            catch (Exception ex) { }
            
           
            return idApi;
            
        }
        /// <summary>
        ///  Metodos para la tabla de Opinion Usuario
        /// </summary>


        public void NuevaOpinion_us(string IdObra, int tipoObra, int IdUsuario, int likeOdis)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            string query = "INSERT INTO Opinion_Usuario (IdObra, TipoObra, IdUsuario, LikeODislike) VALUES (@IdObra, @TipoObra, @IdUsuario, @LikeODislike)";

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand(query, con);
            comando.Parameters.AddWithValue("@IdObra", IdObra);
            comando.Parameters.AddWithValue("@TipoObra", tipoObra);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@LikeODislike", likeOdis);
            comando.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarOpinion_us(int IdUsuario, string IdObra)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdObra", IdObra);
            string query = "DELETE FROM Opinion_Usuario WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)";
            comando = new SQLiteCommand(query, con);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdObra", IdObra);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public void ActualizarOpinion_us(string IdObra, int IdUsuario, int likeOdis)
        {
            try
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                string query = "UPDATE Opinion_Usuario SET LikeODislike=@likeOdis WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)";
                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.Parameters.AddWithValue("@likeOdis", likeOdis);
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
                        
        }


        public void MostrarOpinion_us(ComboBox c)
        {
            string mostrar;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");
            
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            VerificarTransaccionesActivas(con);
            comando = new SQLiteCommand("SELECT * FROM Opinion_Usuario", con);
            c.Items.Clear();
            
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    mostrar = "Id usuario:" + lector["IdUsuario"].ToString() + "Id Obra: " + lector["IdObra"].ToString();
                    c.Items.Add(mostrar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
           
        }

        public int BuscarOpinion_Us(string IdObra, int IdUsuario)
        {

            int cant = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT COUNT(*) FROM Opinion_Usuario WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)", con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                cant = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                cant = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            con.Close();
            return cant;
            
        }

        /// <summary>
        /// Metodo que obtendra las obras con likes
        /// </summary>
        /// <param name="IdObra"></param>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public int ObtLikes(string IdObra, int IdUsuario)
        {
            int likes = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT * FROM Opinion_Usuario WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)", con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                lector  = comando.ExecuteReader();

                likes = Int32.Parse(lector["LikeODislike"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                con.Close();
            }

            return likes;
        }


        /// <summary>
        /// Metodo que obtendra las obras que tengan like por parte del usurio buscando cada una en su respectiva tabla
        /// </summary>
        

        public void ObtObrasLikes(int IdUsuario, ComboBox c)
        {
            int likes = 0;
            obras ob;
            List<obras> lista = new List<obras>();
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT * FROM Opinion_Usuario WHERE (IdUsuario=@IdUsuario) AND (LikeODislike=1)", con);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                   ob = new obras(Int32.Parse(lector["TipoObra"].ToString()), lector["IdObra"].ToString());
                   lista.Add(ob);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            c.Items.Clear();

            try
            {
                foreach(obras obr in lista)
                {
                    switch (obr.tipo)
                    {
                        case 1:

                            comando = new SQLiteCommand("SELECT * FROM Musicas WHERE IdCancionApi="+obr.id, con);

                           
                            try
                            {
                                lector = comando.ExecuteReader();

                                while (lector.Read())
                                {
                                    c.Items.Add("Cancion: " + lector["IdCancion"] + "." + lector["Nombre"].ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                           
                            break;

                        //Pinturas
                        case 2:

                            comando = new SQLiteCommand("SELECT * FROM Pinturas WHERE IdPinturaApi="+obr.id, con);
                           
                            try
                            {
                                lector = comando.ExecuteReader();

                                while (lector.Read())
                                {
                                    c.Items.Add("Pintura: " + lector["IdPintura"] + "." + lector["Nombre"].ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
                            break;

                        //Peliculas
                        case 3:

                            comando = new SQLiteCommand("SELECT * FROM Peliculas WHERE IdPeliculaApi="+obr.id, con);

                            
                            try
                            {
                                lector = comando.ExecuteReader();

                                while (lector.Read())
                                {
                                    c.Items.Add("Pelicula: " + lector["IdPelicula"] + "." + lector["Nombre"].ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
                            break;

                        //Libros
                        case 4:

                            comando = new SQLiteCommand("SELECT * FROM Libro WHERE IdLibroApi='"+ obr.id+"'", con);

                            try
                            {
                                lector = comando.ExecuteReader();

                                while (lector.Read())
                                {
                                    c.Items.Add("Libro: " + lector["IdLibro"] + "." + lector["Nombre"].ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }




        /// <summary>
        /// Metodos para la tabla de Opiniones 
        /// </summary>


        public void NuevaOpinion(string IdObra, int IdUsuario, string opinion)
        {
            try
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                string query = "INSERT INTO Opiniones (IdObra, Opinion, IdUsuario) VALUES (@IdObra, @IdUsuario, @Opinion)";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();
                
                VerificarTransaccionesActivas(con);

                comando = new SQLiteCommand(query, con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.Parameters.AddWithValue("@Opinion", opinion);
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                con.Close();
            }

            
        }

        public void EliminarOpinion(int IdUsuario, string IdObra)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            string query = "DELETE FROM Opiniones WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)";
            comando = new SQLiteCommand(query, con);

            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdObra", IdObra);

            comando.ExecuteNonQuery();
            con.Close();
        }

        public void ActualizarOpinion(string IdObra, int IdUsuario, string opinion)
        {
            try
            {
                string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string strFilePath = Path.Combine(strAppPath, "Resources");
                string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                VerificarTransaccionesActivas(con);

                string query = "UPDATE Opiniones SET Opinion=@Opinion WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)";
                comando = new SQLiteCommand(query, con);

                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.Parameters.AddWithValue("@Opinion", opinion);

                comando.ExecuteNonQuery();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                con.Close();
            }

        }


        public void MostrarOpinion(ComboBox c)
        {
            string mostrar;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");

            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand("SELECT * FROM Opiniones", con);
            c.Items.Clear();
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    mostrar = "Id usuario: " + lector["IdUsuario"].ToString() + ", " + lector["Opinion"].ToString();
                    c.Items.Add(mostrar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            con.Close();
        }

        public void MostrarOpinionPorObras(ComboBox c, string IdObra)
        {
            string mostrar;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }


            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand("SELECT * FROM Opiniones WHERE IdObra=@IdObra", con);
            comando.Parameters.AddWithValue("@IdObra", IdObra);

            c.Items.Clear();
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    mostrar = "Id usuario:" + lector["IdUsuario"].ToString() + ", " + lector["Opinion"].ToString();
                    c.Items.Add(mostrar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            con.Close();
        } 

        public int BuscarOpiniones(string IdObra, int IdUsuario)
        {

            int cant = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+"; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT COUNT(*) FROM Opiniones WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)", con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                cant = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception e)
            {
                cant = 0;
                MessageBox.Show(e.Message);
            }

            con.Close();
            return cant;
        }

        public string ObtOpinion(string IdObra, int IdUsuario)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string opi = "";
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT * FROM Opiniones WHERE (IdUsuario=@IdUsuario) AND (IdObra=@IdObra)", con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                lector = comando.ExecuteReader();

                opi = lector["Opinion"].ToString();

                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            con.Close();
            //lector.Close();
            return opi;
        }

        /// <summary>
        /// Metodos para la tabla de Opiniones de la app
        /// </summary>


        public void NuevoOpinionApp(string IdObra, int ContLikes, int contDisl)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            string query = "INSERT INTO Opiniones_App (IdObra, ContLikes, ContDislikes) VALUES (@IdObra, @ContLikes, @contDisl)";

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand(query, con);

            comando.Parameters.AddWithValue("@IdObra", IdObra);
            comando.Parameters.AddWithValue("@ContLikes", ContLikes);
            comando.Parameters.AddWithValue("@contDisl", contDisl);

            comando.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarOpinionApp(string IdObra)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            string query = "DELETE FROM Opiniones_App WHERE IdObra=@IdObra";
            comando = new SQLiteCommand(query, con);
            comando.Parameters.AddWithValue("@IdObra", IdObra);

            comando.ExecuteNonQuery();
            con.Close();
        }



        public void ActualizarOpinionApp(string IdObra, int ContLikes, int contDisl)
        {
            try
            {
                if ((ContLikes != 0) && (contDisl == 0))
                {
                    string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    string strFilePath = Path.Combine(strAppPath, "Resources");
                    string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                    con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();

                    VerificarTransaccionesActivas(con);

                    string query = "UPDATE Opiniones_App SET ContLikes=@ContLikes WHERE IdObra=@IdObra";
                    comando = new SQLiteCommand(query, con);

                    comando.Parameters.AddWithValue("@IdObra", IdObra);
                    comando.Parameters.AddWithValue("@ContLikes", ContLikes);

                    comando.ExecuteNonQuery();
                    con.Close();
                }
                else if ((ContLikes == 0) && (contDisl != 0))
                {
                    string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    string strFilePath = Path.Combine(strAppPath, "Resources");
                    string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                    con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();

                    VerificarTransaccionesActivas(con);

                    string query = "UPDATE Opiniones_App SET ContDislikes=@contDisl WHERE IdObra=@IdObra";
                    comando = new SQLiteCommand(query, con);

                    comando.Parameters.AddWithValue("@IdObra", IdObra);
                    comando.Parameters.AddWithValue("@contDisl", contDisl);

                    comando.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    string strFilePath = Path.Combine(strAppPath, "Resources");
                    string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
                    con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();

                    VerificarTransaccionesActivas(con);

                    string query = "UPDATE Opiniones_App SET ContLikes=@ContLikes WHERE IdObra=@IdObra";
                    comando = new SQLiteCommand(query, con);

                    comando.Parameters.AddWithValue("@IdObra", IdObra);
                    comando.Parameters.AddWithValue("@ContLikes", ContLikes);
                    comando.Parameters.AddWithValue("@contDisl", contDisl);

                    comando.ExecuteNonQuery();

                    query = "UPDATE Opiniones_App SET ContDislikes=@ContLikes WHERE IdObra=@IdObra";
                    comando = new SQLiteCommand(query, con);

                    comando.Parameters.AddWithValue("@IdObra", IdObra);
                    comando.Parameters.AddWithValue("@ContLikes", ContLikes);
                    comando.Parameters.AddWithValue("@contDisl", contDisl);
                    comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
                
            
        }

        public void MostrarOpinionApp(ComboBox c)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            comando = new SQLiteCommand("SELECT * FROM Opiniones_App", con);
            c.Items.Clear();
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string opApp = "Id Obra: " + lector["IdObra"].ToString() + "Likes: " + lector["ContLikes"].ToString() + "Dislikes: " + lector["ContDislikes"].ToString();

                    c.Items.Add(opApp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //lector.Close();
            
        }

        public int BuscarOpinionesApp(string IdObra)
        {

            int cant = 0;
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFilename = Path.Combine(strFilePath, "Galeria.db");
            con = new SQLiteConnection("Data Source = "+strFullFilename+" ; Version = 3;New = False; Mode=ReadWriteCreate;");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            VerificarTransaccionesActivas(con);

            try
            {
                comando = new SQLiteCommand("SELECT COUNT(*) FROM Opiniones_App WHERE IdObra=@IdObra", con);
                comando.Parameters.AddWithValue("@IdObra", IdObra);

                cant = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception e)
            {
                cant = 0;
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            
            //lector.Close();
            return cant;
        }

        /// <summary>
        /// Metodo que verifica si existen transacciones abiertas y dependiendo si esta posee errores o no hara un commit o rollback para guaradar o deshacer respectivamente
        /// </summary>


        public void VerificarTransaccionesActivas(SQLiteConnection con)
        {
            // Verificar si hay transacciones activas en la base de datos
            using (var comando = new SQLiteCommand("SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'sqlite_locks'", con))
            {
                int cantidadTransacciones = Convert.ToInt32(comando.ExecuteScalar());

                if (cantidadTransacciones > 0)
                {
                    // Hay transacciones activas, confirmar o deshacer las transacciones pendientes
                    using (var transaccion = con.BeginTransaction())
                    {
                        try
                        {
                            // Realizar cualquier operación adicional necesaria dentro de la transacción
                            // Confirmar la transacción para liberar los bloqueos
                            transaccion.Commit();
                        }
                        catch
                        {
                            // Deshacer la transacción en caso de excepción
                            transaccion.Rollback();
                            throw; // Puedes manejar la excepción o propagarla hacia arriba
                        }
                    }
                }
               
                
            }
        }
    }
   }
