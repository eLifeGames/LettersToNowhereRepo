namespace _Root.MovementFeature.Domain
{
    public class MovementModel
    {
        public float MaxSpeed { get; private set; }
        public float Acceleration { get; private set; }
        public float Deceleration { get; private set; }

        public MovementLock MovementLock { get; private set; }

        public bool CanMoveVertical => MovementLock is MovementLock.AllDirection or MovementLock.Vertical;
        public bool CanMoveHorizontal => MovementLock is MovementLock.AllDirection or MovementLock.Horizontal;

        public MovementModel(float maxSpeed, float acceleration, float deceleration, MovementLock movementLock = MovementLock.AllDirection)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            Deceleration = deceleration;

            MovementLock = movementLock;
        }

        public void SetMovementLock(MovementLock movementLock) => MovementLock = movementLock;
    }
}