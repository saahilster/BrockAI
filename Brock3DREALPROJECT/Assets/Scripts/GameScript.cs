using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum Round
{
    ONE,
    TWO,
    THREE
}

public class GameScript : MonoBehaviour
{
    public UnityEvent askPlayer;
    //References
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI chatText;
    [SerializeField] Image png;
    [SerializeField] GameObject decisionBoard;

    //tracks current chunk of dialogue.
    [SerializeField] private List<TextBlock> current = new List<TextBlock> { };
    [SerializeField] int currentBlock = 0;
    //This is for player reponse.
    public bool yieldForAnswer;
    private int val;
    public Round currentRound;

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
    void Awake()
    {
        decisionBoard.SetActive(false);
        currentRound = Round.ONE;
        //copying chunk 1 into current.
        LoadChunk(chunk1);
        UpdateUI(chunk1[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI(TextBlock block)
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
        if (currentBlock < current.Count)
        {
            UpdateUI(current[currentBlock]);
            currentBlock++;
            return;
        }
        
        askPlayer?.Invoke();            
        

    }

    /// <summary>
    /// This function will serve to invoke askPlayer event which the player chooses a dialogue option.
    /// the Buttons will be mapped to 1, 2, 3. Based on that it will load the next chunk.
    /// </summary>
    public void PathDecider()
    {
        int val = ButtonSetter.clickedValue;
        ButtonSetter.canClick = true;
        if (currentRound == Round.ONE)
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
                    Debug.LogWarning("Unknown choice: " + val);
                    return;
            }

            currentRound = Round.TWO;
        }
        else if (currentRound == Round.TWO)
        {
            Debug.Log("Round 2 finished");

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
                    Debug.LogWarning("Unknown choice: " + val);
                    return;
            }

            currentRound = Round.THREE;
        }
        else
        {
            Debug.Log("Level finished");
            return;
        }

        // Next();
    }

    private void LoadChunk(List<TextBlock> chunk)
    {
        currentBlock = 0;
        current.Clear();
        current.AddRange(chunk);
        

    }

    public void AnimateChoices()
    {
        decisionBoard.SetActive(true);
    }
    public void HideChoices()
    {
        decisionBoard.SetActive(false);
    }
}
