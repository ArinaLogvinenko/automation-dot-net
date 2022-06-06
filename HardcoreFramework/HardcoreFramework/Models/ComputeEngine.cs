using System;

namespace HardcoreFramework.Models
{
    public class ComputeEngine
    {
        public int NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string VMClass { get; set; }
        public string InstanceType { get; set; }
        public int NumberOfGPUs { get; set; }
        public string GPUType { get; set; }
        public string LocalSSD { get; set; }
        public string DatacenterLocation { get; set; }
        public string CommitedUsage { get; set; }

        public ComputeEngine() { }

        public ComputeEngine(int NumberOfInstances, string OperatingSystem, string VMClass, string InstanceType,
            int NumberOfGPUs, string GPUType, string LocalSSD, string DatacenterLocation, string CommitedUsage)
        {
            if (string.IsNullOrEmpty(OperatingSystem) || string.IsNullOrEmpty(VMClass) || string.IsNullOrEmpty(InstanceType)
                || string.IsNullOrEmpty(GPUType) || string.IsNullOrEmpty(LocalSSD) || string.IsNullOrEmpty(DatacenterLocation)
                || string.IsNullOrEmpty(CommitedUsage))
            {
                throw new ArgumentException("Field is empty!");
            }

            this.NumberOfInstances = NumberOfInstances;
            this.OperatingSystem = OperatingSystem;
            this.VMClass = VMClass;
            this.InstanceType = InstanceType;
            this.NumberOfGPUs = NumberOfGPUs;
            this.GPUType = GPUType;
            this.LocalSSD = LocalSSD;
            this.DatacenterLocation = DatacenterLocation;
            this.CommitedUsage = CommitedUsage;
        }
    }
}
