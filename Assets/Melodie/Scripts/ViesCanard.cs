using UnityEngine;
using UnityEngine.UI;

public class ViesCanard : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite_coeur;
    [SerializeField]
    private GameObject conteneur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfficherCoeurs(int coeurs)
    {
        //Détruire tous les enfants
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //Créer les coeurs
        for (int i = 0; i < coeurs; i++)
        {
            GameObject coeur = new GameObject("Coeur" + i);
            coeur.transform.SetParent(transform);
            Image image = coeur.AddComponent<Image>();
            coeur.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 50);
            image.sprite = sprite_coeur;
        }
    }
}
