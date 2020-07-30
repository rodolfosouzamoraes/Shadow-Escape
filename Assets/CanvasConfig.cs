using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasConfig : MonoBehaviour
{
    [SerializeField] Toggle toggleAnalogico;
    [SerializeField] Toggle toggleDigital;
    public enum Directional
    {
        joystick = 0,
        buttons = 1,
        keyboard = 2
    }
    void OnEnable()
    {
        var directional = PlayerPrefs.GetInt("Directional").Equals((int)Directional.joystick) ? Directional.joystick : PlayerPrefs.GetInt("Directional").Equals((int)Directional.buttons) ? Directional.buttons : Directional.keyboard;
        switch (directional)
        {
            case Directional.joystick:
                toggleAnalogico.isOn = true;
                toggleDigital.isOn = false;
                break;
            case Directional.buttons:
                toggleAnalogico.isOn = false;
                toggleDigital.isOn = true;
                break;
            case Directional.keyboard:
                toggleAnalogico.isOn = false;
                toggleDigital.isOn = false;
                break;
        }
    }

    public void OnAnalogic(){
        toggleDigital.isOn = false;
        PlayerPrefs.SetInt("Directional",(int)Directional.joystick);
    }

    public void OnDigital(){
        toggleAnalogico.isOn = false;
        PlayerPrefs.SetInt("Directional",(int)Directional.buttons);
    }
}
