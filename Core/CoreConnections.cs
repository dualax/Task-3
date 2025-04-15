using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp3.Core
{
    public static class CoreConnections
    {
        public static Frame CoreFrame { get; set; }
        public static TaskTwoDBEntities DB {  get; set; }
    }
}
