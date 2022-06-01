using System;
using UnityEngine;

namespace _Project
{
    public class PlayerMove : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Vector2 moveDirection)
        {
            var move = moveDirection * Time.deltaTime * 5;
            transform.Translate(move);
        }
    }
}