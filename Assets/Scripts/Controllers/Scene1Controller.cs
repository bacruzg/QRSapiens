using Assets.Scripts;
using Assets.Scripts.Models;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour
{
    public Utils Utils = new Utils();


    [SerializeField]
    GameObject ResultObj;

    [SerializeField]
    Text ResultText;

    [SerializeField]
    Text ResultCorrection;

    [SerializeField]
    Text UserActual;
    [SerializeField]
    Text RondaActual;

    [SerializeField]
    GameObject BtnGroup;

 
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
    Text JN1;
    [SerializeField]
    Text JN2;
    [SerializeField]
    Text JN3;
    [SerializeField]
    Text JN4;
    [SerializeField]
    Text JN5;


    public SaveLoad sl = new SaveLoad();
    Save Guardado;


    private void Start()
    {
        BtnGroup.SetActive(true);
        ResultObj.SetActive(false);


        Guardado = sl.Load();
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

        if (Guardado.BeforeScene == "NamePlayers")
        {
            Debug.Log("Escena uno recibe de Nameplayers " + Guardado.AmountPlayers);
            Utils.InitGame();
            Guardado = sl.Load();
            Guardado.BeforeScene = "Scene1";
            sl.Guardar(Guardado);
            Start();
        }

        else
        {
            Guardado = sl.Load();

            if (String.IsNullOrEmpty(Guardado.UsuarioActual) && Guardado.Usuarios[0].Challenges.Count == 10)
            {
                Guardado.UsuarioActual = Guardado.Usuarios[0].Name;
                Debug.Log("usuario actual guardado: " + Guardado.UsuarioActual);
                Guardado.Turno = 1;
                sl.Guardar(Guardado);
                Start();
            }
            else if (Guardado.Turno <= Guardado.TotalTurnos)
            {
                Guardado = sl.Load();
             
                Debug.Log("userActual= " + Guardado.UsuarioActual);
                UserActual.text = "Jugador actual: "+Guardado.UsuarioActual;
                User UserTemp = Guardado.Usuarios.Where(s => s.Name == Guardado.UsuarioActual).FirstOrDefault();

                System.Random rnd = new System.Random();
                int index = rnd.Next(UserTemp.Challenges.Count);
                Guardado.DesafioActual = UserTemp.Challenges[index];
                Guardado.Usuarios.Where(s => s.Name == Guardado.UsuarioActual).First().Challenges.Remove(Guardado.DesafioActual);
                int Ronda = 10 - Guardado.Usuarios[0].Challenges.Count;
                RondaActual.text = "Ronda: " + Ronda;
                GameObject GOQuestion = GameObject.Find("Question");
                Text Question = GOQuestion.GetComponent<Text>();
                Question.text = Guardado.DesafioActual.Question;
                Guardado.Turno += 1;
                sl.Guardar(Guardado);

            }
            else
            {
                BtnGroup.SetActive(false);
                Guardado = sl.Load();
                //MOstrar ganador
                Debug.Log("Fin de la partida");
                sl.Guardar(Guardado);
                ChangeScene("Podium");
            }

        }

    }

    public void ValidateAnswer(int AnswerResponse)
    {
        Guardado = sl.Load();
        if (Guardado.DesafioActual.AnswerCorrect == (Answer)AnswerResponse)
        {
            Guardado.Usuarios.Where(s => s.Name == Guardado.UsuarioActual).First().Score += Guardado.DesafioActual.Points;
            ResultCorrection.fontSize = 30;
            ResultCorrection.text = "¡Respuesta correcta!";
            //ResultCorrection.color = new Color(149, 241, 78);       
            ResultText.text = "";
        }
        else
        {
            ResultText.text = "¡Respuesta incorrecta!";
            //ResultText.color = Color.red;        
            ResultCorrection.fontSize = 18;
            ResultCorrection.text = Guardado.DesafioActual.AnswerDescription;
        }
        ResultObj.SetActive(true);
        BtnGroup.SetActive(false);
        sl.Guardar(Guardado);

    }

    public void NextTurn()
    {
        Guardado = sl.Load();
        if (Guardado.UsuarioActual == Guardado.NameUser1)
        {
            if (Guardado.Usuarios.Where(u => u.Name == Guardado.NameUser2).FirstOrDefault() != null)
            {
                Guardado.UsuarioActual = Guardado.NameUser2;
            }

        }
        else if (Guardado.UsuarioActual == Guardado.NameUser2)
        {

            if (Guardado.Usuarios.Where(u => u.Name == Guardado.NameUser3).FirstOrDefault() != null)
            {
                Guardado.UsuarioActual = Guardado.NameUser3;
            }
            else
            {
                Guardado.UsuarioActual = Guardado.NameUser1;

            }


        }
        else if (Guardado.UsuarioActual == Guardado.NameUser3)
        {
            if (Guardado.Usuarios.Where(u => u.Name == Guardado.NameUser4).FirstOrDefault() != null)
            {
                Guardado.UsuarioActual = Guardado.NameUser4;
            }
            else
            {
                Guardado.UsuarioActual = Guardado.NameUser1;

            }
        }
        else if (Guardado.UsuarioActual == Guardado.NameUser4)
        {
            if (Guardado.Usuarios.Where(u => u.Name == Guardado.NameUser5).FirstOrDefault() != null)
            {
                Guardado.UsuarioActual = Guardado.NameUser5;
            }
            else
            {
                Guardado.UsuarioActual = Guardado.NameUser1;

            }
        }
        else if (Guardado.UsuarioActual == Guardado.NameUser5)
        {
            Guardado.UsuarioActual = Guardado.NameUser1;
        }

        Debug.Log("Siguiente turno: " + Guardado.UsuarioActual);
        sl.Guardar(Guardado);
        Start();
    }

    public void ChangeScene(string NameScene)
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Username")))
        {
            SceneManager.LoadScene(NameScene);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
