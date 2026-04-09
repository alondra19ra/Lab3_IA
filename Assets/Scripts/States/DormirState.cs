using UnityEngine;

public class DormirState : State
{
    float tiempo;

    public DormirState(FSMManager fsm) : base(fsm) { }

    public override void Enter()
    {
        steering.ActivateArrive(fsm.cama);
        tiempo = 5f;
    }

    public override void Execute()
    {
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            fsm.energia = 100;
            fsm.ChangeState(new JugarState(fsm));
        }
    }

    public override void Exit()
    {
        steering.Stop();
    }
}