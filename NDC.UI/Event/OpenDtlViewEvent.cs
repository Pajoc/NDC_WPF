using Prism.Events;

namespace NDC.UI.Event
{
    public class OpenDtlViewEvent:PubSubEvent<OpenDtlViewEventArgs>
    {
        
    }

    public class OpenDtlViewEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }

    }
}
