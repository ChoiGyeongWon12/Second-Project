using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;


    public CinemachineCamera cineCamera;
    public CinemachineConfiner2D confiner;
    public GameObject player;
    public GameObject cameraTransform;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {

        SetConfiner();
    }

    void LateUpdate()
    {
        SetConfiner();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후 SetConfiner를 호출, 잠시 대기 후 실행
        StartCoroutine(WaitForConfiner());
    }

    // Confiner를 찾을 때까지 기다리는 코루틴
    IEnumerator WaitForConfiner()
    {
        // 씬 로드 후 Confiner 오브젝트를 찾을 때까지 대기 (최대 1초)
        float waitTime = 0f;
        while (waitTime < 3f)
        {
            SetConfiner();  // Confiner를 찾을 때까지 계속 시도
            if (confiner.BoundingShape2D != null)
                yield break;  // Confiner가 설정되면 종료

            waitTime += Time.deltaTime;
            yield return null;
        }

    }

    private void SetConfiner()
    {
        GameObject confinerObj = GameObject.FindGameObjectWithTag("Confiner");

        if (confinerObj != null)
        {
            BoxCollider2D confinerBox = confinerObj.GetComponent<BoxCollider2D>();

            if (confinerBox != null)
            {
                confiner.BoundingShape2D = confinerBox;
            }

        }

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
