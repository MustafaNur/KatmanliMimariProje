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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            EntityDers ent = new EntityDers();
            ent.DersAd = txtDersAd.Text;
            BlDers.DersEkleBL(ent);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            byte deger = byte.Parse(txtDersID.Text);
            EntityDers d = new EntityDers();
            d.DersID = byte.Parse(deger.ToString());
            BlDers.DersSilBL(d.DersID);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityDers> ders = BlDers.DersListesiBL();
            dataGridView1.DataSource = ders;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityDers ent = new EntityDers();
            ent.DersAd = txtDersAd.Text;
            ent.DersID = byte.Parse(txtDersID.Text);
            BlDers.OgrenciGuncelleBL(ent);

        }
    }
}
