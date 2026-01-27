using UnityEngine;

public class CylinderRotator : MonoBehaviour
{
    private Vector3 initialRotation;
    private float xRotation = 90f;
    private SingletonSetup.SingletonSettings singletonSettings;
    void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
        singletonSettings = FindFirstObjectByType<SingletonSetup.SingletonSettings>();
        if(singletonSettings.lyingDown)
        {
            RotateCylinder();
        }
    }

    public void RotateCylinder()
    {
        if(transform.rotation.eulerAngles.x == xRotation)
        {
            transform.rotation = Quaternion.Euler(initialRotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(xRotation, initialRotation.y, initialRotation.z);
        }
    }

}
