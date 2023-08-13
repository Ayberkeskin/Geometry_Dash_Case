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

    private void Start()
    {
        MusicOn = true;
    }
    private void Update()
    {
        Debug.Log(MusicOn);
    }
    public void PlayeGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundOn()
    {
        MusicOn = true;
        _offBut.gameObject.SetActive(true);
        _onBut.gameObject.SetActive(false);

    }

    public void SoundOff()
    {
        MusicOn = false;
        _offBut.gameObject.SetActive(false);
        _onBut.gameObject.SetActive(true);
    }
}

