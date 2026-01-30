using _Root.InteractableFeature.Door.Domain;
using _Root.MovementFeature.Domain;
using _Root.Shared.Ports.MovementFeature;

namespace _Root.InteractableFeature.Door.Application
{
    public class ToggleMovementSetupUseCase
    {
        private readonly DoorModel _doorModel;

        public ToggleMovementSetupUseCase(DoorModel doorModel)
        {
            _doorModel = doorModel;
        }

        public void ToggleMovementLock(IMovePort movePort)
        {
            movePort.SetMovementLock(_doorModel.MovementLock);
        }
    }
}