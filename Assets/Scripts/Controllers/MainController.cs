using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;
using Assets.Scripts.Models;

public class MainController : MonoBehaviour
{
    public SaveLoad sl = new SaveLoad();
    Save Guardado;

    [SerializeField]
    GameObject PasswordObj;

    [SerializeField]
    Text Password;

    private void Start()
    {
        PasswordObj.SetActive(false);
        Guardado = new Save();
        sl.Guardar(Guardado);
        Debug.Log("Se reinician variables");
    }

    public void SetAmountPlayers()
    {
        GameObject NameGO = GameObject.Find("Dropdown");
        Dropdown Dpd = NameGO.GetComponent<Dropdown>();
        Guardado = sl.Load();
        Guardado.AmountPlayers = 1 + Dpd.value;
        sl.Guardar(Guardado);
    }

    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPassword() {

        PasswordObj.SetActive(true);
      
    }

    public void ValidatePassword()
    {
        if (Password.text == "Pr0f3550r")
        {
            Password.text="";
            ChangeScene("LoadQuestions");
        }
        else
        {
            PasswordObj.SetActive(false);
        }
    }
}
