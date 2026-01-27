using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    public Transform sitPos;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 posDiff = transform.position - sitPos.position;

        if(posDiff.magnitude > 0)
        {
            cc.Move(-posDiff);
        }
    }

}
