using UnityEngine;
using UnityEngine.UI;

namespace MenuManager
{
    public class Credit : MonoBehaviour
    {
        [SerializeField]
        private GameObject creditInfo = default;
        [SerializeField]
        private Button closeButton = default;
        [SerializeField]
        private Button openButton = default;
        private AudioSource clicksound;

        public delegate void ButtonClick();
        public ButtonClick OnOpenInfo;
        public ButtonClick OnCloseInfo;

        public void Initialzation(AudioSource sound)
        {
            clicksound = sound;
            closeButton.onClick.AddListener(hide);
            openButton.onClick.AddListener(show);
        }

        private void show()
        {
            clicksound.Play();
            creditInfo.SetActive(true);
        }

        private void hide()
        {
            clicksound.Play();
            creditInfo.SetActive(false);
        }
   
    }
}
