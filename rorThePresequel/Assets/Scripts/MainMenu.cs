using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        long unixTime = now.ToUnixTimeMilliseconds();
        
        SceneManager.LoadScene((char)((unixTime % 3) + 2));
    }



    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }
}
