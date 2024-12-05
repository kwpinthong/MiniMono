using System.Collections;
using System.Collections.Generic;
using StarterKit.AudioManagerLib;
using UnityEngine;
using UnityEngine.UI;

public sealed class ChooseColors : Panel
{
    [SerializeField]
    private Controller controller = default;
    [SerializeField]
    private Button BackButton = default;
    [SerializeField]
    private Button startButton = default;
    [SerializeField]
    private Text popupText = default;
    [SerializeField]
    private GameObject popup = default;
    [SerializeField]
    private List<PlayerConfig> playerConfigs;

    private int count;
    
    public override void Initialize()
    {
        BackButton.onClick.AddListener(BackChoosePlayers);
        startButton.onClick.AddListener(StartGame);
    }
    
    private void OnEnable()
    {
        count = 0;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        var number = UI.ChoosePlayers.GetNumber();
        for (int i = 0; i < playerConfigs.Count; i++)
        {
            playerConfigs[i].SetIamBotPanelActive(i >= number);
            playerConfigs[i].SetColor(i);
        }
    }

    private void BackChoosePlayers()
    {
        AudioManager.PlaySound("Click8bit");
        foreach (PlayerConfig config in playerConfigs)
            config.SetIamBotPanelActive(true);
        UI.ChoosePlayers.Open();
        UI.ChooseColors.Close();
    }

    private void StartGame()
    {
        StopAllCoroutines();
        count++;
        if (count > 7)
        {
            // a little bit of humor, when player tries to
            // click next button more than 7 times
            popupText.text = "Damn you!, Change it!";
        }
        controller.UI_EnterGame();
        if (controller.IsDoneSetting())
        {
            AudioManager.PlaySound("GameStart");
            UI.ChoosePlayers.Close();
            UI.ChooseColors.Close();
        }
        else
        {
            StartCoroutine(PopError(1f));
            AudioManager.PlaySound("ErrorSound");
        }
    }

    private IEnumerator PopError(float time)
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(time);
        popup.SetActive(false);
    }
}


