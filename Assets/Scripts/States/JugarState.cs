using UnityEngine;

public class JugarState : State
{
    public JugarState(FSMManager fsm) : base(fsm) { }

    public override void Enter()
    {
        steering.ActivateWander();
        Debug.Log("Jugando");
    }

    public override void Execute()
    {
        fsm.hambre += Time.deltaTime * 5;
        fsm.necesidadWC += Time.deltaTime * 3;
        fsm.energia -= Time.deltaTime * 2;

        if (fsm.jugueteDetectado)
            fsm.ChangeState(new SeguirJugueteState(fsm));
        else if (fsm.hambre > 80)
            fsm.ChangeState(new ComerState(fsm));
        else if (fsm.energia < 20)
            fsm.ChangeState(new DormirState(fsm));
        else if (fsm.necesidadWC > 70)
            fsm.ChangeState(new WCState(fsm));
    }

    public override void Exit()
    {
        steering.Stop();
    }
}