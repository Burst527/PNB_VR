using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject options;
    public GameObject about;
    public GameObject location;
    public GameObject controls;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button optionButton;
    public Button coontrolsButton;
    public Button aboutButton;
    public Button quitButton;

    [Header("Spwan Location Buttons")]
    public Button PUT;
    public Button D4;
    public Button EB;

    [Header("Mode Select")]
    public GameObject modeSelect;
    public Button normalModeButton;
    public Button freeRoamModeButton;


    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);
        coontrolsButton.onClick.AddListener(EnableControls);
        EB.onClick.AddListener(() => SpwanGame(2));
        D4.onClick.AddListener(() => SpwanGame(1)); 
        PUT.onClick.AddListener(() => SpwanGame(3)); 
        normalModeButton.onClick.AddListener(StartNormalMode);
        freeRoamModeButton.onClick.AddListener(StartFreeRoamMode);


        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        EnableModeSelect();


        // HideAll();
        // SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        about.SetActive(false);
        location.SetActive(false);
        modeSelect.SetActive(false);
    }

    public void SpwanGame(int sceneIndex)
    {
        SceneTransitionManager.singleton.GoToSceneAsync(sceneIndex);
    }
    
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        controls.SetActive(false);
        about.SetActive(false);
        location.SetActive(false);
        modeSelect.SetActive(false);
    }
    public void EnableLocation()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        about.SetActive(false);
        location.SetActive(true);
        modeSelect.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        controls.SetActive(false);
        about.SetActive(false);
        location.SetActive(false);
        modeSelect.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        about.SetActive(true);
        location.SetActive(false);
        modeSelect.SetActive(false);
    }

    public void EnableControls()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(true);
        about.SetActive(false);
        location.SetActive(false);
        modeSelect.SetActive(false);
    }

    void EnableModeSelect()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        about.SetActive(false);
        location.SetActive(false);
        modeSelect.SetActive(true);
    }

    void StartNormalMode()
    {
        GameManager.Instance.currentMode = GameMode.Guided;
        SpwanGame(1);
    }

    void StartFreeRoamMode()
    {
        GameManager.Instance.currentMode = GameMode.FreeRoam;
        EnableLocation();
    }

}
