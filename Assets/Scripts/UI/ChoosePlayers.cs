using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayers : MonoBehaviour
{
    [SerializeField]
    private AudioList audioList = default;
    [SerializeField]
    private Button increaseButton = default;
    [SerializeField]
    private Button decreaseButton = default;
    [SerializeField]
    private Button nextButton = default;
    [SerializeField]
    private Text numberPlayer = default;
    [SerializeField]
    private GameObject choosePlayers = default;

    private int number;
    private List<PlayerConfig> playerConfigs;

    public void Initialzation()
    {
        number = 2;
        playerConfigs = new List<PlayerConfig>();
        increaseButton.onClick.AddListener(Increase);
        decreaseButton.onClick.AddListener(Decrease);
        nextButton.onClick.AddListener(NextChooseColors);
    }

    private void Increase()
    {
        audioList.clickSound.Play();
        if (number >= 4) number = 2;
        else number++;
    }

    private void Decrease()
    {
        audioList.clickSound.Play();
        if (number <= 2) number = 4;
        else number--;
    }

    private void NextChooseColors()
    {
        audioList.click8bit.Play();
        playerConfigs.Clear();
        for (int i = 0; i < number; i++)
        {
            string name = "PlayerConfig " + (i + 1).ToString();
            if (GameObject.Find(name))
            {
                playerConfigs.Add(GameObject.Find(name).GetComponent<PlayerConfig>());
                playerConfigs[i].ClosePanel(false);
            }
        }
        choosePlayers.SetActive(false);
    }

    private void Update()
    {
        numberPlayer.text = number.ToString();
    }

    public int GetNumber() => number ;
    public List<PlayerConfig> GetPlayerConfigs() => playerConfigs;
}
