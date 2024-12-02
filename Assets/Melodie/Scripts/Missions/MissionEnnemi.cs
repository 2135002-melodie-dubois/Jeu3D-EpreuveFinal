using System.Collections;
using UnityEngine;

public class MissionEnnemi : MonoBehaviour, Mission
{
    int ennemisDetruits = 0;
    int butEnnemiDetruits = 0;
    int meilleurScore = 0;
    int recompense = 0;

    public bool EstComplete()
    {
        return meilleurScore >= butEnnemiDetruits;
    }

    public IEnumerator ExecuterMission()
    {
        //a chaque ennemi tué: ennemisDetriuts++
        //si ennemisDetruits > meilleurScore, meilleurScore = ennemisDetruits
        yield return null;
    }

    public int GetRecompense()
    {
        return recompense;
    }

    public void InstancierMission()
    {
        int dificulteAleatoire = Random.Range(1, 5);
        meilleurScore = 0;
        butEnnemiDetruits = 5 * dificulteAleatoire;
        recompense = 10 * dificulteAleatoire;
        ennemisDetruits = 0;
    }

    public void terminerPartie()
    {
        ennemisDetruits = 0;
    }

    public string TexteMission()
    {
        return "Détruire des ennemis ("+ meilleurScore +"/"+ butEnnemiDetruits +")" ;
    }
}
