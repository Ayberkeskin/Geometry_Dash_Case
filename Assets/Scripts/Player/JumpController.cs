using GeometryDash.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GeometryDash.Player
{
    public class JumpController : MonoBehaviour
    {

        [Header("Components")]
        Rigidbody2D _rb;
        InputManager _input;

        [Header("JumpSettings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheck;

        [SerializeField] private bool _isJump;

        [Header("GravitySettings")]
        [SerializeField] private float _fallSpeed;

        Vector2 _vecGravity;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = new InputManager();

            _vecGravity = new Vector2(0, -Physics2D.gravity.y);
        }

        private void FixedUpdate()
        {
            Jump();
        }

        private bool HasInput()
        {
            return _input.IsJump ? true : false;
        }

        private void Jump()
        {
            if (HasInput() && IsGrounded())
            {
                _isJump = true;
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
            else
                _isJump = false;

            Gravity();
        }

        private void Gravity()
        {
            if (_rb.velocity.y < 0)
            {
                _rb.velocity -= _vecGravity * _fallSpeed * Time.deltaTime;
            }
        }

        public bool IsGrounded()
        {
            return Physics2D.OverlapCapsule(_groundCheck.position, new Vector2(1f, 0.15f), CapsuleDirection2D.Horizontal, 0, _groundLayer);
        }

        public bool IsJumping()
        {
            return _isJump;
        }

    }
}
