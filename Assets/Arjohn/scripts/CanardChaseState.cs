using UnityEngine;

public class CanardChaseState : CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    public override void EnterState(CanardGererState canard)
    {

    }

    public override CanardBaseState UpdateState(CanardGererState canard)
    {
        canard.GoChase();

        // si l'ennemi est assez proche, il va attaquer le canard.
        // si l'ennemi est assez loin, il va rester inactif.
        // sinon, continue de chasser le canard
        if (canard.IsAttaque() == true)
        {
            return new CanardAttackState();
        }
        else if (canard.IsIdle() == true)
        {
            return new CanardIdleState();
        }
        else
        {
            return this;
        }
    }

    public override void OnCollisionEnter(CanardGererState canard)
    {

    }
}
