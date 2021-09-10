using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;
using Assets.Scripts.Models;

public class LoadQuestionsController : MonoBehaviour
{
    public SaveLoad sl = new SaveLoad();
    Save Guardado;
    Utils ul = new Utils();
    [SerializeField]
    Text Path;
    [SerializeField]
    GameObject FormLoad;
    [SerializeField]

    GameObject ResultObj;
    [SerializeField]
    Text ResultText;

    private void Start()
    {
        ResultObj.SetActive(false);
    }



    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void LoadNewQuestions()
    {
        if (Path.text != "")
        {
            try
            {
                ul.InitFakeDB(Path.text);
                Guardado = sl.Load();
                sl.GuardarDB(Guardado.Desafios);
                ResultObj.SetActive(true);
                FormLoad.SetActive(false);
                ResultText.text = "Preguntas cargadas correctamente";
            }catch(Exception e)
            {
                ResultObj.SetActive(true);
                FormLoad.SetActive(false);
                ResultText.text = "Hubo un error en el cargue: "+e.Message;
            }
        }
    }

    public void ExitWindow()
    {
        ResultObj.SetActive(false);
        FormLoad.SetActive(true);
        Path.text = "";
    }

}
