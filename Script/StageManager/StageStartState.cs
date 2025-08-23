using UnityEngine;

public class StageStartState : StageState
{
    private Enemy enemy;

    public StageStartState(StageManager _manager, StageStateMachine _machine, string _animName, SoundManager _sound) : base(_manager, _machine, _animName, _sound)
    {
        enemy = Object.FindAnyObjectByType<Enemy>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        sound.PlaySFX(SoundManager.SFXType.start);
        machine.ChangeStageState(stageManager.normalState);

    }
}
