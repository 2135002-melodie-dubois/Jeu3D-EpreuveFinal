using System.Collections;
using UnityEngine;

public class GenerateurEnnemi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Demmarer() 
    {
        Coroutine coroutine = StartCoroutine(JeuCoroutine());
    }
    public IEnumerator JeuCoroutine()
    {
        Ennemi ennemi = new Ennemi();
        yield return null;
    }
    private void Terminer() { }
}
