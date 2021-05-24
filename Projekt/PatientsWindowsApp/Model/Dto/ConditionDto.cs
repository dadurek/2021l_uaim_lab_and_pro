namespace Model.Dto
{
    using System;

    public class ConditionDto
    {
        public int Type { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public override string ToString()
        {
            return Type.ToString() + " " + DiagnosisDate.ToString("dd/MM/yyyy");
        }
    }
}