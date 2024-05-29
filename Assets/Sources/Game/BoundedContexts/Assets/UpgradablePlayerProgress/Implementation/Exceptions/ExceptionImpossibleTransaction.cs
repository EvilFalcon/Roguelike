using System;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Exceptions
{
    public class ExceptionImpossibleTransaction : Exception
    {
        public ExceptionImpossibleTransaction(string message) : base(message)
        {
        }
    }
}