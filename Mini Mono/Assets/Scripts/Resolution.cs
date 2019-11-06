using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private const float min = 3.3f;
    public bool change = true;

    private void Update()
    {
        if (change)
            Camera.main.orthographicSize = 7.5f * Screen.height/ Screen.width * 0.5f;
        if (Camera.main.orthographicSize < min) Camera.main.orthographicSize = min;
    }
}
