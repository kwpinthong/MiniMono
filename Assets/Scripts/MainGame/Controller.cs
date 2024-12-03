using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private ChoosePlayers choosePlayers = default;
    [SerializeField]
    private MainPanel mainPanel = default;
    [SerializeField]
    private AudioList audioList = default;
    [SerializeField]
    private Board board = default;
    [SerializeField]
    private Chip chipPrefab = default;
    [SerializeField]
    private GameObject Parent = default;
    [SerializeField]
    private GameObject startNode = default;


    private int turn;
    private int number;
    private bool isChecking;

    private List<Color> colorsCheck;
    private static List<Character> players;

    private int max;
    private int roll;
    private bool endgame;
    private bool doneSetting;
    private bool coroutineAllowed;
    private Transform[] start;
    private Color[] colors = {
        Color.blue,
        Color.red,
        Color.yellow,
        Color.green
    };

    private void Awake()
    {
        max = 4;
        roll = 1;
        turn = 0;
        number = 0;

        endgame = false;
        isChecking = false;
        doneSetting = false;
        coroutineAllowed = false;

        colorsCheck = new List<Color>();
        players = new List<Character>();
        start = startNode.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(Parent.transform.childCount == 1) 
        {   //ENG THE GMAE!
            endgame = true;
            StopAllCoroutines();
        }
    }

    public void UI_RollDice()
    {  
        if(coroutineAllowed)
            StartCoroutine(StartTurn());  
    }
    public void UI_EnterGame() => EnterGame();

    private void EnterGame()
    {
        Delete();
        players.Clear();
        colorsCheck.Clear();
        number = choosePlayers.GetNumber();
        for (int i = 0; i < number; i++)
        {
            colorsCheck.Add(choosePlayers.GetPlayerConfigs()[i].GetRawImage().color);
        }

        for(int j = 0; j < number; j++)
        {
            if(HaveSameColor(colorsCheck[j]))
            {
                return;
            }
            else if ( j == (number - 1) )
            {
                if( (max - number) == 0)
                {
                    CreatePlayer(true, number);
                }
                else
                {
                    CreatePlayer(true, number);         
                    CreatePlayer(false, (max-number));  
                } 
                
                doneSetting = true;
                mainPanel.SetMainUI();
            }
        }
        mainPanel.ShowTurn(turn, true);
        coroutineAllowed = true;
    }

    private void CreatePlayer(bool isPlayer, int limt)
    {
        for(int i = 0; i < limt; i++)
        {
            string tname;
            Color color = Color.grey;
            Vector3 position = new Vector3(0, 0, 0);
            
            if (isPlayer)
                tname = "Player " + (i+1).ToString();
            else
                tname = "Bot " + (i+1).ToString();

            if (!isPlayer)
            {
                for(int j = 0; j < colors.Length; j++)
                    if(!colorsCheck.Contains(colors[j]))
                    {
                        color = colors[j];
                        colorsCheck.Add(colors[j]);
                        break;
                    }
            }
            else 
            {
                color = choosePlayers.GetPlayerConfigs()[i].GetRawImage().color;
            }

            for(int j = 1; j < start.Length; j++)
            {
                if(start[j].name == NameofColor(color))
                    position = start[j].position;
            }

            Chip chip = Instantiate(chipPrefab, position, Quaternion.identity);
            chip.SetColor(color);
            chip.transform.parent = Parent.transform;

            if(isPlayer)
                chip.name = "Player_Chip " + (i+1).ToString();
            else
                chip.name = "Bot_Chip " + (i+1).ToString();

            chip.Set(9, color);
            chip.Initialzation(board);

            if (isPlayer)
            {
                players.Add(new Player(tname, color, chip)); 
            }
            else
            {
                players.Add(new Bot(tname, color, chip));
            }
        }
    }

    private void Delete()
    {
        if(Parent.transform.childCount != 0)
        {
            foreach(Transform child in Parent.transform)
                Destroy(child.gameObject);
        }
    }

    private bool HaveSameColor(Color c)
    {   //Check Player must not use same color
        int count = 0;
        foreach(Color temp in colorsCheck)
            if(c.Equals(temp)) count++;

        if(count > 1) return true;
        else return false;
    }

    private IEnumerator StartTurn()
    {
        coroutineAllowed = false;

        //this player doesn't have a Dead Flag
        if(!players[turn].IsDead())
        {
            for (int i = 0; i <= 20; i++)
            {
                roll = Random.Range(1, 7);
                yield return new WaitForSeconds(0.05f);
            }

            Chip chip = players[turn].GetChip();

            //Chip moving, and must done moving before do checking.
            chip.Moving(roll); yield return new WaitUntil(() => chip.IsMoving() == false);

            //Start Checking
            isChecking = true;
            if(isChecking)
            {

                Color color = players[turn].GetColor();
                int current = players[turn].GetChip().GetCurrentPosition();
                Node node = board.NodeList()[current].GetComponent<Node>();

                if (node.IsMainNode())
                {
                    if(node.MaterialName().Contains(NameofColor(color)))
                    {
                        chip.AddHP(3);
                        mainPanel.POPHP(turn, "+3");
                    }
                    else
                    {
                        chip.AddHP(1);
                        mainPanel.POPHP(turn, "+1");
                    }
                    audioList.addHPSound.Play();
                }
                else
                {
                    if(node.IsEmpty())
                    {
                        node.SetColor(color);
                    }
                    else
                    {
                        if(node.IsPlayerColor(color))
                        {
                            if(node.IsFull())
                            {
                                chip.AddHP(1);
                                mainPanel.POPHP(turn, "+1");
                                audioList.addHPSound.Play();
                            }
                            else
                            {
                                node.SetColor(color);
                            }
                        }
                        else
                        {
                            int index = 0;
                            for(int i=0; i < node.ListColors().Count; i++)
                            {
                                if(!node.ListColors()[i].Equals(Color.grey))
                                {
                                    if(!node.ListColors()[i].Equals(color))
                                    {
                                        chip.RemoveHP(1);
                                        index = i;
                                        audioList.removeHPSound.Play();
                                    }
                                }
                            }
                            mainPanel.POPHP(turn, "-" + (index+1).ToString());
                            node.RemoveToken(index);
                            if(node.IsEmpty())
                            {
                                node.SetColor(color);
                            }
                        }
                    }
                }

                if(chip.IsDead())
                {
                    players[turn].SetDeadFlag(true);
                    mainPanel.DeadPanel(turn);
                    chip.ClearToken(color, board);
                    chip.Destory();
                    audioList.DeadSound.Play();
                }

                isChecking = false;

            }
        }
    
        yield return new WaitUntil(() => isChecking == false);
        mainPanel.ShowTurn(turn, false);
        Check(turn); //Sending to not-Dead Player
        coroutineAllowed = true;
        //If next turn is a Bot, StartTurn() right away.
        if(players[turn].IsBot()) StartCoroutine(StartTurn());
    }

    private void Check(int tturn)
    {
        tturn++;
        tturn %= players.Count;
        if(players[tturn].IsDead())
        {
            Check(tturn);
        }
        else
        {
            turn = tturn;
            mainPanel.ShowTurn(turn, true);
        }
    }

    private string NameofColor(Color color)
    {
        if (Color.blue == color) return "Blue";
        else if (Color.red == color) return "Red";
        else if (Color.yellow == color) return "Yellow";
        else if (Color.green == color) return "Green";
        else return null;
    }

    public int Max() => max;
    public int Roll() => roll;
    public List<Character> ListPlayer() => players;
    public bool IsCoroutineAllowed() => coroutineAllowed;
    public bool IsDoneSetting() => doneSetting;
    public bool IsEndGame() => endgame;
}