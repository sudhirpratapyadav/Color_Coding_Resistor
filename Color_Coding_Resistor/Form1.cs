using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_Coding_Resistor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cb1.SelectedIndex = 0;
            cb2.SelectedIndex = 0;
            cb3.SelectedIndex = 0;
            tf.Text = "0";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tf.Focused == false)
            {
                int c1 = cb1.SelectedIndex;
                int c2 = cb2.SelectedIndex;
                int c3 = cb3.SelectedIndex;
                double val = c1*10 + c2;
                switch (c3)
                {
                    case 0: val *= 1;
                        break;
                    case 1: val *= 10;
                        break;
                    case 2: val *= 100;
                        break;
                    case 3: val *= 1000;
                        break;
                    case 4: val *= 10000;
                        break;
                    case 5: val *= 100000;
                        break;
                    case 6: val *= 1000000;
                        break;
                    case 7: val *= 10000000;
                        break;
                    case 8: val *= 100000000;
                        break;
                    case 9: val *= 1000000000;
                        break;
                    default: val = 0;
                        break;
                }
                String text = "";
                if (val >= 1000000)
                {
                    val = val / 1000000;
                    text = val.ToString() + " M";
                }
                else if (val >= 1000)
                {
                    val = val / 1000;
                    text = val.ToString() + " K";
                }
                else
                {

                    text = val.ToString();
                }
                tf.Text = text;
            }
        }

        private void tf_TextChanged(object sender, EventArgs e)
        {
            if (tf.Focused == true)
            {
                String txt = tf.Text.Trim();
                if (txt.Length > 0)
                {
                    double val = 0;
                    String ch = (txt.Substring(txt.Length - 1)).ToLower();
                    double mul = 1;
                    if (ch == "k")
                    {
                        txt = tf.Text.Trim();
                        txt = (txt.Substring(0, txt.Length - 1)).Trim();
                        mul = 1000;

                    }
                    else if (ch == "m")
                    {
                        txt = tf.Text.Trim();
                        txt = (txt.Substring(0, txt.Length - 1)).Trim();
                        mul = 1000000;
                    }
                    if (Double.TryParse(txt, out val))
                    {
                        val = val * mul;
                        if (val < 0)
                        {
                            MessageBox.Show("ERROR_1 : negative value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cb1.SelectedIndex = 0;
                            cb2.SelectedIndex = 0;
                            cb3.SelectedIndex = 0;
                            tf.Text = "";
                        }
                        else if (val > 99000000000)
                        {
                            MessageBox.Show("ERROR_2 : max value exceeded", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cb1.SelectedIndex = 0;
                            cb2.SelectedIndex = 0;
                            cb3.SelectedIndex = 0;
                            tf.Text = "";
                        }
                        else
                        {
                            long r = Convert.ToInt64(val);
                            txt = r.ToString();
                            int l = txt.Length;
                            if (l==1)
                            {
                                cb1.SelectedIndex = txt[0]-48;
                                cb2.SelectedIndex = 0;
                                cb3.SelectedIndex = 0;
                            }
                            else if (l==2)
                            {
                                cb1.SelectedIndex = txt[0] - 48;
                                cb2.SelectedIndex = txt[1] - 48;
                                cb3.SelectedIndex = 0;
                            }
                            else
                            {
                                cb1.SelectedIndex = txt[0] - 48;
                                cb2.SelectedIndex = txt[1] - 48;
                                cb3.SelectedIndex = l-2;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR_2 : wrong fromat","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        cb1.SelectedIndex=0;
                        cb2.SelectedIndex=0;
                        cb3.SelectedIndex=0;
                        tf.Text = "";
                    }
                }
                else {
                    cb1.SelectedIndex=0;
                    cb2.SelectedIndex=0;
                    cb3.SelectedIndex=0;
                }
            }
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chb.Checked;
        }
    }
}
