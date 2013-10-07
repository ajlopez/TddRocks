
namespace Consorcios.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ConsorcioRepository
    {
        private int maxid = 0;
        private IList<Consorcio> consorcios = new List<Consorcio>();

        public IList<Consorcio> GetList()
        {
            return this.consorcios;
        }

        public void Add(Consorcio consorcio)
        {
            consorcio.Id = ++maxid;
            this.consorcios.Add(consorcio);
        }
    }
}
