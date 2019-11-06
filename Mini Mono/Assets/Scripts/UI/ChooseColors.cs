using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseColors : MonoBehaviour
{
    [SerializeField]
    private AudioList audioList = default;
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
    private GameObject choosePlayers = default;
    [SerializeField]
    private GameObject chooseColors = default;
    [SerializeField]
    private ChoosePlayers m_choosePlayers = default;

    private int count;
    private List<PlayerConfig> playerConfigs;

    public void Initialzation()
    {
        count = 0;
        playerConfigs = new List<PlayerConfig>();
        BackButton.onClick.AddListener(BackChoosePlayers);
        startButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        playerConfigs = m_choosePlayers.GetPlayerConfigs();
    }

    private void BackChoosePlayers()
    {
        audioList.click8bit.Play();
        foreach (PlayerConfig config in playerConfigs)
            config.ClosePanel(true);
        choosePlayers.SetActive(true);
    }

    private void StartGame()
    {
        StopAllCoroutines();
        count++;
        if (count > 7)
            popupText.text = "Damn you!, Change it!";

        controller.UI_EnterGame();
        if (controller.IsDoneSetting())
        {
            audioList.gameStart.Play();
            chooseColors.SetActive(false);
        }
        else
        {
            StartCoroutine(PopError(1f));
            audioList.errorSound.Play();
        }
    }

    private IEnumerator PopError(float time)
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(time);
        popup.SetActive(false);
    }
}


