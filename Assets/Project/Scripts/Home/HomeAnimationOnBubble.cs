using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAnimationOnBubble : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bubbleList;
    public void SetBubbleActive(){
        foreach(var bubble in _bubbleList){
            bubble.SetActive(true);
        }
    }
}
