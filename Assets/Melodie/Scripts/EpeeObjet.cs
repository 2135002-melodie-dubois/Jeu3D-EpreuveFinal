using UnityEngine;

[CreateAssetMenu(fileName = "EpeeObjet", menuName = "Une Eppee")]
public class EpeeObjet : ScriptableObject
{
    [SerializeField]
    private int degats;

    [SerializeField]
    private int valeur;

    [SerializeField]
    private Material texture;

    private void Attaquer()
    {
        //ATTAQUE
    }
    
}
