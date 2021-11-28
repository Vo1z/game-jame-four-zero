using Ingame.Events;
using Support.UI;
using UnityEngine;  

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

        private void Start()
        {
            _playerEventSystem.OnPsychoMode += OnPsychoMode;
        }

        private void OnDestroy()
        {
            _playerEventSystem.OnPsychoMode -= OnPsychoMode;
        }

        private void Update()
        {
            Move();
            Rotate();
        }
        
        private void OnPsychoMode(PsychoModeDeBuff deBuffType) 
        {
            switch (deBuffType)
            {
                case PsychoModeDeBuff.InverseControls:
                    _directionReverse = true;
                    break;
                case PsychoModeDeBuff.Normal:
                    _directionReverse = false;
                    break;
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