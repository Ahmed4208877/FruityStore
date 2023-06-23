using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruity.BI
{
    [Serializable]
    public class BlException : Exception
    {
        public string ErrorMessage { get; set; }
        public string UserErrorMessage { get; set; }
        public BlException(Exception ex)
        {
            ErrorMessage = ex.Message;
            UserErrorMessage = "error in business layer please try again";
            if (ex.InnerException is InvalidOperationException)
            {
                ErrorMessage = ex.InnerException.Message;
                UserErrorMessage = "operation problem in the system please try again";
            }
            else if (ex.InnerException is OutOfMemoryException)
            {
                ErrorMessage = ex.InnerException.Message;
                UserErrorMessage = "overload on server pleae try again";
            }

            // store all exceptions in database
        }

        public BlException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }

    }
}
