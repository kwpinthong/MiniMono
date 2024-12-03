using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerColor", menuName = "MiniMono/PlayerColor")]
public class PlayerColor : ScriptableObject
{
    public List<Color> PlayerColors = new List<Color>
    {
        Color.blue, 
        Color.red, 
        Color.yellow, 
        Color.green
    };

    public Color GetColor(int index) => index >= 0 && index < PlayerColors.Count ? PlayerColors[index] : Color.black;
}
