using UnityEngine;

public class CanardChaseState : CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    public override void EnterState(CanardGererState canard)
    {

    }

    public override void UpdateState(CanardGererState canard)
    {
        canard.GoChase();

        if (canard.IsAttaque() == true)
        {
            canard.SwitchState(canard.AttackState);
        }
        else if (canard.IsIdle() == true)
        {
            canard.SwitchState(canard.IdleState);
        }
    }

    public override void OnCollisionEnter(CanardGererState canard)
    {

    }
}
