using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalsMobile : MonoBehaviour
{
    [SerializeField] GameObject joystickDirectional;
    [SerializeField] GameObject buttonDirectional;
    [SerializeField] GameObject buttonJump;

    public enum Directional
    {
        joystick = 0,
        buttons = 1,
        keyboard = 2
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        var directional = PlayerPrefs.GetInt("Directional").Equals((int)Directional.joystick) ? Directional.joystick : PlayerPrefs.GetInt("Directional").Equals((int)Directional.buttons) ? Directional.buttons : Directional.keyboard;
        switch (directional)
        {
            case Directional.joystick:
                EnablesDirectionals(true, false);
                break;
            case Directional.buttons:
                EnablesDirectionals(false, true);
                break;
            case Directional.keyboard:
                EnablesDirectionals(false, false);
                buttonJump.SetActive(false);
                break;
        }
        PlayerManager.ChooseDirectional((int)directional);
    }

    void EnablesDirectionals(bool isJoy, bool isButton)
    {
        joystickDirectional.SetActive(isJoy);
        buttonDirectional.SetActive(isButton);
    }
}
