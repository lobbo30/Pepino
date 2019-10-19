using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetUtilizacionTests
    {
        [TestMethod]
        public void GetUtilizacion()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            float resultado = JobTimeCalculator.GetUtilizacion(secuenciaTrabajos);

            Assert.AreEqual(0.364f, resultado, 0.001f);
        }

        [TestMethod]
        public void GetUtilizacion_WhenArgumentIsDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            float resultado = JobTimeCalculator.GetUtilizacion(secuenciaTrabajos);

            Assert.AreEqual(0.3802f, resultado, 0.0001f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUtilizacion_WhenArgumentIsNull()
        {
            float resultado = JobTimeCalculator.GetUtilizacion(null);
        }
    }
}
