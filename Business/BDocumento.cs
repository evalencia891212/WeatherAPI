using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASISCOM.Business
{
    public class BDocumento
    {
        EDocumento EDocumento = new EDocumento();
        EDocumentoDetalle EDocumentoDetalle = new EDocumentoDetalle();

        public List<EDocumento> ObtenerDocumentos()
        {
            return new Ddocumento().ObtenerDocumentos();
        }

        public List<EDocumentoDetalle> ObtenerDocumentosDetalle()
        {
            return new Ddocumento().ObtenerDocumentosDetalle();
        }

    }
}
