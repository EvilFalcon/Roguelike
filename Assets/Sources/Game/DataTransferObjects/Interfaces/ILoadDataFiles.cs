namespace Sources.Game.DataTransferObjects.Interfaces
{
    public interface ILoadDataFiles
    {
        T Load<T>(T @object, string prefix = "",string postfix = "" );
        T Load<T>(string key);
    }
}