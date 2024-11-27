using UnityEngine;
using UnityEngine.AI;

public class CanardIdleState : CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    public override void EnterState(CanardGererState canard)
    {
        
    }

    public override void UpdateState(CanardGererState canard)
    {
        canard.GoIdle();

        if (canard.IsChase() == true)
        {
            canard.SwitchState(canard.ChaseState);
        }
    }

    public override void OnCollisionEnter(CanardGererState canard)
    {

    }
}
