using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NUnit.Framework.Internal;

enum Round
{
    ONE,
    TWO,
    THREE
}

public class GameScript : MonoBehaviour
{   
    UnityEvent askPlayer;
    //References
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI chatText;
    [SerializeField] Image png;

    //tracks current chunk of dialogue.
    [SerializeField] private List<TextBlock> current = new List<TextBlock>{};
    [SerializeField] int chunkLen = 0;
    [SerializeField] int currentBlock = 0;
    //This is for player reponse.
    public bool yieldForAnswer;
    private int trackedValue;
    private Round currentRound = Round.ONE;

    //Player Dialogue
    [SerializeField] List<TextBlock> option1 = new List<TextBlock> { };
    [SerializeField] List<TextBlock> option2 = new List<TextBlock> { };


    //Client Dialogue
    [Tooltip("Section is for Neutral Choices")]
    //section 1 (start)
    [SerializeField] List<TextBlock> chunk1 = new List<TextBlock> { };

    //section 2
    [SerializeField] List<TextBlock> chunk2a = new List<TextBlock> { };
    [SerializeField] List<TextBlock> chunk2b = new List<TextBlock> { };
    [SerializeField] List<TextBlock> chunk2c = new List<TextBlock> { };

    //section 3 (final)
    [SerializeField] List<TextBlock> chunk3a = new List<TextBlock> { };
    [SerializeField] List<TextBlock> chunk3b = new List<TextBlock> { };
    [SerializeField] List<TextBlock> chunk3c = new List<TextBlock> { };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //copying chunk 1 into current.
        LoadChunk(chunk1);
        Next();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI(TextBlock block)
    {
        nameText.text = block.charName;
        chatText.text = block.dialogue;
        png.sprite = block.charPng;
    }

    /// <summary>
    /// This function will handle going to the next chunk data by using the button event system
    /// embeeded within unity event.
    /// 
    /// TEST: It should update dialogue per button click event.
    /// 
    /// </summary>
    public void Next()
    {
        //go to the next dialogue
        if(currentBlock < current.Count)
        {
            UpdateUI(current[currentBlock]);
            currentBlock++;
        }
        //if done
        askPlayer?.Invoke();
    }

    /// <summary>
    /// This function will serve to invoke askPlayer event which the player chooses a dialogue option.
    /// the Buttons will be mapped to -1, 0, 1. Based on that it will load the next chunk.
    /// </summary>
    public void PathDecider()
    {
        int val = ButtonSetter.clickedValue;
        if(currentRound == Round.ONE)
        {
            Debug.Log("Round 1 finished");
            
            switch (val)
            {
                case 1:
                    Debug.Log("Good");
                    LoadChunk(chunk2a); 
                    break;
                case 2:
                    Debug.Log("Neutral");
                    LoadChunk(chunk2b); 
                    break;
                case 3:
                    Debug.Log("Bad");
                    LoadChunk(chunk2c); 
                    break;
                default:
                    Debug.Log("unknown error");
                    break;
            }
            currentRound = Round.TWO;

        }else if(currentRound == Round.TWO)
        {
            Debug.Log("Round 2 fin");
            switch (val)
            {
                case 1:
                    Debug.Log("Good");
                    LoadChunk(chunk3a); 
                    break;
                case 2:
                    Debug.Log("Neutral");
                    LoadChunk(chunk3b); 
                    break;
                case 3:
                    Debug.Log("Bad");
                    LoadChunk(chunk3c); 
                    break;
                default:
                    Debug.Log("unknown error");
                    break;
            }
            currentRound = Round.THREE;
        }else if(currentRound == Round.THREE)
        {
            Debug.Log("Level finished");
        }

        Next();
    }

    private void LoadChunk(List<TextBlock> chunk)
    {
        current.Clear();
        current.AddRange(chunk);
        currentBlock = 0;
        
    }

}
