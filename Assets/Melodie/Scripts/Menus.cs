using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    private TextMeshProUGUI ui_score;
    [SerializeField]
    private TextMeshProUGUI ui_meilleur_score;
    [SerializeField]
    private TextMeshProUGUI ui_compteur_pieces;

    //Valeurs menu missions
    [SerializeField]
    private Mission[] missions;
    private List<Coroutine> coroutinesMissions;
    [SerializeField]
    private TextMeshProUGUI[] ui_texte_missions;

    //UnityEvents
    public UnityEvent<int> OnAmeliorerVitesse;
    public UnityEvent<int> OnAmeliorerVie;



    private void Start()
    {
        NiveauVie = 0;
        NiveauVitesse = 0;
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

    public void DemmarerPartie()
    {
        //Lancer un message: Demarer Partie
        demmarerMissions();
        terminerMissions();
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
                OnAmeliorerVie?.Invoke(1);
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
                OnAmeliorerVie?.Invoke(1);
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
