using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmlakOtomasyonu
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where ISLETME=@P1 and KULLANICI=@P2 and SIFRE=@P3", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtisletmeAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AnaModul fr = new AnaModul();

                //Ana Sayfaya bilgi çekmek için
                fr.kullanici = TxtKullaniciAd.Text;
                fr.kurum = TxtisletmeAd.Text;

                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }
    }
}
