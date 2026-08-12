using UnityEngine;

public class SceneMusicTrigger : MonoBehaviour
{
    public AudioClip musicToPlay;

    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlaySceneMusic(musicToPlay);
        }
    }
}