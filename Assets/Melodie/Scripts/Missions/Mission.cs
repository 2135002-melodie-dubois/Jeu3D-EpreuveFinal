using System.Collections;
using UnityEngine;

public interface Mission
{
    string TexteMission();
    IEnumerator ExecuterMission();
    void InstancierMission();
    bool EstComplete();
    int GetRecompense();
    void terminerPartie();
}
