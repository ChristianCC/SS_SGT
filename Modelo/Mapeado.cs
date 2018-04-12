using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


namespace Modelo
{
    public class Mapeado
    {
        public void Inicializar()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                
                //cfg.CreateMap<VMGridProyectoGet, Grid>();
                //cfg.CreateMap<Proyecto, VMListProyecto>();
                //cfg.CreateMap<VWProyecto, Proyecto>();
                //cfg.CreateMap<Proyecto, VWProyecto>()
                //    .ForMember(x => x.ListSubProyecto, x => x.MapFrom(y => y.listSubproyecto));
                
            });
        }
    }
}
