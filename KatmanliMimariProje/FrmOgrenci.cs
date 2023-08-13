using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using BusinessLayer;

namespace KatmanliMimariProje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Numara = maskedTextBox1.Text;
            ent.Bolum = txtBolum.Text;
            BLOgrenci.OgrenciEkleBL(ent);
            MessageBox.Show("Ogrenci eklendi");

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityOgrenci> ogrenciler = BLOgrenci.OgrenciListesiBL();
            dataGridView1.DataSource = ogrenciler;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int deger = int.Parse(txtOgrID.Text);
            EntityOgrenci en = new EntityOgrenci();
            en.Id = deger;
            BLOgrenci.OgrenciSilBL(en.Id);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.Ad = txtAd.Text;
            ent.Soyad= txtSoyad.Text;
            ent.Numara = maskedTextBox1.Text;
            ent.Bolum= txtBolum.Text;
            ent.Id = int.Parse(txtOgrID.Text);
            BLOgrenci.OgrenciGuncelleBL(ent);
        }
    }
}
