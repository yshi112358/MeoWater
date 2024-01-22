using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BookDetailDestory : MonoBehaviour
{
    public void DestoryPrevDetail()
    {
        Destroy(transform.Find("Detail").gameObject);
        transform.Find("Detail New").name = "Detail";
    }
}
