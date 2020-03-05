using UnityEngine;

public class Crystal : MonoBehaviour, IPlayerOnTrigger
{
    private const int PERCENT_OF_OCCURRENCE = 20;

    public void OnTrigger()
    {
        GameManager.AddScoreCrystal();
        gameObject.SetActive(false);
    }

    public void Show(){
        gameObject.SetActive(CheckProbability());
    }

    private bool CheckProbability(){
        return Random.Range(1,101) <= PERCENT_OF_OCCURRENCE;
    }
}
