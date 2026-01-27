using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchAutomator : MonoBehaviour
{
    private SpinManager spinManager;
    private bool triggered = false;
    public float delay;
    public int sceneIndex;

    private void OnEnable()
    {
        spinManager = GetComponent<SpinManager>();
    }

    private void Update()
    {
        if(spinManager.hasRotated && !triggered)
        {
            triggered = true;
            StartCoroutine(SwitchScene(sceneIndex));
        }
    }

    private IEnumerator SwitchScene(int x)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}
