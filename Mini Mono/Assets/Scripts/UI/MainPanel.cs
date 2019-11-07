using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private AudioList audioList = default;
    [SerializeField]
    private Controller controller = default;
    private List<PlayerInfo> playerInfos;

    public void Initialzation()
    {
        playerInfos = new List<PlayerInfo>();
    }

    public void SetMainUI()
    {
        playerInfos.Clear();
        playerInfos.Clear();
        for (int i = 0; i < controller.Max(); i++)
        {
            string name = "";
            if (controller.ListPlayer()[i].GetColor().Equals(Color.blue)) name = "Player 1";
            else if (controller.ListPlayer()[i].GetColor().Equals(Color.red)) name = "Player 2";
            else if (controller.ListPlayer()[i].GetColor().Equals(Color.yellow)) name = "Player 3";
            else if (controller.ListPlayer()[i].GetColor().Equals(Color.green)) name = "Player 4";

            if (GameObject.Find(name))
            {
                playerInfos.Add(GameObject.Find(name).GetComponent<PlayerInfo>());
                playerInfos[i].Set(controller.ListPlayer()[i].GetChip().GetHP(), controller.ListPlayer()[i].GetName());
            }
        }
        StartCoroutine(PlayBG());
    }

    public void Damage(int index)
    {
        playerInfos[index].DamageBlink();
        //StartCoroutine(playerInfos[index].DamageBlink_2());
        //StartCoroutine(playerInfos[index].DamageBlink_3());
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
