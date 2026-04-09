using UnityEngine;

public abstract class State
{
    protected FSMManager fsm;
    protected SteeringManager steering;

    public State(FSMManager fsm)
    {
        this.fsm = fsm;
        this.steering = fsm.GetComponent<SteeringManager>();
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}