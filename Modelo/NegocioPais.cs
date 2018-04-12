using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAO;
using DAO.ADO;
using Entidad.Common;
using System.ServiceModel;
using ViewModel.Catalogo._Pais;
using Tools;

namespace Modelo
{
    public class NegocioPais
    {
        public List<VMPais> ObtenerCatalogoPaises()
        {
            try
            {
                IDAOPais iDaoPais =new DAOPais();
                RespuestaBD resp = iDaoPais.ObtenerCatalogoPais(true);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMPais> lista = new List<VMPais>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMPais()
                                 {
                                     Activo = x.Field<bool>("fl_activo"),
                                     IdPais = x.Field<int>("fi_id_pais"),
                                     Nombre = x.Field<string>("fc_pais"),                                     
                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }
    }
}
