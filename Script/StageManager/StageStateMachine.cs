using UnityEngine;

public class StageStateMachine : MonoBehaviour
{
    public StageState currentState;


    public void Initialized(StageState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void ChangeStageState(StageState changeState)
    {
        currentState.Exit();
        currentState = changeState;
        currentState.Enter();
    }
}
