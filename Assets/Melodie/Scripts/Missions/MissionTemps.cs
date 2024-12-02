using System.Collections;
using UnityEngine;

public class MissionTemps : MonoBehaviour, Mission
{
    int tempsSurvie = 0;
    int butTempsSurvie = 0;
    int meilleurScore = 0;
    int recompense = 0;
    public bool EstComplete()
    {
        return meilleurScore >= butTempsSurvie;
    }

    public IEnumerator ExecuterMission()
    {
        //Attendre 1 seconde
        //tempsSurvie++
        //si tempsSurvie > meilleurScore, meilleurScore = tempsSurvie
        yield return null;
    }

    public int GetRecompense()
    {
        return recompense;
    }

    public void InstancierMission()
    {
        int dificulteAleatoire = Random.Range(1, 4);
        meilleurScore = 0;
        butTempsSurvie = 30 * dificulteAleatoire;
        recompense = 10 * dificulteAleatoire;
        tempsSurvie = 0;
    }

    public void terminerPartie()
    {
        tempsSurvie = 0;
    }

    public string TexteMission()
    {
        return "Survivre" + butTempsSurvie + "secondes (" + meilleurScore + "/" + butTempsSurvie + ")";
    }
}
