﻿namespace HA.Library.Core.Primitives
{
    public class Error
    {
        public string Code { get; private set; }

        public string Message { get; private set; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
