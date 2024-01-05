using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoCollisionData : MonoBehaviour
{
    private List<GameObject> Neko=new List<GameObject>();

    public void AddCollisionData(GameObject neko)
    {
        if(!Neko.Contains(neko))
            Neko.Add(neko);
    }
    public void RemoveCollisionData(GameObject neko)
    {
        if(Neko.Contains(neko))
            Neko.Remove(neko);
    }
}
