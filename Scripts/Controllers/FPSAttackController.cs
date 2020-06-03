using Bytes.Entities;
using Photon.Pun;
using System.IO;
using UnityEngine;

namespace Bytes.Controllers
{
    public class FPSAttackController : MonoBehaviourPun, IAttackController
    {
        [SerializeField] Transform projectileInstantiateLocation;
        AmmoInventoryController inventoryController;
        Player player;
        [SerializeField] Transform raycastOrigin;

        void Start()
        {
            player = GetComponent<Player>();
            inventoryController = GetComponent<AmmoInventoryController>();
        }

        public void Attack()
        {
            if (inventoryController.inventory.ContainsKey(player.CurrentWeapon))
            {
                int count = inventoryController.inventory[player.CurrentWeapon];

                if (count > 0)
                {
                    var go = PhotonNetwork.Instantiate(Path.Combine("Bytes", "Models", "Weapons", "Food", "Projectile", player.CurrentWeapon.ToString()),
                        projectileInstantiateLocation.position, Quaternion.identity);

                    var rb = go.GetComponent<Rigidbody>();
                    rb.AddForce(raycastOrigin.forward * 1500f);

                    var projectile = go.GetComponent<Projectile>();
                    projectile.InstanceID = player.InstanceID;

                    inventoryController.Remove(player.CurrentWeapon, 1);

                    Debug.Log("Fired: " + player.CurrentWeapon);
                }
            }
        }
    }
}
