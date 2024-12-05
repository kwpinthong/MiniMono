using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private AudioList audioList = default;
    [SerializeField]
    private Controller controller = default;
    [SerializeField]
    private List<PlayerInfo> playerInfos = default;

    public void SetMainUI()
    {
        for (int i = 0; i < controller.Max(); i++)
            playerInfos[i].Set(controller.ListPlayer()[i].GetChip().GetHP(), controller.ListPlayer()[i].GetName());
        StartCoroutine(PlayBG());
    }

    public void Damage(int index)
    {
        playerInfos[index].DamageBlink();
    }

    public void DeadPanel(int index)
    {
        playerInfos[index].dead.SetActive(true);
    }

    public void POPHP(int index, string hp)
    {
        StartCoroutine(playerInfos[index].POP(hp));
    }

    public void ShowTurn(int index, bool y)
    {
        playerInfos[index].showTurn = y;
    }

    private IEnumerator PlayBG()
    {
        yield return new WaitForSeconds(1f);
        audioList.mainBG.Play();
    }

    private void Update()
    {
        for (int i = 0; i < controller.ListPlayer().Count; i++)
            playerInfos[i].Set(controller.ListPlayer()[i].GetChip().GetHP(), controller.ListPlayer()[i].GetName());
    }
}
