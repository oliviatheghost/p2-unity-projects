using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button; //button for start of game
    private GameManager gameManager; // to respond to the game manager script

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // find the game componet
        button.onClick.AddListener(SetDifficulty); // set the difficulty of each button 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked"); // knows which button was clicked
        gameManager.StartGame(difficulty); // set games difficulty for each button
    }
}
