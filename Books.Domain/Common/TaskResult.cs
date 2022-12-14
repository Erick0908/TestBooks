using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBooks.Domain.Common
{
   public class TaskResult
    {
        private bool _success;

        public bool Success { get { return _success; } }

        private List<string> _messages;
        public string Message { get { return string.Join(",", _messages); } }

        public TaskResult()
        {
            _success = true;
            _messages = new List<string>();
        }

        public void AddMessage(string message) 
        {
            _messages.Add(message);
        }

        public void AddErrorMessage(string message) 
        {
            _success = false;
            AddMessage(message);

        }

    }

    public class TaskResult<T> : TaskResult
    {
        public T Data {get; set;}
    }
}
