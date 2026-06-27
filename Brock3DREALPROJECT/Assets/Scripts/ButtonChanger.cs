using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameScript gs;
    [SerializeField] private TextMeshProUGUI choiceText;

    [Header("Round 1")]
    [SerializeField] private List<TextBlock> previews = new List<TextBlock>();
    [SerializeField] private List<TextBlock> responses = new List<TextBlock>();

    [Header("Round 2")]
    [SerializeField] private List<TextBlock> previews2 = new List<TextBlock>();
    [SerializeField] private List<TextBlock> responses2 = new List<TextBlock>();

    [SerializeField] private TextBlock selectedResponse;


    void Start()
    {
        choiceText.text = previews[0].dialogue;
        selectedResponse = responses[0];
    }
    public void UpdateButtonText()
    {
        Round round = gs.currentRound;

        if (round == Round.ONE)
        {
            ChangePreview(ButtonSetter.clickedValue, previews, responses);
        }
        else if (round == Round.TWO)
        {
            Debug.Log("Round 2 confirmed");
            ChangePreview(ButtonSetter.clickedValue, previews2, responses2);
        }
    }

    private void ChangePreview(int val, List<TextBlock> previewBlocks, List<TextBlock> responseBlocks)
    {
        int index = val - 1;

        if (index < 0 || index >= previewBlocks.Count || index >= responseBlocks.Count)
        {
            Debug.LogWarning("Invalid choice index: " + index);
            return;
        }

        choiceText.text = previewBlocks[index].dialogue;
        selectedResponse = responseBlocks[index];
    }

    public void UpdateDialogue()
    {
        if (selectedResponse == null)
        {
            Debug.LogWarning("No response selected.");
            return;
        }

        gs.UpdateUI(selectedResponse);
    }
}