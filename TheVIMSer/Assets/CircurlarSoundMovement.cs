using UnityEngine;

public class CircurlarSoundMovement : MonoBehaviour
{
    public Transform center;
    public float radius = 1.5f;
    public float speed = 0.3f;

    private AudioSource aSource;
    private bool started = false;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.Stop();
        if (aSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (!started) return;

        float angle = Time.time * speed * Mathf.PI * 2f;
        Vector3 newPos = center.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        transform.position = newPos;    
    }

    public void StartAudioSpin()
    {
        started = true;
        aSource.Play();
    }
}
