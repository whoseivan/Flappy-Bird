using UnityEngine;

public class LoadData : MonoBehaviour
{
    public void LoadScore()
    {
        int savedScore = PlayerPrefs.GetInt("Score"); // ,0 - �������� �� ���������, ���� ���� �� ������
        Debug.Log("Loaded Score: " + savedScore);
    }
}
