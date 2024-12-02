using UnityEngine;

public class CanardAttackState : CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    public override void EnterState(CanardGererState canard)
    {

    }

    public override CanardBaseState UpdateState(CanardGererState canard)
    {
        // fonction n'existe pas encore
        // canard.GoAttack();

        // si l'ennemi n'est pas assez proche, il va chasser le canard.
        // sinon, repeter AttackState
        if (canard.IsChase() == true)
        {
            return new CanardChaseState();
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
