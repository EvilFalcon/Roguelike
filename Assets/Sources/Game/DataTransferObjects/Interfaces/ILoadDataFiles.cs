namespace Sources.Game.DataTransferObjects.Interfaces
{
    public interface ILoadDataFiles
    {
        T Load<T>(T @object, string postfix = "");
        T Load<T>(string key);
    }
}