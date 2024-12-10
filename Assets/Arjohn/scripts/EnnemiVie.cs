using UnityEngine;

public class EnnemiVie : MonoBehaviour
{
    public float ptsVie;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ptsVie = 5;
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
