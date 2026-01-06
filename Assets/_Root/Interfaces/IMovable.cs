using UnityEngine;

namespace Assets._Root.Interfaces
{
    public interface IMovable
    {
        float Speed { get; }
        float Acceleration { get; }
        float Deceleration { get; }
        bool VerticalMove { get; }

        public void Move(Vector2 motion);
    }
}