using System.Collections;
using UnityEngine;

public class MissionEnnemiTotal : MonoBehaviour, Mission
{
    int ennemisDetruits = 0;
    int butEnnemiDetruits = 0;
    int recompense = 0;

    public bool EstComplete()
    {
        return ennemisDetruits < butEnnemiDetruits;
    }

    public IEnumerator ExecuterMission()
    {
        //a chaque ennemi tué: ennemisDetruits++;
        yield return null;
    }

    public int GetRecompense()
    {
        return recompense;
    }

    public void InstancierMission()
    {
        int dificulteAleatoire = Random.Range(1,5);
        butEnnemiDetruits = 10 * dificulteAleatoire;
        recompense = 5 * dificulteAleatoire;
        ennemisDetruits = 0;
    }

    public void terminerPartie()
    {
        //rien a faire
    }

    public string TexteMission()
    {
        return "Détruire un nombre total d'ennemis (" + ennemisDetruits + "/" + butEnnemiDetruits + ")";
    }

    //
    // codes faites par Ariel John Fajardo
    //

    public void IncrementerPts()
    {
        ennemisDetruits++;
    }
}
