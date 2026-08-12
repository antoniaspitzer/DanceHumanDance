using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Sources -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource acidSource;

    [Header("----------- Audio Clips -----------")]
    public AudioClip BGFirstStage;
    public AudioClip säure;
    public AudioClip wreckingBall;
    public AudioClip wreckingBallHit;
    public AudioClip explosion;
    public AudioClip kanonen;
    public AudioClip ouch;
    public AudioClip shopMusic;
    public AudioClip shopButtonClick;
    public AudioClip itemPurchase;
    public AudioClip notEnoughMoney;
    public AudioClip deathScreen;
    public AudioClip homeScreen;
    public AudioClip buffer;
    public AudioClip booing;
    public AudioClip cheering;

    public void PlaySceneMusic(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;

        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip, volume);
        }
    }

    public void StopSFX()
    {
        SFXSource.Stop();
    }


    public void PlayAcidSFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
        {
            acidSource.clip = clip;
            acidSource.volume = volume;
            acidSource.loop = true;  // Falls du möchtest, dass es sich wiederholt
            acidSource.Play();
        }
    }


    public void StopAcidSFX()
    {
        if (acidSource.isPlaying)
        {
            acidSource.Stop();
        }
    }
}
