using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isStart { get; private set; }
    private static int _scoreCrystal;
    [SerializeField] private Player player;
    [SerializeField] private BlockSpawner blockSpawner;

    private void Start () {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public static void StartGame(){
        isStart = true;
    }

    public void GameOver(Direction direction){
        isStart = false;
        player.AddForce(direction);
        player.Disable();
        UIManager.ShowRetry();
    }

    public static void AddScoreCrystal(){
        _scoreCrystal ++;
        UIManager.ApplyScoreCrystal(_scoreCrystal);
    }

    public void Retry(){
        player.Reset();
        blockSpawner.RetryBlocks();
        CameraSnap.Retry();
    }

}