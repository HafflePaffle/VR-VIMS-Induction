using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField] Transform center;

    [SerializeField] float radiusX;
    [SerializeField] float radiusZ;
    [SerializeField] float angularSpeed = 2f;

    private float posX, posZ, angle = 0f;

    private void Update()
    {
        posX = center.position.x + Mathf.Cos(angle) * radiusX;
        posZ = center.position.y + Mathf.Sin(angle) * radiusZ;
        transform.position = new Vector3(posX, transform.position.y, posZ);
        angle += Time.deltaTime * angularSpeed;

        if(angle >= 360)
            angle = 0f;
    }
}
