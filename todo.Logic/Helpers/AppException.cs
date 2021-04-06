using System;

namespace todo.Logic.Helpers
{
    //app specific exceptions example
    public class AppException : Exception
    {
        public AppException() 
        {
        }

        public AppException(string message) : base(message)
        {
        }
    }
}