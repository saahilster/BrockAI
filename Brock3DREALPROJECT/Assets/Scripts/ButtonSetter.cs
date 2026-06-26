using UnityEngine;

public class ButtonSetter : MonoBehaviour
{
    public static int clickedValue;

    public void SetValue(int value)
    {
        clickedValue = value;
        Debug.Log("Value set to :" + value);
    }

    public void ResetValue()
    {
        SetValue(0);
    }
}
