using _Root.Shared.Ports.Input;
using _Root.MovementFeature.Domain;

namespace _Root.MovementFeature.Application
{
    public class MovementUsecase
    {
        private readonly MovementState _movementState;
        private readonly MovementModel _movementModel;
        private readonly IInputPort _inputPort;

        public MovementUsecase(MovementState movementState, MovementModel movementModel, IInputPort inputPort)
        {
            _movementState = movementState;
            _movementModel = movementModel;
            _inputPort = inputPort;

            // NOTE: Сейчас смысла его менять в HandleMovementSpeed нету, так-как игрок ходит с одной скоростью.
            _movementState.MaxSpeed = _movementModel.MaxSpeed;
        }

        public void Handle()
        {
            HandleMovementSpeed();
            HandleMovingState();
        }

        private void HandleMovementSpeed()
            => _movementState.SpeedFactor = _movementState.IsMoving
            ? _movementModel.Acceleration
            : _movementModel.Deceleration;
        
        private void HandleMovingState()
            => _movementState.IsMoving = _movementState.HasSignificantInput(_inputPort.MoveInput.sqrMagnitude);
    }
}