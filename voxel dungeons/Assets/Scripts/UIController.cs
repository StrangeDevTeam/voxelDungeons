using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static GameObject InteractionPanel;
    public static GameObject DialoguePanel;


    public static bool isCursorVisible = true; //when true, the user can use mouse to navigate menus without rotating the camera or player in game

    // Start is called before the first frame update
    void Start()
    {
        ToggleMenus(); //default to cursor invisible on start
        InteractionPanel = GameObject.Find("InteractionPanel");
        InteractionPanel.SetActive(false);
        DialoguePanel = GameObject.Find("DialoguePanel");
        DialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when escape is pressed
            ToggleMenus();                    // toggle whether mouse moves character or cursor
    }

    void ToggleMenus()
    {
        isCursorVisible = !isCursorVisible;           // toggles between
        if (isCursorVisible)                          // - locking cursor and mouse movements
            UnityEngine.Cursor.lockState = CursorLockMode.None;   //   move player and camera
        else                                          // - unlocking cursor so user can navigate menus
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; //   and locking the players rotation
        UnityEngine.Cursor.visible = isCursorVisible;             //

    }


    public static void ShowInteractionTooltip()
    {
        InteractionPanel.SetActive(true);
    }
    public static void HideInteractionTooltip()
    {
        InteractionPanel.SetActive(false);
    }

    public static void ShowDialogueBox(string text)
    {
        Text dialogueText = DialoguePanel.GetComponentInChildren<Text>();
        dialogueText.text = text;
        DialoguePanel.SetActive(true);
    }
    public static void HideDialogueBox()
    {
        DialoguePanel.SetActive(false);
    }
}
