using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private Text hp = default;
    [SerializeField]
    private Text playername = default;
    [SerializeField]
    private Text poptextHP = default;
    [SerializeField]
    private GameObject turn = default;
    [SerializeField]
    private Slider hpBar = default;

    public GameObject dead = default;
    public bool showTurn = false;

    private int _hp;
    private string _playername;

    private void Update()
    {
        hpBar.value = _hp;


        hp.text = "HP: "+_hp.ToString();
        playername.text = _playername;
        if(showTurn)
            turn.SetActive(true);
        else
            turn.SetActive(false);
    }

    public void Set(int h, string n)
    {
        _hp = h;
        _playername = n;
    }

    public IEnumerator POP(string textpop)
    {
        poptextHP.text = textpop;
        poptextHP.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        poptextHP.gameObject.SetActive(false);
    }
}
