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
using System.Xml;

namespace EmlakOtomasyonu
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        void haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlOku.Read())
            {
                if (xmlOku.Name == "title")
                {
                    listBox1.Items.Add(xmlOku.ReadString());
                }
            }
        }

        void notlar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BASLIK,DETAY,OLUSTURAN From TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string isletme;
        public string ad;
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

            Lblisletme.Text = isletme;
            LblKullanici.Text = ad;

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            haberler();

            notlar();
        }
    }
}
