using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

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

    void OnTaper()
    {
        //donner type_ennemi.points points
    }
}
