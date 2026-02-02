using _Root.Shared.Ports.MovementFeature;

namespace _Root.InteractableFeature.Door.Domain
{
    public class DoorModel
    {
        public Transition Transition { get; set; }

        public DoorModel(Transition transition, MovementLock movementLock)
        {
            Transition = transition;
        }
    }
}