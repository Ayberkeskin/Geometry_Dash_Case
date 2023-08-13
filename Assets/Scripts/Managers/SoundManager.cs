using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;


    private void Start()
    {
        if (U�Controller.MusicOn)
            PlayMusic();
        else
            PauseMusic();
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
}