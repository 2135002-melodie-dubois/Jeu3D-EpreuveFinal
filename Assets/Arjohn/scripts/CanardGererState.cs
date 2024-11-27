using UnityEngine;
using UnityEngine.AI;

public class CanardGererState : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_

    CanardBaseState currentState;
    public CanardIdleState IdleState = new CanardIdleState();
    public CanardAttackState AttackState = new CanardAttackState();
    public CanardChaseState ChaseState = new CanardChaseState();

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // IDLE
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // ATTAQUER
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // STATES
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // state debutant pour la machine a etat
        currentState = IdleState;
        // "this" est une reference de la contexte (cet exact MonoBehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        // il va caller tous les logiques dans les fonctions Update() dans le state actuel
        currentState.UpdateState(this);

        // chequer si le joueur est dans le vue de l'ennemi
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        // chequer si le joueur est assez proche pour l'attaquer
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    }

    public void GoIdle()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // si l'ennemi est dans sa destination
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    public void GoChase()
    {
        agent.SetDestination(player.position);
    }

    /// <summary>
    /// changer state
    /// </summary>
    /// <param name="state">state de l'ennemi(IDLE, CHASE, ATTAQUE)</param>
    public void SwitchState(CanardBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    /// <summary>
    /// si l'ennemi ne voit pas le joueur ni le joueur n'est pas assez proche de l'ennemi, il reste idle
    /// </summary>
    /// <returns></returns>
    public bool IsIdle()
    {
        if (!playerInSightRange && !playerInAttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// si le joueur est dans le vue mais pas assez proche de l'ennemi, il va chaser
    /// </summary>
    /// <returns></returns>
    public bool IsChase()
    {
        if (playerInSightRange && !playerInAttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// si le joueur est dans le vue et assez proche de l'ennemi, il va attaquer
    /// </summary>
    /// <returns></returns>
    public bool IsAttaque()
    {
        if (playerInSightRange && playerInAttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
