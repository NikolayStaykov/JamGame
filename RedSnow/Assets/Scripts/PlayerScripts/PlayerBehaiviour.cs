using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerBehaiviour : MonoBehaviour
{
    //movement controls
    private KeyCode forwardKey;
    private KeyCode backwardsKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode dashKey;
    private Vector3 toMove = new Vector3(0, 0, 0);
    private Boolean dashCooldown = true;
    private Boolean movementAllowed = true;
    //weapon controls
    private KeyCode leftWeaponKey;
    private KeyCode rightWeaponKey;
    void Start()
    {
        try
        {
            forwardKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveUpKey", "W"));
        } catch (Exception)
        {
            forwardKey = KeyCode.W;
        }
        try
        {
            backwardsKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveDownKey", "S"));
        }
        catch (Exception)
        {
            backwardsKey = KeyCode.S;
        }
        try
        {
            leftKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveLeftKey", "A"));
        }
        catch (Exception)
        {
            leftKey = KeyCode.A;
        }
        try
        {
            rightKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveRightKey", "D"));
        }
        catch (Exception)
        {
            rightKey = KeyCode.D;
        }
        try
        {
            dashKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dashKey", "Space"));
        } 
        catch(Exception)
        {
            dashKey = KeyCode.Space;
        }
        try
        {
            leftWeaponKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireLeftkey", "Mouse0"));
        }
        catch
        {
            leftWeaponKey = KeyCode.Mouse0;
        }
        try
        {
            rightWeaponKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireRightKey", "Mouse1"));
        }
        catch
        {
            rightWeaponKey = KeyCode.Mouse1;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(forwardKey) && movementAllowed)
        {
            toMove.z = 5 * Time.deltaTime;
        }
        else if (Input.GetKey(backwardsKey) && movementAllowed)
        {
            toMove.z = -5 * Time.deltaTime;
        }
        if (Input.GetKey(leftKey) && movementAllowed)
        {
            toMove.x = -5 * Time.deltaTime;
        } 
        else if(Input.GetKey(rightKey) && movementAllowed)
        {
            toMove.x = 5 * Time.deltaTime;
        }
        if (Input.GetKey(dashKey) && dashCooldown)
        {
            movementAllowed = false;
            this.gameObject.GetComponent<Rigidbody>().AddForce(toMove * 650, ForceMode.Impulse);
            dashCooldown = false;
            dashCooldownReset();
        }
        else
        {
            this.gameObject.transform.Translate(toMove);
        }
        toMove.x = 0;
        toMove.z = 0;
        if (Input.GetKeyDown(leftWeaponKey))
        {
            Debug.Log("Fire Left");
        }
        if (Input.GetKeyDown(rightWeaponKey))
        {
            Debug.Log("Fire Right");
        }
    }

    private async void dashCooldownReset()
    {
        await Task.Delay(150);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        movementAllowed = true;
        await Task.Delay(2850);
        dashCooldown = true;
    }
}
