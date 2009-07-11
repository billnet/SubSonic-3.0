using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubSonic
{
    /// <summary>
    /// An exception that is thrown when a record cannot be updated because it was changed
    /// by someone else
    /// </summary>
    public class DataConcurrencyException : Exception
    {
        public static string DefaultMessage = "The item you attempted to update has changed since it was last loaded. Your changes cannot be saved.";

        public DataConcurrencyException() : base(DefaultMessage) { }
        public DataConcurrencyException(string msg) : base(msg) { }
    }
}
