using UnityEngine;

public class ComerState : State
{
    float tiempo;

    public ComerState(FSMManager fsm) : base(fsm) { }

    public override void Enter()
    {
        steering.ActivateArrive(fsm.comedor);
        tiempo = 3f;
        Debug.Log("Comiendo");
    }

    public override void Execute()
    {
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            fsm.hambre = 0;
            fsm.ChangeState(new JugarState(fsm));
        }
    }

    public override void Exit()
    {
        steering.Stop();
    }
}