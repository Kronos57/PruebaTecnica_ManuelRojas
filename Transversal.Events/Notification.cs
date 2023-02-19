namespace Transversal.Events
{
    public class Notification
    {
        public Exception Exception { get; set; }

        public Layer Layer { get; set; }

        public Notification(Exception exception, Layer layer)
        {
            Exception = exception;
            Layer = layer;
        }
    }
}
