using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private Balrog balrog;
    private SoundManager sound;
    private new CameraManager camera;

    public string StartScene;


    void Awake()
    {
       balrog = FindAnyObjectByType<Balrog>();
        sound = FindAnyObjectByType<SoundManager>();
        camera = FindAnyObjectByType<CameraManager>();

        if (StartScene == sound.currentScene)
        {
            balrog.transform.position = this.transform.position;
            camera.cineCamera.ForceCameraPosition(this.transform.position, Quaternion.identity);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
