﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField]
    private Animator animator = default;
    private int hp;
    private Color color;
    private const int min = 0;
    private const int max = 9;

    public void Set(int _hp, Color _color)
    {
        this.hp = _hp;
        this.color = _color;
    }
    
    public void AddHP(int _hp)
    {
        StartCoroutine(WaitForAnimation(0.5f, 3));
        if (this.hp < max) this.hp += _hp;
        if(this.hp >= max) this.hp = max;
    }

    public void RemoveHP(int _hp)
    {
        StartCoroutine(WaitForAnimation(0.1f, 5));
        this.hp -= _hp;
        if(this.hp <= min) this.hp = min;
    }

    public bool IsDead()
    {
        if(this.hp <= min) return true;
        else return false;
    }

    private IEnumerator WaitForAnimation(float time, int index)
    {
        animator.SetInteger("animation", index);
        yield return new WaitForSeconds(time);
        animator.SetInteger("animation", 1);
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    public void ClearToken(Color color, Board currentRoute)
    {
        List<Transform> nodelist = currentRoute.NodeList();
        for(int i = 0; i < nodelist.Count; i++)
        {
            Node node = nodelist[i].GetComponent<Node>();
            List<Color> listColors = node.ListColors();
            for(int j = 0; j < listColors.Count; j++)
            {
                if(listColors[j].Equals(color)){
                    listColors[j] = Color.grey;
                }
            }
        }
    }

    public int GetHP() => this.hp;
    public Color GetColor() => this.color;
    public void Destory() => Destroy(this.gameObject);

    //**************** Movement ****************//

    private int steps;
    private int position;
    private bool isMoving;
    private Board currentRoute;

    public void Initialzation(Board board)
    {
        currentRoute = board;
        //START Position Node For Each Chip//
        if (this.color == Color.blue) position = (int)Colors.Blue;
        else if (this.color == Color.red) position = (int)Colors.Red;
        else if (this.color == Color.yellow) position = (int)Colors.Yellow;
        else if (this.color == Color.green) position = (int)Colors.Green;
    }

    private enum Colors
    {
        Blue = 0,
        Red = 4,
        Yellow = 8,
        Green = 12
    }

    public void Moving(int m_steps)
    {
        steps = m_steps;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        if(isMoving) 
        {
            yield break;
        }
    
        isMoving = true;

        while(steps > 0)
        {
            position++;
            position %= currentRoute.NodeList().Count;

            Vector3 nextPosition = new Vector3(currentRoute.NodeList()[position].position.x, transform.position.y, currentRoute.NodeList()[position].position.z);
            while(MoveToNext(nextPosition)) 
            { 
                yield return null; 
            }

            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.15f);
            steps--;
        }
        isMoving = false;
    }

    private bool MoveToNext(Vector3 goal) => goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 10f * Time.deltaTime));
    public int GetCurrentPosition() => position;
    public bool IsMoving() => isMoving;
}
