using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetTotalProcessTimeTests
    {
        [TestMethod]
        public void GetTotalProcessTime()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            float resultado = JobTimeCalculator.GetTotalProcessTime(secuenciaTrabajos);

            Assert.AreEqual(28, resultado);
        }

        [TestMethod]
        public void GetTotalProcessTime_WhenArgumentsAreDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            float resultado = JobTimeCalculator.GetTotalProcessTime(secuenciaTrabajos);

            Assert.AreEqual(27, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalProcessTime_WhenArgumentIsNull()
        {
            float resultado = JobTimeCalculator.GetTotalProcessTime(null);
        }
    }
}
