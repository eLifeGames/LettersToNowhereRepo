using System;
using _Root.MovementFeature.Application;
using _Root.MovementFeature.Domain;
using _Root.Shared.Ports.MovementFeature;

using UnityEngine;
using Zenject;

namespace _Root.MovementFeature.Infrastructure
{
    public class MovementAdapter : MonoBehaviour, IMovePort, ITickable
    {
        private MovementState _movementState;
        private MovementModel _movementModel;
        private MovementSystem _movementSystem;

        [Inject]
        public void Construct(MovementState movementState, MovementModel movementModel, MovementSystem movementSystem)
        {
            _movementState = movementState;
            _movementModel = movementModel;
            _movementSystem = movementSystem;
        }

        #region Handling

        public void Move(Vector2 direction)
        {
            // TODO

            if (_movementModel.MovementLock == MovementLock.NoDirection) return;

            if (!_movementModel.CanMoveVertical) direction.y = 0;
            if (!_movementModel.CanMoveHorizontal) direction.x = 0;

            Vector2 targetVelocity = direction.normalized * _movementState.MaxSpeed;

            _movementState.CurrentVelocity = Vector2.MoveTowards(
                _movementState.CurrentVelocity,
                targetVelocity,
                _movementState.SpeedFactor * Time.deltaTime
            );

            transform.position += (Vector3)(_movementState.CurrentVelocity * Time.deltaTime);
        }
        
        float _lastDirection = 1f; // NOTE: если 0 то ваш персонаж станет лепешкой в 2Д (схлопнется)

        // REVIEW: Есть прикол, что можно денсить (нажимая право-лево), есть вариант добавить заддержку с использованием времени.
        
        public void Rotate(Vector2 direction)
        {
            if (_lastDirection != direction.x && direction.x != 0)
                _lastDirection = Mathf.Sign(direction.x); // -1..1
            
            if (!Mathf.Approximately(_lastDirection, transform.localScale.x)) // NOTE: не ебу как, но дрожания исчезают, прошлый опыт
            {
                Vector3 newScale = transform.localScale;
                newScale.x = _lastDirection;

                transform.localScale = Vector3.Lerp(transform.localScale, newScale, _movementModel.RotateSmooth * Time.deltaTime);
            }
        }

        #endregion

        public void Tick() => _movementSystem.OnTick();
    }
}