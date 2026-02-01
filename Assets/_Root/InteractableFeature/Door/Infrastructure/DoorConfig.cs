using _Root.InteractableFeature.Door.Domain;
using _Root.MovementFeature.Domain;
using UnityEngine;

namespace _Root.Player.Infrastructure
{
    [CreateAssetMenu(fileName = "DoorConfig", menuName = "Create/Interactive/Door", order = 0)]
    public class DoorConfig : ScriptableObject
    {
        public string FromLocationID;
        public string ToLocationID;
        public MovementLock MovementLock;

        public DoorModel ToModel()
        {
            return new DoorModel(new Transition
            {
                LocationFromID = FromLocationID,
                LocationToID = ToLocationID,
            }, MovementLock);
        }
    }
}