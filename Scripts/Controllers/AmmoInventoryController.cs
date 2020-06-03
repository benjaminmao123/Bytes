using System.Collections.Generic;
using UnityEngine;
using Bytes.Entities;

namespace Bytes.Controllers
{
    public class AmmoInventoryController : MonoBehaviour
    {
        public Dictionary<WeaponType, int> inventory = new Dictionary<WeaponType, int>();

        public void Add(Ammo ammo)
        {
            if (inventory.ContainsKey(ammo.weaponType))
                inventory[ammo.weaponType] += ammo.count;
            else
                inventory.Add(ammo.weaponType, ammo.count);

            ammo.OnCollect();

            Debug.Log(ammo.weaponType + ", " + inventory[ammo.weaponType]);
        }

        public void Remove(WeaponType type, int count)
        {
            if (inventory.ContainsKey(type))
                inventory[type] -= count;
        }
        private void OnTriggerEnter(Collider other)
        {
            Ammo ammo = other.GetComponent<Ammo>();

            if (ammo)
                Add(ammo);
        }
    }
}

