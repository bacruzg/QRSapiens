using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;
using Assets.Scripts.Models;
using System.Linq;

public class PodiumController : MonoBehaviour
{
    public SaveLoad sl = new SaveLoad();
    Save Guardado;

    [SerializeField]
    GameObject TopScoresObj;

    [SerializeField]
    Text JS1;
    [SerializeField]
    Text JS2;
    [SerializeField]
    Text JS3;
    [SerializeField]
    Text JS4;
    [SerializeField]
    Text JS5;

    [SerializeField]
    GameObject TopNamesObj;

    [SerializeField]
    Text JN1;
    [SerializeField]
    Text JN2;
    [SerializeField]
    Text JN3;
    [SerializeField]
    Text JN4;
    [SerializeField]
    Text JN5;

    private void Start()
    {
        Guardado = sl.Load();
        Guardado.Usuarios = Guardado.Usuarios.OrderByDescending(c=>c.Score).ToList();
        switch (Guardado.Usuarios.Count)
        {

            case 1:
                JN1.text = Guardado.Usuarios[0].Name;
                JS1.text = Guardado.Usuarios[0].Score.ToString();
                break;

            case 2:
                JN1.text = Guardado.Usuarios[0].Name;
                JS1.text = Guardado.Usuarios[0].Score.ToString();
                JN2.text = Guardado.Usuarios[1].Name;
                JS2.text = Guardado.Usuarios[1].Score.ToString();
                break;

            case 3:
                JN1.text = Guardado.Usuarios[0].Name;
                JS1.text = Guardado.Usuarios[0].Score.ToString();
                JN2.text = Guardado.Usuarios[1].Name;
                JS2.text = Guardado.Usuarios[1].Score.ToString();
                JN3.text = Guardado.Usuarios[2].Name;
                JS3.text = Guardado.Usuarios[2].Score.ToString();
                break;

            case 4:
                JN1.text = Guardado.Usuarios[0].Name;
                JS1.text = Guardado.Usuarios[0].Score.ToString();
                JN2.text = Guardado.Usuarios[1].Name;
                JS2.text = Guardado.Usuarios[1].Score.ToString();
                JN3.text = Guardado.Usuarios[2].Name;
                JS3.text = Guardado.Usuarios[2].Score.ToString();
                JN4.text = Guardado.Usuarios[3].Name;
                JS4.text = Guardado.Usuarios[3].Score.ToString();
                break;
            case 5:
                JN1.text = Guardado.Usuarios[0].Name;
                JS1.text = Guardado.Usuarios[0].Score.ToString();
                JN2.text = Guardado.Usuarios[1].Name;
                JS2.text = Guardado.Usuarios[1].Score.ToString();
                JN3.text = Guardado.Usuarios[2].Name;
                JS3.text = Guardado.Usuarios[2].Score.ToString();
                JN4.text = Guardado.Usuarios[3].Name;
                JS4.text = Guardado.Usuarios[3].Score.ToString();
                JN5.text = Guardado.Usuarios[4].Name;
                JS5.text = Guardado.Usuarios[4].Score.ToString();
                break;
        }

    }



    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }


}
