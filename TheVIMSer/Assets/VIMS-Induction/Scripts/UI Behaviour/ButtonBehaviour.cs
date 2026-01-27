using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color hoverColor = Color.yellow;
    private Color originalColor;
    private Image imageComponent;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            originalColor = imageComponent.color;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageComponent.color = originalColor;
    }

}
