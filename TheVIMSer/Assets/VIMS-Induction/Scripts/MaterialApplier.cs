using UnityEngine;

public class MaterialApplier : MonoBehaviour
{
    public string resourcesFolder = "Material";
    private string CustomMaterial;

    private void Start()
    {
        ApplyFromResources();
    }

    public void ApplyFromResources()
    {
        string loadPath = string.IsNullOrEmpty(resourcesFolder) ? "" : resourcesFolder;
        var mats = Resources.LoadAll<Material>(loadPath);
        if (mats != null && mats.Length > 0)
        {
            // Optionally sort by name for deterministic behavior:
            // System.Array.Sort(mats, (a, b) => string.CompareOrdinal(a.name, b.name));
            CustomMaterial = mats[0].name;
            Debug.Log($"No CustomMaterial set — using first material: {CustomMaterial}");
        }
        else
        {
            Debug.LogWarning($"No materials found under Resources/{resourcesFolder}.");
            return;
        }

        string path = string.IsNullOrEmpty(resourcesFolder) ? CustomMaterial : $"{resourcesFolder}/{CustomMaterial}";
        var mat = Resources.Load<Material>(path);
        if (mat == null)
        {
            Debug.LogError($"Material not found at Resources/{path}. Make sure the .mat is placed under Assets/Resources/{resourcesFolder}/ and the name is correct.");
            return;
        }

        Apply(mat);
    }

    public void Apply(Material mat)
    {
        if (mat == null)
        {
            Debug.LogError("Material is null, cannot apply.");
            return;
        }

        var r = GetComponent<Renderer>();
        if (r == null)
        {
             Debug.LogWarning("No Renderer found on this GameObject.");
             return;
        }
        SetRendererMaterial(r, mat);
    }

    private void SetRendererMaterial(Renderer renderer, Material mat)
    {
       renderer.sharedMaterial = mat;  
    }
}
