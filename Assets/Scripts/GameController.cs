using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int whoseTurn; // 0 = x and 1 = o 
    public int turnCount; // counts the number of turns played
    public GameObject[] turnIcon; // displays whos turn it is
    public Sprite[] playerIcons; // 0 = x icon and 1 = o icon
    public Button[] tictactoeSpaces; // playable space for our game
   //public int[] markedSpaces;  // ID's which space was marked by which player
    // Start is called before the first frame update
    void Start()
    {
      // calling function GameSetup 
      GameSetup();  
    }

    void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnIcon[0].SetActive(true);
        turnIcon[1].SetActive(false);
        for (int i = 0; i <tictactoeSpaces.Length; i++) // access each element of our tictactoeSpaces variable
        {
          tictactoeSpaces[i].interactable = true;
          tictactoeSpaces[i].GetComponent<Image>().sprite = null;  // sprite = getting image of button 
        }
        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -1; // change the value of the corresponding element inside this array to the value of whoseTurn it is
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //access the button that was clicked 
    public void TicTacToeButton(int WhichNumber)
    {
        tictactoeSpaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoseTurn; // the method used to identify which space has been marked by which player. 

        // Change who's turn it is 
        if (whoseTurn == 0)
        {
            whoseTurn = 1; // o players turn
            turnIcon[0].SetActive(false);
            turnIcon[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcon[0].SetActive(true);
            turnIcon[1].SetActive(false);
        }
    }
}
