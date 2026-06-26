using UnityEngine;

[CreateAssetMenu(fileName = "TextBlock", menuName = "Scriptable Objects/TextBlock")]
public class TextBlock : ScriptableObject
{
    public string dialogue;
    public string charName;
    public Sprite charPng;
}
