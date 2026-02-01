using _Root.MovementFeature.Application;
using _Root.MovementFeature.Domain;
using _Root.Shared.Ports.MovementFeature;

using UnityEngine;
using Zenject;

namespace _Root.MovementFeature.Infrastructure
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CapsuleCollider2D))]
    public class MovementAdapter : MonoBehaviour, IMovePort, ITickable, IFixedTickable
    {
        [SerializeField] private SpriteRenderer _playerSprite;
        [SerializeField] private Rigidbody2D _rigidbody;

        private MovementState _movementState;
        private MovementSystem _movementSystem;
        private MovementModel _movementModel;

        [Inject]
        public void Construct(MovementState movementState, MovementSystem movementSystem, MovementModel movementModel)
        {
            _movementState = movementState;
            _movementSystem = movementSystem;
            _movementModel = movementModel;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody2D>();

            // REVIEW
            _rigidbody.gravityScale = 0f; // zero gravity
            _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            _rigidbody.sleepMode = RigidbodySleepMode2D.NeverSleep; // REVIEW - Оставлять или не
            _rigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
#endif

        #region Handling

        public void Move(Vector2 direction)
        {
            // NOTE: позаимствовал
            Vector2 dir = _movementState.IsMoving ? direction : Vector2.zero;

            switch (_movementModel.MovementLock)
            {
                case MovementLock.Horizontal:
                    dir.y = 0f;
                    break;
                case MovementLock.Vertical:
                    dir.x = 0f;
                    break;
                case MovementLock.NoDirection:
                    dir = Vector2.zero;
                    break;
            }

            dir.Normalize();

            float maxSpeed = Mathf.Max(0f, _movementState.MaxSpeed); // NOTE: оставил

            Vector2 desired = dir * maxSpeed;
            Vector2 current = _rigidbody.linearVelocity; // Unity6 кажется
            Vector2 delta   = desired - current;

            float ratePerSec = Mathf.Max(0f, _movementState.SpeedFactor);
            float maxDeltaStep = ratePerSec * Time.fixedDeltaTime;

            Vector2 appliedDelta = Vector2.ClampMagnitude(delta, maxDeltaStep);

            if (_movementState.HasSignificantInput(appliedDelta.sqrMagnitude))
            {
                appliedDelta *= _rigidbody.mass;
                _rigidbody.AddForce(appliedDelta, ForceMode2D.Impulse);
            }
        }

        const float RotTolerance = 0.01f;

        public void Rotate(Vector2 direction)
        {
            // Можно в системуу перенести
            if (!_movementState.IsMoving)
                return;
            
            float dot = Vector2.Dot(direction.normalized, Vector2.right);

            if (Mathf.Abs(dot) < RotTolerance)
                return;
            
            _playerSprite.flipX = dot < 0f;
        }

        #endregion

        public void Tick() => _movementSystem.OnTick();

        public void FixedTick() => _movementSystem.OnFixedTick();
    }
}