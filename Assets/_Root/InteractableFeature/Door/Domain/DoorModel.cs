using _Root.MovementFeature.Domain;

namespace _Root.InteractableFeature.Door.Domain
{
    public class DoorModel
    {
        public Transition Transition { get; set; }
        public MovementLock MovementLock { get; set; }

        public DoorModel(Transition transition, MovementLock movementLock)
        {
            Transition = transition;
            MovementLock = movementLock;
        }
    }
}