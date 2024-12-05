using System.Collections.Generic;
using StarterKit.AudioManagerLib;
using UnityEngine;
using UnityEngine.UI;

public sealed class ChoosePlayers : Panel
{
    private const int DefaultChoosePlayers = 1;
    private const int MaxChoosePlayers = 4;
    
    [SerializeField]
    private Button increaseButton = default;
    [SerializeField]
    private Button decreaseButton = default;
    [SerializeField]
    private Button nextButton = default;
    [SerializeField]
    private Text numberPlayer = default;
    [SerializeField]
    private List<PlayerConfig> playerConfigs;

    private int number;

    public override void Initialize()
    {
        increaseButton.onClick.AddListener(Increase);
        decreaseButton.onClick.AddListener(Decrease);
        nextButton.onClick.AddListener(NextChooseColors);
        number = DefaultChoosePlayers;
        UpdateNumberPlayerText();
    }

    protected override void PreOpen()
    {
        base.PreOpen();
        UpdateNumberPlayerText();
    }

    private void Increase()
    {
        AudioManager.PlaySound("ClickSound");
        number = number >= MaxChoosePlayers ? DefaultChoosePlayers : number + 1;
        UpdateNumberPlayerText();
    }

    private void Decrease()
    {
        AudioManager.PlaySound("ClickSound");
        number = number <= DefaultChoosePlayers ? MaxChoosePlayers : number - 1;
        UpdateNumberPlayerText();
    }

    private void NextChooseColors()
    {
        AudioManager.PlaySound("Click8bit");
        UI.ChooseColors.Open();
        UI.ChoosePlayers.Close();
    }
    
    private void UpdateNumberPlayerText()
    {
        numberPlayer.text = $"{number}";
    }

    public int GetNumber() => number ;
    public List<PlayerConfig> GetPlayerConfigs() => playerConfigs;
}
