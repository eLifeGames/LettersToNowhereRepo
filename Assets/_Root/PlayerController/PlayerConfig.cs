using UnityEngine;

namespace Assets._Root.PlayerController
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configurations/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public bool AllowVerticalMove { get; set; }
        [field: SerializeField, Range(0, 10), Tooltip("Скорость которую достигает игрок")] public float Speed { get; set; } = 5f;
        [field: SerializeField, Range(2, 10), Tooltip("Плавность ускорения игрока")] public float Acceleration { get; set; } = 5f;
        [field: SerializeField, Range(2, 10), Tooltip("Плавность снижения скорости игрока")] public float Deceleration { get; set; } = 5f;
    }
}