using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    private MovimentPlayer Moviment;

    public enum Directional
    {
        joystick = 0,
        buttons = 1,
        keyboard = 2
    }

    public static GameObject Player
    {
        get
        {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Start()
    {
        if (instance == null)
        {
            Moviment = GetComponent<MovimentPlayer>();
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ChooseDirectional(int directional)
    {
        instance.Moviment.directional = directional;
    }
}
