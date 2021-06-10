/*using System;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;*/

using System.Collections.Generic;

namespace Controlador
{
    public class Controlador
    {
        Jugador jugadorX, jugadorO;
        bool turnoX;
        int[] jugX;
        int[] jugO;
        const string url = "http://192.168.0.34:5055/api/darposiciones";        
        const string urlPost = "http://192.168.0.34:5055/api/guardarjugador";


        public Controlador(string jX, string jO)
        {
            turnoX = true; // empieza el jugador X
            
            // inicializo array de jugadas
            jugX = new int[9]; 
            jugO = new int[9];

            // inicializo jugadores y asigno nombre
            jugadorX = new Jugador();
            jugadorX.nombre = jX;
            jugadorO = new Jugador();
            jugadorO.nombre = jO;
        }  
        
        public Controlador() { }

        public string getUrlPost()
        {
            return urlPost;
        }
        public string getUrl()
        {
            return url;
        }
        public Jugador getJugX()
        {
            return jugadorX;
        }
        public Jugador getJugO()
        {
            return jugadorO;
        }

        public string darValor() // método que devuelve el valor para el texto de los botones
        {
            string r = "";
            if (turnoX)
            {
                r = "X";
                turnoX = false;
            }
            else
            {
                r = "O";
                turnoX = true;
            }

            return r;
        }

        public bool quienJuega() // 
        {
            return turnoX;
        }

        public void asignaJugada(int n) // carga la jugada en la posición del vector correspondiente
        {
            if (!turnoX)
                jugX[n] = 1;
            else
                jugO[n] = 1;
        }
                
         public bool hayGanador() // verifica si hay ganador y le suma un punto
        {
            bool gano = false;
            if (!turnoX) // según quien haya jugado
            {
                gano = verificar(jugX); // verifico si ganó
                if (gano)
                    jugadorX.puntos += 1; // en caso verdadero, sumo un punto al ganador
            }
            else
            {
                gano = verificar(jugO);
                if (gano)
                    jugadorO.puntos += 1;
            }

            return gano;
        }

        public bool verificar(int[] jug) // evalua c/u de las combinaciones que dan TATETI. Como el vector tiene un 1 en cada posición, cuando la suma
                                         // es igual a 3, entonces hay ganador.
        {
            bool ganador = false;
            if (jug[0] + jug[1] + jug[2] == 3)
                ganador = true;
            else if (jug[3] + jug[4] + jug[5] == 3)
                    ganador = true;
                else if (jug[6] + jug[7] + jug[8] == 3)
                        ganador = true;
                    else if (jug[0] + jug[4] + jug[8] == 3)
                            ganador = true;
                        else if (jug[2] + jug[4] + jug[6] == 3)
                                ganador = true;
                            else if (jug[0] + jug[3] + jug[6] == 3)
                                 ganador = true;
                                else if (jug[1] + jug[4] + jug[7] == 3)
                                    ganador = true;
                                    else if (jug[2] + jug[5] + jug[8] == 3)
                                        ganador = true;            
            return ganador;
        }                    

        public void reiniciaJuego()
        {
            turnoX = true; // empieza jugando el jugador X
            for (int i=0; i<jugX.Length; i++) // limpio registros de jugadas
            {
                jugX[i] = 0;
                jugO[i] = 0;
            }
        }

        public List<string> preparaLista(List<Jugador> list)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                lista.Add(i + 1 + "º " + list[i].nombre.ToString() + " // " + list[i].puntos.ToString());
            }
            return lista;
        }
              
    }
}
