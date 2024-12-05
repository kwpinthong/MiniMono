using StarterKit.AudioManagerLib;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField]
    private Image dice = default;
    [SerializeField]
    private Button rollButton = default;
    [SerializeField]
    private Controller controller = default;
    [SerializeField]
    private Image[] diceSides;

    public void Initialzation()
    {
        diceSides = dice.GetComponentsInChildren<Image>();
        rollButton.onClick.AddListener(RollDice);
        dice.sprite = diceSides[1].sprite;
    }

    private void Update()
    {
        if (!controller.IsCoroutineAllowed())
        {
            rollButton.gameObject.SetActive(false);
            dice.sprite = diceSides[controller.Roll()].sprite;
        }
        else
        {
            rollButton.gameObject.SetActive(true);
        }
    }

    private void RollDice()
    {
        controller.UI_RollDice();
        AudioManager.PlaySound("RollSound");
    }
}
