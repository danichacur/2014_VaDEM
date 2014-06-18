using System;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Componentes_Comunes
{
    public class Paginar
    {

        private int _inicio = 0;
        private int _tope = 0;

        private int _numeroPagina = 1;
        private int _cantidadRegistros = 0;
        private int _ultimaPagina = 0;
        private DataTable lis;
        private DataTable _datos;

        public Paginar(Object lista, int i_cantidadxpagina)
        {
            this._inicio = 0;
            this._tope = i_cantidadxpagina;
            
            
            try
            {
                lis = (DataTable)lista;
                this._datos = lis.Clone();
               
                DataTable auxiliar;

                auxiliar = new DataTable();


                for (int i = this._inicio; i < this._tope && i<lis.Rows.Count; i++)
                {
                                  
                    _datos.ImportRow(lis.Rows[i]);
                   // _datos.Rows[i].ItemArray = lis.Rows[i].ItemArray;
                }

                this._cantidadRegistros = ((DataTable)lista).Rows.Count;

                asignarTope();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void asignarTope()
        {
            _ultimaPagina = _cantidadRegistros / _tope;


            int aux = _cantidadRegistros % _tope ;  
            if (_ultimaPagina == 0)
            {
                this._ultimaPagina = 1;
            }
            else if (_ultimaPagina >= 1 && (aux > 0))
            {
                this._ultimaPagina = _ultimaPagina + 1;
            }

            this._numeroPagina = 1;
        }

        public DataTable cargar()
        {
            return _datos;
        }

        public DataTable primeraPagina()
        {
            this._numeroPagina=1;
            this._inicio = 0;
            this._datos.Clear();
            for (int i = this._inicio; i < this._inicio + this._tope; i++)
            {
                _datos.ImportRow(lis.Rows[i]);
            }
            return _datos;
        }

        public DataTable ultimaPagina() 
        {
            this._numeroPagina = _ultimaPagina;
            this._inicio = (_ultimaPagina-1 ) * _tope;
            this._datos.Clear();
            for (int i = this._inicio; (i < this._inicio + this._tope) && (i<lis.Rows.Count) ; i++)
            {
                _datos.ImportRow(lis.Rows[i]);
            }
            return _datos;
        }

        public DataTable atras()
        {
            if (this._numeroPagina == 1)
            {
                return _datos;
            }

            this._numeroPagina--;
            this._inicio = _inicio - _tope;
            this._datos.Clear();
            for (int i = this._inicio; i < this._inicio + this._tope && i< lis.Rows.Count; i++)
            {
                _datos.ImportRow(lis.Rows[i]);
            }
            return _datos;
        }

        public DataTable adelante()
        {
            if (this._ultimaPagina == this._numeroPagina)
            {
                return _datos;
            }

            this._numeroPagina++;
            this._inicio = _inicio + _tope;
            this._datos.Clear();
            for (int i = this._inicio; i < this._inicio+ this._tope && i<lis.Rows.Count; i++)
            {
                _datos.ImportRow(lis.Rows[i]);
            }
            return _datos;
        }

        public DataTable actualizaTope(int i_tope)
        {
            this._tope = i_tope;
            this._inicio = 0;
            asignarTope();

            _datos.Clear();
            for (int i = this._inicio; i < this._tope; i++)
            {
                _datos.ImportRow(lis.Rows[i]);
            } 
            return _datos;
        }



        public int countRow()
        {
            return _cantidadRegistros;
        }

        public int countPag()
        {
            return _ultimaPagina;
        }

        public int numPag()
        {
            return _numeroPagina;
        }

        public int limitRow()
        {
            return _tope;
        }


    }
}
