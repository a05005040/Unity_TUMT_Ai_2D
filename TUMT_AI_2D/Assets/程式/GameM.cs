using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("遊戲");
    }
    public void Quil()
    {
        Application.Quit();
    }
	
}
