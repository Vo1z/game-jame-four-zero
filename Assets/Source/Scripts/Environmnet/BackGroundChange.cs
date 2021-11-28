using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment {
public class BackGroundChange : MonoBehaviour
{
        // Start is called before the first frame update
        [SerializeField]
        private Sprite _backGroundNormal;
        [SerializeField]
        private Sprite _backGroundOnWeird;

        public bool NotReversed = true;
        private SpriteRenderer _spriteRenderer;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (!NotReversed)
            {
                ReverseSprite();
            }
        }
        private void Start()
        {
            EnterNormalMode();
        }
        public virtual void EnterSecondMode()
        {
            _spriteRenderer.sprite = _backGroundOnWeird;
        }
        public void EnterNormalMode()
        {
            _spriteRenderer.sprite = _backGroundNormal;
        }

        private void ReverseSprite()
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}