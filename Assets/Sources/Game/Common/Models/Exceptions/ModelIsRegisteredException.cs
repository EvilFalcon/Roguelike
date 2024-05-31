using System;

namespace Sources.Game.Common.Models.Exceptions
{
    public class ModelIsRegisteredException : Exception
    {
        public ModelIsRegisteredException(string message) : base(message)
        {
        }
    }
}