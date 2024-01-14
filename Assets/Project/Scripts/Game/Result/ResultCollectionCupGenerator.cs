using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCollectionCupGenerator : MonoBehaviour
{
    void Awake()
    {
        int index = 1;
        foreach (var neko in NekoSelectionManager.nekoDataBaseListStatic)
        {
            var nekoScoreCup = Instantiate(neko.nekoCupCollection, transform);
            nekoScoreCup.name = "Cup Result Parent " + index;
            index++;
        }
    }
}
