using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Transform[] childObjects;
    private List<Transform> nodelist = new List<Transform>();

    private void GetNode()
    {
        nodelist.Clear();
        childObjects = GetComponentsInChildren<Transform>();
        foreach(Transform child in childObjects){
            if(child != this.transform && child.gameObject.tag!="Token"){
                nodelist.Add(child);
            }
        }
    }

    private void Start() => GetNode();
    public List<Transform> NodeList() => nodelist;
}
