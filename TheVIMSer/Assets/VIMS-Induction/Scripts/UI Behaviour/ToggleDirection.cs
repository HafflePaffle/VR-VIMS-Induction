using UnityEngine;
using UnityEngine.UI;
using SingletonSetup;

public class ToggleDirection : MonoBehaviour
{
    private SingletonSettings singletonSetup;
    [SerializeField] private Toggle[] toggles;
    private void Start()
    {
        singletonSetup = FindFirstObjectByType<SingletonSettings>();
        switch(singletonSetup.rotateLeft)
        {
            case true:
                toggles[0].isOn = true;
                break;
            case false:
                toggles[1].isOn = true;
                break;
        }
    }
    public void SendMessage(bool toggleValue)
    {
        singletonSetup.rotateLeft = toggleValue;
    }
}
