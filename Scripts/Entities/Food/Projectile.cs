using UnityEngine;
using Photon.Pun;

namespace Bytes.Entities
{
    public class Projectile : Item
    {
        public WeaponType weaponType;
        public Player owner;

        private void Awake()
        {
            itemType = ItemType.Projectile;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (photonView.IsMine)
            {
                Player player = collision.collider.GetComponent<Player>();

                if (player)
                {
                    if (InstanceID != player.InstanceID)
                    {
                        ProjectileCollision col = player.GetComponent<ProjectileCollision>();

                        col.FlashRed();

                        if (player.OnDamage(damage))
                        {
                            ++owner.score;
                        }
  
                        PhotonNetwork.Destroy(gameObject);
                    }
                }
            }
        }
    }
}

