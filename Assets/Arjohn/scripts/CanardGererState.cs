using UnityEngine;

public class CanardGererState : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl

    CanardBaseState currentState;
    CanardIdleState IdleState = new CanardIdleState();
    CanardAttackState AttackState = new CanardAttackState();
    CanardChaseState ChaseState = new CanardChaseState();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
