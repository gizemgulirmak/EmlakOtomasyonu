﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmlakOtomasyonu
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-I8ENJGD\SQLEXPRESS;Initial Catalog=EmlakOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
