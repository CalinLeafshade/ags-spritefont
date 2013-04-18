using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AGSSpriteFontGen
{
    public partial class Form1 : Form
    {

        List<Glyph> glyphs = new List<Glyph>();

        public Form1()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.CheckFileExists = true;
            fd.Filter = "(XML files)|*.xml";
            fd.ShowDialog();
            txtMetricsFile.Text = fd.FileName;

        }

        private void butCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }

        private void butGenCode_Click(object sender, EventArgs e)
        {
            glyphs.Clear();
            try
            {
                XDocument doc = XDocument.Load(txtMetricsFile.Text);
                
                foreach(XElement xE in doc.Root.Elements("character"))
                {
                    glyphs.Add(new Glyph(xE.Attribute("key").Value, xE.Element("x").Value,xE.Element("y").Value,xE.Element("width").Value,xE.Element("height").Value));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            StringBuilder sb = new StringBuilder();
            foreach (Glyph g in glyphs)
            {
                sb.AppendLine(g.ToAGSScript(txtFont.Text));
            }
            txtCode.Text = sb.ToString();
        }
    }
}
