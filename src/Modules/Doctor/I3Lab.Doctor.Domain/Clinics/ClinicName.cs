using I3Lab.BuildingBlocks.Domain;
using MassTransit.Scheduling;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace I3Lab.Doctors.Domain.Clinics
{
    public class ClinicName : ValueObject
    {
        public string Name { get; set; }    

        private ClinicName(string name) 
            => Name = name; 

        public static ClinicName Create(string name)
        {
            return new ClinicName(name);
        }
    }
}
