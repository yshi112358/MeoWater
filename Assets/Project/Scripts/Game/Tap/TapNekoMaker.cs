using UnityEngine;
using UniRx;
public class TapNekoMaker : MonoBehaviour
{
    public ReactiveCollection<GameObject> nekoList => _nekoList;

    private ReactiveCollection<GameObject> _nekoList = new ReactiveCollection<GameObject>();
    public void MakeNeko(NekoDataBase nekoData)
    {
        _nekoList.Add(Instantiate(nekoData.nekoPrefab, transform.position, transform.rotation));
    }
}
