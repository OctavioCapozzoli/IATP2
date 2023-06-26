using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRed : MonoBehaviour
{
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material material;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    public IEnumerator DamageFlash()
    {
        meshRenderer.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material = material;
    }
}
