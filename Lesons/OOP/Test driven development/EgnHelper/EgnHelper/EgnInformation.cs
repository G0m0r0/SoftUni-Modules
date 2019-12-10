using System;

namespace EgnHelper
{
    public class EgnInformation
    {
        public EgnInformation(string sex, DateTime dateOfBirth, Sex placeOfBirth)
        {
            Sex = sex;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
        }

        public string Sex { get;  }
        public DateTime DateOfBirth { get; }
        public Sex PlaceOfBirth { get; }
    }
}