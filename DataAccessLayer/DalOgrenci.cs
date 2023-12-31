﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DalOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci p)
        {
            SqlCommand komut1 = new SqlCommand("insert into tblOgrenci (Ad,Soyad, Numara, Bolum) values (@p1, @p2, @p3, @p4)", Baglanti.bgl);
            if (komut1.Connection.State != System.Data.ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", p.Ad);
            komut1.Parameters.AddWithValue("@p2", p.Soyad);
            komut1.Parameters.AddWithValue("@p3", p.Numara);
            komut1.Parameters.AddWithValue("@p4", p.Bolum);
            return komut1.ExecuteNonQuery();

        }
        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> ogrenciler = new List<EntityOgrenci>();
            SqlCommand komut2 = new SqlCommand("Select * From tblOgrenci", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.Id = int.Parse(dr[0].ToString());
                ent.Ad = dr[1].ToString();
                ent.Soyad = dr[2].ToString();
                ent.Numara = dr[3].ToString();
                ent.Bolum = dr[4].ToString();
                ogrenciler.Add(ent);
            }
            dr.Close();
            return ogrenciler;
        }
        public static int OgrenciSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete From tblOgrenci where OgrID=@p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery();
        }
        public static int OgrenciGuncelle(EntityOgrenci p)
        {
            SqlCommand komut4 = new SqlCommand("Update tblOgrenci set Ad=@p1, Soyad=@p2, Numara= @p3, Bolum = @p4 where ID=@p5", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", p.Ad);
            komut4.Parameters.AddWithValue("@p2", p.Soyad);
            komut4.Parameters.AddWithValue("@p3", p.Numara);
            komut4.Parameters.AddWithValue("@p4", p.Bolum);
            komut4.Parameters.AddWithValue("@p5", p.Id);
            return komut4.ExecuteNonQuery();
        }
    }
}
