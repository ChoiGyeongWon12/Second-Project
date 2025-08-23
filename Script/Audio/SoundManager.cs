using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region 배경음악 열거형
    public enum BGMType
    {
        Elinia,
        Henesis,
        Perion,
        Kerningcity,
        Boss_Stage,
        ClearGame,
        TitleScene,
        TutorialScene,
        TutorialScene2,
        PrologueScene,
        CreditScene,
        EndingScene,
        EndingScene2,
    }
    #endregion

    #region 효과음 열거형
    public enum SFXType
    {
        portal,
        start,
        clear,
        death,
        nexon,
        levelUP,
        lightbulb,
        swing,
    }
    #endregion

    #region UI 사운드 열거형
    public enum UISoundType // 예시입니당
    {
        buttonClick,
        buttonHover,
        menuOpen,
        menuClose,
        confirmSound,
        cancelSound,
        errorSound,
        pageFlip,
        itemSelect,
        tabSwitch
    }
    #endregion

    public static SoundManager instance;

    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider UISlider; // UI 사운드 볼륨 슬라이더

    [Header("BGM Clips")]
    [SerializeField] private AudioClip[] bgmClips;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip[] sfxClips;

    [Header("UI Sound Clips")]
    [SerializeField] private AudioClip[] uiSoundClips;

    private AudioSource bgmSource;
    private AudioSource sfxSource;
    private AudioSource uiSoundSource; // UI 전용 AudioSource

    public string currentScene;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        bgmSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        uiSoundSource = gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true;
        bgmSource.playOnAwake = false;

        sfxSource.loop = false;
        sfxSource.playOnAwake = false;

        uiSoundSource.loop = false;
        uiSoundSource.playOnAwake = false;
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        PlaySceneBGM(currentScene);
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != currentScene)
        {
            currentScene = sceneName;
            PlaySceneBGM(sceneName);
        }
    }

    // 볼륨 조절
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        bgmSource.volume = volume;
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        sfxSource.volume = volume;
    }

    public void SetUIVolume()
    {
        float volume = UISlider.value;
        uiSoundSource.volume = volume;
    }

    // BGM 재생
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip) return;
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // BGM 정지
    public void StopBGM()
    {
        bgmSource.Stop();
        bgmSource.clip = null;
    }

    // 씬 이름에 따른 자동 BGM
    public void PlaySceneBGM(string sceneName)
    {
        if (System.Enum.TryParse<BGMType>(sceneName, out var bgmType))
        {
            int index = (int)bgmType;
            if (index >= 0 && index < bgmClips.Length)
                PlayBGM(bgmClips[index]);
        }
        else
        {
            StopBGM();
        }
    }

    // 효과음 재생
    public void PlaySFX(SFXType type)
    {
        int index = (int)type;
        if (index >= 0 && index < sfxClips.Length)
            sfxSource.PlayOneShot(sfxClips[index]);
    }

    // UI 사운드 재생
    public void PlayUISound(UISoundType type)
    {
        int index = (int)type;
        if (index >= 0 && index < uiSoundClips.Length)
            uiSoundSource.PlayOneShot(uiSoundClips[index]);
    }
}