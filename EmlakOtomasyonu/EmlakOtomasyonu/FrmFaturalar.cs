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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            Txtid.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtVergiDaire.Text = "";
            TxtAlici.Text = "";
            TxtSatici.Text = "";
            TxtTeslimEden.Text = "";
            TxtKomisyon.Text = "";
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtFaturaID.Text == "")
            {
                SqlCommand komut = new SqlCommand("Insert into TBL_FATURABILGI (TARIH,SAAT,VERGIDAIRE,ALICI,SATICI,TESLIMEDEN,KOMISYON) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", MskTarih.Text);
                komut.Parameters.AddWithValue("@P2", MskSaat.Text);
                komut.Parameters.AddWithValue("@P3", TxtVergiDaire.Text);
                komut.Parameters.AddWithValue("@P4", TxtAlici.Text);
                komut.Parameters.AddWithValue("@P5", TxtSatici.Text);
                komut.Parameters.AddWithValue("@P6", TxtTeslimEden.Text);
                komut.Parameters.AddWithValue("@P7", TxtKomisyon.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            if (TxtFaturaID.Text != "")
            {
                SqlCommand komut2 = new SqlCommand("Insert into TBL_FATURADETAY (EMLAKID,FIYAT,FATURAID) values (@P1,@P2,@P3)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", TxtEmlakID.Text);
                komut2.Parameters.AddWithValue("@P2", TxtFiyat.Text);
                komut2.Parameters.AddWithValue("@P3", TxtFaturaID.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                Txtid.Text = dr["FATURABILGIID"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtSatici.Text = dr["SATICI"].ToString();
                TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                TxtKomisyon.Text = dr["KOMISYON"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_FATURABILGI where FATURABILGIID=@P1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@P1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set TARIH=@P1,SAAT=@P2,VERGIDAIRE=@P3,ALICI=@P4,SATICI=@P5,TESLIMEDEN=@P6,KOMISYON=@P7 where FATURABILGIID=@P8", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", MskTarih.Text);
            komut.Parameters.AddWithValue("@P2", MskSaat.Text);
            komut.Parameters.AddWithValue("@P3", TxtVergiDaire.Text);
            komut.Parameters.AddWithValue("@P4", TxtAlici.Text);
            komut.Parameters.AddWithValue("@P5", TxtSatici.Text);
            komut.Parameters.AddWithValue("@P6", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@P7", TxtKomisyon.Text);
            komut.Parameters.AddWithValue("@P8", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaDetay fr = new FrmFaturaDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }
    }
}
