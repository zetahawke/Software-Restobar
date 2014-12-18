﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioCategorias
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

        public NegocioCategorias()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Cate";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarCategoria(Cate cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Cate + ",'" +
                cli._nombre +  "')";
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

        public Cate buscarCategoria(int idCliente)
        {

            Cate cli = new Cate();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Cate = " + idCliente ;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Cate = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Cate = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Cate buscarCategoriaString(string idCliente)
        {

            Cate cli = new Cate();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombre = '" + idCliente + "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Cate = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Cate = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarCategoria(Cate cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Cate=" + cli._ID_Cate + "," +
                        "nombre='" + cli._nombre + "'" +
                        " where ID_Cate=" + cli._ID_Cate;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCategoria(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Cate=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
