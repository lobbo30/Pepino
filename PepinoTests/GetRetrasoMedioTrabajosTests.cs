using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetRetrasoMedioTrabajosTests
    {
        [TestMethod]
        public void GetRetrasoMedioTrabajos()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6, JobDelayTime = 0 },
                new Job() { Nombre = "B", ProcessTime = 2, JobDelayTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8, JobDelayTime = 0 },
                new Job() { Nombre = "D", ProcessTime = 3, JobDelayTime = 4 },
                new Job() { Nombre = "E", ProcessTime = 9, JobDelayTime = 5 }
            };

            float resultado = JobTimeCalculator.GetRetrasoMedioTrabajos(secuenciaTrabajos);

            Assert.AreEqual(2.2f, resultado);
        }

        [TestMethod]
        public void GetRetrasoMedioTrabajos_WhenArgumentIsDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6, JobDelayTime = 1 },
                new Job() { Nombre = "B", ProcessTime = 2, JobDelayTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8, JobDelayTime = 3 },
                new Job() { Nombre = "D", ProcessTime = 3, JobDelayTime = 4 }
            };

            float resultado = JobTimeCalculator.GetRetrasoMedioTrabajos(secuenciaTrabajos);

            Assert.AreEqual(2.5f, resultado);
        }
    }
}
