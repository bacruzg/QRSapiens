using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Utils
    {
        public SaveLoad sl = new SaveLoad();
        Save Guardado;

        public void InitUsers()
        {
            Guardado = sl.Load();
            string[] Names = { Guardado.NameUser1, Guardado.NameUser2, Guardado.NameUser3, Guardado.NameUser4, Guardado.NameUser5 };
            List<User> list = new List<User>();
            for (int x = 0; x < Guardado.AmountPlayers; x++)
            {
                User userTemp = new User();
                userTemp.Name = Names[x];
                userTemp.Score = 0;
                userTemp.Challenges = new List<Challenge>();
                list.Add(userTemp);
            }

            Guardado.Usuarios = list;
            Debug.Log("Se crearon " + list.Count + " usuarios");
            sl.Guardar(Guardado);
        }

        public void InitFakeDB(string Path)
        {
            Guardado = sl.Load();
            string[] tempArr;
            int cont = 0;
            List<Challenge> desafios = new List<Challenge>();
            using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.GetEncoding(1252), false))
            {
                sr.ReadLine();
                while (sr.Peek() != -1)
                {
                    cont += 1;
                    tempArr = sr.ReadLine().Split(';');
                    desafios.Add(new Challenge
                    {
                        Id = cont,
                        Question = tempArr[0],
                        AnswerCorrect = (Answer)Int32.Parse(tempArr[1]),
                        AnswerDescription = tempArr[2],
                        Points = Int32.Parse(tempArr[3])
                    });
                }
            }

            Guardado.Desafios = desafios;

            sl.Guardar(Guardado);
            Debug.Log("Se  initFakedb: "+Path + desafios.Count);
        }

        public void AsignDesafios()
        {
            Guardado = sl.Load();
            List<Challenge> Des100 = Guardado.Desafios.Where(a => a.Points == 100).ToList();
            List<Challenge> Des200 = Guardado.Desafios.Where(a => a.Points == 200).ToList();
            List<Challenge> Des300 = Guardado.Desafios.Where(a => a.Points == 300).ToList();
          
            int Cant100 = 5;
            int Cant200 = 3;
            int Cant300 = 2;

            foreach (User us in Guardado.Usuarios)
            {
                System.Random rnd = new System.Random();
               
                for (int x = 0; x < Cant100; x++)
                {
                    int index = rnd.Next(Des100.Count);
                    Challenge question100 = Des100[index];
                    us.Challenges.Add(question100);
                    Des100.RemoveAt(index);
                }
                for (int x = 0; x < Cant200; x++)
                {
                    int index = rnd.Next(Des200.Count);
                    Challenge question200 = Des200[index];
                    us.Challenges.Add(question200);
                    Des200.RemoveAt(index);
                }
                for (int x = 0; x < Cant300; x++)
                {
                    int index = rnd.Next(Des300.Count);
                    Challenge question300 = Des300[index];
                    us.Challenges.Add(question300);
                    Des300.RemoveAt(index);
                }
            }
            sl.Guardar(Guardado);
            Debug.Log("Finalza asigndesafios " + Guardado.Usuarios[0].Challenges[0].Question);

            Debug.Log("Finalza asigndesafios " + Guardado.Usuarios[0].Name);
        }

        public void InitGame()
        {
            Guardado = sl.Load();
            if(sl.LoadDB() != null){
                Guardado.Desafios = sl.LoadDB();
                sl.Guardar(Guardado);
                Debug.Log("Encontró BD desafios guardados");
            }
            else
            {
                string Path = "Assets/Resources/Rs1";
                InitFakeDB(Path);
                Debug.Log("NO encontró BD desafios guardados");
            }        
         
            InitUsers();          
            AsignDesafios();         
            Guardado = sl.Load();
            Guardado.TotalTurnos = Guardado.Usuarios.Count * 10;
            sl.Guardar(Guardado);
        }



    }


}

