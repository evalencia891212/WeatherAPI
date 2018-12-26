using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using ASISCOM.Entities;
using ASISCOM.Data;
using System.Data;


namespace ASISCOM.Business
{
    public class BPersona
    {
        EPersona EPersona = new EPersona();
        public List<EPersona> BuscarClientes()
        {
            return new DPersona().BuscarPersonas();
        }

        public DataTable ObtenerCarteraGeneral()
        {
            return new DPersona().ObtenerCarteraGeneral();
        }

        public DataTable ObtenerUltimosAbonos()
        {
            return new DPersona().ObtenerUltimosAbonos();
        }
    }
}
