using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class VehiculoServicio
    {
        public bool Crear(Entidades.VehiculoServicio data)
        {
            bool res = false;
            string q = "INSERT [Vehiculo-Servicio] ( ID_Servicio, ID_Vehiculo) VALUES ( ' " + data.ID_Servicio + "',  " + data.ID_Vehiculo + " )";
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            if (cc.abrir())
            {
                res = cc.hacerHit(q);
            }
            return res;
        }
        public Entidades.VehiculoServicio[] Reporte(int action) {//Entidades.Servicios data
           
            DataTable dt = new DataTable();
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            int cantidad = 0;
            Entidades.VehiculoServicio[] array = null;
            if (cc.abrir())
            {
                string query = "select s.Descripcion as ServicioName,v.Placa as VehiculoName from[Vehiculo-Servicio] vs " +
                " inner join Vehiculo v on vs.ID_Vehiculo = v.ID_Vehiculo " +
                " inner join Servicios s on s.ID_Servicio = vs.ID_Servicio " +
                " where s.ID_Servicio = " + action + ";";
                dt = cc.hacerSelect(query);
                cantidad = dt.Rows.Count;
                if (cantidad > 0)
                {
                    array = new Entidades.VehiculoServicio[cantidad];
                    for (int i = 0; i < cantidad; i++)
                    {
                        Entidades.VehiculoServicio obj = new Entidades.VehiculoServicio();
                        obj.ServicioName = dt.Rows[i]["ServicioName"].ToString();
                        obj.VehiculoName = dt.Rows[i]["VehiculoName"].ToString();
                        array[i] = obj;
                    }
                }
            }
            return array;

        }

        public Entidades.Vehiculo[] getAll()
        {
            DataTable dt = new DataTable();
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            int cantidad = 0;
            Entidades.Vehiculo[] array = null;
            if (cc.abrir())
            {
                string query = "select ID_Vehiculo,Placa from Vehiculo";
                dt = cc.hacerSelect(query);
                cantidad = dt.Rows.Count;
                if (cantidad > 0)
                {
                    array = new Entidades.Vehiculo[cantidad];
                    for (int i = 0; i < cantidad; i++)
                    {
                        Entidades.Vehiculo obj = new Entidades.Vehiculo();
                        obj.ID_Vehiculo = Int32.Parse(dt.Rows[i]["ID_Vehiculo"].ToString());
                        obj.Placa = dt.Rows[i]["Placa"].ToString();
                        array[i] = obj;
                    }
                }
            }
            return array;
        }
    }
}
