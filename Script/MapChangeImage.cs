using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapChangeImage : MonoBehaviour
{
    public static MapChangeImage instance;

    public Image image; // 이미지
    public float fadeDuration; // 이미지 연출 지속시간

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(image.transform.parent.gameObject); // 이미지를 포함한 이미지의 부모객체까지 파괴 ㄴㄴ
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 시작되면 구독 채널 알람(실행)
    }

    public void FadeOutLoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float timer = 0f;
        Color color = image.color;

        // FadeOut 시작
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / fadeDuration); // 이미지 투명도 증가
            image.color = color;
            yield return null;
        }

        // 이미지가 완전히 보이면 씬을 비동기적으로 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 씬 로드가 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 씬이 로드된 후 FadeIn 실행
        StartCoroutine(FadeIn());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn()); // 씬이 로드된 후에 FadeIn 실행
    }

    public IEnumerator FadeIn()
    {
        float timer = 0f;
        Color color = image.color;
        color.a = 1f; // 처음에는 완전히 보이는 상태로 설정
        image.color = color;

        // FadeIn 시작
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(timer / fadeDuration); // 이미지 투명도 감소
            image.color = color;
            yield return null;
        }

        // FadeIn이 끝난 후 이미지 완전히 숨기기
        color.a = 0f;
        image.color = color;
    }
}
