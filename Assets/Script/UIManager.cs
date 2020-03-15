using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCrystal;
    [SerializeField] private GameObject _retry, _mainMenu;

    public void ApplyScoreCrystal(int score){
        _scoreCrystal.text = score.ToString();
    }

    public void ShowRetry(){
        _retry.SetActive(true);
    }

    public void ShowMainMenu(){
        _mainMenu.SetActive(true);
    }

}