using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _132HiranurKulakcı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Islem işlem1;
        BindingList<Islem>islemListesi=new BindingList<Islem>();


        private void Form1_Load(object sender, EventArgs e)
        {
            islemListesi.Add(new Islem (1,"Elektirik",new DateTime(2023,12,25),"Fatura",320,false));
            islemListesi.Add(new Islem(2, "Mesai", new DateTime(2024, 10, 05), "Ek Gelir", 1500,true));
            islemListesi.Add(new Islem(3, "Eğlence", new DateTime(2024, 07, 01), "Ek Gider", 100, true));
            islemListesi.Add(new Islem(4, "Ocak", new DateTime(2024, 01, 28), "Kira", 8000, false));
            islemListesi.Add(new Islem(5, "Harçlık", new DateTime(2023, 12, 25), "Ek Gider", 20, false));
            dgvListe.DataSource = islemListesi;
        }

      
        private void dgvListe_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvListe.CurrentRow.Cells["id"].Value.ToString();
            txtTanim.Text = dgvListe.CurrentRow.Cells["tanim"].Value.ToString();
            dtpTarih.Value = (DateTime)dgvListe.CurrentRow.Cells["tarih"].Value;
            cmbTur.Text = dgvListe.CurrentRow.Cells["tur"].Value.ToString();
            numMiktar.Value = Convert.ToInt32(dgvListe.CurrentRow.Cells["miktar"].Value);
            cbGelir.Checked = (bool)dgvListe.CurrentRow.Cells["gelir"].Value;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtId.Text);
            string tanim = txtTanim.Text;
            DateTime tarih=dtpTarih.Value;
            string tur=cmbTur.Text;
            int miktar = Convert.ToInt32( numMiktar.Value);
            bool gelir = cbGelir.Checked;

            Islem yeniIslem=new Islem(id,tanim,tarih,tur,miktar,gelir);
            islemListesi.Add(yeniIslem);
            dgvListe.DataSource = islemListesi.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dgvListe.SelectedRows[0];
            Islem secilenIslem=secilenSatir.DataBoundItem as Islem;
            int id = Convert.ToInt32(txtId.Text);
            string tanim = txtTanim.Text;
            DateTime tarih = dtpTarih.Value;
            string tur = cmbTur.Text;
            int miktar = Convert.ToInt32(numMiktar.Value);
            bool gelir = cbGelir.Checked;

            secilenIslem.Id= id;
            secilenIslem.Tanim= tanim;
            secilenIslem.Tarih= tarih;
            secilenIslem.Tur= tur;
            secilenIslem.Miktar= miktar;
            secilenIslem.Gelir= gelir;

            dgvListe.DataSource = null;
            dgvListe.DataSource = islemListesi.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dgvListe.SelectedRows[0];
            Islem secilenIslem = secilenSatir.DataBoundItem as Islem;

            DialogResult result = MessageBox.Show("Seçilen İşlem Bilgileri Silinsin mi?", "İşlem Bilgisini Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                islemListesi.Remove(secilenIslem);
            }
            dgvListe.DataSource = islemListesi.ToList();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
