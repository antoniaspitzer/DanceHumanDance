using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip introClip;
    public VideoClip successClip;
    public VideoClip failClip;

    public int score; // Score wird in Start() gesetzt
    [SerializeField] private int zielScore = 6000; // Zielwert für Erfolg

    void Start()
    {
        // Score vom ScoreManager holen
        if (ScoreManager.Instance != null)
        {
            score = ScoreManager.Instance.GetTotalScore();
            Debug.LogWarning("Score: "+ score);
        }
        else
        {
            Debug.LogWarning("ScoreManager.Instance ist NULL – Score wird 0 gesetzt.");
            score = 0;
        }

        // Event registrieren: was passiert am Ende des Videos
        videoPlayer.loopPointReached += OnVideoEnd;

        // Intro-Video starten
        PlayIntro();
    }

    void PlayIntro()
    {
        videoPlayer.clip = introClip;
        videoPlayer.Play();
    }

    void PlaySuccess()
    {
        videoPlayer.clip = successClip;
        videoPlayer.Play();
    }

    void PlayFail()
    {
        videoPlayer.clip = failClip;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Entscheide nur nach IntroClip, was als nächstes kommt
        if (vp.clip == introClip)
        {
            if (score >= zielScore)
            {
                PlaySuccess();
            }
            else
            {
                PlayFail();
            }
        }
        else
        {
            Debug.Log("Alle Videos fertig.");
            // Optional: Szene wechseln oder UI einblenden
            // SceneManager.LoadScene("NextScene");
        }
    }
}
