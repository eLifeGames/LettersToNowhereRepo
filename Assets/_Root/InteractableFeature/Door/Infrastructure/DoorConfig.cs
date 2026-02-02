using _Root.InteractableFeature.Door.Domain;
using _Root.Shared.Ports.MovementFeature;

using UnityEngine;

namespace _Root.Player.Infrastructure
{
    [CreateAssetMenu(fileName = "DoorConfig", menuName = "Create/Interactive/Door", order = 0)]
    public class DoorConfig : ScriptableObject
    {
        public string ToLocationID;
        public MovementLock MovementLock;

        public DoorModel ToModel()
        {
            return new DoorModel(new Transition
            {
                LocationToID = ToLocationID,
            }, MovementLock);
        }
    }
}