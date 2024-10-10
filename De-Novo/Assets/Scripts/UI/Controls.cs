using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    private bool _keyboardSelected;
    private bool _controllerSelected;

    public TMP_Text keyboardButtonText;
    public TMP_Text controllerButtonText;

    public Button keyboardButton;
    public Button controllerButton;

    public bool KeyboardSelected
    {
        get { return _keyboardSelected; }
        set { _keyboardSelected = value;
            if (_keyboardSelected) _controllerSelected = false;
            UpdateButtonLabels();
        }
    }

    public bool ControllerSelected
    {
        get { return _controllerSelected; }
        set
        {
            _controllerSelected = value;
            if (_controllerSelected) _keyboardSelected = false;
            UpdateButtonLabels();
        }
    }

    private void Start()
    {
        KeyboardSelected = true;
        UpdateButtonLabels();

        keyboardButton.onClick.AddListener(ToggleKeyboard);

        controllerButton.onClick.AddListener(ToggleController);
    }

    public void ToggleKeyboard()
    {
        KeyboardSelected = true;

    }

    public void ToggleController()
    {
        ControllerSelected = true;

    }

    private void UpdateButtonLabels()
    {
        keyboardButtonText.text = KeyboardSelected ? "Keyboard: ON" : "Keyboard: OFF";
        controllerButtonText.text = ControllerSelected ? "Controller: ON" : "Controller: OFF";
    }

}
