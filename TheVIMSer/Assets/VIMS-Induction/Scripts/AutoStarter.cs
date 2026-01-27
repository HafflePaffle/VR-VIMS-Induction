using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class AutoStarter : MonoBehaviour
{
    private SpinManager spinManager;
    public float delay;
    public UnityEvent events;

    void OnEnable()
    {
        spinManager = GetComponent<SpinManager>();
        StartCoroutine(StartItAll());
    }

    private IEnumerator StartItAll()
    {
        yield return new WaitForSeconds(delay);

        events.Invoke();
    }
}
