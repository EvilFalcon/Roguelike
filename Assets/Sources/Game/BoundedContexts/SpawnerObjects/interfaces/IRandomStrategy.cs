namespace Sources.Game.BoundedContexts.SpawnerObjects.interfaces
{
    interface IRandomStrategy
    {
        float GetRandomZValue(float transformZ, float radius);
    }
}