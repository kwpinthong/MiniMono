using UnityEngine;

public class UI : MonoBehaviour
{
    private static UI instance;
    
    public static ChooseColors ChooseColors => instance.chooseColors;
    public static ChoosePlayers ChoosePlayers => instance.choosePlayers;
    
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
        instance = this;
    }

    private void Start()
    {
        chooseColors.Initialize();
        choosePlayers.Initialize();
        endgame.Initialzation();
        diceRoll.Initialzation();
        mainPanel.Initialzation();
        music.Initialzation();
    }
}
