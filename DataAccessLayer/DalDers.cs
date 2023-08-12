using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class DalDers
    {
        //crud Metotları
        //Eklme silme güncelleme listeleme
        public static int DersEkle(EntityDers parametre)
        {
            SqlCommand komut1 = new SqlCommand("insert into tblDersler " +
                "(DersAd) values (@p1)", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", parametre.DersAd);
            return komut1.ExecuteNonQuery();
        }
        
    }
}
