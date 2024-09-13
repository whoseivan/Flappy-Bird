using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
