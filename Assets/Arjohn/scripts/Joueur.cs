using UnityEngine;

public class Joueur : MonoBehaviour
{
    // REFERENCES:
    // https://youtu.be/Cmx76-Q11tM?si=RLWWz6wH7TsgVlYB (Countdown Timers In Unity | Coroutines Tutorial 2024)

    public float ptsVie;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ptsVie = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (ptsVie <= 0)
        {
            //Destroy
        }
    }

    /// <summary>
    /// supprime de vie du joueur
    /// </summary>
    public void RetirerVie()
    {
        ptsVie--;
    }
}
