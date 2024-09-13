using UnityEngine;

public class LoadData : MonoBehaviour
{
    public void LoadScore()
    {
        int savedScore = PlayerPrefs.GetInt("Score"); // ,0 - значение по умолчанию, если ключ не найден
        Debug.Log("Loaded Score: " + savedScore);
    }
}
