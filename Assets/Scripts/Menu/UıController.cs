using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UıController : MonoBehaviour
{
    [Header("On/Off Button")]
    [SerializeField] private Button _onBut;
    [SerializeField] private Button _offBut;

    public static bool MusicOn;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusicState();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetInt("Music", 1);

        MusicOn = PlayerPrefs.GetInt("Music") == 1;
        UpdateMusicState();
    }

    private void UpdateMusicState()
    {
        if (MusicOn)
        {
            _offBut.gameObject.SetActive(true);
            _onBut.gameObject.SetActive(false);
        }
        else
        {
            _offBut.gameObject.SetActive(false);
            _onBut.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(MusicOn);
        Debug.Log(PlayerPrefs.GetInt("Music"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundOn()
    {
        MusicOn = true;
        PlayerPrefs.SetInt("Music", 1);
        UpdateMusicState();
    }

    public void SoundOff()
    {
        MusicOn = false;
        PlayerPrefs.SetInt("Music", 0);
        UpdateMusicState();
    }
}

