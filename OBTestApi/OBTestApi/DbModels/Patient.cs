using System;
using OBTestApi.Constants;

namespace OBTestApi.DbModels
{
    public class Patient
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public AmputationLevel AmputationLevel { get; set; }
        public bool HasOBDevice { get; set; }
        public DateTime BirthDate { get; set; }
        public int Mobis { get; set; }
    }
}
