using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] materials;
    private MeshRenderer mr;
    private int matIndex = 0;
    bool debounce;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    public void ChangeMat()
    {
        if(!debounce)
        {
            matIndex++;
            if (matIndex >= materials.Length)
                matIndex = 0;
            mr.material = materials[matIndex];
            debounce = true;
            StartCoroutine(CoolDown());
        }

    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        debounce = false;
    }
}
