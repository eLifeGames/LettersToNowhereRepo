using UnityEngine;

namespace _Root.Shared.Ports.MovementFeature
{
    public interface IMovePort
    {
        public void Move(Vector2 direction);
        public void Rotate(Vector2 direction); // TODO
        public void SetMovementLock(MovementLock movementLock);
    }
}