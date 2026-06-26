using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
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
        current.AddRange(chunk1);
        UpdateChunkLength();
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

    void UpdateChunkLength()
    {
        //resetting length before each call;
        chunkLen = 0;
        if (current == null)
        {
            Debug.Log("No chunk loaded.");
            return;
        }

        foreach (TextBlock block in current){
            chunkLen++;
            Debug.Log("Chunk Length: " + chunkLen);
        }
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
        if(currentBlock >= chunkLen)
        {
            UpdateUI(current[currentBlock]);
        }
    }
}
