namespace Model.IOperation
{
    public interface IPatientOperation
    {
        void LoadPatientById();

        void LoadPatientByPesel();

        void AddPatient();

        void AddConditionToNewPatient();

        void DeleteConditionFromNewConditionList();

        void DeletePatientById();

        void DeletePatientByPesel();
    }
}