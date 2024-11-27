using UnityEditor;
using UnityEngine;

public class Menus : MonoBehaviour
{
    [SerializeField]
    private MenuBoutique menuBoutique;
    //Le menu missions pourrait etre un autre menu boutique
    [SerializeField]
    private MenuMissions menuMissions;
    private int pieces;

    //Valeurs du menu boutique
    [SerializeField]
    private int AmeliorationVieMax;
    [SerializeField]
    private EpeeObjet TypeEppeeAmelioree;
    private int NiveauVie;
    private bool EppeeAchetee;

    private void Start()
    {
        NiveauVie = 0;
        EppeeAchetee = false;
        pieces = 0;
    }

    //Fonctions Du Menu Boutique
    public void OuvrirMenuBoutique()
    {
        menuBoutique.OuvrirMenu();
    }

    public void FermerMenuBoutique()
    {
        menuBoutique.FermerMenu();
    }

    
    public void AcheterEppee()
    {
        if (!EppeeAchetee)
        {
            //Si Assez Pieces
                EppeeAchetee = true;
                //Retirer Pieces
                //Lancer un message: Ameliorer l'eppee
        }

    }

    public void AcheterVie()
    {
        if (NiveauVie < AmeliorationVieMax)
        {
            //Si assez Pieces
                //Retirer Pieces
                //Lancer un message: Augmenter Vie Max
        }
    }

    //Fonctoins Du menu missions
    public void OuvrirMenuMissions()
    {
        menuMissions.OuvrirMenu();
    }

    public void FermerMenuMissions()
    {
        menuMissions.FermerMenu();
    }
}
