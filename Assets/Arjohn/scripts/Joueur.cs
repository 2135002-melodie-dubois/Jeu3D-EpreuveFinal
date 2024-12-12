using System.Collections;
using UnityEngine;

public class Joueur : MonoBehaviour
{
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
            Destroy(gameObject);
            Debug.Log("T'as perdu le jeu!");
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
