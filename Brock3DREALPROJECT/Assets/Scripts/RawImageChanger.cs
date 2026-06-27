using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RawImageChanger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RawImage targetRawImage;
    [SerializeField] private Texture newTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerClick(PointerEventData eventData)
    {
        if (targetRawImage != null && newTexture != null)
        {
            targetRawImage.texture = newTexture;
        }
    }
}

