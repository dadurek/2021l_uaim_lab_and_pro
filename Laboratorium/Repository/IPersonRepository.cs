namespace Repository
{
    public interface IPersonRepository
    {
        Person[] Find(Sex sex);
    }
}