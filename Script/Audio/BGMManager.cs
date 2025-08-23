using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip Elinia;
    [SerializeField] private AudioClip Henesis;
    [SerializeField] private AudioClip Perion;
    [SerializeField] private AudioClip Kerningcity;

    public AudioSource arBGM { get; private set; }

    void Awake()
    {
        arBGM = GetComponent<AudioSource>();
        arBGM.loop = true; // 무한 루프
        arBGM.playOnAwake = false; // awake에서는 실행안되도록
    }

    public void PlayBGM(AudioClip clip) // 클립 실행
    {
        if (arBGM.clip == clip) return; // 실행되고 있는 클립이 똑같은 클립이라면 무시
        arBGM.clip = clip;
        arBGM.Play();
    }

    public void StopBGM() // 클립 멈춤
    {
        arBGM.Stop();
        arBGM.clip = null;
    }

    public void PlaySceneMusic(string sceneName) // 씬에 알맞은 음악 클립 실행.
    {
        switch (sceneName)
        {
            case "Elinia":
                PlayBGM(Elinia);
                break;
            case "Henesis":
                PlayBGM(Henesis);
                break;
            case "Perion":
                PlayBGM(Perion);
                break;
            case "Kerningcity":
                PlayBGM(Kerningcity);
                break;
            default:
                StopBGM();
                break;

        }
    }

}
