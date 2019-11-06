using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    protected bool mainNode = false;
    protected string mateialName = string.Empty;
    protected List<Color> colort = new List<Color>();
    protected List<GameObject> tokens = new List<GameObject>();

    public void SetColor(Color c)
    {
        for (int i = 0; i < colort.Count; i++)
        {
            if (colort[i].Equals(Color.grey))
            {
                colort[i] = c;
                return;
            }
        }
    }

    public void RemoveToken(int index)
    {
        colort[index] = Color.grey;
    }

    public bool IsFull()
    {
        if (colort.Contains(Color.grey)) return false;
        return true;
    }

    public bool IsEmpty()
    {
        for (int i = 0; i < colort.Count; i++)
            if (!colort[i].Equals(Color.grey)) return false;
        return true;
    }

    public bool IsPlayerColor(Color color)
    {
        if (colort.Contains(color)) return true;
        else return false;
    }

    public List<Color> ListColors() => colort;
    public bool IsMainNode() => mainNode;
    public string MaterialName() => mateialName;
}

