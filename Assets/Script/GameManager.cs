using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isStart { get; private set; }
    private static int _scoreCrystal;
    [SerializeField] private Player _player;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private CameraSnap _cameraSnap;
    [SerializeField] private UIManager _uiManager;
  //TEST
    private void Start () {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame(){
        isStart = true;
        _player.Enable();
        _cameraSnap.Enable();
    }

    public void GameOver(Direction direction){
        isStart = false;
        _cameraSnap.Disable();
        _player.Disable(direction);
        _uiManager.ShowRetry();
    }

    public static void AddScoreCrystal(){
        _scoreCrystal ++;
        instance._uiManager.ApplyScoreCrystal(_scoreCrystal);
    }

    public void Retry(){
        _player.Retry();
        _blockSpawner.RetryBlocks();
        _cameraSnap.Retry();
        _uiManager.ShowMainMenu();
    }

}