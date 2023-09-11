namespace WS.CustomerBase.Api.Exceptions;

public abstract class CustomException : Exception
{
    protected CustomException(){}
    
    protected CustomException(string message): base(message) {}
    
    protected CustomException(string message, Exception inner) : base(message, inner){}
}