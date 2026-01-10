using UnityEngine;

namespace _Root.MovementFeature.Domain
{
    public class MovementState
    {
        public float SpeedFactor { get; set; }
        public float MaxSpeed { get; set; }
        
        public bool IsMoving { get; set; }

        public Vector2 CurrentVelocity { get; set; }
    }
}