using UnityEngine;

namespace WeaponDirectory
{
    public abstract class Weapon : MonoBehaviour
    {
        public int basicDamage;

        public abstract int StartAttack();
    }
}