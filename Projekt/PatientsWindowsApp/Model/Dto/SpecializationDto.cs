namespace Model.Dto
{
    using System;

    public class SpecializationDto
    {
        public int Type { get; set; }

        public DateTime CertificationDate { get; set; }

        public override string ToString()
        {
            return Type.ToString() + " " + CertificationDate.ToString("dd/MM/yyyy");
        }
    }
}