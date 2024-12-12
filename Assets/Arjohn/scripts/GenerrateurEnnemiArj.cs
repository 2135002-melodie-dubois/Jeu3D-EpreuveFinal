using UnityEngine;
using UnityEngine.Events;

public class GenerrateurEnnemiArj : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemiBateau;

    /// <summary>
    /// script personelle pour generer un ennemi dans un point
    /// predetermine dans le bain. le script est cree car je 
    /// n'ai pas encore le moyen de tester l'ajout de point 
    /// pour le mission
    /// </summary>
    public void CreerBateau()
    {
        GameObject nouvelleEnnemi = Instantiate(ennemiBateau);
    }
}
