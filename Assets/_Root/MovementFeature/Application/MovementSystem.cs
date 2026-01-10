using _Root.Shared.Ports.Input;
using _Root.Shared.Ports.MovementFeature;

namespace _Root.MovementFeature.Application
{
    public class MovementSystem
    {
        private MovementUsecase _movementUsecase;
        private IMovePort _movePort;
        private IInputPort _inputPort;

        public MovementSystem(
            MovementUsecase movementUsecase,
            IMovePort movePort,
            IInputPort inputPort
        )
        {
            _movementUsecase = movementUsecase;
            _movePort = movePort;
            _inputPort = inputPort;
        }

        public void OnTick()
        {
            // TODO
            _movementUsecase.Handle();

            _movePort.Move(_inputPort.MoveInput);
            _movePort.Rotate(_inputPort.MoveInput);
        }
    }
}