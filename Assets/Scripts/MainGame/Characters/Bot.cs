using UnityEngine;

public sealed class Bot : Character
{
    public Bot(string _name, Color _color, Chip _chip)
    {
        this.Name = _name;
        this.color = _color;
        this.chip = _chip;
        this.DeadFlag = false;
        this.BotFlag = true;
    }
}
