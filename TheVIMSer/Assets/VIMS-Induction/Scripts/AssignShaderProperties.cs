using UnityEngine;

public class AssignShaderProperties : MonoBehaviour
{
    private MaterialPropertyBlock propBlock;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        
        
        int randomVariant = Random.Range(0, 9);
        
       
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
        
        
        float randomSpeed = Random.Range(0.5f, 4.0f);
        
       
        float randomTimeOffset = Random.Range(0f, 3f);

        rend.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Variant", randomVariant);
        propBlock.SetColor("_Color", randomColor);
        propBlock.SetFloat("_Speed", randomSpeed);
        propBlock.SetFloat("_TimeOffset", randomTimeOffset);
        rend.SetPropertyBlock(propBlock);
    }
}
