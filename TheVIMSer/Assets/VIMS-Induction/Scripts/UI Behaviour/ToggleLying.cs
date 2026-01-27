using SingletonSetup;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLying : MonoBehaviour
{
    private SingletonSettings singletonSetup;
    [SerializeField] private Toggle toggles;
    private void Start()
    {
        singletonSetup = FindFirstObjectByType<SingletonSettings>();
        if(singletonSetup.lyingDown)
        {
            toggles.isOn = true;
        }
        else
        {
            toggles.isOn = false;
        }
    }
    public void SendMessage(bool toggleValue)
    {
        singletonSetup.lyingDown = toggleValue;
    }
}
