using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class Vehiculo
    {
        public bool Listar() {
            bool res = false;
            return res;
        }
        public bool Crear(Entidades.Vehiculo data)
        {
            bool res = false;
            string q = "INSERT Vehiculo ( Placa, Dueno, Marca) VALUES ('" + data.Placa + " ', ' " + data.Dueno + "', ' " + data.Marca + " ')";
            AccesoDatos.Class1 cc = new AccesoDatos.Class1();
            res = cc.hacerHit(q);
            return res;
        }
        public bool Editar()
        {
            bool res = false;
            return res;
        }
        public bool Eliminar()
        {
             
            bool res = false;
            return res;
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
