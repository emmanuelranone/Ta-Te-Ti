using Android.App;
using Android.OS;
using Android.Support.V7.App;
//using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Android.Views;

namespace TaTeTi
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtNombre, txtNombreO;
        Button btnPrueba, btnSalir, btnPosi;
        
        //Label = "@string/app_name", 
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle); //oculta el título

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtNombreO = FindViewById<EditText>(Resource.Id.txtNombreO);
            btnPrueba = FindViewById<Button>(Resource.Id.btnJugar);
            btnPosi = FindViewById<Button>(Resource.Id.btnPosi);
            btnSalir = FindViewById<Button>(Resource.Id.btnSalir);

            btnPrueba.Click += BtnPrueba_Click;
            btnPosi.Click += BtnPosi_Click;
            btnSalir.Click += BtnSalir_Click;            
            

        }

        private void BtnPosi_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PuntajeActivity));
            StartActivity(intent);
        }

        private void BtnPrueba_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(JugarActivity));
            string n = txtNombre.Text;
            string nO = txtNombreO.Text;

            if (txtNombre.Text != "" && txtNombreO.Text != "")
            {
                intent.PutExtra(JugarActivity.key_X, n);
                intent.PutExtra(JugarActivity.key_O, nO);                
                StartActivity(intent);
            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Completá los Nombres", ToastLength.Short);
                toast.Show();
            }
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            txtNombre.Text = "";
            txtNombreO.Text = "";
        }

        private void BtnSalir_Click(object sender, System.EventArgs e)
        {
            this.Finish();
        }
    }
}