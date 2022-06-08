using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.BD;


namespace OnBreak.BC
{
    public class ActividadEmpresa
    {
        #region Propiedades
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructor
        public ActividadEmpresa()
        {
            this.Init();

        }

        private void Init()
        {
            IdActividadEmpresa = 0;
            Descripcion = string.Empty;
        }
        #endregion

        #region Customer
        public List<ActividadEmpresa> ReadAll()
        {
            //Crear una conexión al Entities
            BD.OnBreakEntities bd = new BD.OnBreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.ActividadEmpresa> listaDatos = bd.ActividadEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<ActividadEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ActividadEmpresa>();
            }
        }

        private List<ActividadEmpresa> GenerarListado(List<BD.ActividadEmpresa> listaDatos)
        {
            List<ActividadEmpresa> listaNegocio = new List<ActividadEmpresa>();
            foreach (BD.ActividadEmpresa datos in listaDatos)
            {
                ActividadEmpresa negocio = new ActividadEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
        #endregion
    }
}
