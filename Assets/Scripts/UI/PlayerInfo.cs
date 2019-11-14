using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private Text hpText = default;
    [SerializeField]
    private Slider hpBar = default;
    [SerializeField]
    private Text playername = default;
    [SerializeField]
    private Text poptextHP = default;
    [SerializeField]
    private Image damagePanel = default;
    [SerializeField]
    private float targetPositionY = default;
    [SerializeField]
    private GameObject turn = default;
    public GameObject dead = default;
    public bool showTurn = false;

    private int _hp;
    private string _playername;
    private Sequence sequence_damageblink;
    private Sequence sequencePOP;
 
    private void Update()
    {
        hpBar.value = _hp;
        hpText.text = _hp.ToString();
        playername.text = _playername;
        if (showTurn)
            turn.SetActive(true);
        else turn.SetActive(false);
    }

    public void Set(int h, string n)
    {
        _hp = h;
        _playername = n;
    }

    public void DamageBlink()
    {
        sequence_damageblink?.Kill();
        sequence_damageblink = DOTween.Sequence();

        for (int i = 0; i < 2; i++)
        {
            sequence_damageblink.Append(damagePanel.DOFade(1.0f, 0.1f).SetEase(Ease.Flash));
            sequence_damageblink.Append(damagePanel.DOFade(0.0f, 0.1f).SetEase(Ease.Flash));
        }
        sequence_damageblink.SetAutoKill(true);
        sequence_damageblink.Play();
    }

    public IEnumerator POP(string textpop)
    {
        Vector2 originPosition = poptextHP.rectTransform.localPosition;
        sequencePOP?.Kill();
        sequencePOP = DOTween.Sequence();
        sequencePOP.Append(poptextHP.rectTransform.DOLocalMoveY(targetPositionY, 0.6f).SetEase(Ease.OutExpo));
        poptextHP.text = textpop;
        poptextHP.gameObject.SetActive(true);
        sequencePOP.SetAutoKill(true);
        sequencePOP.Play(); 
        yield return new WaitForSeconds(0.6f);
        poptextHP.gameObject.SetActive(false);
        poptextHP.rectTransform.localPosition = originPosition;

    }

}
