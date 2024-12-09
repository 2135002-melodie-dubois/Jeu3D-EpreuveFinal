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
        float tempsDepuisDebut = 0.0f;

        tempsDepuisDebut += Time.deltaTime;
        if (tempsDepuisDebut >= 1)
        {
            tempsDepuisDebut -= 1;
            tempsSurvie++;
            if (tempsSurvie > meilleurScore)
            {
                meilleurScore = tempsSurvie;
            }
        }
        
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
        return "Survivre" + butTempsSurvie + "secondes (" + meilleurScore + "/" + butTempsSurvie + "";
    }
}
