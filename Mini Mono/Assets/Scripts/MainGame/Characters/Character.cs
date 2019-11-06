using UnityEngine;

public abstract class Character
{
    protected string Name;
    protected Color color;
    protected Chip chip;
    protected bool DeadFlag;
    protected bool BotFlag;

    public string GetName() => this.Name;
    public Color GetColor() => this.color;
    public Chip GetChip() => this.chip;
    public bool IsDead() => this.DeadFlag;
    public bool IsBot() => this.BotFlag;
    public void SetDeadFlag(bool Dead) => this.DeadFlag = Dead;
}

