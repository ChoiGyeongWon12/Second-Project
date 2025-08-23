using UnityEngine;

public class NormalState : StageState
{
    private Enemy enemy;
    private BossStateMachine boss;
    public GameManager game;
    public Portal portal;

    public NormalState(StageManager _manager, StageStateMachine _machine, string _animName, SoundManager _sound) : base(_manager, _machine, _animName, _sound)
    {
        enemy = Object.FindAnyObjectByType<Enemy>();
        boss = Object.FindAnyObjectByType<BossStateMachine>();
        game = Object.FindAnyObjectByType<GameManager>();
        portal = Object.FindAnyObjectByType<Portal>();
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
        BossStateMachine boss = Object.FindAnyObjectByType<BossStateMachine>();
        Enemy enemy = Object.FindAnyObjectByType<Enemy>();          // 업데이트에서 적을 항상 확인함
        Portal portal = Object.FindAnyObjectByType<Portal>();

        if (!isCheckEnemy && enemy != null)
        {
            machine.ChangeStageState(stageManager.startState);
            isCheckEnemy = true;
        }

        if (!isBoss && boss != null)
        {
            machine.ChangeStageState(stageManager.startState);
            isBoss = true;
        }

        if (isCheckEnemy && enemy == null && game.isClear)
        {
            Debug.Log("hoho");
            machine.ChangeStageState(stageManager.clearState);
            portal.AppearPortal();
            isCheckEnemy = false;
            game.isClear = false;
        }

        if (isBoss && boss == null)
        {
            machine.ChangeStageState(stageManager.clearState);
            portal.AppearPortal();
            isBoss = false;            
        }

    }
}