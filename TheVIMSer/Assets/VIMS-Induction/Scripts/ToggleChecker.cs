using UnityEngine;
using UnityEngine.UI;

public class ToggleChecker : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    void Start()
    {
        SingletonSetup.SingletonSettings singletonSettings = FindFirstObjectByType<SingletonSetup.SingletonSettings>();
        int sceneIndex = singletonSettings.sceneIndex;
        switch(sceneIndex)
        {
            case 1:
                toggles[0].isOn = true;
                break;
            case 2:
                toggles[1].isOn = true;
                break;
            case 3:
                toggles[2].isOn = true;
                break;
            case 4:
                toggles[3].isOn = true;
                break;
            default:
                break;
        }
    }
}
