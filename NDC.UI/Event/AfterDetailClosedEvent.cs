using Prism.Events;

namespace NDC.UI.Event
{
    public class AfterDetailClosedEvent : PubSubEvent<AfterDetailClosedDeletedEventArgs>
    {
        
    }

    public class AfterDetailClosedDeletedEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
