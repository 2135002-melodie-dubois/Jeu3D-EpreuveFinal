using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    [SerializeField]
    private EnnemiObjet type_Ennemi;

    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = type_Ennemi.vitesse;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
