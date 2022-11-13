using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlBinding : MonoBehaviour
{
    public TMP_Text moveUpText;
    public TMP_Text moveLeftText;
    public TMP_Text moveDownText;
    public TMP_Text moveRightText;
    public TMP_Text fireRightText;
    public TMP_Text fireLeftText;
    public TMP_Text dashText;
    private bool changeMoveUpFlag;
    private bool changeMoveLeftFlag;
    private bool changeMoveDownFlag;
    private bool changeMoveRightFlag;
    private bool changeFireRightFlag;
    private bool changeFireLeftFlag;
    private bool changeDashFlag;
    private KeyCode moveLeftKey;
    private KeyCode moveUpKey;
    private KeyCode moveDownKey;
    private KeyCode moveRightKey;
    private KeyCode fireRightKey;
    private KeyCode fireLeftKey;
    private KeyCode dashKey;
    void Start()
    {
        changeMoveRightFlag = false;
        changeMoveUpFlag = false;
        changeMoveLeftFlag = false;
        changeMoveDownFlag = false;
        changeFireRightFlag = false;
        changeFireLeftFlag = false;
        moveUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveUpKey", "W"));
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveLeftKey", "A"));
        moveDownKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveDownKey", "S"));
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveRightKey", "D"));
        fireLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireLeftkey", "Mouse0"));
        fireRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireRightKey", "Mouse1"));
        dashKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dashKey", "Space"));
        moveUpText.text = ">" + moveUpKey.ToString();
        moveLeftText.text = ">" + moveLeftKey.ToString();
        moveDownText.text = ">" + moveDownKey.ToString();
        moveRightText.text = ">" + moveRightKey.ToString();
        dashText.text = ">" + dashKey.ToString();
        fireLeftText.text = ">" + fireLeftKey.ToString();
        fireRightText.text = ">" + fireRightKey.ToString();
    }


    void OnGUI()
    {
        KeyCode pressKey;
        Event dirEvent = Event.current;
        if (changeMoveDownFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeMoveDownFlag = false;
                moveDownKey = pressKey;
                moveDownText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeMoveDownFlag = false;
                moveDownText.text = ">" + moveDownKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeMoveLeftFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeMoveLeftFlag = false;
                moveLeftKey = pressKey;
                moveLeftText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeMoveDownFlag = false;
                moveLeftText.text = ">" + moveLeftKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeMoveUpFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeMoveUpFlag = false;
                moveUpKey = pressKey;
                moveUpText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeMoveDownFlag = false;
                moveUpText.text = ">" + moveUpKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeMoveRightFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeMoveRightFlag = false;
                moveRightKey = pressKey;
                moveRightText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeMoveDownFlag = false;
                moveRightText.text = ">" + moveRightKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeFireRightFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeFireRightFlag = false;
                fireRightKey = pressKey;
                fireRightText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeFireRightFlag = false;
                fireRightText.text = ">" + fireRightKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeFireLeftFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeFireLeftFlag = false;
                fireLeftKey = pressKey;
                fireLeftText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeFireLeftFlag = false;
                fireLeftText.text = ">" + fireLeftKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (changeDashFlag && dirEvent.isKey)
        {
            pressKey = dirEvent.keyCode;
            if (pressKey != KeyCode.Escape && pressKey != moveDownKey && pressKey != moveLeftKey && pressKey != moveUpKey && pressKey != moveRightKey && pressKey != KeyCode.None && pressKey != fireLeftKey && pressKey != fireRightKey && pressKey != dashKey)
            {
                changeDashFlag = false;
                dashKey = pressKey;
                dashText.text = ">" + pressKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                updateBindings();
            }
            else
            {
                changeDashFlag = false;
                dashText.text = ">" + fireLeftKey.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void ChangeMoveLeftButtonClicked()
    {
        moveLeftText.text = ">";
        changeMoveLeftFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ChangeMoveUpButtonClicked()
    {
        moveUpText.text = ">";
        changeMoveUpFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ChnageMoveRightButtonClicked()
    {
        moveRightText.text = ">";
        changeMoveRightFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ChangeMoveDownButtonClicked()
    {
        moveDownText.text = ">";
        changeMoveDownFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ChangeDashButtonClicked()
    {
        dashText.text = ">";
        changeDashFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ChangeFireRightButtonClicked()
    {
        fireRightText.text = ">";
        changeFireRightFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ChangeFireLeftButtonClicked()
    {
        fireLeftText.text = ">";
        changeFireLeftFlag = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void updateBindings()
    {
        PlayerPrefs.SetString("moveUpKey", moveUpKey.ToString());
        PlayerPrefs.SetString("moveLeftKey", moveLeftKey.ToString());
        PlayerPrefs.SetString("moveDownKey", moveDownKey.ToString());
        PlayerPrefs.SetString("moveRightKey", moveRightKey.ToString());
        PlayerPrefs.SetString("fireLeftkey", fireLeftKey.ToString());
        PlayerPrefs.SetString("fireRightKey", fireRightKey.ToString());
    }
    public void ResetBindings()
    {
        moveUpKey = KeyCode.W;
        moveLeftKey = KeyCode.A;
        moveDownKey = KeyCode.S;
        moveRightKey = KeyCode.D;
        dashKey = KeyCode.Space;
        fireRightKey = KeyCode.Mouse1;
        fireLeftKey = KeyCode.Mouse0;
        moveUpText.text = ">W";
        moveLeftText.text = ">A";
        moveDownText.text = ">S";
        moveRightText.text = ">D";
        dashText.text = ">Space";
        fireRightText.text = ">Mouse R";
        fireLeftText.text = ">Mouse L";
        updateBindings();
    }
}