using UnityEngine;

public class MenuMissions : MonoBehaviour
{

    private CanvasGroup menu;

    private void Start()
    {
        menu = GetComponent<CanvasGroup>();
    }
    public void FermerMenu()
    {
        menu.alpha = 0;
        menu.interactable = false;
        menu.blocksRaycasts = false;
    }

    public void OuvrirMenu()
    {
        menu.alpha = 1;
        menu.interactable = true;
        menu.blocksRaycasts = true;
    }
}
