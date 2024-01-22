using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BookDetailGenerator : MonoBehaviour
{
    [SerializeField] private NekoDataBaseList _nekoDataBaseList;
    [SerializeField] private BookDetailSwitcher _bookDetailSwitcher;
    [SerializeField] private GameObject _bookDetailSecret;
    void Start()
    {
        _bookDetailSwitcher.index
            .Where(index => index >= 0)
            .Subscribe(index =>
            {
                GameObject detailObject = null;
                if (index >= _nekoDataBaseList.nekoDataBaseList.Count)
                {
                    detailObject = _bookDetailSecret;
                }
                else
                {
                    var nekoDataBase = _nekoDataBaseList.nekoDataBaseList[index];
                    detailObject = nekoDataBase.bookDetail;
                }

                var bookDetail = Instantiate(detailObject, transform);
                bookDetail.transform.SetParent(transform);
                bookDetail.transform.localPosition = Vector3.zero;

            
                if(transform.Find("Detail") == null)
                    bookDetail.name = "Detail";
                else
                    bookDetail.name = "Detail New";
            })
            .AddTo(this);
    }
}
