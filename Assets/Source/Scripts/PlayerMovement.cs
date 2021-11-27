using DG.Tweening;
using Support;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerMovement : MonoBehaviour, IMovable
    {
        [SerializeField] [Min(0)] private float movingDistance;
        [SerializeField] [Min(0)] private float travelTime = .2f;

        private enum MovingState { Moving, Waiting }

        private MovingState _movingState = MovingState.Waiting;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            TouchScreenInputSystem.Instance.OnSwipeAction += OnSwipe;
        }

        private void OnDestroy()
        {
            TouchScreenInputSystem.Instance.OnSwipeAction -= OnSwipe;
        }

        private void OnSwipe(SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case SwipeDirection.Left:
                    MoveLeft();
                    break;
                case SwipeDirection.Right:
                    MoveRight();
                    break;
                case SwipeDirection.Up:
                    MoveUp();
                    break;
                case SwipeDirection.Down:
                    MoveDown();
                    break;
            }
        }

        public void MoveRight()
        {
            if(_movingState != MovingState.Waiting)
                return;
            
            _movingState = MovingState.Moving;
            
            var targetPos = _rigidbody2D.position + (Vector2)_rigidbody2D.transform.right * movingDistance;
            transform.DOMove(targetPos, travelTime)
                .OnComplete(() => _movingState = MovingState.Waiting);
        }

        public void MoveLeft()
        {
            if(_movingState != MovingState.Waiting)
                return;

            _movingState = MovingState.Moving;
            
            var targetPos = _rigidbody2D.position + -(Vector2)_rigidbody2D.transform.right * movingDistance;
            transform.DOMove(targetPos, travelTime)
                .OnComplete(() => _movingState = MovingState.Waiting);
        }

        public void MoveUp()
        {
            if(_movingState != MovingState.Waiting)
                return;

            _movingState = MovingState.Moving;
            
            var targetPos = _rigidbody2D.position + (Vector2)_rigidbody2D.transform.up * movingDistance;
            transform.DOMove(targetPos, travelTime)
                .OnComplete(() => _movingState = MovingState.Waiting);
        }

        public void MoveDown()
        {
            if(_movingState != MovingState.Waiting)
                return;

            _movingState = MovingState.Moving;
            
            var targetPos = _rigidbody2D.position + -(Vector2)_rigidbody2D.transform.up * movingDistance;
            transform.DOMove(targetPos, travelTime)
                .OnComplete(() => _movingState = MovingState.Waiting);
        }
    }
}