using UnityEngine;

public class StageClearState : StageState
{

    private Enemy enemy;


    public StageClearState(StageManager _manager, StageStateMachine _machine, string _animName, SoundManager _sound) : base(_manager, _machine, _animName, _sound)
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
        sound.PlaySFX(SoundManager.SFXType.clear);
        machine.ChangeStageState(stageManager.normalState);

    }



}
