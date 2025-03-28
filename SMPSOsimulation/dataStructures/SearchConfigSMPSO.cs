﻿namespace SMPSOsimulation.dataStructures
{
    public class SearchConfigSMPSO
    {
        public int swarmSize, archiveSize;
        public int maxGenerations;
        public double turbulenceRate;
        public EnvironmentConfig environment;
        public DominationConfig domination;
        internal readonly int MaxFrequency;

        public bool IsRespectingConstraints()
        {
            if (swarmSize <= 0) return false;
            if (archiveSize <= 0) return false;
            if (maxGenerations <= 0) return false;
            if (turbulenceRate <= 0 || turbulenceRate >= 1) return false;
            if (!domination.IsWithinConstraints()) return false;
            return true;
        }

        public SearchConfigSMPSO(int swarmSize, int archiveSize, int maxGenerations, double turbulenceRate, int maxFrequency, EnvironmentConfig environment, DominationConfig domination)
        {
            this.swarmSize = swarmSize;
            this.archiveSize = archiveSize;
            this.maxGenerations = maxGenerations;
            this.turbulenceRate = turbulenceRate;
            this.environment = environment;
            this.domination = domination;
            this.MaxFrequency = maxFrequency;

            if (!this.IsRespectingConstraints())
                throw new Exception("SearchCOnfigSMPSO does not respect constraints");
        }
    }
}
