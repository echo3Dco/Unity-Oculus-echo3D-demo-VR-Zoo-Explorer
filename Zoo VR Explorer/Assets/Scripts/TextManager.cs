using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    XRDeviceSimulatorControls xrSimulatorControls;
    XRIDefaultInputActions xrDefaultControls;
    private bool pressed;
    public TextAsset textfile;
    private List<string> textLines;
    private int currentLine;
    public TMP_Text text;

    public Coroutine currentScrollType;

    public float typeSpeed;       //how fast the scroll works
    private bool isTyping;       //used for checking if textScroll is happening
    private bool cancelTyping;   //used to check if player wants to cancel the scroll

    public float stayTime; //how long the text will stay before fading out
    private bool goText;    //if coroutine is happening

    public GameObject textbox;

    //public string NextSceneName;

    private void Awake(){
        xrSimulatorControls = new XRDeviceSimulatorControls();
        xrDefaultControls = new XRIDefaultInputActions();
    }
    private void OnEnable() {
        textbox.SetActive(true);
        text.gameObject.SetActive(true);
        textLines = new List<string>(textfile.text.Split('\n'));
        currentLine = 0;
        text.text = textLines[currentLine];
        typeSpeed = 0.03f;
        isTyping = false;
        cancelTyping = false;
        stayTime = 5f;
        goText = false;

        xrSimulatorControls.InputControls.PrimaryButton.Enable();
        xrSimulatorControls.InputControls.PrimaryButton.performed += SkipText;

        xrDefaultControls.XRILeftHand.UIPress.Enable();
        xrDefaultControls.XRILeftHand.UIPress.performed += SkipText;
    }

    private void OnDisable() {
        xrSimulatorControls.InputControls.PrimaryButton.Disable();

        xrDefaultControls.XRILeftHand.UIPress.Disable();
    }

    private void SkipText(InputAction.CallbackContext obj){
        pressed = true;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!goText)
        {
            Scroll();
            goText = true;
        }
        if (pressed && currentLine == textLines.Count - 1 && cancelTyping)
        {
            pressed = false;
            text.text = "";
            textbox.gameObject.SetActive(false);
            this.gameObject.GetComponent<TextManager>().enabled = false;
            //SceneManager.LoadScene(NextSceneName);
        }
        else if (pressed && !cancelTyping)
        {
            pressed = false;
            cancelTyping = true;
        }
        else if (pressed && cancelTyping)
        {
            pressed = false;
            NextLine();
        }
    }

    public void Scroll()
    {
        currentScrollType = StartCoroutine(ScrollTyping());
    }

    public void NextLine()
    {
        StopCoroutine(currentScrollType);
        currentLine++;
        goText = false;
    }

    public IEnumerator ScrollTyping()
    {
        int index = 0;
        text.text = "";
        isTyping = true;
        cancelTyping = false;
        string currentTextLine = textLines[currentLine];
        while (isTyping && !cancelTyping && (index < currentTextLine.Length - 1))
        {
            text.text += currentTextLine[index];
            index++;
            yield return new WaitForSeconds(typeSpeed);
        }
        cancelTyping = true;
        text.text = textLines[currentLine];
        yield return new WaitForSeconds(stayTime);
        currentLine++;
        goText = false;
    }
}
