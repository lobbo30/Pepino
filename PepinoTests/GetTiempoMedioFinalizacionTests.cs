using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetTiempoMedioFinalizacionTests
    {
        [TestMethod]
        public void GetTiempoMedioFinalizacion()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            float resultado = JobTimeCalculator.GetTiempoMedioFinalizacion(secuenciaTrabajos);

            Assert.AreEqual(15.4f, resultado);
        }

        [TestMethod]
        public void GetTiempoMedioFinalizacion_WhenArgumentsAreDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            float resultado = JobTimeCalculator.GetTiempoMedioFinalizacion(secuenciaTrabajos);

            Assert.AreEqual(14.2f, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTiempoMedioFinalizacion_WhenArgumentIsNull()
        {
            float resultado = JobTimeCalculator.GetTiempoMedioFinalizacion(null);
        }

        [TestMethod]
        public void GetTiempoMedioFinalizacion_WhenPriorityRuleIsSPT()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            float resultado = JobTimeCalculator.GetTiempoMedioFinalizacion(secuenciaTrabajos, PriorityRule.SPT);

            Assert.AreEqual(13f, resultado);
        }

        [TestMethod]
        public void GetTiempoMedioFinalizacion_WhenPriorityRuleIsSPTAndArgumentIsDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            float resultado = JobTimeCalculator.GetTiempoMedioFinalizacion(secuenciaTrabajos, PriorityRule.SPT);

            Assert.AreEqual(14.2f, resultado);
        }
    }
}
