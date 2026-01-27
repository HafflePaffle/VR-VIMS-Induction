using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    [SerializeField] Texture img1;
    [SerializeField] Texture img2;
    [SerializeField] Texture img0;
    [SerializeField] RawImage image;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Update()
    {
        switch(dropdown.value)
        {
            case 0: image.texture = img0; break;
            case 1: image.texture = img1; break;
            case 2: image.texture = img2; break;
        }
    }
}
