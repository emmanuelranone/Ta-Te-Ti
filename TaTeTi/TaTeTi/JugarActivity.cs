using System;
using System.Collections.Generic;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controlador;*/
using Android.App;
using Android.Content;
//using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
using Android.Widget;
using Controlador;
//using System.Timers;


namespace TaTeTi
{
    [Activity(Label = "JugarActivity")]
    public class JugarActivity : Activity
    {
        internal static string key_X = "keyX";
        internal static string key_O = "keyO";
        Controlador.Controlador c;
        Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnSalir;
        TextView txtTur;
        int jugadas;
        string jugX, jugO;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_jugar);

            // Create your application here
            GridLayout gl = FindViewById<GridLayout>(Resource.Id.gridLayout1);

            jugX = Intent.GetStringExtra("keyX");
            jugO = Intent.GetStringExtra("keyO");

            //llamo al constructor de la clase Controlador, le paso los jugadores por parámetros
            c = new Controlador.Controlador(jugX,jugO);

            //asocio los elementos
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btn5 = FindViewById<Button>(Resource.Id.btn5);
            btn6 = FindViewById<Button>(Resource.Id.btn6);
            btn7 = FindViewById<Button>(Resource.Id.btn7);
            btn8 = FindViewById<Button>(Resource.Id.btn8);
            btn9 = FindViewById<Button>(Resource.Id.btn9);
            btnSalir = FindViewById<Button>(Resource.Id.btnVolver);
            txtTur = FindViewById<TextView>(Resource.Id.txtTurno);

            // creo los delegados
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            btn5.Click += Btn5_Click;
            btn6.Click += Btn6_Click;
            btn7.Click += Btn7_Click;
            btn8.Click += Btn8_Click;
            btn9.Click += Btn9_Click;
            btnSalir.Click += BtnSalir_Click;

            jugadas = 0;
            estableceJug(); // informo quien juega
                      
        }
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Finish(); // termino la actividad
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text == "")
            {
                btn9.Text = c.darValor(); // devuelve el valor para el texto del botón (X,O)
                c.asignaJugada(8); // cargo lo que presiono el jugador en el arreglo de jugadas
                jugadas++; // aumento el contador de jugadas. Si llega a 9 y nadie gano es porque hubo un empate.
            }

            if (btn9.Text == "O")
                btn9.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404")); // color rojo para O
            if (btn9.Text == "X")
                btn9.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8")); // color azul para X

            if (c.hayGanador()) // método booleano que devuelve si hubo un ganador
            {
                tateti(); // hubo ganador
            }
            else
                if (jugadas == 9) // si llegamos a 9 juegadas y nadie gano
                    empate(); // se produjo un empate
                else
                    estableceJug(); // informa quien será el próximo jugador
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text == "")
            {
                btn8.Text = c.darValor();
                c.asignaJugada(7);
                jugadas++;
            }

            if (btn8.Text == "O")
                btn8.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn8.Text == "X")
                btn8.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                empate();
                else
                    estableceJug();
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text == "")
            {
                btn7.Text = c.darValor();
                c.asignaJugada(6);
                jugadas++;
            }

            if (btn7.Text == "O")
                btn7.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn7.Text == "X")
                btn7.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text == "")
            {
                btn6.Text = c.darValor();
                c.asignaJugada(5);
                jugadas++;
            }

            if (btn6.Text == "O")
                btn6.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn6.Text == "X")
                btn6.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text == "")
            {
                btn5.Text = c.darValor();
                c.asignaJugada(4);
                jugadas++;
            }

            if (btn5.Text == "O")
                btn5.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn5.Text == "X")
                btn5.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "")
            {
                btn4.Text = c.darValor();
                c.asignaJugada(3);
                jugadas++;
            }

            if (btn4.Text == "O")
                btn4.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn4.Text == "X")
                btn4.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
               if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "")
            {
                btn3.Text = c.darValor();
                c.asignaJugada(2);
                jugadas++;
            }

            if (btn3.Text == "O")
                btn3.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn3.Text == "X")
                btn3.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                btn2.Text = c.darValor();
                c.asignaJugada(1);
                jugadas++;
            }

            if (btn2.Text == "O")
                btn2.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn2.Text == "X")
                btn2.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "")
            {
                btn1.Text = c.darValor();
                c.asignaJugada(0);
                jugadas++;
            }

            if (btn1.Text == "O")
                btn1.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
            if (btn1.Text == "X")
                btn1.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));

            if (c.hayGanador())
            {
                tateti();
            }
            else
                if (jugadas == 9)
                    empate();
                else
                    estableceJug();
        }

        public void estableceJug()
        {
            if (c.quienJuega()) // método que determina quién es el próximo jugador
            {
                txtTur.SetTextColor(Android.Graphics.Color.ParseColor("#ff0019d8"));
                txtTur.Text = "Turno Jugador " + jugX;
            }
            else
            {
                txtTur.SetTextColor(Android.Graphics.Color.ParseColor("#fff50404"));
                txtTur.Text = "Turno Jugador " + jugO;
            }
        }

        public void bloqueaTablero()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;

        }

        public void desbloqueaTablero()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            estableceJug();
        }       

        public void empezarDeNuevo()
        {
            c.reiniciaJuego();
            desbloqueaTablero();           
        }

        public void tateti()
        {
            txtTur.Text = "TATETI";
            bloqueaTablero();

            mostrarAlerta(true);
        }

        public void empate()
        {
            txtTur.Text = "EMPATE";
            bloqueaTablero();
            
            mostrarAlerta(false);
        }

        public void  mostrarAlerta(bool op)
        {
            jugadas = 0; // termino el juego, reinicio contador de jugadas
            string msg = "";
            if (op) // dependiendo el valor de op, el juego termino como EMPATE o TATETI
                msg = "Tenemos un ganador";
            else
                msg = "Empatamos";

            //muestro un alerta con opciones para seguir...
            AlertDialog alerta = new AlertDialog.Builder(this).Create();
            alerta.SetTitle(msg);
            alerta.SetMessage("¿Jugamos una vez más?");
            alerta.SetButton("No", (a, b) =>
            {                
                postearResultado();              

                this.Finish();
            });
            alerta.SetButton2("Si", (e, d) =>
            {
                empezarDeNuevo(); //   establecer valores para volver a jugar              
            });

            alerta.Show();
        }

        async void postearResultado()
        {            
            Rest r = new Rest();
            var resp = 0;
            if (c.getJugX().puntos > 0) 
                resp = await r.postPuntaje<int>(c.getUrlPost(),c.getJugX());
            if (c.getJugO().puntos > 0)
                resp = await r.postPuntaje<int>(c.getUrlPost(), c.getJugO());
        }

    }
}