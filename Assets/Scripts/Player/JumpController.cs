﻿using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float _height;
        [SerializeField] private Animator _animator;

        private bool _isJumping;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
                _rigidBody.AddForce(transform.up * _height, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D ground))
            {
                _isJumping = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D ground))
            {
                _isJumping = true;
                _animator.SetTrigger("jump");
            }
        }
    }
}