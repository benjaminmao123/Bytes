using System.Collections.Generic;
using UnityEngine;
using Bytes.Entities;
using Bytes.Utility;

namespace Bytes.Controllers
{
    public class ReferenceController : Singleton<ReferenceController>
    {
        GameObject[] projectileGO;
        GameObject[] ammoGO;
        public Dictionary<WeaponType, Ammo> ammo = new Dictionary<WeaponType, Ammo>();
        public Dictionary<WeaponType, Projectile> projectiles = new Dictionary<WeaponType, Projectile>();

        private void Start()
        {
            projectileGO = GameObject.FindGameObjectsWithTag("Projectile");
            ammoGO = GameObject.FindGameObjectsWithTag("Ammo");

            Debug.Log(ammoGO.Length);

            foreach (var go in ammoGO)
            {
                var mAmmo = go.GetComponent<Ammo>();

                if (!ammo.ContainsKey(mAmmo.weaponType))
                    ammo.Add(mAmmo.weaponType, mAmmo);
            }

            foreach (var go in projectileGO)
            {
                var mProjectile = go.GetComponent<Projectile>();

                if (!projectiles.ContainsKey(mProjectile.weaponType))
                    projectiles.Add(mProjectile.weaponType, mProjectile);
            }
        }
    }
}

