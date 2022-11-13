using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    // Panels
    public GameObject mainMenuPanel;
    public GameObject optionsMenuPanel;
    public GameObject videoOptionsPanel;
    public GameObject audioOptionsPanel;
    public GameObject controlsOptionsPanel;
    // resolution options
    public TMP_Dropdown resolutionsMenu;
    public UnityEngine.UI.Toggle fullscreenToggle;
    void Start()
    {
        resolutionsMenu.value = resolutionsMenu.options.FindIndex(option => option.text == PlayerPrefs.GetString("Resolution","1920 x 1080"));
        fullscreenToggle.isOn = Boolean.Parse(PlayerPrefs.GetString("FullScreen","True"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OptionsButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }
    public void BackButtonClicked()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void VideoOptionsButtonClicked()
    {
        audioOptionsPanel.SetActive(false);
        controlsOptionsPanel.SetActive(false);
        videoOptionsPanel.SetActive(true);
    }
    public void AudioOptionsButtonClicked()
    {
        controlsOptionsPanel.SetActive(false);
        videoOptionsPanel.SetActive(false);
        audioOptionsPanel.SetActive(true);
    }
    public void ControlsOptionsButtonClick()
    {
        audioOptionsPanel.SetActive(false);
        videoOptionsPanel.SetActive(false);
        controlsOptionsPanel.SetActive(true);
    }
    public void ApplyButtonClicked()
    {
        try
        {
            PlayerPrefs.SetString("Resolution", resolutionsMenu.options[resolutionsMenu.value].text);
            PlayerPrefs.SetString("FullScreen", fullscreenToggle.isOn.ToString());
            String[] resolutions = resolutionsMenu.options[resolutionsMenu.value].text.Split('x');
            Screen.SetResolution(int.Parse(resolutions[0].Trim()), int.Parse(resolutions[1].Trim()), fullscreenToggle.isOn);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
