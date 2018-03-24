using System;
using System.Windows.Forms;

namespace YutuskiTranslate
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string translateA, string translateB)
        {
            InitializeComponent();
            Ggt = translateA;
            Bdt = translateB;
        }

        public string Ggt { get; set; }

        public string Bdt { get; set; }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Ggt);
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Bdt);
            Close();
        }

        private void MyMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}