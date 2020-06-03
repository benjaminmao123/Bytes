using Bytes.Entities;

namespace Bytes.Components
{
    public interface IAttack
    {
        float AttackSpeed { get; set; }
        WeaponType CurrentWeapon { get; set; }
        float MaxDistance { get; set; }
        float AttackForce { get; set; }
    }
}