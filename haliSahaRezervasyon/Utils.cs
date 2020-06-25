using haliSahaRezervasyon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haliSahaRezervasyon
{
    class Utils
    {

        public BindingSource saatler()
        {
            BindingSource bindingSource1 = new BindingSource();
          
            bindingSource1.Add(new Saatler("08:00 - 09:00"));
            bindingSource1.Add(new Saatler("09:00 - 10:00"));
            bindingSource1.Add(new Saatler("10:00 - 11:00"));
            bindingSource1.Add(new Saatler("11:00 - 12:00"));
            bindingSource1.Add(new Saatler("12:00 - 13:00"));
            bindingSource1.Add(new Saatler("13:00 - 14:00"));
            bindingSource1.Add(new Saatler("14:00 - 15:00"));
            bindingSource1.Add(new Saatler("15:00 - 16:00"));
            bindingSource1.Add(new Saatler("16:00 - 17:00"));
            bindingSource1.Add(new Saatler("17:00 - 18:00"));
            bindingSource1.Add(new Saatler("18:00 - 19:00"));
            bindingSource1.Add(new Saatler("19:00 - 20:00"));
            bindingSource1.Add(new Saatler("20:00 - 21:00"));
            bindingSource1.Add(new Saatler("21:00 - 22:00"));
            bindingSource1.Add(new Saatler("22:00 - 23:00"));
            bindingSource1.Add(new Saatler("23:00 - 24:00"));

            return bindingSource1;
        }

        public BindingSource gunler()
        {
            BindingSource bindingSource2 = new BindingSource();

            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 01)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 02)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 03)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 04)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 05)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 06)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 07)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 08)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 09)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 10)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 11)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 12)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 13)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 14)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 15)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 16)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 17)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 18)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 19)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 20)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 21)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 22)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 23)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 24)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 25)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 26)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 27)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 28)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 29)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 30)));

            return bindingSource2;
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        public void ColRemove(DataGridView datagrid, string name)
        {
            datagrid.Columns[name].Visible = false;
        }
        public DataGridViewColumn ColGenerator(DataGridView datagrid, string name,string val)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = name;
            column.Name = val;
            column.Width = datagrid.Width;

            return column;
        }
        public void clearText(TextBox[] textBoxes)
        {
            foreach (TextBox textBoxe in textBoxes)
            {
                textBoxe.Text = "";
            }

        }


    }
}
