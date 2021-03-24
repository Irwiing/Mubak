using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public int installments { get; set; }
    }
}
