using System.Collections;
using UnityEngine;

public class Epee : MonoBehaviour
{
    public EnnemiVie ennemiVie;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
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
