﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Challenge> Challenges { get; set; }
    }
}
