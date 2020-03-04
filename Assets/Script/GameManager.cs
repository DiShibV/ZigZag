using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isStart { get; private set; }
    [SerializeField] private Player player;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {

    }

    public static void StartGame(){
        isStart = true;
    }

    public void GameOver(Direction direction){
        isStart = false;
        player.AddForce(direction);
        player.enabled = false;
    }

    public static void Restart(){

    }

}