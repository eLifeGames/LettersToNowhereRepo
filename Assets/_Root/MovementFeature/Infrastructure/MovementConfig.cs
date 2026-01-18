using _Root.MovementFeature.Domain;
using UnityEngine;

namespace _Root.MovementFeature.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(MovementConfig), menuName ="Create/Movement/MovementConfig", order = 0)]
    public class MovementConfig : ScriptableObject
    {
        [Tooltip("Maximum Movement Speed")]
        [field: Range(1f, 10f)] public float MaxSpeed = 1f;

        [Header("Speed factors")]

        [Tooltip("Movement Acceleration Speed Factor")]
        [field: Range(1f, 10f)] public float Acceleration;

        [Tooltip("Movement Deceleration Speed Factor")]
        [field: Range(1f, 10f)] public float Decelration;

        [Header("Other")]

        [Tooltip("Selects direction player can move")]
        public MovementLock MovementLockSelection;

        public MovementModel ToModel()
            => new(MaxSpeed, Acceleration, Decelration, MovementLockSelection);
    }
}