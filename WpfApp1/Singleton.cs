using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class Singleton
    {
        public static readonly uchetEntities DB = new uchetEntities();
    }
}
