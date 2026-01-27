using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private bool debouncer = false;

    private void Awake()
    {
        debouncer = true;
        StartCoroutine(Cooldown());
    }

    public void SwitchScene(int x)
    {
        int scene = SceneManager.GetActiveScene().buildIndex + x;
        if (scene >= SceneManager.sceneCountInBuildSettings)
            scene = 0;
        SceneManager.LoadScene(scene);
    }

    public void SwitchSceneByIndex(int x)
    {
        if(!debouncer)
        {
            debouncer = true;
            //StartCoroutine(Cooldown());
            SceneManager.LoadScene(x);
        }
    }

    public void SwitchSceneBySingleton()
    {
        SingletonSetup.SingletonSettings singleton = FindFirstObjectByType<SingletonSetup.SingletonSettings>();
        singleton.LoadScene();
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        debouncer = false;
    }

}
