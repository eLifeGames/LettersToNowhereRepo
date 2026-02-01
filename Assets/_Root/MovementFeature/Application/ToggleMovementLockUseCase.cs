using _Root.MovementFeature.Domain;
using _Root.Shared.Ports.MovementFeature;

namespace _Root.MovementFeature.Application
{
    public class ToggleMovementLockUseCase
    {
        private readonly MovementModel _movementModel;

        public ToggleMovementLockUseCase(MovementModel movementModel)
        {
            _movementModel = movementModel;
        }

        public void ToggleMovementLock(MovementLock movementLock)
            => _movementModel.SetMovementLock(movementLock);
    }
}