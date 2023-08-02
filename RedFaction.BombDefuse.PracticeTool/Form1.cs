using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedFaction.BombDefuse.PracticeTool
{
    public partial class Form1 : Form
    {
        private BombModel _bomb;

        public Dictionary<string, string> BombKeys = new Dictionary<string, string>()
        {
            { "Up", "^"},
            {"Down", "v" },
            {"Left", "<" },
            {"Right", ">" }
        };

        private int _currentTextButtonNumber = 1;

        public Form1()
        {
            InitializeComponent();
            _bomb = new BombModel();

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox9.ReadOnly = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            base.OnKeyDown(e);

            if (label1.Visible)
            {
                return;
            }

            if (IsValidKeyPress(e))
            {
                if (_bomb.CheckKeyPress(e, _currentTextButtonNumber))
                {
                    _currentTextButtonNumber++;
                    PopulateNextButtonTextBox(e);
                    return;
                }
            }

            _currentTextButtonNumber = 1;
            ClearTextBoxes();
        }

        private bool IsValidKeyPress(KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "Up":
                case "Down":
                case "Left":
                case "Right":
                    return true;
                default: return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _bomb = new BombModel();
            ClearTextBoxes();
            label1.Visible = false;
        }

        private void PopulateNextButtonTextBox(KeyEventArgs e)
        {
            // find first non-empty text box which are numbered
            // textBox[1-11]
            string buttonSymbol = BombKeys[e.KeyData.ToString()];


            if (textBox1.Text == "")
            {
                textBox1.Text = buttonSymbol;
                return;
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = buttonSymbol;
                return;
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = buttonSymbol;
                return;
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = buttonSymbol;
                _bomb.SetUpperPanelComplete();
                return;
            }

            if (textBox5.Text == "")
            {
                textBox5.Text = buttonSymbol;
                return;
            }

            if (textBox6.Text == "")
            {
                textBox6.Text = buttonSymbol;
                return;
            }

            if (textBox7.Text == "")
            {
                textBox7.Text = buttonSymbol;
                return;
            }

            if (textBox8.Text == "")
            {
                textBox8.Text = buttonSymbol;
                return;
            }

            if (textBox9.Text == "")
            {
                textBox9.Text = buttonSymbol;
                return;
            }

            if (textBox10.Text == "")
            {
                textBox10.Text = buttonSymbol;
                return;
            }

            if (textBox11.Text == "")
            {
                _bomb.SetLowerPanelComplete();
                textBox11.Text = buttonSymbol;

                label1.Visible = true;

                return;
            }
        }

        private void ClearTextBoxes()
        {
            bool isUpperPanelComplete = _bomb._isUpperPanelComplete;

            if (!isUpperPanelComplete )
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

            textBox8.Clear();
            textBox7.Clear();    
            textBox6.Clear();
            textBox5.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
        }
    }
}
