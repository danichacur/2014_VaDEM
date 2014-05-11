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
        private const String NombreModulo = "BaseDatos";

        private String mConnectionString;
        private SqlConnection mSqlCnn;
        private SqlTransaction mSqlTran;

        private static AccesoDatos _instance;
        //static readonly AccesoDatos _instance = new AccesoDatos();
        public static AccesoDatos Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccesoDatos();
                return _instance;
            }
        }
        AccesoDatos()
        {

            
            //String cstr = ConfigurationManager.ConnectionStrings["FrbaCommerce.Properties.Settings.conexionBD"].ToString();
            String cstr = ConfigurationManager.AppSettings["conexionBD"];
            mConnectionString = cstr;
            mSqlCnn = new SqlConnection(mConnectionString);

        }


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
            catch (Exception ex)
            {
                throw new Exception(NombreModulo + ".EjecutarScript " + ex.Source + " " + ex.Message, ex);
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

    }
}

        /*
        public DataTable ObtenerDatosComoDataTable(String NombreProcedimientoAlmacenado)
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

                sqlCmd.CommandText = NombreProcedimientoAlmacenado;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception ex)
            {
                throw new Exception(NombreModulo + ".ObtenerDatosComoDataTable " + ex.Source + " " + ex.Message, ex);
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

        public DataTable ObtenerDatosComoDataTable(String NombreProcedimientoAlmacenado, SqlParameter[] Parametros)
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

                sqlCmd.CommandText = NombreProcedimientoAlmacenado;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddRange(Parametros);

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception ex)
            {
                throw new Exception(NombreModulo + ".ObtenerDatosComoDataTable " + ex.Source + " " + ex.Message, ex);
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

    }
    
    public static class Datos
    {
        Const NombreModulo = "BaseDatos";

        private String mConnectionString;
        private SqlConnection mSqlCnn;
        private SqlTransaction mSqlTran;

        public Datos(String ConnectionString)
        {
            try
            {
                mConnectionString = ConnectionString;
                mSqlCnn = new SqlConnection(mConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(NombreModulo & ".Datos " & ex.Source & " " & ex.Message, ex);
            }            
        }

        public DataTable ObtenerDatosComoDataTable(String NombreProcedimientoAlmacenado)
        {
            SqlCommand sqlCmd;
            SqlDataAdapter sqlAdp;
            DataTable sqlTbl;
            sqlCmd = new SqlCommand();
            sqlAdp = new SqlDataAdapter(sqlCmd);

            try{
                if (this.mSqlCnn != null){
                    this.mSqlCnn.Open();
                }

                sqlCmd.CommandText = NombreProcedimientoAlmacenado;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception ex){
                throw new Exception(NombreModulo & ".ObtenerDatosComoDataTable " & ex.Source & " " & ex.Message, ex);
            }
            finally{
                if(this.mSqlCnn != null && this.mSqlCnn.State == ConnectionState.Open){
                    this.mSqlCnn.Close();
                }
                    
                if (sqlCmd != null){
                    sqlCmd.Dispose();
                }
                
                if (sqlAdp != null){
                    sqlAdp.Dispose();
                }
            }
        }

        public DataTable ObtenerDatosComoDataTable(String NombreProcedimientoAlmacenado, SqlParameter[] Parametros)
        {
            SqlCommand sqlCmd;
            SqlDataAdapter sqlAdp;
            DataTable sqlTbl;
            sqlCmd = new SqlCommand();
            sqlAdp = new SqlDataAdapter(sqlCmd);

            try{
                if (this.mSqlCnn != null){
                    this.mSqlCnn.Open();
                }

                sqlCmd.CommandText = NombreProcedimientoAlmacenado;
                sqlCmd.Connection = this.mSqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddRange(Parametros);

                sqlTbl = new DataTable();
                sqlAdp.Fill(sqlTbl);

                return sqlTbl;
            }
            catch (Exception ex){
                throw new Exception(NombreModulo & ".ObtenerDatosComoDataTable " & ex.Source & " " & ex.Message, ex);
            }
            finally{
                if(this.mSqlCnn != null && this.mSqlCnn.State == ConnectionState.Open){
                    this.mSqlCnn.Close();
                }
                    
                if (sqlCmd != null){
                    sqlCmd.Dispose();
                }
                
                if (sqlAdp != null){
                    sqlAdp.Dispose();
                }
            }
        }

        

      
    }*/
