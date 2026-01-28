using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SingletonSetup;

public class SliderText : MonoBehaviour
{
    private Slider slider;
    private SingletonSettings singletonSettings;

    public TMP_Text sliderValueText;
    [SerializeField] private bool frequency;

    private void Start()
    {
        singletonSettings = FindFirstObjectByType<SingletonSettings>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateSliderText);
        if(frequency)
            slider.value = singletonSettings.frequency;
        else
            slider.value = singletonSettings.degreesPerSecond;
        UpdateSliderText(slider.value); // Initialize text
    }
    public void UpdateSliderText(float value)
    {
        if(value > 1)
        {
            sliderValueText.text = value.ToString("0");
            singletonSettings.degreesPerSecond = value;
        }
        else
        {
            sliderValueText.text = value.ToString("0.0");
            singletonSettings.frequency = value;
        }

    }

    public void ChangeSlider(float value)
    {
        slider.value += value;
    }
}

