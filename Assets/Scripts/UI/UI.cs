using UnityEngine;

public class UI : MonoBehaviour
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
    private MainPanel mainPanel = default;
    [SerializeField]
    private Music music = default;


    private void Awake()
    {
        chooseColors.Initialzation();
        choosePlayers.Initialzation();
        endgame.Initialzation();
        diceRoll.Initialzation();
        mainPanel.Initialzation();
        music.Initialzation();
    }


}
