using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PepinoLib;

namespace PepinoTests
{
    [TestClass]
    public class GetTotalFlowTimeTests
    {
        [TestMethod]
        public void GetTotalFlowTime()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 6 },
                new Job() { Nombre = "B", ProcessTime = 2 },
                new Job() { Nombre = "C", ProcessTime = 8 },
                new Job() { Nombre = "D", ProcessTime = 3 },
                new Job() { Nombre = "E", ProcessTime = 9 }
            };

            int resultado = JobTimeCalculator.GetTotalFlowTime(secuenciaTrabajos);

            Assert.AreEqual(77, resultado);
        }

        [TestMethod]
        public void GetTotalFlowTime_WhenArgumentsAreDifferent()
        {
            List<Job> secuenciaTrabajos = new List<Job>()
            {
                new Job() { Nombre = "A", ProcessTime = 4 },
                new Job() { Nombre = "B", ProcessTime = 1 },
                new Job() { Nombre = "C", ProcessTime = 9 },
                new Job() { Nombre = "D", ProcessTime = 7 },
                new Job() { Nombre = "E", ProcessTime = 6 }
            };

            int resultado = JobTimeCalculator.GetTotalFlowTime(secuenciaTrabajos);

            Assert.AreEqual(71, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTotalFlowTime_WhenArgumentIsNull()
        {
            int resultado = JobTimeCalculator.GetTotalFlowTime(null);
        }
    }

    
}
