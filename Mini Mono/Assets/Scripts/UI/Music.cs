using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioList audioList = default;
    [SerializeField]
    private Image music = default;
    [SerializeField]
    private Button muteButton = default;
    private Image[] images;

    public void Initialzation()
    {
        images = music.GetComponentsInChildren<Image>();
        muteButton.onClick.AddListener(MuteMusic);
        music.sprite = images[1].sprite;
    }

    private void MuteMusic()
    {
        if (audioList.mainBG.mute == false)
        {
            audioList.mainBG.mute = true;
            music.sprite = images[2].sprite;
        }
        else
        {
            audioList.mainBG.mute = false;
            music.sprite = images[1].sprite;
        }

    }
}
