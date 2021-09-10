using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class Save
    {
        public int AmountPlayers=1, Turno, TotalTurnos;
        public Challenge DesafioActual= new Challenge();
        public string UsuarioActual;
        public List<Challenge> Desafios=new List<Challenge>();
        public List<User> Usuarios= new List<User>();

        public string
              NameUser1 = "Jugador1",
              NameUser2 = "Jugador2",
              NameUser3 = "Jugador3",
              NameUser4 = "Jugador4",
              NameUser5 = "Jugador5",
              BeforeScene;




    }
}
