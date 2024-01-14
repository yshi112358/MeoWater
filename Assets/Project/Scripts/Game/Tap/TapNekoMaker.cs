using UnityEngine;

public class TapNekoMaker : MonoBehaviour
{
    public void MakeNeko(NekoDataBase nekoData)
    {
        Instantiate(nekoData.nekoPrefab, transform.position, transform.rotation);
    }
}
