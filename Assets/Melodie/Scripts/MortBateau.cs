using UnityEngine;

public class MortBateau : IEnnemiMort
{
    public void Mourrir()
    {
        Debug.Log("Bateau Mort");
    }
}
