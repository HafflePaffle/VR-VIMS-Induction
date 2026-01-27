using UnityEngine;

public class AudioOrbit : MonoBehaviour
{
    [Header("Target to Orbit")]
    [SerializeField] private Transform player; // Moving player

    [Header("Elliptical Orbit Settings")]
    [SerializeField] private float radiusX = 1.5f; // Horizontal radius of sound orbit
    [SerializeField] private float radiusZ = 0.75f; // Vertical radius of sound orbit
    [SerializeField] private float orbitSpeed = 30f; // Degrees per second

    private float orbitAngle = 0f;

    void Update()
    {
        if (player == null) return;

        // Update the orbit angle
        orbitAngle += orbitSpeed * Time.deltaTime;
        if (orbitAngle > 360f) orbitAngle -= 360f;

        // Compute elliptical offset
        float rad = Mathf.Deg2Rad * orbitAngle;
        float offsetX = Mathf.Cos(rad) * radiusX;
        float offsetZ = Mathf.Sin(rad) * radiusZ;

        // Apply new position relative to player
        transform.position = player.position + new Vector3(offsetX, 0f, offsetZ);
    }
}
