using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetNumeroMedioTrabajosSistemaTests
    {
        [TestMethod]
        public void GetNumeroMedioTrabajosSistema()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            float resultado = JobTimeCalculator.GetNumeroMedioTrabajosSistema(secuenciaTrabajos);

            Assert.AreEqual(2.75f, resultado, 0.01f);
        }

        [TestMethod]
        public void GetNumeroMedioTrabajosSistema_WhenArgumentIsDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            float resultado = JobTimeCalculator.GetNumeroMedioTrabajosSistema(secuenciaTrabajos);

            Assert.AreEqual(2.63f, resultado, 0.01f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNumeroMedioTrabajosSistema_WhenArgumentIsNull()
        {
            float resultado = JobTimeCalculator.GetNumeroMedioTrabajosSistema(null);
        }
    }
}
