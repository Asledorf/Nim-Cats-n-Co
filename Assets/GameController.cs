using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject newGame;
    public GameObject game;
    public GameObject gameOver;
    public GameObject options;
    public GameObject credits;
    public GameObject winner;
    public TMP_Text winnerText;

    public StringData winCondition;
    public BoolData isEasy;

    private gameStates gameState = gameStates.NotActive;

    enum gameStates
    {
        NotActive,
        Active
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case gameStates.NotActive:
                break;
            case gameStates.Active:

                if(winCondition != "")
                {
                    winnerText.text = winCondition + " Has Won!!!";
                    gameState = gameStates.NotActive;
                    ToGameOver();
                    winCondition.value = "";
                }
                break;
        }
    }

    public void ToMainMenu()
    {
        newGame.SetActive(false);
        options.SetActive(false);
        game.SetActive(false);
        gameOver.SetActive(false);
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ToNewGame()
    {
        mainMenu.SetActive(false);
        newGame.SetActive(true);
    }
    public void To5Game()
    {
        newGame.SetActive(false);
        game.SetActive(true);
        isEasy.value = true;
        gameState = gameStates.Active;
    }
    public void To7Game()
    {
        newGame.SetActive(false);
        game.SetActive(true);
        isEasy.value = false;
        gameState = gameStates.Active;
    }
    public void ToGameOver()
    {
        game.SetActive(false);
        gameOver.SetActive(true);
    }
    public void ToOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void ToCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
}
