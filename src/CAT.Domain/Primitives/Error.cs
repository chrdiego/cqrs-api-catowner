﻿namespace CAT.Domain.Primitives
{
    public sealed class Error
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        public string Message { get; }

        internal static Error None => new Error(string.Empty, string.Empty);
    }
}
