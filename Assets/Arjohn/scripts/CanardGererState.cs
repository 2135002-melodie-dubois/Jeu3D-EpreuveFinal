using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CanardGererState : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/Vt8aZDPzRjI?si=vky1X70Ao43ZDoHl (How to Program in Unity: State Machines Explained)
    // https://youtu.be/UjkSFoLxesw?si=jTUd7VaeAo0Ox9G_ (FULL 3D ENEMY AI in 6 MINUTES! || Unity Tutorial)
    // https://youtu.be/zNdGUUOohzE?si=2gZ30PdsSnO-n8Vl (Create a Simple Enemy AI in Unity: Player Detection and Chasing)
    // https://youtu.be/Cmx76-Q11tM?si=RLWWz6wH7TsgVlYB (Countdown Timers In Unity | Coroutines Tutorial 2024)

    public CanardBaseState currentState;
    public Joueur joueur;
    public EnnemiVie ennemiVie;
    private BoxCollider boxCollider;

    private NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsWater, whatIsPlayer;
    public float distance;

    // evenement quand on detruit l'ennemi
    public UnityEvent<CanardGererState> OnDestEnnemi;

    // IDLE
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // ATTAQUER
    private float vitesseDash;

    // STATES
    public float sightRange, attackRange;

    void Awake()
    {
        player = GameObject.Find("Joueur").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        boxCollider = GetComponent<BoxCollider>();
        sightRange = 1f;
        attackRange = .25f;
        walkPointRange = 2f;
        vitesseDash = 5;
        // state debutant pour la machine a etat
        currentState = new CanardIdleState();
        // "this" est une reference de la contexte (cet exact MonoBehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        // il va caller tous les logiques dans les fonctions Update() dans le state actuel
        currentState = currentState.UpdateState(this);

        // chequer si le joueur est dans le vue de l'ennemi
        distance = Vector3.Distance(agent.transform.position, player.transform.position);
        //Debug.Log(currentState);

        // chequer si le joueur est assez proche pour l'attaquer
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

    /// <summary>
    /// l'ennemi entre dans un state Idle
    /// </summary>
    public void GoIdle()
    {
        //Debug.Log("je suis idle!");
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            //Debug.Log(agent.SetDestination(walkPoint));

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            // si l'ennemi est dans sa destination
            if (distanceToWalkPoint.magnitude < 0.5f || Mathf.Approximately(agent.velocity.sqrMagnitude, 0.0f))
            {
                walkPointSet = false;
            }
        }
    }

    /// <summary>
    /// l'ennemi entre dans un state Chase
    /// </summary>
    public void GoChase()
    {
        //Debug.Log("je te chasse!");
        agent.SetDestination(player.transform.position);
        //   Debug.Log(agent.SetDestination(player.transform.position));
    }

    /// <summary>
    /// l'ennemi entre dans un state Attaque
    /// </summary>
    public void GoAttack()
    {
        //Debug.Log("je t'attaque!");
        agent.SetDestination(player.position * vitesseDash);
        // changer vitesse pour chasser le joueur plus vite, donne l'air comme un "dash".
        // aussi attaquer dans un position de joueur qui etait la et non le position actuelle du joueur

        //   Debug.Log(agent.SetDestination(player.transform.position));
    }

    /// <summary>
    /// IDLE l'ennemi cherche un point aleatoire dans le bain
    /// </summary>
    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsWater))
        {
            walkPointSet = true;
        }
    }

    /// <summary>
    /// ATTACK si l'ennemi a touche le joueur, le joueur perd de vie
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Debug.Log("l'ennemi a touche le joueur!");
            StartCoroutine(PrendVie());
        }
    }

    /// <summary>
    /// Retirer un point de vie du joueur
    /// </summary>
    /// <returns></returns>
    private IEnumerator PrendVie()
    {
        joueur.RetirerVie();
        DisableAttack();
        yield return new WaitForSeconds(3);
        EnableAttack();
    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }

    /// <summary>
    /// si l'ennemi ne voit pas le joueur ni le joueur n'est pas assez proche de l'ennemi, il reste idle
    /// </summary>
    /// <returns></returns>
    public bool IsIdle()
    {
        if (distance > sightRange)
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
        if (distance < sightRange && distance > attackRange)
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
        if (distance < attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnDestroy()
    {
        // spawner un nouveau ennemi
    }
}
