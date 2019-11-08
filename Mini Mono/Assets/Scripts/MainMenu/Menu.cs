using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
        private GameObject text = default;
        [SerializeField]
        private Credit credit = default;
        [SerializeField]
        private StartGame icon = default;

        private bool isPlaying;

        private void Awake()
        {
            isPlaying = false;
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

        private void Update()
        {
            if (!isPlaying)
                StartCoroutine(Blink(1.0f));
        }

        private IEnumerator Blink(float time)
        {
            isPlaying = true;
            text.SetActive(false);
            yield return new WaitForSecondsRealtime(time);
            text.SetActive(true);
            yield return new WaitForSecondsRealtime(time);
            isPlaying = false;
        }

        private void IconStart(){ }
        private void showCredit(){ }
        private void closeCredit(){ }
    }
}
