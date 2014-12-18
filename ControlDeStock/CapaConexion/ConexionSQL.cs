using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaConexion
{
    public class ConexionSQL
    {
        private SqlConnection cnn;
        private SqlDataAdapter dta;
        private SqlCommand comandoSql;
        private System.Data.DataSet dts;

        private string nombreBaseDatos;
        private string nombreTabla;
        private string sentenciaSQL;
        private string cadenaConexion;
        private string user;
        private string password;
        private bool esSelect;

        public ConexionSQL()
        {
            nombreBaseDatos = "";
            nombreTabla = "";
            sentenciaSQL = "";
            cadenaConexion = "";
            user = "";
            password = "";
            esSelect = false;
        }

        public string _nombreBaseDatos
        {
            get { return nombreBaseDatos; }
            set { nombreBaseDatos = value; }
        }

        public string _nombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }

        public string _cadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        public string _user
        {
            get { return user; }
            set { user = value; }
        }

        public string _password
        {
            get { return password; }
            set { password = value; }
        }

        public string _sentenciaSQL
        {
            get { return sentenciaSQL; }
            set { sentenciaSQL = value; }
        }

        public bool _esSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }
        public SqlConnection _dbConnection
        {
            get { return cnn; }
            set { cnn = value; }
        }

        public System.Data.DataSet _dbDataSet
        {
            get { return dts; }
            set { dts = value; }
        }

        public SqlDataAdapter _dbDataAdapter
        {
            get { return dta; }
            set { dta = value; }
        }

        //Metodo para Abrir la Conexión
        public void abrirConexion()
        {
            try
            {
                this._dbConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al Abrir la Conexión: " + e.Message,
                    "Error de Conexión", MessageBoxButtons.OK);
            }
        }
        //Metodo para Cerrar la Conexión
        public void cerrarConexion()
        {
            try
            {
                this._dbConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al Cerrar la Conexión: " + e.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        //Metodo principal para la conexión
        public void conectar()
        {
            try
            {
                //Crear la Conexión
                this._dbConnection = new SqlConnection(this._cadenaConexion);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear la Conexión: " + e.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            //Abrir la Conexión
            this.abrirConexion();

            //Verificar si es un QUERY o un UPDATE
            if (_esSelect == true)
            {
                //Ejecutar un QUERY
                //Crear un DataSet y un DataAdapter
                this._dbDataSet = new System.Data.DataSet();
                try
                {
                    //Crear DataAdapter
                    this._dbDataAdapter = new SqlDataAdapter(this._sentenciaSQL,
                        this._dbConnection);
                    //Llenar el DataSet
                    this._dbDataAdapter.Fill(this._dbDataSet, this._nombreTabla);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al crear la Consulta: " + e.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                try
                {
                    //Ejecutar un UPDATE
                    this.comandoSql = new SqlCommand(this._sentenciaSQL,
                        this._dbConnection);
                    this.comandoSql.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al ejecutar una Actualización: " + e.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }

            }
        }
    }
}
