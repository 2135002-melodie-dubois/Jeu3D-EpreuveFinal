using System.Collections;
using UnityEngine;

public class Epee : MonoBehaviour
{
    private EnnemiVie ennemiVie;
    private BoxCollider boxCollider;

    void Start()
    {
        ennemiVie = GameObject.FindGameObjectWithTag("Ennemi").GetComponent<EnnemiVie>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        //j'ecrit ca pour les ennemis qui va etre creer par le generateur
        ennemiVie = GameObject.FindGameObjectWithTag("Ennemi").GetComponent<EnnemiVie>();
    }

    /// <summary>
    /// si on touche l'ennemi avec l'epee, on diminue sa vie
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ennemi")
        {
            //Debug.Log("on frappe l'ennemi!");
            StartCoroutine(PerdVie());
        }
    }

    /// <summary>
    /// Coroutine pour eviter un mort vit de notre ennemi
    /// le collider de notre epee se desactive pendant une
    /// seconde apres de toucher l'ennemi
    /// </summary>
    /// <returns></returns>
    private IEnumerator PerdVie()
    {
        ennemiVie.RetirerVie();
        DisableAttack();
        yield return new WaitForSeconds(1);
        EnableAttack();
    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }
}
