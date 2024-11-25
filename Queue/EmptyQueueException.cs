namespace DataStructures.Queue
{
    public class EmptyQueueException : Exception
    {
        private string _message;

        public EmptyQueueException(string message = "Queue is empty") : base(message)
        {
             
        }
    }
}
