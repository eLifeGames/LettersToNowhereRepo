
using _Root.Shared.Ports.MovementFeature;
using UnityEngine;

namespace _Root.Shared.Ports.Player.Events
{
    public abstract class PlayerEvent {}
    public class PlayerSpawnEvent : PlayerEvent
    {
        public Vector3 SpawnPosition { get; }

        public PlayerSpawnEvent(Vector3 spawnPosition)
        {
            SpawnPosition = spawnPosition;
        }
    }
}