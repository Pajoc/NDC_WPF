using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gest.Model
{
    public class LookupItem
    {

        public Guid Id { get; set; }

        public string DisplayMember { get; set; }
    }

    public class NullLookupItem : LookupItem
    {
        public new Guid? Id { get { return null; } }
    }
}
