using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var departamentStr = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullNameDoctor = firstName +" "+ secondName;

                this.hospital.AddDoctor(firstName, secondName);
                this.hospital.AddDepartament(departamentStr);
                this.hospital.AddPatient(departamentStr, fullNameDoctor, patient);
            }

            while ((command=Console.ReadLine())!="End")
            {
                string[] tokens = command.Split();
                if(tokens.Length==1)
                {
                    var departmentName = tokens[0];
                    var department = this.hospital.Departaments.FirstOrDefault(de => de.Name==departmentName);

                    Console.WriteLine(department);
                }
                else
                {
                    bool isRoom = int.TryParse(tokens[1], out int resultRoom); 

                    if(isRoom)
                    {
                        string departmentName = tokens[0];
                        Department departmnet = this.hospital.Departaments.FirstOrDefault(de=>de.Name==departmentName);

                        Room currentRoom = departmnet.Rooms[resultRoom - 1];

                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        string firstName = tokens[0];
                        string lastName = tokens[1];

                        string fullName = firstName + " " + lastName;

                        Doctor doctor = this.hospital.Doctors.FirstOrDefault(d => d.Fullname == fullName);

                        Console.WriteLine(doctor);
                    }
                }
            }
        }

    }
}
