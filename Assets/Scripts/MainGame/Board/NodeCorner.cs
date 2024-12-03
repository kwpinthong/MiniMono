using UnityEngine;

public sealed class NodeCorner : Node
{
    private void Start()
    {
        if (this.tag == "mainNode")
        {
            mainNode = true;
            mateialName = this.GetComponent<Renderer>().material.name;
        }
    }
}
