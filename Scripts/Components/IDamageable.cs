namespace Bytes.Components
{
    public interface IDamageable
    {
        bool OnDamage(int value);
        float Health { get; set; }
        float FlashTime { get; set; }
    }
}
