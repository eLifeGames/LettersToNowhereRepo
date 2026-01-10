using _Root.Shared.Ports.Input;
using _Root.MovementFeature.Domain;

namespace _Root.MovementFeature.Application
{
    public class MovementUsecase
    {
        private MovementState _movementState;
        private MovementModel _movementModel;
        private IInputPort _inputPort;

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
            HandleMovingState();
            HandleMovementSpeed();
        }

        private void HandleMovingState()
            => _movementState.IsMoving = _inputPort.MoveInput.sqrMagnitude > 0.1f;

        private void HandleMovementSpeed()
            => _movementState.SpeedFactor = _movementState.IsMoving ? _movementModel.Acceleration : _movementModel.Deceleration;
    }
}