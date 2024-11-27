using UnityEngine;

[CreateAssetMenu(fileName = "EpeeObjet", menuName = "Eppee")]
public class EpeeObjet : ScriptableObject
{
    [SerializeField]
    private int valeur;

    [SerializeField]
    private Material texture;

    [SerializeField]
    private int multiplicateur;
    
}
