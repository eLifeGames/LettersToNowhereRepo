using _Root.Player.Domain;
using UnityEngine;

namespace _Root.Player.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Create/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        // TODO
        public PlayerModel ToModel()
            => new();
    }
}