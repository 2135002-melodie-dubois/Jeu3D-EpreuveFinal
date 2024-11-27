using TMPro;
using UnityEditor;
using UnityEngine;

public class Menus : MonoBehaviour
{
    //MenuBoutique gere ouverture/fermeture des menus
    [SerializeField]
    private MenuBoutique menuBoutique;
    [SerializeField]
    private MenuBoutique menuMissions;
    
    private int pieces;
    private int score;
    private int meilleur_score;

    //Valeurs du menu boutique
    [SerializeField]
    private int AmeliorationVieMax;
    [SerializeField]
    private EpeeObjet TypeEppeeAmelioree;
    private int NiveauVie;
    private bool EppeeAchetee;

    //Valeurs du UI de combat
    [SerializeField]
    private TextMeshProUGUI ui_score;
    [SerializeField]
    private TextMeshProUGUI ui_meilleur_score;
    [SerializeField]
    private TextMeshProUGUI ui_compteur_pieces;
    

    private void Start()
    {
        NiveauVie = 0;
        EppeeAchetee = false;
        pieces = 0;
        score = 0;
        meilleur_score = 0;

        UpdateScore();
        UpdateMeilleurScore();
        UpdatePieces();
    }

    public void AjouterScore(int valeur)
    {
        score += valeur;
        if (score > meilleur_score)
            meilleur_score = score;
        UpdateScore();
        UpdateMeilleurScore();
    }

    void UpdateScore()
    {
        ui_score.text = "Score: " + score.ToString();
    }

    public void UpdateMeilleurScore()
    {
        ui_meilleur_score.text = "Meilleur Score: " + meilleur_score.ToString();
    }

    public void UpdatePieces()
    {
        ui_compteur_pieces.text = pieces.ToString();
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
                UpdatePieces();
        }

    }

    public void AcheterVie()
    {
        if (NiveauVie < AmeliorationVieMax)
        {
            //Si assez Pieces
                NiveauVie++;
                //Retirer Pieces
                //Lancer un message: Augmenter Vie Max
                UpdatePieces();
            
        }
    }

    //Fonctions Du menu missions
    public void OuvrirMenuMissions()
    {
        menuMissions.OuvrirMenu();
    }

    public void FermerMenuMissions()
    {
        menuMissions.FermerMenu();
    }

    public void ExecuterMission()
    {

    }
}
