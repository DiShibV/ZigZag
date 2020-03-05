using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCrystal;
    [SerializeField] private GameObject _retry;
    public static UIManager instance;

    private void Start()
    {
        instance = this;
    }

    public static void ApplyScoreCrystal(int score){
        instance._scoreCrystal.text = score.ToString();
    }

    public static void ShowRetry(){
        instance._retry.SetActive(true);
    }

}