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
    private GameObject iambotPanel = default;
    [SerializeField]
    private AudioSource clickSound = default;
    [SerializeField]
    private PlayerColor playerColor = default;

    private int index = 0;
    
    private void Awake()
    {
        nextButton.onClick.AddListener(Next);
        previouseButton.onClick.AddListener(Previouse);
    }
    
    private void Next()
    { 
        clickSound.Play(); 
        index = index >= 3 ? 0 : index + 1;
        SetColor(index);
    }
    
    private void Previouse()
    { 
        clickSound.Play();
        index = index <= 0 ? 3 : index - 1;
        SetColor(index);
    }
    
    public void SetColor(int colorIndex)
    { 
        imageColor.color = playerColor.GetColor(colorIndex);
    }
    
    public void SetIamBotPanelActive(bool active) => iambotPanel.SetActive(active);
    public RawImage GetRawImage() => imageColor;
}
