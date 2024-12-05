using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MenuManager
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField]
        private Button iconButton = default;
        private AudioSource EnterSound;

        public delegate void ButtonClick();
        public ButtonClick OnStartGame;

        public void Initialzation(AudioSource sound)
        {
            EnterSound = sound;
            iconButton.onClick.AddListener(ToStartGame);
        }

        private void ToStartGame()
        {
            EnterSound.Play();
            SceneManager.LoadScene("main");
        }
    }
}