using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        public List<Patient> Patients;
        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public bool IsFull => this.Patients.Count == 3;

        public void AddPatient(Patient patient)
        {
            if (IsFull)
            {
                this.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in Patients.OrderBy(x=>x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
