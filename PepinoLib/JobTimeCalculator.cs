using System;
using System.Collections.Generic;
using System.Linq;

namespace PepinoLib
{
    public class JobTimeCalculator
    {
        public static float GetTotalProcessTime(ICollection<Job> jobSequence)
        {
            return jobSequence.Sum(j => j.ProcessTime);
        }

        public static float GetTotalFlowTime(ICollection<Job> jobSequence)
        {
            if (jobSequence == null)
            {
                throw new ArgumentNullException();
            }
            float total = 0;
            for (int i = 0; i < jobSequence.Count; i++)
            {
                total += jobSequence.Take(i + 1).Sum(j => j.ProcessTime);
            }
            return total;
        }

        public static float GetNumeroMedioTrabajosSistema(ICollection<Job> secuenciaTrabajos)
        {
            float tiempoRealizacionProceso, sumaTiemposFlujo;
            CalculateTotalTimes(secuenciaTrabajos, out tiempoRealizacionProceso, out sumaTiemposFlujo);
            return sumaTiemposFlujo / tiempoRealizacionProceso;
        }

        private static void CalculateTotalTimes(ICollection<Job> secuenciaTrabajos, out float tiempoRealizacionProceso, out float sumaTiemposFlujo)
        {
            if (secuenciaTrabajos == null)
            {
                throw new ArgumentNullException();
            }
            tiempoRealizacionProceso = GetTotalProcessTime(secuenciaTrabajos);
            sumaTiemposFlujo = GetTotalFlowTime(secuenciaTrabajos);
        }

        public static float GetUtilizacion(ICollection<Job> secuenciaTrabajos)
        {
            float tiempoRealizacionProceso, sumaTiemposFlujo;
            CalculateTotalTimes(secuenciaTrabajos, out tiempoRealizacionProceso, out sumaTiemposFlujo);
            return tiempoRealizacionProceso / sumaTiemposFlujo;
        }

        public static float GetTiempoMedioFinalizacion(ICollection<Job> jobSequence)
        {
            float sumaTiemposFlujo = GetTotalFlowTime(jobSequence);
            int numeroTrabajos = jobSequence.Count;
            return sumaTiemposFlujo / numeroTrabajos;
        }
    }
}