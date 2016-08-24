using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karty__Idz_na_ryby
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Game game;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("Wpisz swoje imię", " Nie można jeszcze rozpocząć gry.");
                return;
            }

            game = new Game(textName.Text, new List<string> { "janek", "Bartek" }, textBox1);
            buttonStart.Enabled = false;
            textName.Enabled = false;
            buttonAsk.Enabled = true;
            UpdateForm();
        }

        private void UpdateForm()
        {
            listhand.Items.Clear();
            foreach (String cardname in game.GetplayerCardNames())
            {
                listhand.Items.Add(cardname);
            }
            textBooks.Text = game.DescribeBooks();
            textBox1.Text += game.DescribePlayerHands();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (listhand.SelectedIndex < 0)
            {
                MessageBox.Show("wybierz kartę.");
                return;
            }
            if (game.PlayOneRound(listhand.SelectedIndex))
            {
                textBox1.Text += "Zwycięzcą jest.. " + game.GetWinnername();
                textBooks.Text = game.DescribeBooks();
                buttonAsk.Enabled = false;
            }
            else UpdateForm();
        }
    }
}
