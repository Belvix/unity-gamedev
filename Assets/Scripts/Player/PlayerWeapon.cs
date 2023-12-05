using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private EquippablesSO weapon;

    [SerializeField]
    private InventorySO inventoryData;

    // [SerializeField] private List<ItemParameter> weaponParameters, weaponCurrentState;

    [SerializeField]
    private EquippedMeleeSlot equippedMeleeSlot;

    [SerializeField]
    public int weaponDurability;

    [SerializeField]
    public int weaponMeleeDamage;

    public void SetWeapon(EquippablesSO weaponSO)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1);
        }

        this.weapon = weaponSO;
        equippedMeleeSlot.SetData(weaponSO.ItemSprite);
        this.weaponDurability = weapon.Durability;
        this.weaponMeleeDamage = weapon.MeleeDamage;

        // this.weaponCurrentState = new List<ItemParameter>(itemState);
        // ModifyParameters();
    }

    public EquippablesSO GetWeapon()
    {
        return this.weapon;
    }

    public void UnequipAndDestroy()
    {
        this.weaponDurability = 0;
        this.weaponMeleeDamage = 0;
        Destroy(this.weapon);
        equippedMeleeSlot.ResetData();
    }

    /* private void ModifyParameters()
    {
        foreach (var param in weaponParameters)
        {
            if (weaponCurrentState.Contains(param))
            {
                int index = weaponCurrentState.IndexOf(param);
                float newValue = weaponCurrentState[index].value + param.value;
                weaponCurrentState[index] = new ItemParameter
                {
                    itemParameter = param.itemParameter,
                    value = newValue
                };

            }
        }
    } */

}
