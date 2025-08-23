using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public StageStateMachine machine { get; private set; }

    public GameObject clearImage;

    public Animator anim => GetComponent<Animator>();

    #region 상태
    public NormalState normalState { get; private set; }
    public StageStartState startState { get; private set; }
    public StageClearState clearState { get; private set; }

    #endregion
    [SerializeField] Transform currentTransform;
    Vector3 worldPos;
    Vector3 viewPos;


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
        machine = new StageStateMachine();

        normalState = new NormalState(this, machine, "Normal", SoundManager.instance);
        startState = new StageStartState(this, machine, "Start", SoundManager.instance);
        clearState = new StageClearState(this, machine, "Clear", SoundManager.instance);

        machine.Initialized(normalState);
    }

    void Update()
    {
        viewPos = new Vector3(0.5f, 0.8f, 0);
        worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        currentTransform.position = new Vector2(worldPos.x, worldPos.y);
        machine.currentState.Update();
    }


}
