using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public Material temporaryMaterial;

    private Material[] originalMaterials;
    private bool isSwapped = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SwapMaterials()
    {
        //turn outline off
        Outline outline = GetComponent<Outline>();
        if (outline != null) outline.enabled = false;

        if (isSwapped || meshRenderer == null || temporaryMaterial == null) return;

        originalMaterials = meshRenderer.sharedMaterials;

        Material[] newMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = temporaryMaterial;
        }

        meshRenderer.materials = newMaterials;
        isSwapped = true;
    }

    public void RevertMaterials()
    {
        if (!isSwapped || meshRenderer == null || originalMaterials == null) return;

        meshRenderer.materials = originalMaterials;
        isSwapped = false;

        //turn outline on
        Outline outline = GetComponent<Outline>();
        if (outline != null) outline.enabled = true;
    }
}
