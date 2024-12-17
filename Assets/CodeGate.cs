using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodeGate : MonoBehaviour
{
    public Canvas displayCanvas;

    public GameObject interactButton;

    public Transform player;

    public Text messageBox;

   //private PlayerInput input;

    public Camera panelCam;

    public EventSystem _eventSystem;

    private bool opened = false;

    private bool inRange = false;

    public string correctCode;

    public GameObject lairOpenedTimeline;
    private void Start()
    {
        //input = player.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (!inRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowPanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (opened) return;

        inRange = true;

        interactButton.SetActive(true);

        //Character.OnInteract += ShowPanel;

        
    }

    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);

        inRange = false;
        
    }

    private void ShowPanel()
    {
        //Character.OnInteract -= ShowPanel;
        player.gameObject.SetActive(false);
        interactButton.SetActive(false);
        panelCam.depth = Camera.main.depth + 1;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddDigit(int number)
    {
        if (messageBox.text.Length > 6) messageBox.text = "";

        messageBox.text += number.ToString();

        if (messageBox.text.Length == 4)
        {
            StartCoroutine(CheckCombo());
        }
    }

    IEnumerator CheckCombo()
    {
        _eventSystem.enabled = false;

        if (messageBox.text == correctCode)
        {
            opened = true;
            print("ACCESS GRANTED!!");
            StopCoroutine(CheckCombo());
            //player.gameObject.SetActive(true);
            //panelCam.depth = Camera.main.depth - 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;

            lairOpenedTimeline.SetActive(true);
            ///
            _eventSystem.enabled = true;
        }
        else
        {
            messageBox.text = "WRONG CODE!!";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "WRONG CODE!!";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "WRONG CODE!!";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "";
            yield return new WaitForSeconds(0.3f);
            messageBox.text = "Input Code...";

            _eventSystem.enabled = true;
        }
    }

    public void Leave()
    {
        _eventSystem.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        player.gameObject.SetActive(true);
        panelCam.depth = Camera.main.depth - 1;
    }
}