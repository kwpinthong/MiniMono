using UnityEngine;

public sealed class Player : Character
{
    public Player(string _name, Color _color, Chip _chip)
    {
        this.Name = _name;
        this.color = _color;
        this.chip = _chip;
        this.DeadFlag = false;
        this.BotFlag = false;
    }
}
