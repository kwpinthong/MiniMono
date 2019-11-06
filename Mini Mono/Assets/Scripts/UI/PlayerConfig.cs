using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour
{
    class configMenu
    {
        int index = 0;
        Color[] colors = {
            Color.blue,     
            Color.red,              
            Color.yellow,   
            Color.green
        };

        public Color GetColor(int index) => colors[index];
        public int GetIndex() => this.index;

        public void Next()
        {
            if(index >= 3) index = 0;
            else index++;
        }

        public void Previouse()
        {
            if(index <= 0) index = 3;
            else index--;
        }
    }

    [SerializeField]
    private Button nextButton = default;
    [SerializeField]
    private Button previouseButton = default;
    [SerializeField]
    private RawImage imageColor = default;
    [SerializeField]
    private GameObject panel = default;
    [SerializeField]
    private AudioSource clickSound = default;
    private configMenu player = new configMenu();

    public void ClosePanel(bool Y)
    {
        if(Y) panel.SetActive(true);
        else panel.SetActive(false);
    }
    private void Next()
    { 
        clickSound.Play();
        player.Next(); 
    }
    
    private void Previouse()
    { 
        clickSound.Play();
        player.Previouse(); 
    }

    public RawImage GetRawImage() => imageColor;

    private void Awake()
    {
        nextButton.onClick.AddListener(Next);
        previouseButton.onClick.AddListener(Previouse);
    }

    private void Update()
    {
        imageColor.color = player.GetColor(player.GetIndex());
    }

}
