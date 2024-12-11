using System.Collections;
using UnityEngine;

public class GenerateurEnnemi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ennemi_objet;
    private Coroutine coroutine;

    public void Demmarer(GameObject ennemi) 
    {
        ennemi_objet = ennemi;
        coroutine = StartCoroutine(JeuCoroutine());
    }
    public IEnumerator JeuCoroutine()
    {
        GameObject ennemi = Instantiate(ennemi_objet);

        yield return new WaitForSeconds(5);
    }
    public void Terminer() 
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
