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
            forwardKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ForwardKey", "W"));
        } catch (Exception)
        {
            forwardKey = KeyCode.W;
        }
        try
        {
            backwardsKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("BackwardsKey", "S"));
        }
        catch (Exception)
        {
            backwardsKey = KeyCode.S;
        }
        try
        {
            leftKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey", "A"));
        }
        catch (Exception)
        {
            leftKey = KeyCode.A;
        }
        try
        {
            rightKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey", "D"));
        }
        catch (Exception)
        {
            rightKey = KeyCode.D;
        }
        try
        {
            dashKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DashKey", "Space"));
        } 
        catch(Exception)
        {
            dashKey = KeyCode.Space;
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
            this.gameObject.GetComponent<Rigidbody>().AddForce(toMove * 1000, ForceMode.Impulse);
            dashCooldown = false;
            dashCooldownReset();
        }
        else
        {
            this.gameObject.transform.Translate(toMove);
        }
        toMove.x = 0;
        toMove.z = 0;
    }

    private async void dashCooldownReset()
    {
        await Task.Delay(200);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        movementAllowed = true;
        await Task.Delay(2800);
        dashCooldown = true;
    }
}
