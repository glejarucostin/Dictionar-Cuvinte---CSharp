﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proiect_GlejaruCostin
{
    public partial class AdjectivBD : Form
    {
        string connString;
        public AdjectivBD()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Adjectiv.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM adjectiv";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["cuvant"].ToString());
                    itm.SubItems.Add(reader["clasificare"].ToString());
                    itm.SubItems.Add(reader["mijloc_exprimare"].ToString());
                    itm.SubItems.Add(reader["val_stilistica"].ToString());
                    itm.SubItems.Add(reader["pronuntie"].ToString());
                    itm.SubItems.Add(reader["regionalisme"].ToString());
                    itm.SubItems.Add(reader["origine"].ToString());
                    itm.SubItems.Add(reader["explicatii"].ToString());

                    listView1.Items.Add(itm);


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        
    }

        private void intoarcereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Adjectiv f = new Adjectiv();
            f.Show();
        }
    }
}
