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

    public override CanardBaseState UpdateState(CanardGererState canard)
    {
        canard.GoIdle();

        // si l'ennemi 'vois' le canard, il va chasser.
        // sinon, rester inactif
        if (canard.IsChase() == true)
        {
            //Debug.Log("suppose de chase");
            return new CanardChaseState();
        } 
        return this;
    }

    public override void OnCollisionEnter(CanardGererState canard)
    {

    }
}
