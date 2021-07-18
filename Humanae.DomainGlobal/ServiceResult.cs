using System;

namespace Humanae.DomainGlobal
{
    public class ServiceResult
    {
        public bool ExcecutedSuccessfully { get; set; } = true;
        public string Message { get; set; } = "La operación se ha realizado de manera exitosa.";

        public void AddMessage(string message)
        {
            Message = message;
        }

        public void AddErrorMessage(string message)
        {
            ExcecutedSuccessfully = false;
            Message = message;
        }

        public void AddErrorMessage(Exception exception)
        {
            if (exception.InnerException != null)
            {
                AddErrorMessage(exception.InnerException);
            }
            else
            {
                AddErrorMessage(exception.Message);
            }
        }
    }

    public class ServiceResult<T> where T : class
    {
        public bool ExcecutedSuccessfully { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
        
        public void AddMessage(string message)
        {
            Message = message;
        }

        public void AddErrorMessage(string message)
        {
            ExcecutedSuccessfully = false;
            Message = message;
        }

        public void AddErrorMessage(Exception exception)
        {
            if (exception.InnerException != null)
            {
                AddErrorMessage(exception.InnerException);
            }
            else
            {
                AddErrorMessage(exception.Message);
            }
        }
    }
}
