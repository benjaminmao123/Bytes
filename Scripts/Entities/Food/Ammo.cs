namespace Bytes.Entities
{
    public class Ammo : Item
    {
        public WeaponType weaponType;

        void Awake()
        {
            itemType = ItemType.Ammo;
        }
    }
}
