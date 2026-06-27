using UnityEngine;

public class ButtonSetter : MonoBehaviour
{
    public static int clickedValue;
    public static bool canClick = false;
    public void SetValue(int value)
    {
        if (!canClick) return;

        clickedValue = value;
        Debug.Log("Value set to :" + value);
        canClick = false;
    }

    public void ResetValue()
    {
        SetValue(0);
    }
}
