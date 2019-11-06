using UnityEngine;
public sealed class NodeTokens : Node
{
    private Transform[] childObjects;

    private void Start()
    {
        tokens.Clear();
        childObjects = GetComponentsInChildren<Transform>();
        foreach (Transform child in childObjects)
            if (child.gameObject.tag == "Token")
                tokens.Add(child.transform.gameObject);

        for (int i = 0; i < tokens.Count; i++)
            colort.Add(Color.grey);
    }

    private void Update()
    {
        tokens[0].GetComponent<Renderer>().material.color = colort[0];
        tokens[1].GetComponent<Renderer>().material.color = colort[1];
        tokens[2].GetComponent<Renderer>().material.color = colort[2];
    }
}
