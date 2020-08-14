using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameActive = true;
    void Update()
    {
        if (isGameActive)
        {
            if (PlayerStats.Lives <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        isGameActive = false;
        Debug.Log("Game over");
        Time.timeScale = 0;
    }

}
