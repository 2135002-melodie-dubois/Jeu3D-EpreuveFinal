using UnityEngine;

public abstract class CanardBaseState
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl

    public abstract void EnterState(CanardGererState canard);

    public abstract void UpdateState(CanardGererState canard);

    public abstract void OnCollisionEnter(CanardGererState canard);
}
