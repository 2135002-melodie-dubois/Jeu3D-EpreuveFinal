using UnityEngine;
using UnityEngine.Events;

public class EnnemiVie : MonoBehaviour
{
    // REFERENCES:
    // https://youtu.be/djW7g6Bnyrc?si=N559-g3AW0wFozDu (UnityEvents Explained in 4 Minutes)

    public float ptsVie;

    public UnityEvent ennemiMort;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ennemiMort.AddListener(GameObject.FindGameObjectWithTag("EnnemiPoint").GetComponent<GenerrateurEnnemiArj>().CreerBateau);
        ptsVie = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (ptsVie <= 0)
        {
            ennemiMort.Invoke();
            Destroy(gameObject);
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