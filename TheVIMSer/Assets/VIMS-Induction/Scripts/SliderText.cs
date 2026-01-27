using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SingletonSetup;

public class SliderText : MonoBehaviour
{
    private Slider slider;
    private SingletonSettings singletonSettings;

    public TMP_Text sliderValueText;

    private void Start()
    {
        singletonSettings = FindFirstObjectByType<SingletonSettings>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateSliderText);
        slider.value = singletonSettings.degreesPerSecond;
        UpdateSliderText(slider.value); // Initialize text
    }
    public void UpdateSliderText(float value)
    {
        sliderValueText.text = value.ToString("0");
        singletonSettings.degreesPerSecond = value;
    }

    public void ChangeSlider(float value)
    {
        slider.value += value;
    }
}

