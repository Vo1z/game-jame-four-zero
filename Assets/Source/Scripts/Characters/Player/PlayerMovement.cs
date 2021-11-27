using Ingame.Events;
using Support.UI;
using UnityEngine;
using Support;
using static Support.GameController;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventSystem), typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerEventSystem _playerEventSystem;
        private Rigidbody2D _rigidbody2D;
        private bool _directionReverse = false;

        private Vector3 _initialScale;
        
        private void Awake()
        {
            _initialScale = transform.localScale;
            _playerEventSystem = GetComponent<PlayerEventSystem>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void OnWeirdThingHappend(TypeOfEvent type) 
        {
            switch (type)
            {
                case TypeOfEvent.ReverseControll:
                    {
                        _directionReverse = true;
                        break;
                    }
            }
        }
        
        private void DeactiveWeirdThingHappend(TypeOfEvent type)
        {
            switch (type)
            {
                case TypeOfEvent.ReverseControll:
                    {
                        _directionReverse = false;
                        break;
                    }
            }
        }
        
        private void Move()
        {
            var movingDirection = new Vector2(UiController.Instance.Joystick.Horizontal, UiController.Instance.Joystick.Vertical);
            movingDirection = movingDirection.normalized;
            var movingOffset = (_directionReverse ? -1 : 1) * movingDirection * _playerEventSystem.PlayerStats.CurrentSpeed;
            var deltaMovement = movingOffset * Time.deltaTime;
            
            _playerEventSystem.Move(movingOffset.magnitude);
            
            transform.position += (Vector3) deltaMovement;
        }

        private void Rotate()
        {
            var targetScale = transform.localScale;
            
            if (UiController.Instance.Joystick.Horizontal > 0)
            {
                targetScale.x = -Mathf.Abs(targetScale.x);
            }
            else if (UiController.Instance.Joystick.Horizontal < 0)
            {
                targetScale.x = Mathf.Abs(targetScale.x);
            }

            transform.localScale = targetScale;
        }
    }
}