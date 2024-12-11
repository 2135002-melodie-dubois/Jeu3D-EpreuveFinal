using System.Collections;
using UnityEngine;

public class GenerateurEnnemi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Ennemi ennemi_objet;
    private Coroutine coroutine;

    public void Demmarer(Ennemi ennemi) 
    {
        ennemi_objet = ennemi;
        coroutine = StartCoroutine(JeuCoroutine());
    }
    public IEnumerator JeuCoroutine()
    {
        Ennemi ennemi = Instantiate(ennemi_objet,transform);
        ennemi.gameObject.transform.position = transform.position;

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
