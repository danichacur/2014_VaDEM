using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace FrbaCommerce.Datos
{
    public sealed class AccesoDatos
    {
        #region VariablesDeClase

        private String mConnectionString;
        private SqlConnection mSqlCnn;
        //private SqlTransaction mSqlTran;

        private static AccesoDatos _instance;
        public static AccesoDatos Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccesoDatos();
                return _instance;
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        AccesoDatos()
        {
            try
            {
                String cstr = ConfigurationManager.AppSettings["conexionBD"];
                mConnectionString = cstr;
                mSqlCnn = new SqlConnection(mConnectionString);
            }
            catch (Exception)
            {
                throw;
            }


        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Recibe un script, lo ejecuta con la conexión abierta, y devuelve el resultado en un datatable
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public DataTable EjecutarScript(String script)
        {
            SqlCommand sqlCmd;
            SqlDataAdapter sqlAdp;
            DataTable sqlTbl;
            sqlCmd = new SqlCommand();
            sqlAdp = new SqlDataAdapter(sqlCmd);

            try
            {
                if (this.mSqlCnn != null)
                {
                    this.mSqlCnn.Open();
                }

                sqlCmd.CommandText = script;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.Text;

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.mSqlCnn != null && this.mSqlCnn.State == ConnectionState.Open)
                {
                    this.mSqlCnn.Close();
                }

                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                }

                if (sqlAdp != null)
                {
                    sqlAdp.Dispose();
                }
            }
        }
		
		public DataTable EjecutarSp(String script, List<SqlParameter> colParam)
        {
            SqlCommand sqlCmd;
            SqlDataAdapter sqlAdp;
            DataTable sqlTbl;
            sqlCmd = new SqlCommand();
            sqlAdp = new SqlDataAdapter(sqlCmd);

            try
            {
                if (this.mSqlCnn != null)
                {
                    this.mSqlCnn.Open();
                }

                sqlCmd.CommandText = script;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                
                foreach (SqlParameter item in colParam)
                {
                    sqlCmd.Parameters.Add(item);    
                }
                

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.mSqlCnn != null && this.mSqlCnn.State == ConnectionState.Open)
                {
                    this.mSqlCnn.Close();
                }

                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                }

                if (sqlAdp != null)
                {
                    sqlAdp.Dispose();
                }
            }
        }

        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}

       