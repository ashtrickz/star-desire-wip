using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [HideInInspector] public int selectedWeapon;

    void Start() => SelectWeapon();
    
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void ChangeWeapon()
    {
        int previousWeapon = selectedWeapon;
        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else selectedWeapon++;
        if (previousWeapon != selectedWeapon)
            SelectWeapon();
    }
}
