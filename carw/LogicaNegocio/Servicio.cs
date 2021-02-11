using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class Servicio
    {
        public bool Crear(Entidades.Servicios data)
        {
            bool res = false; 
            string q = "INSERT Servicios ( Descripcion, Monto) VALUES ( ' " + data.Descripcion + "',  " + data.Monto + " )";
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            res = cc.hacerHit(q);
            return res;
        }
        public Entidades.Servicios[] getAll()
        {
            DataTable dt = new DataTable();
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            int cantidad = 0;
            Entidades.Servicios[] array = null;
            if (cc.abrir())
            {
                string query = "select ID_Servicio,Descripcion from Servicios";
                dt = cc.hacerSelect(query);
                cantidad = dt.Rows.Count;
                if (cantidad > 0)
                {
                    array = new Entidades.Servicios[cantidad];
                    for (int i = 0; i < cantidad; i++)
                    {
                        Entidades.Servicios obj = new Entidades.Servicios();
                        obj.ID_Servicio = Int32.Parse(dt.Rows[i]["ID_Servicio"].ToString());
                        obj.Descripcion = dt.Rows[i]["Descripcion"].ToString();
                        array[i] = obj;
                    }
                }
            }
            return array;
        }
    }
}
