namespace ZsutPwPatterns.WindowsApplication.Logic.Model.Data
{
    using System.Collections.Generic;

    public class ExaminationRoomData
    {
        public ExaminationRoomData()
        {
        }

        public ExaminationRoomData(string number, IEnumerable<int> certifications)
        {
            Number = number;
            Certifications = certifications;
        }

        public string Number { get; set; }

        public IEnumerable<int> Certifications { get; set; }
    }
}