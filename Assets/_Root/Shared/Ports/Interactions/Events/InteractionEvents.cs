using _Root.Shared.Ports.MovementFeature;

namespace _Root.Shared.Ports.Interactions.Events
{
    public abstract class InteractionEvent
    {
        
    }

    // Событие взаимодействия с дверью, содержащее порт для управления движением
    public class DoorInteractionEvent : InteractionEvent
    {
        public IMovePort MovePort { get; }

        public DoorInteractionEvent(IMovePort movePort)
        {
            MovePort = movePort;
        }
    }
}