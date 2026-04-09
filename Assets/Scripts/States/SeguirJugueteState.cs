using UnityEngine;

public class SeguirJugueteState : State
{
    public SeguirJugueteState(FSMManager fsm) : base(fsm) { }

    public override void Enter()
    {
        steering.ActivateSeek(fsm.jugueteTransform);
        Debug.Log("Persiguiendo juguete");
    }

    public override void Execute()
    {
        if (!fsm.jugueteDetectado)
        {
            fsm.ChangeState(new JugarState(fsm));
        }
    }

    public override void Exit()
    {
        steering.Stop();
    }
}