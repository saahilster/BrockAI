using UnityEngine;

public class MoraleMeterController : MonoBehaviour
{
    public MoraleMeterData meterData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddGoodPoints(float amount)
    {
        meterData.currentGoodPoints = Mathf.Clamp(meterData.currentGoodPoints + amount, 0, meterData.maximumGoodPoints);
    }
    public void AddBadPoints(float amount)
    {
        meterData.currentBadPoints = Mathf.Clamp(meterData.currentBadPoints + amount, 0, meterData.maximumBadPoints);
    }
    public void RemoveGoodPoints(float amount)
    {
        meterData.currentGoodPoints = Mathf.Clamp(meterData.currentGoodPoints - amount, 0, meterData.maximumGoodPoints);
    }
    public void RemoveBadPoints(float amount)
    {
        meterData.currentBadPoints = Mathf.Clamp(meterData.currentBadPoints - amount, 0, meterData.maximumBadPoints);
    }
}
