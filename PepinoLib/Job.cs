using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepinoLib
{
    public class Job
    {
        public string Nombre { get; set; }
        /// <summary>
        /// Tiempo de realización (proceso) del trabajo.
        /// </summary>
        public int ProcessTime { get; set; }
        //public int FechaEntregaSolicitada { get; set; }
        ///// <summary>
        ///// Retraso del trabajo.
        ///// </summary>
        //public int JobDelayTime { get; set; }
    }
}
