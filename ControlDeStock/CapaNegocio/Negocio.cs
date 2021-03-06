﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion;
using CapaDatos;

namespace CapaNegocio
{
    public class Negocio
    {
         private ConexionSQL cnn;

        public Negocio()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Cate";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Mauricio\\documents\\visual studio 2010\\Projects\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";

        }

        public void insertarCategoria(Cate categoria)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                categoria._ID_Cate + ",'" +
                categoria._nombre + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getCate()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cate ca = new Cate();
                ca._ID_Cate = int.Parse(dr["ID_Cate"].ToString());
                ca._nombre = (string)dr["nombre"];
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Cate buscarCategoria(string NombreCategoria)
        {

            Cate categoria = new Cate();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombre = '" + NombreCategoria+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                categoria._ID_Cate = int.Parse(dt.Rows[0][0].ToString());
                categoria._nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                categoria._ID_Cate = 0;
            }
            this.cnn.cerrarConexion();
            return categoria;
        }

        public void modificarCategoria(Cate categoria)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Cate='" + categoria._ID_Cate + "'," +
                        "nombre='" + categoria._nombre + "'," +
                        " where ID_Cate=" + categoria._ID_Cate;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCategoria(int idCategoria)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Cate=" + idCategoria;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
