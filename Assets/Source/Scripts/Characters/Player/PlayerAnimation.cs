using Ingame.Events;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventSystem))]
    public class PlayerAnimation : MonoBehaviour
    {
        private PlayerEventSystem _playerEventSystem;
        private Animator _animator;
        
        private void Awake()
        {
            _playerEventSystem = GetComponent<PlayerEventSystem>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            PlayerEventSystem.Instance.OnPlayerMove += OnMove;
        }

        private void OnDestroy()
        {
            PlayerEventSystem.Instance.OnPlayerMove -= OnMove;
        }

        private void OnMove(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }
    }
}