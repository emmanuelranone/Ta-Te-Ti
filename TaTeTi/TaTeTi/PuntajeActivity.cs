using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using Android.App;
//using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
using Android.Widget;
using Controlador;




namespace TaTeTi
{
    [Activity(Label = "PuntajeActivity")]
    public class PuntajeActivity : Activity
    {
        Button btnVolver;
        ListView lView;
        List<string> lista;
        Controlador.Controlador c;
             

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_puntaje);           
       
            lView = FindViewById<ListView>(Resource.Id.listView1);
            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);
            btnVolver.Click +=  BtnVolver_Click;

            c = new Controlador.Controlador();
            lista = new List<string>();

            // HAGO LA LLAMADA AL SERVICIO          
            try
            {                
                Rest r = new Rest();
                var list = await r.getRequest<List<Jugador>>(c.getUrl());

                //LLENO LA LISTA
                if (default(List<Jugador>) != list)                                  
                    lView.Adapter = new Adapter.DataAdapter(this, c.preparaLista(list));                
                else
                {
                    var toast = Toast.MakeText(Application.Context, "Error al conectar", ToastLength.Short);
                    toast.Show();
                }
            }
            catch (Exception ex)
            {
                var toast = Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Long);
                toast.Show();
            }          
        }  
        

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Finish(); //termino la actividad
        }
    }
}