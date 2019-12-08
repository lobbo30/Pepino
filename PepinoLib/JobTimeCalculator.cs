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

        public static float GetNumeroMedioTrabajosSistema(ICollection<Job> jobSequence)
        {
            float tiempoRealizacionProceso, sumaTiemposFlujo;
            CalculateTotalTimes(jobSequence, out tiempoRealizacionProceso, out sumaTiemposFlujo);
            return sumaTiemposFlujo / tiempoRealizacionProceso;
        }

        public static float GetRetrasoMedioTrabajos(ICollection<Job> jobSequence)
        {
            float totalDiasRetraso = jobSequence.Sum(j => j.JobDelayTime);
            int numeroTrabajos = jobSequence.Count;
            return totalDiasRetraso / numeroTrabajos;
        }

        private static void CalculateTotalTimes(ICollection<Job> jobSequence, out float tiempoRealizacionProceso, out float sumaTiemposFlujo)
        {
            if (jobSequence == null)
            {
                throw new ArgumentNullException();
            }
            tiempoRealizacionProceso = GetTotalProcessTime(jobSequence);
            sumaTiemposFlujo = GetTotalFlowTime(jobSequence);
        }

        public static float GetUtilizacion(ICollection<Job> jobSequence)
        {
            float tiempoRealizacionProceso, sumaTiemposFlujo;
            CalculateTotalTimes(jobSequence, out tiempoRealizacionProceso, out sumaTiemposFlujo);
            return tiempoRealizacionProceso / sumaTiemposFlujo;
        }

        public static float GetTiempoMedioFinalizacion(ICollection<Job> jobSequence, PriorityRule priorityRule = PriorityRule.FCFS)
        {
            if (priorityRule == PriorityRule.SPT)
            {
                return GetTiempoMedioFinalizacion(jobSequence.OrderBy(j => j.ProcessTime).ToList());
            }
            //else if (priorityRule == PriorityRule.EDD)
            //{
            //    return GetTiempoMedioFinalizacion(jobSequence.OrderBy(j => j.FechaEntregaSolicitada).ToList());
            //}
            return GetTiempoMedioFinalizacion(jobSequence);
        }

        private static float GetTiempoMedioFinalizacion(ICollection<Job> jobSequence)
        {
            float sumaTiemposFlujo = GetTotalFlowTime(jobSequence);
            int numeroTrabajos = jobSequence.Count;
            return sumaTiemposFlujo / numeroTrabajos;
        }

    }
}