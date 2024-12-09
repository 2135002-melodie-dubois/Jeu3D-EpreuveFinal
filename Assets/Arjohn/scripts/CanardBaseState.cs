using UnityEngine;

public abstract class CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    // IDLE > CHASE > ATTAQUER > CHASE > IDLE || IDLE > CHASE > IDLE   

    public abstract void EnterState(CanardGererState canard);

    public abstract CanardBaseState UpdateState(CanardGererState canard);

    public abstract void OnCollisionEnter(CanardGererState canard);
}
