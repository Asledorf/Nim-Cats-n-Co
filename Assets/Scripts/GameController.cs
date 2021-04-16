using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameBackground;
    public GameObject newGame;
    public GameObject game;
    public GameObject gameOver;
    public TMP_Text winnerText;

    public GameObject menuBackground;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject credits;

    public TMP_InputField player1;
    public TMP_InputField player2;
    public Toggle pvp;
    public Toggle pvc;

    public StringData player1data;
    public StringData player2data;
    public StringData winCondition;
    public BoolData IsPVP;
    public BoolData isEasy;

    public AudioMixer audioMixer;

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
        gameBackground.SetActive(false);
        newGame.SetActive(false);
        options.SetActive(false);
        game.SetActive(false);
        gameOver.SetActive(false);
        credits.SetActive(false);
        menuBackground.SetActive(true);
        mainMenu.SetActive(true);
    }
    public void ToNewGame()
    {
        menuBackground.SetActive(false);
        mainMenu.SetActive(false);
        gameBackground.SetActive(true);
        gameOver.SetActive(false);
        newGame.SetActive(true);
    }
    public void To5Game()
    {
        writeNames();
        newGame.SetActive(false);
        game.SetActive(true);
        isEasy.value = true;
        gameState = gameStates.Active;
    }
    public void To7Game()
    {
        writeNames();
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

    public void OnMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", level);
    }
    public void OnMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", level);
    }
    public void onSFXVolume(float level)
    {
        audioMixer.SetFloat("SFXVolume", level);
    }

    public void OnPVP(bool change)
    {
        if (change)
        {
            pvc.isOn = false;
            IsPVP.value = true;
        }
        else
        {
            pvc.isOn = true;
            IsPVP.value = false;
        }
    }
    public void OnPVC(bool change)
    {
        if (change)
        {
            pvp.isOn = false;
            IsPVP.value = false;
        }
        else
        {
            pvp.isOn = true;
            IsPVP.value = true;
        }
    }

    private void writeNames()
    {
        player1data.value = player1.text;
        player2data.value = player2.text;
    }
}
