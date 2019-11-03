using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Fullname => this.Firstname + " " + this.LastName;

        public List<Patient> Patients { get; set; }

        public Doctor(string firstName,string secondName)
        {
            this.Firstname = firstName;
            this.LastName = secondName;
            this.Patients = new List<Patient>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(x=>x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
