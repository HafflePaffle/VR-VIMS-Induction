using System.Collections;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    [Header("X-Axis settings")]
    [SerializeField] private KeyCode keyX;
    [SerializeField] private Transform xAxis;
    public float degreesPerSecondX;
    public float degreesToTurnX;
    private bool rotatingX;

    [Header("Y-Axis settings")]
    [SerializeField] private KeyCode keyY;
    [SerializeField] private Transform yAxis;
    public float degreesPerSecondY;
    public float degreesToTurnY;
    private bool rotatingY;
    public bool hasRotated = false;

    [Header("Wave settings")]
    [SerializeField] private KeyCode keyZ;
    [SerializeField] private Transform waver;
    public float waveOffset;
    private bool waving;

    [Header("Circular movement settings")]
    [SerializeField] private KeyCode keyC;
    [SerializeField] Transform center;
    [SerializeField] Transform player;
    [SerializeField] float radiusX;
    [SerializeField] float radiusZ;
    private float posX, posZ, angle = 0f;
    private bool moving;
    private bool circling;

    private SingletonSetup.SingletonSettings singletonSettings;

    private void Start()
    {
        singletonSettings = FindFirstObjectByType<SingletonSetup.SingletonSettings>();
        degreesPerSecondY = singletonSettings.degreesPerSecond;
    }

    public void StartXRotation()
    {
        Debug.Log($"StartXRotation called. DPS: {degreesPerSecondX}, Degrees: {degreesToTurnX}");

        if (!rotatingX)
            StartCoroutine(RotateXAxis());
    }

    public void StartYRotation()
    {
        Debug.Log($"StartYRotation called. DPS: {degreesPerSecondY}, Degrees: {degreesToTurnY}");

        if (!rotatingY)
        {
            if(singletonSettings.rotateLeft)
            {
                StartCoroutine(RotateYAxisReverse());
            }
            else
            {
                StartCoroutine(RotateYAxis());
            }
        }
    }

    public void StopYRotation()
    {
        StopAllCoroutines();
        StartCoroutine(ResetY(degreesToTurnY));
        degreesToTurnY = 0;
    }

    private IEnumerator ResetY(float x)
    {
        yield return new WaitForSeconds(1);
        degreesToTurnY = x;
    }

    public void StartWaves()
    {
        Debug.Log("Started wave movement");

        if (!waving)
        {
            StartCoroutine(WaveMovement());
        }
    }

    public void StartCircularMovement()
    {
        if(!moving)
        { 
            StartCoroutine(CircularMovement()); 
        }
    }

    private IEnumerator RotateXAxis()
    {
        rotatingX = true;
        float totalTime = (degreesPerSecondX == 0) ? 0 : (degreesToTurnX / degreesPerSecondX);
        float elapsedTime = 0f;
        float startRotation = xAxis.transform.eulerAngles.z;
        float endRotation = startRotation + degreesToTurnX;

        Debug.Log("RotateXAxis started");

        while (elapsedTime < totalTime)
        {
            float newRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / totalTime);
            xAxis.transform.eulerAngles = new Vector3(
                xAxis.transform.eulerAngles.x,
                xAxis.transform.eulerAngles.y,
                newRotation);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rotatingX = false;
    }

    private IEnumerator RotateYAxis()
    {
        rotatingY = true;
        float totalTime = (degreesPerSecondY == 0) ? 0 : (degreesToTurnY / degreesPerSecondY);
        float elapsedTime = 0f;
        float startRotation = yAxis.transform.eulerAngles.y;
        float endRotation = startRotation + degreesToTurnY;

        Debug.Log("RotateYAxis started");

        while (elapsedTime < totalTime)
        {
            float newRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / totalTime);
            yAxis.transform.eulerAngles = new Vector3(
                yAxis.transform.eulerAngles.x,
                newRotation,
                yAxis.transform.eulerAngles.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rotatingY = false;
        hasRotated = true;
    }

    private IEnumerator RotateYAxisReverse()
    {
        rotatingY = true;

        // Use absolute magnitude for duration so totalTime is always positive
        float magnitude = Mathf.Abs(degreesToTurnY);
        float totalTime = (degreesPerSecondY == 0f) ? 0f : magnitude / degreesPerSecondY;
        float elapsedTime = 0f;

        float startRotation = yAxis.transform.eulerAngles.y;
        // Reverse direction by subtracting degreesToTurnY instead of adding it
        float endRotation = startRotation - degreesToTurnY;

        Debug.Log("RotateYAxis started (reversed)");

        if (totalTime <= 0f)
        {
            // Instant snap if there's no time to animate
            yAxis.transform.eulerAngles = new Vector3(
                yAxis.transform.eulerAngles.x,
                endRotation,
                yAxis.transform.eulerAngles.z);
            rotatingY = false;
            hasRotated = true;
            yield break;
        }

        while (elapsedTime < totalTime)
        {
            float t = elapsedTime / totalTime;
            float newRotation = Mathf.Lerp(startRotation, endRotation, t);
            yAxis.transform.eulerAngles = new Vector3(
                yAxis.transform.eulerAngles.x,
                newRotation,
                yAxis.transform.eulerAngles.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final rotation exactly matches endRotation
        yAxis.transform.eulerAngles = new Vector3(
            yAxis.transform.eulerAngles.x,
            endRotation,
            yAxis.transform.eulerAngles.z);

        rotatingY = false;
        hasRotated = true;
    }

    private IEnumerator WaveMovement()
    {
        //The whole movement should take 5 seconds
        waving = true;
        float totalTime = 5;
        float elapsedTime = 0f;
        Vector3 startPosition = waver.position;
        float topPosition = startPosition.y + waveOffset;
        float bottomPosition = startPosition.y - waveOffset;
        bool goingUp = false;


        while (waving)
        {
            if(goingUp)
            {
                float newHeight = Mathf.Lerp(startPosition.y, topPosition, elapsedTime / (totalTime * 0.5f));
                waver.transform.localPosition = new Vector3 (startPosition.x, newHeight, startPosition.z);
                elapsedTime += Time.deltaTime;
                if(waver.position.y == topPosition)
                {
                    goingUp = false;
                    elapsedTime = 0f;
                    startPosition = waver.position;
                }
            }
            else
            {
                float newHeight = Mathf.Lerp(startPosition.y, bottomPosition, elapsedTime / (totalTime * 0.5f));
                waver.transform.localPosition = new Vector3(startPosition.x, newHeight, startPosition.z);
                elapsedTime += Time.deltaTime;
                if (waver.position.y == bottomPosition)
                {
                    goingUp = true;
                    elapsedTime = 0f;
                    startPosition = waver.position;
                }
            }

            yield return null;
        }

    }

    private IEnumerator CircularMovement()
    {
        moving = true;
        while(moving)
        {
            Vector3 directionAway = player.position - center.position;

            posX = center.position.x + Mathf.Cos(angle) * radiusX;
            posZ = center.position.y + Mathf.Sin(angle) * radiusZ;

            player.rotation = Quaternion.RotateTowards(player.rotation, Quaternion.LookRotation(directionAway), 100f * Time.deltaTime);
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y, 0);

            Vector3 moveDir = new Vector3 (posX, 0 , posZ);
            Vector3 direction = moveDir - player.position;
            CharacterController cc = player.GetComponent<CharacterController>();

            cc.Move(direction.normalized * Time.deltaTime);
            if (Vector3.Magnitude(player.position - moveDir) < 0.01f)
                moving = false; circling = true;
            yield return null;
        }

        while(circling)
        {
            float degreesThisFrame = degreesPerSecondY * Time.deltaTime;

            angle -= degreesThisFrame;

            posX = center.position.x + Mathf.Cos(Mathf.Deg2Rad * angle) * radiusX;
            posZ = center.position.z + Mathf.Sin(Mathf.Deg2Rad * angle) * radiusZ;
            player.position = new Vector3(posX, player.position.y, posZ);

            Vector3 directionAway = player.position - center.position;
            yAxis.rotation = Quaternion.LookRotation(directionAway, Vector3.up);
            yAxis.rotation = Quaternion.Euler(0, yAxis.rotation.eulerAngles.y, 0);

            if(Mathf.Abs(angle) >= degreesToTurnY)
                circling = false;

            yield return null;
        }

        hasRotated = true;
    }

    public void ChangeDPSX(string dps)
    {
        float.TryParse(dps, out degreesPerSecondX);
    }

    public void ChangeDPSY(string dps)
    {
        float.TryParse(dps, out degreesPerSecondY);
    }

    public void ChangeDegreesX(string degrees)
    {
        float.TryParse(degrees, out degreesToTurnX);
    }

    public void ChangeDegreesY(string degrees)
    {
        float.TryParse(degrees, out degreesToTurnY);
    }
}
