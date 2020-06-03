using UnityEngine;
using Bytes.Components;
using Bytes.Input;
using Photon.Pun;

namespace Bytes.Entities
{
    public class Player : Entity, IMove, IRotate, IAttack, IDamageable, IKillable
    {
        public Vector3 MoveSpeed { get; set; }
        public float RotationSpeed { get; set; }
        public Vector3 Velocity { get; set; }
        public float AttackSpeed { get; set; }
        public WeaponType CurrentWeapon { get; set; }
        public float MaxDistance { get; set; }
        public float AttackForce { get; set; }
        public float Health { get; set; }
        public float FlashTime { get; set; }
        public int score;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            MoveSpeed = new Vector3(5, 1, 5);
            RotationSpeed = PlayerPrefs.GetFloat("sensitivity");
            Velocity = Vector3.zero;
            AttackSpeed = 0.5f;
            CurrentWeapon = WeaponType.GreenApple;
            MaxDistance = 2000f;
            AttackForce = 1500f;
            Health = 100f;
            FlashTime = 0.25f;
            score = 0;
        }

        void Update()
        {
            if (!KeyboardPauseCommand.isPaused)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }

        public bool OnDamage(int value)
        {
            Health -= value;

            if (Health <= 0)
            {
                OnDeath();
                return true;
            }

            return false;
        }

        public void OnDeath()
        {

        }
    }
}
