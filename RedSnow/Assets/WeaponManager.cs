using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour 
{
    public GameObject rightHand;
    public GameObject leftHand;

    public void setLeftWeapon(string weapon)
    {
        GameObject weaponToSpawn = Resources.Load<GameObject>($"Weapons/{weapon}Left");
        weaponToSpawn = Instantiate(weaponToSpawn,leftHand.transform);
        weaponToSpawn.GetComponent<IWeapon>().setAsWeapon("left");
    }

    public void setRightWeapon(string weapon)
    {
        GameObject weaponToSpawn = Resources.Load<GameObject>($"Weapons/{weapon}Right");
        weaponToSpawn = Instantiate(weaponToSpawn, rightHand.transform);
        weaponToSpawn.GetComponent<IWeapon>().setAsWeapon("right");
    }

    public void Start()
    {
        setRightWeapon("SawedOffShotGun");
        setLeftWeapon("MachineGun");
    }
}
