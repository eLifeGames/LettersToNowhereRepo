using UnityEngine;

namespace _Root.MovementFeature.Domain
{
    public class MovementState
    {
        const float InputEps = 0.001f;

        public float SpeedFactor { get; set; }
        public float MaxSpeed { get; set; }
        
        public bool IsMoving { get; set; }

        public bool HasSignificantInput(float value)
            => value > InputEps;
    }
}