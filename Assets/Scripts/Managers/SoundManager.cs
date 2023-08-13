/*using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private bool isMusicPlaying = true;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.Play();
        isMusicPlaying = true;
    }

    public void PauseMusic()
    {
        musicSource.Pause();
        isMusicPlaying = false;
    }

    public void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            PauseMusic();
        }
        else
        {
            PlayMusic();
        }
    }
}
*/
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;


    private void Start()
    {
        if (UýController.MusicOn)
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