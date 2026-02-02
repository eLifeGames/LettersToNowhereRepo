
using _Root.Shared.Ports.MovementFeature;
using UnityEngine;

namespace _Root.Shared.Ports.Player.Events
{
    public abstract class PlayerEvent {}
    public sealed class PlayerSpawnEvent : PlayerEvent
    {
        public MovementLock MovementLockOnSpawn { get; }

        public PlayerSpawnEvent(MovementLock movementLockOnSpawn)
        {
            MovementLockOnSpawn = movementLockOnSpawn;
        }
    }

    public sealed class PlayerReachedEndOfLocationEvent : PlayerEvent
    {
        public string TransitionZoneId { get; }

        public PlayerReachedEndOfLocationEvent(string transitionZoneId)
        {
            TransitionZoneId = transitionZoneId;
        }
    }
}