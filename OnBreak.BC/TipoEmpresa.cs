using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.BD;

namespace OnBreak.BC
{
     public class TipoEmpresa
    {
        #region Propiedades
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructor
        public TipoEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoEmpresa = 0;
            Descripcion = string.Empty;
        }

        #endregion

        #region Customer
        public List<TipoEmpresa> ReadAll()
        {
            //Crear una conexión al Entities
            BD.OnBreakEntities bd = new BD.OnBreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.TipoEmpresa> listaDatos = bd.TipoEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<TipoEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoEmpresa>();
            }
        }

        private List<TipoEmpresa> GenerarListado(List<BD.TipoEmpresa> listaDatos)
        {
            List<TipoEmpresa> listaNegocio = new List<TipoEmpresa>();
            foreach (BD.TipoEmpresa datos in listaDatos)
            {
                TipoEmpresa negocio = new TipoEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
        #endregion
    }
}
