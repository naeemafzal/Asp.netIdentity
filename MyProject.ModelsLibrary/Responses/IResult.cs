using System;
using System.Collections.Generic;

namespace Identity.ModelsLibrary.Responses
{
    public interface IResult
    {
        bool Success { get; }
        bool FaildValidation { get; }
        List<string> Messages { get; }
        Exception Exception { get; }
    }

    public interface IResult<T> : IResult
    {
        T Outcome { get; }
    }
}
