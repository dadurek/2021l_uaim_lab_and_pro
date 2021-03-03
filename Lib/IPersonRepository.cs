namespace Lib
{
    public interface IPersonRepository
    {
        Person[] Find(Sex sex);
    }
}