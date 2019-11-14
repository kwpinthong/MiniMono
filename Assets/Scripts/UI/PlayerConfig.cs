using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField]
    private Button nextButton = default;
    [SerializeField]
    private Button previouseButton = default;
    [SerializeField]
    private RawImage imageColor = default;
    [SerializeField]
    private Image charImage = default;
    [SerializeField]
    private List<Image> images = default;
    [SerializeField]
    private GameObject panel = default;
    [SerializeField]
    private AudioSource clickSound = default;
    private int index;
    private readonly Color[] colors = 
    {
        Color.blue,
        Color.red,
        Color.yellow,
        Color.green
    };

    public void ClosePanel(bool Y)
    {
        if(Y) panel.SetActive(true);
        else panel.SetActive(false);
    }
    private void Next()
    { 
        clickSound.Play();
        if (index >= 3) index = 0;
        else index++;
    }

    private void Previouse()
    { 
        clickSound.Play();
        if(index <= 0) index = 3;
        else index--;
    }

    public RawImage GetRawImage() => imageColor;

    private void Awake()
    {
        index = 0;
        nextButton.onClick.AddListener(Next);
        previouseButton.onClick.AddListener(Previouse);
    }

    private void Update()
    {
        imageColor.color = colors[index];
        charImage.sprite = images[index].sprite;
    }

}
