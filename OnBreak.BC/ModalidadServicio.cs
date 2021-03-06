using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class ModalidadServicio
    {
        #region Propiedades
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }
        #endregion

        #region Constructor
        public ModalidadServicio()
        {
            this.Init();
        }

        private void Init()
        {
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            Nombre = string.Empty;
            ValorBase = 0;
            PersonalBase = 0;

        }
        #endregion

        #region Customer
        public List<ModalidadServicio> ReadAll()
        {
            //Crear una conexión al Entities
            BD.OnBreakEntities bd = new BD.OnBreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.ModalidadServicio> listaDatos = bd.ModalidadServicio.ToList();
                //Crear una lista de NEGOCIO
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        private List<ModalidadServicio> GenerarListado(List<BD.ModalidadServicio> listaDatos)
        {
            List<ModalidadServicio> listaNegocio = new List<ModalidadServicio>();
            foreach (BD.ModalidadServicio datos in listaDatos)
            {
                ModalidadServicio negocio = new ModalidadServicio();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

        public List<ModalidadServicio> ReadOnlyByTipoEvento(int idtipoevento)
        {
            BD.OnBreakEntities bd = new BD.OnBreakEntities();
            try
            {
                //Crear una lista de DATOS (esto es un select where)
                List<BD.ModalidadServicio> listaDatos = bd.ModalidadServicio.Where(e => e.IdTipoEvento == idtipoevento).ToList<BD.ModalidadServicio>();
                //Crear una lista de NEGOCIO
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        #endregion

    }
}
