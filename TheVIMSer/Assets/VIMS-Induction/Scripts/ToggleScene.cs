using UnityEngine;
using UnityEngine.UI;
using SingletonSetup;

public class ToggleScene : MonoBehaviour
{
    private SingletonSettings singletonSetup;
    [SerializeField] private int index;
    private void Start()
    {
        singletonSetup = FindFirstObjectByType<SingletonSettings>();
    }
    public void SendMessage(bool toggleValue)
    {
        if(toggleValue)
        {
            singletonSetup.sceneIndex = index;
        }
    }
}
