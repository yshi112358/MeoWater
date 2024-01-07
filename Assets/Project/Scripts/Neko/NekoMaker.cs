using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Manager;
using Game.Neko;
using UnityEngine;

public class NekoMaker : MonoBehaviour
{
    public void MakeNeko(NekoData nekoData)
    {
        Instantiate(nekoData.gameObject, transform.position, transform.rotation);
    }
}
