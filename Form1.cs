using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            //AGREGAR
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                //var nombre = "prueba addTransaction";
                //var descripcion = "descripcion";

                //var query = @"select * from Areas where idArea = @idArea";

                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();


                    var transaction = sql.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("stp_areas_add", sql, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@idArea", idArea));
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Desarrollo 2"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@descripcion", "Area de desarrollo de TI"));
                        cmd.ExecuteNonQuery();
                        //DataTable dt = new DataTable();
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //sql.Open();

                        //da.Fill(dt);
                        //dataGridView1.DataSource = dt;
                        //SqlDataReader lector;
                        //lector = cmd.ExecuteReader();
                    }
                    throw new ApplicationException("Ooops Error"); //Proboca el error en la transaccion


                    using (SqlCommand cmd = new SqlCommand("stp_areas_add", sql, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@idArea", idArea));
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Laboratorio de redes"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@descripcion", "Laboratorio de la Uni"));
                        cmd.ExecuteNonQuery();
                        //DataTable dt = new DataTable();
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //sql.Open();

                        //da.Fill(dt);
                        //dataGridView1.DataSource = dt;
                        //SqlDataReader lector;
                        //lector = cmd.ExecuteReader();
                    }
                    transaction.Commit();

                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            Console.Read();

            */
            /*
            
            
                        //ACTUALIZAR
                        try
                        {
                            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                            //var nombre = "prueba addTransaction";
                            //var descripcion = "descripcion";

                            //var query = @"select * from Areas where idArea = @idArea";

                            using (SqlConnection sql = new SqlConnection(connectionString))
                            {
                                sql.Open();

                                var transaction = sql.BeginTransaction();
                                using (SqlCommand cmd = new SqlCommand("stp_areas_update", sql, transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@idArea", 17));
                                    cmd.Parameters.Add(new SqlParameter("@nombre", "Baños"));//evitar la vunerabilidad sql injection vidio 5
                                    cmd.Parameters.Add(new SqlParameter("@descripcion", "Baños del edificio"));
                                    cmd.ExecuteNonQuery();
                                    //DataTable dt = new DataTable();
                                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    //sql.Open();

                                    //da.Fill(dt);
                                    //dataGridView1.DataSource = dt;
                                    //SqlDataReader lector;
                                    //lector = cmd.ExecuteReader();
                                }
                                //throw new ApplicationException("Ooops Error");


                                using (SqlCommand cmd = new SqlCommand("stp_areas_update", sql, transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@idArea", 16));
                                    cmd.Parameters.Add(new SqlParameter("@nombre", "Consultorio"));//evitar la vunerabilidad sql injection vidio 5
                                    cmd.Parameters.Add(new SqlParameter("@descripcion", "Consultas"));
                                    cmd.ExecuteNonQuery();
                                    //DataTable dt = new DataTable();
                                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    //sql.Open();

                                    //da.Fill(dt);
                                    //dataGridView1.DataSource = dt;
                                    //SqlDataReader lector;
                                    //lector = cmd.ExecuteReader();
                                }
                                transaction.Commit();

                            }
                        }
                        catch (ApplicationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }



                        Console.Read();
            
            


            */
            //AGREGAR SOCIOS
           /* try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    var transaction = sql.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand("stp_socios_add", sql, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Prueba"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@apellido", "Montalvo"));
                        cmd.Parameters.Add(new SqlParameter("@edad", 18)); //Generamos una edad aleatoria
                        cmd.Parameters.Add(new SqlParameter("@direccion", "Leon, Guanajuato"));
                        cmd.Parameters.Add(new SqlParameter("@idSucursal", 2));
                        cmd.ExecuteNonQuery();
                    }
                    //throw new ApplicationException("Ooops Error");

                    using (SqlCommand cmd = new SqlCommand("stp_socios_add", sql, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Prueba1"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@apellido", "Montalvo"));
                        cmd.Parameters.Add(new SqlParameter("@edad", 18)); //Generamos una edad aleatoria
                        cmd.Parameters.Add(new SqlParameter("@direccion", "Leon, Guanajuato"));
                        cmd.Parameters.Add(new SqlParameter("@idSucursal", 3));
                        cmd.ExecuteNonQuery();
                    }
                        transaction.Commit();
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();*/




















            /*TRIGGERS*/
            /*Trigger 1 - Sucursal*//*
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();

                    using (SqlCommand cmd = new SqlCommand("stp_sucursales_add", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Jair"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@direccion", "Purisima Del Rincon"));
                        cmd.Parameters.Add(new SqlParameter("@telefono", "4776512345"));
                        cmd.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();




            /*Trigger 2 - Area*//*
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();

                    using (SqlCommand cmd = new SqlCommand("stp_areas_add", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                      
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Willy Nuevo"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@descripcion", "Willy Nuevo"));
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();

            */

            /*Trigger 3 - Socios*//*
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();

                    using (SqlCommand cmd = new SqlCommand("stp_socios_add", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", "Jair"));//evitar la vunerabilidad sql injection vidio 5
                        cmd.Parameters.Add(new SqlParameter("@apellido", "Montalvo"));
                        cmd.Parameters.Add(new SqlParameter("@edad", 18)); //Generamos una edad aleatoria
                        cmd.Parameters.Add(new SqlParameter("@direccion", "Leon, Guanajuato"));
                        cmd.Parameters.Add(new SqlParameter("@idSucursal", 2));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();*/

        }



    }
}
