using UnityEngine;

namespace MenuManager
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        private AudioSource MenuBG = default;
        [SerializeField]
        private AudioSource clickSound = default;
        [SerializeField]
        private AudioSource clickSoundEnter = default;

        [SerializeField]
        private Credit credit = default;
        [SerializeField]
        private StartGame icon = default;

        private void Awake()
        {
            icon.Initialzation(clickSoundEnter);
            credit.Initialzation(clickSound);
            // Delegate
            credit.OnOpenInfo = showCredit;
            credit.OnCloseInfo = closeCredit;
            icon.OnStartGame = IconStart;
        }

        private void Start()
        {
            MenuBG.Play();
        }

        private void IconStart(){ }
        private void showCredit(){ }
        private void closeCredit(){ }
    }
}
