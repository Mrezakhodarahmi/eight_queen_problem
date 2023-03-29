using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eight_queen_problem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            DateTime DateTime = DateTime.Now;
            time_txtbox.Text = DateTime.ToString();

        }
        private void textBox_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_solve.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public void btn_solve_Click(object sender, EventArgs e)
        {
            int n = 8;
            output.ColumnCount = n;
            output.RowCount = n;
            output.RowTemplate.Resizable = DataGridViewTriState.True;
            output.RowTemplate.DividerHeight = 50;
            #region  chess board style

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0 && j%2==0)
                    {
                        output.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        output.Rows[i].Cells[j].Style.ForeColor = Color.White;
                        output.DefaultCellStyle.SelectionForeColor.ToKnownColor();

                    }
                    if (i % 2 == 1 && j%2==1)
                    {
                        output.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        output.Rows[i].Cells[j].Style.ForeColor = Color.White;

                    }
                }

            }
            #endregion;

            int[,] result = eight_queen.main();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (result[i, j] == 1)
                    {
                        output.Rows[i].Cells[j].Value ="‌‌‌♛";
                    }
                }
            }
        }
    }
}
