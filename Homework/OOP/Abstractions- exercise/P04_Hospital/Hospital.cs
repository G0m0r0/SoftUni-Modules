using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            this.Departaments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }
        public List<Department> Departaments { get; set; }
        public List<Doctor> Doctors { get; set; }

        public void AddDoctor(string firstName, string lastName)
        {
            if (!this.Doctors.Any(d => d.Firstname == firstName && d.LastName == lastName))
            {
                Doctor doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartament(string name)
        {
            if (!this.Departaments.Any(de => de.Name == name))
            {
                Department department = new Department(name);
                this.Departaments.Add(department);
            }
        }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            Department department = this.Departaments.FirstOrDefault(de => de.Name == departmentName);
            Doctor doctor = this.Doctors.FirstOrDefault(d => d.Fullname == doctorName);

            Patient patient = new Patient(patientName);

            department.AddPatientToRoom(patient);
            doctor.Patients.Add(patient);
        }
    }
}
