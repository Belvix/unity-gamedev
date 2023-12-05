using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EquippablesSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        [field: SerializeField]
        public bool HasProjectile { get; private set; }

        [field: SerializeField]
        public AudioClip ActionSound => throw new System.NotImplementedException();

        [field: SerializeField]
        public int Durability { get; set; }

        [field: SerializeField]
        public int MeleeDamage { get; set; }

        public bool PerformAction(GameObject character)
        {
            PlayerWeapon weaponSystem = character.GetComponent<PlayerWeapon>();
            if (weaponSystem != null)
            {
                weaponSystem.SetWeapon(this);
                SwordAnimation swordAnim = character.GetComponentInChildren<SwordAnimation>();
                if (swordAnim != null)
                {
                    swordAnim.UpdateEquippedSword(character);
                }
                return true;
            }
            
            return false;
        }
    }
}