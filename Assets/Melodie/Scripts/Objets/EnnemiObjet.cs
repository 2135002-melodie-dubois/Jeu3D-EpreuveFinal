using UnityEngine;

[CreateAssetMenu(fileName = "Ennemi", menuName = "Ennemi")]
public class EnnemiObjet : ScriptableObject
{
    [SerializeField]
    public float vitesse;

    [SerializeField]
    public int tempsChasse;
    
}
