using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;
using Assets.Scripts.Models;

public class NamePlayersController : MonoBehaviour
{
    public SaveLoad sl = new SaveLoad();
    Save Guardado;


    private void Start()
    {
        Guardado = sl.Load();
        Guardado.BeforeScene = "NamePlayers";

        GameObject nameGO1 = GameObject.Find("IN1");
        GameObject nameGO2 = GameObject.Find("IN2");
        GameObject nameGO3 = GameObject.Find("IN3");
        GameObject nameGO4 = GameObject.Find("IN4");
        GameObject nameGO5 = GameObject.Find("IN5");
        InputField IN1 = nameGO1.GetComponent<InputField>();
        InputField IN2 = nameGO2.GetComponent<InputField>();
        InputField IN3 = nameGO3.GetComponent<InputField>();
        InputField IN4 = nameGO4.GetComponent<InputField>();
        InputField IN5 = nameGO5.GetComponent<InputField>();
        switch (Guardado.AmountPlayers)
        {
            case 1:
                nameGO2.SetActive(false);
                nameGO3.SetActive(false);
                nameGO4.SetActive(false);
                nameGO5.SetActive(false);
                break;
            case 2:

                nameGO3.SetActive(false);
                nameGO4.SetActive(false);
                nameGO5.SetActive(false);
                break;
            case 3:

                nameGO4.SetActive(false);
                nameGO5.SetActive(false);
                break;
            case 4:
                nameGO5.SetActive(false);
                break;
            case 5:
                break;
            default:
                Debug.Log("Cantidad no correcta " + Guardado.AmountPlayers);
                break;

        }
        sl.Guardar(Guardado);


    }

    public void SetPlayersName()
    {
        Guardado = sl.Load();
        GameObject nameGO1 = GameObject.Find("IN1");
        GameObject nameGO2 = GameObject.Find("IN2");
        GameObject nameGO3 = GameObject.Find("IN3");
        GameObject nameGO4 = GameObject.Find("IN4");
        GameObject nameGO5 = GameObject.Find("IN5");
        switch (Guardado.AmountPlayers)
        {

            case 1:
                InputField IN1 = nameGO1.GetComponent<InputField>();
                if (IN1.text != "")
                    Guardado.NameUser1 = IN1.text;
                break;
            case 2:
                InputField IN21 = nameGO1.GetComponent<InputField>();
                if (IN21.text != "")
                    Guardado.NameUser1 = IN21.text;

                InputField IN22 = nameGO2.GetComponent<InputField>();
                if (IN22.text != "")
                    Guardado.NameUser2 = IN22.text;

                break;
            case 3:
                InputField IN31 = nameGO1.GetComponent<InputField>();
                if (IN31.text != "")
                    Guardado.NameUser1 = IN31.text;

                InputField IN32 = nameGO2.GetComponent<InputField>();
                if (IN32.text != "")
                    Guardado.NameUser2 = IN32.text;

                InputField IN33 = nameGO3.GetComponent<InputField>();
                if (IN33.text != "")
                    Guardado.NameUser3 = IN33.text;
                break;
            case 4:
                InputField IN41 = nameGO1.GetComponent<InputField>();
                if (IN41.text != "")
                    Guardado.NameUser1 = IN41.text;

                InputField IN42 = nameGO2.GetComponent<InputField>();
                if (IN42.text != "")
                    Guardado.NameUser2 = IN42.text;

                InputField IN43 = nameGO3.GetComponent<InputField>();
                if (IN43.text != "")
                    Guardado.NameUser3 = IN43.text;

                InputField IN44 = nameGO4.GetComponent<InputField>();
                if (IN44.text != "")
                    Guardado.NameUser4 = IN44.text;
                break;
            case 5:
                InputField IN51 = nameGO1.GetComponent<InputField>();
                if (IN51.text != "")
                    Guardado.NameUser1 = IN51.text;

                InputField IN52 = nameGO2.GetComponent<InputField>();
                if (IN52.text != "")
                    Guardado.NameUser2 = IN52.text;

                InputField IN53 = nameGO3.GetComponent<InputField>();
                if (IN53.text != "")
                    Guardado.NameUser3 = IN53.text;

                InputField IN54 = nameGO4.GetComponent<InputField>();
                if (IN54.text != "")
                    Guardado.NameUser4 = IN54.text;

                InputField IN55 = nameGO5.GetComponent<InputField>();
                if (IN55.text != "")
                    Guardado.NameUser5 = IN55.text;
                break;
        }
        Guardado.BeforeScene = "NamePlayers";
        sl.Guardar(Guardado);
    } 

    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }


}
