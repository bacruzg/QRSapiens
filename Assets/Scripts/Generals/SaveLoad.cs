using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SaveLoad
    {
        public void Guardar(Save sv)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Temp.gd");
            bf.Serialize(file, sv);
            file.Close();
        }

        public Save Load()
        {
            Save rt = new Save();
            if (File.Exists(Application.persistentDataPath + "/Temp.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/Temp.gd", FileMode.Open);
                rt = (Save)bf.Deserialize(file);
                file.Close();
                return rt;
            }
            return null;
        }

        public List<Challenge> LoadDB()
        {
            List<Challenge> rt = new List<Challenge>();
            if (File.Exists(Application.persistentDataPath + "/ChBase.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ChBase.gd", FileMode.Open);
                rt = (List<Challenge>)bf.Deserialize(file);
                file.Close();
                return rt;
            }
            return null;
        }

        public void GuardarDB(List<Challenge> sv)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/ChBase.gd");
            bf.Serialize(file, sv);
            file.Close();
        }
    }
}
