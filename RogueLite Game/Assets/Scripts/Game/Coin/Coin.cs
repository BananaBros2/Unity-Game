using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // Used to access and modify aspects of a UI

public class Coin : Collectable         // The Coin class will use features from the Collectable class
{
    public float pickupDelay = 3;       // A variable for restricting the user from collecting the coin immediatly

    public int coinAmount = 1;      // Sets the amount of coinitude per coin
    private Text coinText;      // The variable that will be used to change the textbox for the coin
    private Text scoreText;         // The variable that will be used to change the textbox for the score

    public Gameplay gameplay;       // A variable which will be used to inherit features used in the 'Gameplay' script

    void LateUpdate()       // Starts when all other Update() functions have run
    {
        pickupDelay -= Time.deltaTime;      // Takes away the time since last frame from the pickupDelay variable
    }

    protected override void OnCollect()         // Uses the OnCollect function from the Collectable class
    {
        if (pickupDelay <= 0)         // checks if the pickupDelay timer is or has gone below 0
        {
            gameplay = FindObjectOfType<Gameplay>();        // Sets the gameplay variable to the hidden Gameplay object
            gameplay.coinCount += coinAmount;       // Adds the set coinAmount to the coinCount variable in the Gameplay class
            coinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();        // Sets coinText to the Coins child of the Canvas
            coinText.text = ("- " + gameplay.coinCount.ToString());         // Sets the text of the coinText to "- " and then the current coin count

            gameplay.score += 1;        // 
            scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();       // Sets scoreText to the Score child of the Canvas
            scoreText.text = ("Score\n" + gameplay.score.ToString());       // Sets the text of the coinText to "Score " and then the score on the next line

            Destroy(gameObject);        // Removes the game object that this script is attached to
        }
    }
}
