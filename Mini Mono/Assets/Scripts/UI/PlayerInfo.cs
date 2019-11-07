using System.Collections;
using System.Collections.Generic;
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
    private Animator animator = default;
    [SerializeField]
    private GameObject turn = default;

    public GameObject dead = default;
    public bool showTurn = false;
    private int _hp;
    private string _playername;

    private void Update()
    {
        hpBar.value = _hp;
        hpText.text = _hp.ToString();
        playername.text = _playername;
        if (showTurn)
            turn.SetActive(true);
        else
            turn.SetActive(false);
    }

    public void Set(int h, string n)
    {
        _hp = h;
        _playername = n;
    }

    public void DamageBlink()
    {
        animator.SetTrigger("setDamage");
    }

    public IEnumerator DamageBlink_2()
    {
        Color originColor = damagePanel.color;
        Color targetColor = new Color(1f, 0f, 0f, 0.5f);

        damagePanel.color = targetColor;
        yield return new WaitForSeconds(0.1f);
        damagePanel.color = originColor;
        yield return new WaitForSeconds(0.1f);
        damagePanel.color = targetColor;
        yield return new WaitForSeconds(0.1f);
        damagePanel.color = originColor;
        yield return new WaitForSeconds(0.1f);
        damagePanel.color = targetColor;
        yield return new WaitForSeconds(0.1f);
        damagePanel.color = originColor;
    }

    private bool changeColor = false;
    public IEnumerator DamageBlink_3()
    {
        //Color originColor = damagePanel.color;
        //Color targetColor = new Color(1f, 0f, 0f, 0.5f);

        //damagePanel.color = Color.Lerp(damagePanel.color, targetColor, 5.0f);
        //yield return new WaitForSeconds(0.2f);
        //damagePanel.color = Color.Lerp(damagePanel.color, originColor, 5.0f);

        changeColor = true;
        float duration = 2f;
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Done");
        changeColor = false;
    }
    
    public IEnumerator POP(string textpop)
    {
        poptextHP.text = textpop;
        poptextHP.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        poptextHP.gameObject.SetActive(false);
    }
}
