using Zenject;

using UnityEngine;
using Assets._Root.Interfaces;

namespace Assets._Root.PlayerController
{
    /// <summary>
    /// Базовый монобех игрока
    /// </summary>
    public class Player : MonoBehaviour, IMovable
    {
        // IMovable
        public float Speed { get; private set; }
        public float Acceleration { get; private set; }
        public float Deceleration { get; private set; }
        public bool VerticalMove { get; private set; }

        [Inject]
        public void Contructor(PlayerConfig playerConfig)
        {
            Speed = playerConfig.Speed;
            Acceleration = playerConfig.Acceleration;
            Deceleration = playerConfig.Deceleration;
            VerticalMove = playerConfig.AllowVerticalMove;
        }

        // TODO: Придумать способ отделить логику в отдельном скрипте
        // Чтобы Player был просто мостом.

        #region Motion

        private Vector2 _currentVelocity;

        public void Move(Vector2 motion)
        {
            if (!VerticalMove) motion.y = 0;

            // REVIEW: normalized нахуя тут

            Vector2 targetVelocity = motion.normalized * Speed;

            float accel = motion.sqrMagnitude > 0
                ? Acceleration
                : Deceleration;
            
            _currentVelocity = Vector2.MoveTowards(
                _currentVelocity,
                targetVelocity,
                accel * Time.deltaTime
            );

            transform.position += (Vector3)(_currentVelocity * Time.deltaTime);
        }

        #endregion
    }
}