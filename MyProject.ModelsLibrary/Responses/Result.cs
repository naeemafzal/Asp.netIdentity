using System;
using System.Collections.Generic;
namespace Identity.ModelsLibrary.Responses
{
    public class Result : IResult
    {
        public bool Success { get; private set; }
        public bool FaildValidation { get; private set; }
        public List<string> Messages { get; private set; }
        public Exception Exception { get; private set; }

        public Result Ok()
        {
            Success = true;
            FaildValidation = false;
            Messages = new List<string>();
            return this;
        }

        public Result Error(string message)
        {
            Success = false;
            FaildValidation = false;
            Messages = new List<string> { message };
            return this;
        }

        public Result NotImplemented()
        {
            Success = false;
            FaildValidation = false;
            Messages = new List<string> { "This feature is not implemented yet." };
            return this;
        }

        public Result ExceptionOccurred(Exception exception)
        {
            Success = false;
            FaildValidation = false;
            Exception = exception;
            Messages = new List<string> { exception.Message };
            return this;
        }
    }

    public class Result<T> : IResult<T>
    {
        public bool Success { get; private set; }
        public bool FaildValidation { get; private set; }
        public List<string> Messages { get; private set; }
        public Exception Exception { get; private set; }
        public T Outcome { get; private set; }

        public Result<T> Ok(T outcome)
        {
            Success = true;
            FaildValidation = false;
            Messages = new List<string>();
            Outcome = outcome;
            return this;
        }

        public Result<T> Error(string message)
        {
            Success = false;
            FaildValidation = false;
            Messages = new List<string> { message };
            return this;
        }

        public Result<T> NotImplemented()
        {
            Success = false;
            FaildValidation = false;
            Messages = new List<string> { "This feature is not implemented yet." };
            return this;
        }

        public Result<T> ExceptionOccurred(Exception exception)
        {
            Success = false;
            FaildValidation = false;
            Exception = exception;
            Messages = new List<string> { exception.Message };
            return this;
        }
    }
}
