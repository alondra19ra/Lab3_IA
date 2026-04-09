using UnityEngine;

public class WCState : State
{
    float tiempo;

    public WCState(FSMManager fsm) : base(fsm) { }

    public override void Enter()
    {
        steering.ActivateArrive(fsm.banio);
        tiempo = 2f;
    }

    public override void Execute()
    {
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            fsm.necesidadWC = 0;
            fsm.ChangeState(new JugarState(fsm));
        }
    }

    public override void Exit()
    {
        steering.Stop();
    }
}