using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    [SerializeField]
    private Controller controller = default;
    [SerializeField]
    private GameObject endgame = default;
    [SerializeField]
    private Button restartButton = default;
    [SerializeField]
    private Button menuButton = default;

    public void Initialzation()
    {
        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(Menu);
    }

    private void Update()
    {
        if (controller.IsEndGame())
            endgame.SetActive(true);
    }

    private void RestartGame() => SceneManager.LoadScene("main");
    private void Menu() => SceneManager.LoadScene("menu");
}
