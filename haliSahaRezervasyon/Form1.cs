using haliSahaRezervasyon.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using haliSahaRezervasyon.Entity;
using System.Deployment.Application;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace haliSahaRezervasyon
{
    public partial class Form1 : Form
    {
        SqlCon sql = new SqlCon();
        Utils utils = new Utils();


        public string sahaidKontrol;
        string saat, tarih, SahaId;

        public Form1()
        {
            InitializeComponent();
        }
        Context c = new Context();
        private void Form1_Load(object sender, EventArgs e)
        {
            c.Database.CreateIfNotExists();
            
            DataGridYenile();
             
            BindingSource bindingSource1 = new BindingSource();
            BindingSource bindingSource2 = new BindingSource();

            bindingSource1 = utils.saatler();
            bindingSource2 = utils.gunler();

           
            dataGridView4.Columns.Add(utils.ColGenerator(dataGridView4,"Saat","Saat"));
            dataGridView3.Columns.Add(utils.ColGenerator(dataGridView3, "Tarih", "Saat"));



            dataGridView4.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView3.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            
            dataGridView4.ReadOnly = true;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.DataSource = bindingSource1;
            dataGridView3.DataSource = bindingSource2;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();

        }
        public void DataGridYenile()
        {
            dataGridView1.DataSource = sql.TabloyuGetir1(null);
            dataGridView2.DataSource = sql.TabloyuGetir1(true);

            utils.ColRemove(dataGridView1, "Fiyat");
            utils.ColRemove(dataGridView1, "Adres");
            utils.ColRemove(dataGridView1, "SahaKisi");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            Sahalar saha = new Sahalar();
            int strToplam = dataGridView2.Rows.Count;
            if(textBox3.Text!=null&&textBox3.Text!=""&& textBox1.Text != null && textBox1.Text != ""&& textBox2.Text != null && textBox2.Text != ""&& richTextBox1.Text != null && richTextBox1.Text != "") {
            for (int i = 0; i < strToplam; i++)
            {
               if(dataGridView2.Rows[i].Cells[1].Value.ToString()!=textBox3.Text)
                {


                   sql.SahaEkle(textBox3.Text, richTextBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox1.Text), true);
                   

                    DataGridYenile();
                    textBox3.Text = "";
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox2.Text = "";
                    dataGridView1.ClearSelection();
                    dataGridView2.ClearSelection();
                    break;
                }
                if(i==(strToplam-1))
                {
                    utils.Message("Farklı kayıt giriniz.");
                    textBox3.Text = "";
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox2.Text = "";
                }
            }
            }
            else
            {
                utils.Message("Gerekli bilgileri doldurunuz!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                sql.SahaDurumGuncelle(numara, false);
                DataGridYenile();
            }
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            
        }
       
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch)&& ch!=8)
            {
                e.Handled = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                sql.SahaDurumGuncelle(numara, true);
                DataGridYenile();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rezervasyon rzv = new Rezervasyon();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            button5.Visible = false;
            rzv.Notes = f4.richTextBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int satirs = dataGridView4.Rows.Count;
            for (int i = 0; i < satirs; i++)
            {
                utils.Message(dataGridView4.Rows[i].Cells[0].Value.ToString()); 
            }
        }
        public string tarihKontrol;

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SahaId = dataGridView2.SelectedCells[0].RowIndex.ToString();
            label5.Visible = true;

            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

            sahaidKontrol = selectedRow.Cells[0].Value.ToString();

            dataGridView3.Visible = true;
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
            button5.Visible = false;
            button3.Visible = false;


        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

            tarihKontrol = selectedRow.Cells[0].Value.ToString();


            tarih = dataGridView3.SelectedCells[0].RowIndex.ToString();


            label6.Visible = true;
            dataGridView4.Visible = true;

            dataGridView4.ClearSelection();
            button5.Visible = false;
            button3.Visible = false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
            string saatKontrol = selectedRow.Cells[0].Value.ToString();
            Boolean check = sql.SaatTarihKontrol(int.Parse(sahaidKontrol), tarihKontrol, saatKontrol);

            if (check)
            {
                utils.Message("Bu saatler arası başka bir rezervasyon vardır. ");
                button5.Visible = false;
                button3.Visible = false;
            }
            else
            {
                saat = dataGridView4.SelectedCells[0].RowIndex.ToString();
                button5.Visible = true;

                button3.Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            string s = "";
            string t = "";
            string i = "";
            int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
            string saatKontrol = selectedRow.Cells[0].Value.ToString();
            Boolean check = sql.SaatTarihKontrol(int.Parse(sahaidKontrol), tarihKontrol, saatKontrol);

            if (check)
            {
                utils.Message("Bu saatler arası başka bir rezervasyon var. ");
                utils.Message("Rezervasyonunuz yapılmadı.");
                label5.Visible = false;
                label6.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                button3.Visible = false;
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
            }
            else { 
            try { 
             s = dataGridView4.Rows[int.Parse(saat)].Cells["Saat"].Value.ToString();
             t = dataGridView3.Rows[int.Parse(tarih)].Cells["Tarih"].Value.ToString();
             i =  dataGridView2.Rows[int.Parse(SahaId)].Cells["SahaId"].Value.ToString();
            }
            catch
            {
                utils.Message("Değerler null olamaz");

            }
             Rezervasyon hsrez = new Rezervasyon();
             if(s==null|t==null|i==null && s==""|t==""|i=="")
            {
                utils.Message("Lütfen seçim yaptığınızdan emin olun.");
                    utils.Message("Rezervasyonunuz yapılmadı.");

                }
                else {
                hsrez.RezervasyonSaat = dataGridView4.Rows[int.Parse(saat)].Cells["Saat"].Value.ToString();
             string v = dataGridView3.Rows[int.Parse(tarih)].Cells["Tarih"].Value.ToString();
                hsrez.Tarih = Convert.ToDateTime(v);
                hsrez.SahaId = int.Parse(dataGridView2.Rows[int.Parse(SahaId)].Cells["SahaId"].Value.ToString());
                hsrez.Notes = f4.richTextBox1.Text;
                c.Rezervasyons.Add(hsrez);
                c.SaveChanges();
                label5.Visible = false;
                label6.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                button3.Visible = false;
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
                Form1 f1 = new Form1();
                f1.Visible = false;
                Form2 f2 = new Form2();
                f2.Visible = true;
                
                
            }

            }

        }
    }
}
