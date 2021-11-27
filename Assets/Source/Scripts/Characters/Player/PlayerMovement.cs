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

        private void Awake()
        {
            _playerEventSystem = GetComponent<PlayerEventSystem>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var movingDirection = new Vector2(UiController.Instance.Joystick.Horizontal, UiController.Instance.Joystick.Vertical);
            var deltaMoving = movingDirection * _playerEventSystem.PlayerStats.CurrentSpeed * Time.deltaTime;

            transform.position += (Vector3) deltaMoving;
        }
    }
}