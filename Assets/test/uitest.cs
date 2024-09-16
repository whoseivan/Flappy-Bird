using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uitest : MonoBehaviour
{
    public GameObject panel;
    bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    public void ActionButton()
    {
        isActive = !isActive;
        if (isActive)
        {
            panel.SetActive(false);
        }
        else
        {

            panel.SetActive(true);
        }
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
