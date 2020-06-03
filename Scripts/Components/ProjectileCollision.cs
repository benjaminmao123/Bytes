using Bytes.Entities;
using Photon.Pun;
using UnityEngine;

public class ProjectileCollision : MonoBehaviourPun
{
    [SerializeField] SkinnedMeshRenderer meshRenderer;
    Color originalColor;
    [SerializeField] Player player;

    private void Start()
    {
        originalColor = meshRenderer.material.color;
    }

    public void FlashRed()
    {
        meshRenderer.material.color = Color.red;
        Invoke("ResetColor", player.FlashTime);
    }

    void ResetColor()
    {
        meshRenderer.material.color = originalColor;
    }
}
