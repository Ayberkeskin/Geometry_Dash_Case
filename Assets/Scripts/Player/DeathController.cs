using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GeometryDash.Player
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] GameManager _gm;
        [SerializeField] Transform _player;
        [SerializeField] GameObject _finishScreen;

        [Header("Particles")]
        [SerializeField] private GameObject _tailParticle;
        [SerializeField] private GameObject _explosionParticle;

        [Header("Bodys")]
        [SerializeField] private GameObject _cubeBody;
        [SerializeField] private GameObject _planeBody;

        bool _playerDeath;

        public bool PlayerDeath { get => _playerDeath; set => _playerDeath = value; }

        private void Awake()
        {
            _playerDeath = false;
            Time.timeScale = 1;
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("RedZone"))
            {
                StartCoroutine(Death());
            }
            if (collision.gameObject.CompareTag("Ground") && _player.localPosition.y <= collision.transform.localPosition.y)
            {
                StartCoroutine(Death());
            }
            if (collision.gameObject.CompareTag("Finish"))
            {
                Destroy(collision.gameObject);
                StartCoroutine(FinishTime());
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("RedZone"))
            {
                StartCoroutine(Death());
            }
            if (collision.gameObject.CompareTag("Ground")&& _player.localPosition.y<= collision.transform.localPosition.y)
            {
                StartCoroutine(Death());
            }
            if (collision.gameObject.CompareTag("Finish"))
            {
                Destroy(collision.gameObject);
                StartCoroutine(FinishTime());
            }
        }

        private IEnumerator Death()
        {
            _playerDeath = true;
            if (_gm.GetCurrentGameMode==GameMode.Ground)
                _cubeBody.SetActive(false);
            else if(_gm.GetCurrentGameMode == GameMode.Fly)
                _planeBody.SetActive(false);
            
            _tailParticle.SetActive(false);
            _explosionParticle.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _explosionParticle.SetActive(false);
            GameOver();
        }
        private IEnumerator FinishTime()
        {
            _finishScreen.SetActive(true);
            _playerDeath = true;
            if (_gm.GetCurrentGameMode == GameMode.Ground)
                _cubeBody.SetActive(false);
            else if (_gm.GetCurrentGameMode == GameMode.Fly)
                _planeBody.SetActive(false);

            _tailParticle.SetActive(false);
            _explosionParticle.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _explosionParticle.SetActive(false);
            Finish();
        }

        private void GameOver()
        {
            Time.timeScale = 1;
            _finishScreen.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        private void Finish()
        {
            Time.timeScale = 0;

        }
    }

}