namespace Bytes.Entities
{
    public enum ItemType
    {
        Ammo,
        Projectile,
        Powerup
    }

    public enum WeaponType
    {
        GreenApple,
        RedApple,
        MultiApple
    }

    public class Item : Entity
    {
        public int count = 1;
        public ItemType itemType;
        public int damage = 0;

        public virtual void OnCollect()
        {
            Destroy(gameObject);
        }
    }
}
