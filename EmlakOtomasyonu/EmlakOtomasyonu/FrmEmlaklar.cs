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
    public partial class FrmEmlaklar : Form
    {
        public FrmEmlaklar()
        {
            InitializeComponent();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_EMLAKLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            Txtid.Text = "";
            CmbKategori.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            CmbOdaSayisi.Text = "";
            CmbBinaYasi.Text = "";
            CmbKat.Text = "";
            CmbKatSayisi.Text = "";
            CmbIsitma.Text = "";
            CmbBanyoSayisi.Text = "";
            CmbBalkon.Text = "";
            CmbEsyali.Text = "";
            CmbKullanimDurumu.Text = "";
            TxtFiyat.Text = "";
            TxtilanSahibi.Text = "";
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmEmlaklar_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_EMLAKLAR (KATEGORI,IL,ILCE,ODASAYISI,BINAYASI,BULUNDUGUKAT,KATSAYISI,ISITMA,BANYOSAYISI,BALKONSAYISI,ESYALI,KULLANIMDURUMU,FIYAT,ILANSAHIBI) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", CmbKategori.Text);
            komut.Parameters.AddWithValue("@P2", Cmbil.Text);
            komut.Parameters.AddWithValue("@P3", Cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", CmbOdaSayisi.Text);
            komut.Parameters.AddWithValue("@P5", CmbBinaYasi.Text);
            komut.Parameters.AddWithValue("@P6", CmbKat.Text);
            komut.Parameters.AddWithValue("@P7", CmbKatSayisi.Text);
            komut.Parameters.AddWithValue("@P8", CmbIsitma.Text);
            komut.Parameters.AddWithValue("@P9", CmbBanyoSayisi.Text);
            komut.Parameters.AddWithValue("@P10", CmbBalkon.Text);
            komut.Parameters.AddWithValue("@P11", CmbEsyali.Text);
            komut.Parameters.AddWithValue("@P12", CmbKullanimDurumu.Text);
            komut.Parameters.AddWithValue("@P13", TxtFiyat.Text);
            komut.Parameters.AddWithValue("@P14", TxtilanSahibi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni emlak kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_EMLAKLAR where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Seçilen emlak silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            CmbKategori.Text = dr["KATEGORI"].ToString();
            Cmbil.Text = dr["IL"].ToString();
            Cmbilce.Text = dr["ILCE"].ToString();
            CmbOdaSayisi.Text = dr["ODASAYISI"].ToString();
            CmbBinaYasi.Text = dr["BINAYASI"].ToString();
            CmbKat.Text = dr["BULUNDUGUKAT"].ToString();
            CmbKatSayisi.Text = dr["KATSAYISI"].ToString();
            CmbIsitma.Text = dr["ISITMA"].ToString();
            CmbBanyoSayisi.Text = dr["BANYOSAYISI"].ToString();
            CmbBalkon.Text = dr["BALKONSAYISI"].ToString();
            CmbEsyali.Text = dr["ESYALI"].ToString();
            CmbKullanimDurumu.Text = dr["KULLANIMDURUMU"].ToString();
            TxtFiyat.Text = dr["FIYAT"].ToString();
            TxtilanSahibi.Text = dr["ILANSAHIBI"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_EMLAKLAR set KATEGORI=@P1,IL=@P2,ILCE=@P3,ODASAYISI=@P4,BINAYASI=@P5,BULUNDUGUKAT=@P6,KATSAYISI=@P7,ISITMA=@P8,BANYOSAYISI=@P9,BALKONSAYISI=@P10,ESYALI=@P11,KULLANIMDURUMU=@P12,FIYAT=@P13,ILANSAHIBI=@P14 where ID=@P15", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", CmbKategori.Text);
            komut.Parameters.AddWithValue("@P2", Cmbil.Text);
            komut.Parameters.AddWithValue("@P3", Cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", CmbOdaSayisi.Text);
            komut.Parameters.AddWithValue("@P5", CmbBinaYasi.Text);
            komut.Parameters.AddWithValue("@P6", CmbKat.Text);
            komut.Parameters.AddWithValue("@P7", CmbKatSayisi.Text);
            komut.Parameters.AddWithValue("@P8", CmbIsitma.Text);
            komut.Parameters.AddWithValue("@P9", CmbBanyoSayisi.Text);
            komut.Parameters.AddWithValue("@P10", CmbBalkon.Text);
            komut.Parameters.AddWithValue("@P11", CmbEsyali.Text);
            komut.Parameters.AddWithValue("@P12", CmbKullanimDurumu.Text);
            komut.Parameters.AddWithValue("@P13", TxtFiyat.Text);
            komut.Parameters.AddWithValue("@P14", TxtilanSahibi.Text);
            komut.Parameters.AddWithValue("@P15", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Emlak bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From TBL_ILCELER where SEHIR=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
