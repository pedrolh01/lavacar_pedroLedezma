using System;
using System.Data; 
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Class1
    {
        string cadena = "Data Source=DESKTOP-FOJSS3J;Initial Catalog=carw;Integrated Security=true;";
        public SqlConnection conectar = new SqlConnection();

        public Class1()
        {
            conectar.ConnectionString = cadena;
        }


        public bool abrir()
        {
            bool re = false;
            try
            {
                this.conectar.Open();
                re = true;
            }
            catch (Exception)
            {
                re = false;
            }
            return re;
        }
        public bool cerrar()
        {
            bool re = false;
            try
            {
                this.conectar.Close();
                re = true;
            }
            catch (Exception)
            {
                re = false;
            }
            return re;
        }

        public DataTable hacerSelect(string _query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(_query, conectar);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                if (conectar.State != ConnectionState.Open)
                {
                    this.abrir();
                } 
                dt.Load(cmd.ExecuteReader());
                this.cerrar();
            }
            catch (Exception)
            {

            }
            return dt;
        }
         
        public bool hacerHit(string _query)
        {
            bool res = false;
            try
            {
                SqlCommand cmd = new SqlCommand(_query, conectar);

                if (conectar.State != ConnectionState.Open)
                {
                    this.abrir();
                }
                cmd.ExecuteNonQuery();
                this.cerrar();
                res = true; 
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
    }
}
