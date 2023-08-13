using GeometryDash.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        DeathController _deathController;

        [Header("PlayerSettings")]
        [SerializeField] private float _speed;

        private void Awake()
        {
            _deathController=GetComponent<DeathController>();
        }
        private void FixedUpdate()
        {
            if (!_deathController.PlayerDeath) 
            PlayerMove();
        }

        private void PlayerMove()
        {
            transform.Translate(Vector2.right*_speed*Time.deltaTime);
        }
    }
}