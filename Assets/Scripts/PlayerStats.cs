using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Coins;
    public static int Lives;
    public static int Points;

    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private int startCoins = 200;
    private int startLives = 10;
    private int startPoints = 0;

    private void Start()
    {
        Coins = startCoins;
        Lives = startLives;
        Points = startPoints;
    }

    private void Update()
    {
        coinsText.text = Coins.ToString();
        livesText.text = Lives.ToString();
        pointsText.text = Points.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
