namespace Sources.Game.DataTransferObjects.Interfaces
{
    public interface ILoadDataFiles
    {
        T LoadData<T>(T @object, string postfix);
    }
}