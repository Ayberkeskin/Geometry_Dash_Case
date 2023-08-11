using GeometryDash.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("PlayerSettings")]
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            transform.Translate(Vector2.right*_speed*Time.deltaTime);
        }
    }
}