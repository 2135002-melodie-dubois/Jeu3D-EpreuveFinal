using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    private int NiveauVie;
    private int NiveauVitesse;
    [SerializeField]
    private int AmeliorationVitesseMax;

    //Valeurs du UI de combat
    [SerializeField]
    private TextMeshProUGUI ui_compteur_pieces;

    //Valeurs menu missions
    [SerializeField]
    private Mission[] missions;
    private List<Coroutine> coroutinesMissions;
    [SerializeField]
    private TextMeshProUGUI[] ui_texte_missions;

    //Autres elements
    public GenerateurEnnemi generateurEnnemi;
    [SerializeField]
    private GameObject ennemi;
    [SerializeField]
    private Joueur joueur;
    [SerializeField]
    private ViesCanard joueurviesCanard;
    private bool enCombat;
    [SerializeField]
    private CanvasGroup ui_normal;



    private void Start()
    {
        NiveauVie = 0;
        NiveauVitesse = 0;
        pieces = 0;
        score = 0;
        meilleur_score = 0;
        generateurEnnemi = new GenerateurEnnemi();
        enCombat = false;
        missions = new Mission[3];
        missions[0] = new MissionTemps();
        missions[1] = new MissionEnnemi();
        missions[2] = new MissionEnnemiTotal();

        foreach (var m in missions)
        {
            m.InstancierMission();
        }


        UpdatePieces();
    }

    private void Update()
    {
        joueurviesCanard.AfficherCoeurs((int)joueur.ptsVie);
        if (enCombat)
        {
            ui_normal.alpha = 0;
        }  
        else
        {
            ui_normal.alpha = 1;
        }
    }


    public void UpdatePieces()
    {
        ui_compteur_pieces.text = pieces.ToString();
    }

    public void DemmarerPartie()
    {
        enCombat = true;
        generateurEnnemi.Demmarer(ennemi);
        demmarerMissions();
        while (joueur.ptsVie > 0) { }
        terminerPartie();
    }

    public void terminerPartie()
    {
        terminerMissions();
        generateurEnnemi.Terminer();
        enCombat = false;
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

    public void AcheterVie()
    {
        if (NiveauVie < AmeliorationVieMax)
        {
            if (pieces >= 50)
            {
                NiveauVie++;
                pieces -= 50;
                //Ajouter au script joueur
                //joueur.AjouterVie();
                UpdatePieces();
            }
        }
    }
    public void AcheterVitesse()
    {
        if (NiveauVitesse < AmeliorationVitesseMax)
        {
            if (pieces >= 50)
            {
                NiveauVitesse++;
                pieces -= 50;
                //Ajouter au script Joueur
                //joueur.AjouterVitesse();
                UpdatePieces();
            }
        }
    }

    //Fonctions Du menu missions
    public void OuvrirMenuMissions()
    {
        menuMissions.OuvrirMenu();
        for (int i = 0; i < ui_texte_missions.Length; i++)
        {
            ui_texte_missions[i].text = missions[i].TexteMission();
        }
    }

    public void FermerMenuMissions()
    {
        menuMissions.FermerMenu();
    }

    public void ExecuterMission(int position)
    {
        Mission misson = missions[position];
        if (misson.EstComplete())
        {
            pieces += misson.GetRecompense();
            misson.InstancierMission();
        }
    }

    public void demmarerMissions()
    {
        coroutinesMissions = new List<Coroutine>();
        foreach (var m in missions)
        {
            coroutinesMissions.Add(StartCoroutine(m.ExecuterMission()));
        }
        
    }
    public void terminerMissions()
    {
        foreach (var c in coroutinesMissions)
        {
            StopCoroutine(c);
        }
    }
}
