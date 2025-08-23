public class StageState
{
    public StageManager stageManager;

    public StageStateMachine machine;

    public SoundManager sound;



    public string animBoolName;

    protected bool isCheckEnemy = false;
    protected bool isBoss = false;

    public StageState(StageManager _manager, StageStateMachine _machine, string _animName, SoundManager _sound)
    {
        this.stageManager = _manager;
        this.machine = _machine;
        this.animBoolName = _animName;
        this.sound = _sound;
    }

    public virtual void Enter()
    {
        stageManager.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        stageManager.anim.SetBool(animBoolName, false);
    }
}
