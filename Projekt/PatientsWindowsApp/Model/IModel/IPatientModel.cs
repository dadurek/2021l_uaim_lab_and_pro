namespace Model.IModel
{
    using IData;
    using IOperation;

    public interface IPatientModel : IPatientData, IPatientOperation
    {
    }
}