using System.Collections.Generic;

namespace PruebaAloe.Services.Framework
{
    public class TaskResult
    {
        private bool success;
        public bool Success { get { return success; } }

        private List<string> messages;
        public string Messages { get { return string.Join(", ", messages); } }
        public TaskResult()
        {
            success = true;
            messages = new List<string>();
        }
        public void AddErrorMessage(string message)
        {
            success = false;
            messages.Add(message);
        }
        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
    public class TaskResult<T> : TaskResult
    {
        public T Data { get; set; }
    }
}
