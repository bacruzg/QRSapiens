using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Challenge
    {
        public int Id { get; set; }
        //public string PathImg { get; set; }
        public string Question { get; set; }   
        public Answer AnswerCorrect { get; set; }
        public string AnswerDescription { get; set; }
        public int Points { get; set; }





 

    }
}
