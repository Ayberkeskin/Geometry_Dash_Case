using GeometryDash.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        Rigidbody2D _rb;
        InputManager _input;

        [Header("PlayerSettings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;


        bool _isJump;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = new InputManager();
        }
        private void Update()
        {
            if (_input.IsJump)
            {
                _isJump=true;
            }
            else
            {
                _isJump=false;
            }
        }
        private void FixedUpdate()
        {
            PlayerMove();
            Jump();
        }

        private void PlayerMove()
        {
            transform.Translate(Vector2.right*_speed*Time.deltaTime);
        }

        private void Jump()
        {
            Debug.Log(_input.IsJump);
            if (_isJump) 
            {
                _rb.AddForce(Vector2.up*_jumpForce*Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
}