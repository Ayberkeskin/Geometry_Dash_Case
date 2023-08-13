using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.Player
{
    public class GameModeController : MonoBehaviour
    {
        [SerializeField] GameManager _gm;
        DeathController _deathController;
        Rigidbody2D _rb;

        [Header("GroundModeComponent")]
        [SerializeField] GameObject _groundBody;
        JumpController _jumpController;
        PlayerRotate _playerRotate;

        [Header("FlyModeComponent")]
        [SerializeField] GameObject _flyBody;
        FlyController _flyController;

        private void Awake()
        {
            _rb=GetComponent<Rigidbody2D>();    
            _jumpController =GetComponent<JumpController>();
            _playerRotate=GetComponent<PlayerRotate>();
            _flyController=GetComponent<FlyController>();
            _deathController=GetComponent<DeathController>();
        }

        private void Update()
        {
            ModeController();
        }

        private void ModeController()
        {
            if (_gm.GetCurrentGameMode==GameMode.Ground&&!_deathController.PlayerDeath)
            {
                _rb.gravityScale = 5f;
                _jumpController.enabled=true;
                _playerRotate.enabled=true;
                _flyController.enabled=false;
                _groundBody.SetActive(true);
                _flyBody.SetActive(false);
                
            }
            else if (_gm.GetCurrentGameMode == GameMode.Fly&&!_deathController.PlayerDeath)
            {
                _rb.gravityScale = 3.5f;
                _flyController.enabled = true;
                _jumpController.enabled = false;
                _playerRotate.enabled = false;
                _flyBody.SetActive(true);
                _groundBody.SetActive(false);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ChangeMode"))
            {
                Debug.Log("sa");
                _gm.ChangeMode();
                collision.gameObject.SetActive(false);
            }
        }
    }

}
