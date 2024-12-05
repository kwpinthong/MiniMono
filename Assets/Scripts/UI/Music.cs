using StarterKit.AudioManagerLib;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField]
    private Image music = default;
    [SerializeField]
    private Button muteButton = default;
    [SerializeField]
    private Sprite muteMusic;
    [SerializeField]
    private Sprite unmuteMusic;

    public void Initialzation()
    {
        muteButton.onClick.AddListener(MuteMusic);
        music.sprite = unmuteMusic;
    }

    private void MuteMusic()
    {
        if (AudioManager.IsBGMMute)
        {
            AudioManager.MuteBGM(false);
            music.sprite = unmuteMusic;
        }
        else
        {
            AudioManager.MuteBGM(true);
            music.sprite = muteMusic;
        }
    }
}
