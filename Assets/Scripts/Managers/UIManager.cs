using GeometryDash.Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _restartBut;
    [SerializeField] private Button _returnMenu;

    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] AudioSource _audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseScreen != null)
            {
                Time.timeScale = 0;
                _audio.Pause();
                _pauseScreen.SetActive(true);
            }
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        _audio.Play();
        _pauseScreen.SetActive(false);
    }
}
