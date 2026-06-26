using UnityEngine;

[CreateAssetMenu(fileName = "MoraleMeterData", menuName = "Scriptable Objects/MoraleMeterData")]
public class MoraleMeterData : ScriptableObject
{
    [Range(0f, 100f)]
    public float currentGoodPoints = 0f;
    [Range(0f, 100f)]
    public float maximumGoodPoints = 100f;
    [Range(0f, 100f)]
    public float currentBadPoints = 0f;
    [Range(0f, 100f)]
    public float maximumBadPoints = 100f;
}
