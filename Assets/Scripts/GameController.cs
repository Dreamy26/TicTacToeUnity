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
    public int[] markedSpaces; // ID's whic space was marked by which player
    
    
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
            markedSpaces[i] = -100; // change the value of the corresponding element inside this array to the value of whoseTurn it is
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // access the button that was clicked 
    public void TicTacToeButton(int whichNumber)
    {
        tictactoeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoeSpaces[whichNumber].interactable = false;

        markedSpaces[whichNumber] = whoseTurn + 1;
        turnCount++;
        if (turnCount > 4)
        {
            WinnerCheck();
        }
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
  void WinnerCheck()
  {
      int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];// each element of top row of grid adding them together and storing them in the s1 variable.
      int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
      int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];// bottom row

      int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];// vertical
      int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
      int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];

      int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];// Diagonal
      int s8 = markedSpaces[0] + markedSpaces[4] + markedSpaces[6];
      var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8};
      for (int i = 0; i <solutions.Length; i++)
      {
          if (solutions[i] == 3 * (whoseTurn +1))
          {
              Debug.Log("Player " + whoseTurn + " WON!");
              return;
          }
      }
  }     
}   

    
