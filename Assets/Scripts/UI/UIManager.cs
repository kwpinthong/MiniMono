using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private ChooseColors chooseColors = default;
    [SerializeField]
    private ChoosePlayers choosePlayers = default;
    [SerializeField]
    private EndGame endgame = default;
    [SerializeField]
    private DiceRoll diceRoll = default;
    [SerializeField]
    private Music music = default;
    [SerializeField]
    private GameObject choosPlayerPanel = default;
    [SerializeField]
    private GameObject choosColorPanel = default;


    private void Awake()
    {
        choosColorPanel.SetActive(true);
        choosPlayerPanel.SetActive(true);

        chooseColors.Initialzation();
        choosePlayers.Initialzation();
        endgame.Initialzation();
        diceRoll.Initialzation();
        music.Initialzation();
    }


}
