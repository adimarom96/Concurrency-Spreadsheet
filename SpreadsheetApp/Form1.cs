using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        private SharableSpreadaheet s;

        public Form1()
        {
            InitializeComponent();
        }

        private void bCreateSpread_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textRowSize.Text) || String.IsNullOrEmpty(textColSize.Text))
            {
                Result.Text = "One cell or more are empty!";
                return;
            }
            try { 
            int row = Int32.Parse(textRowSize.Text);
            int col = Int32.Parse( textColSize.Text);
            s = new SharableSpreadaheet(row, col);
            Result.Text = "new sheet created with size: " + row + "*" + col;
            view_data();
            }
            catch (Exception)
            {
                Result.Text = "insert only postive number to create a new spread sheet ";

            }

        }

        private void textSsize_TextChanged(object sender, EventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {

        }

        private void textStringSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if(s != null) { 
            if (String.IsNullOrEmpty(textStringSearch.Text))
            {
                Result.Text = "One cell or more are empty!";
                return;
            }
            int a = -1;
            int b = -1;
            string str = textStringSearch.Text;
            bool flag = s.searchString(str, ref a, ref b);
            if (flag)
            {
                Result.Text = str + " found at : [" + a + "," + b + "]";
            }
            else
            {
                Result.Text = " Could not found " + str;
            }

        }
            else
            {
                Result.Text = "There is nothing to search for  yet, maybe you wnat to create a new sheet ?";

            }
        }


        private void textStringSet_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPostSetSting_TextChanged(object sender, EventArgs e)
        {

        }

        private void bSetString_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textStringSet.Text) || String.IsNullOrEmpty(textROW2.Text) || String.IsNullOrEmpty(textCOL1.Text))
            {
                Result.Text = "One cell or more are empty!";
                return;
            }
            string str = textStringSet.Text;

            try { 
            int r = Int32.Parse(textROW2.Text);
            int c = Int32.Parse(textCOL1.Text);
            if (r>this.s.getRow() || r<0 || c > this.s.getColumn() || c < 0)
            {
                Result.Text = "index outside of bound";
                return;
            }
            s.setCell(r, c, str);
            Result.Text = str + " successfully set at: ["+r + "," + c+"] , Click on the print icon to see the changes" ;
            
            }
            catch (Exception)
            {
                Result.Text = "insert only postive number to create a new spread sheet ";

            }
        }
        private void view_data()
        {
            if (s == null)
            {
                Result.Text = "There is nothing to print yet, maybe you wnat to create a new sheet ?";
                return;
            }
            DataTable table = new DataTable();


            table.Columns.Add("Row / Col ", typeof(string));
            for (int i = 1; i < this.s.getColumn() + 1; i++)
            {
                table.Columns.Add(i.ToString(), typeof(string));
                Console.WriteLine("add new col");
            }

            for (int i = 1; i < this.s.getRow() + 1; i++)
            {

                DataRow dr = table.NewRow();
                dr[0] = i;

                for (int j = 1; j < s.getColumn() + 1; j++)
                {
                    dr[j] = s.getCell(i, j);

                }

                table.Rows.Add(dr);
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = table;
        }
       
        private void bPrint_Click(object sender, EventArgs e)
        {
            view_data();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (s == null)
            {
                Result.Text = "There is nothing to print yet, maybe you wnat to create a new sheet ?";
                return;
            }
            DataTable table = new DataTable();


            table.Columns.Add("Row / Col ", typeof(string));
            for (int i = 1; i < this.s.getColumn() + 1; i++)
            {
                table.Columns.Add(i.ToString(), typeof(string));
                Console.WriteLine("add new col");
            }

            for (int i = 1; i < this.s.getRow() + 1; i++)
            {

                DataRow dr = table.NewRow();
                dr[0] = i;

                for (int j = 1; j < s.getColumn() + 1; j++)
                {
                    dr[j] = s.getCell(i, j);

                }

                table.Rows.Add(dr);
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = table;
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog v1 = new OpenFileDialog();
            v1.Filter = "Text file (*.txt)|*.dat";
            if(v1.ShowDialog() == DialogResult.OK)
            {
                s = new SharableSpreadaheet(1, 1);
               
                string path = v1.FileName;
                s.load(path);
                Result.Text = "File loaded successfully";
            }
            view_data();

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (s == null)
            {
                Result.Text = "There is nothing to Save yet, maybe you wnat to create a new sheet ?";
                return;
            }
            SaveFileDialog v1 = new SaveFileDialog();
            if (v1.ShowDialog() == DialogResult.OK)
            {

                string path = v1.FileName;
                s.save(path);
                Result.Text = "File save successfully";
                
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}

