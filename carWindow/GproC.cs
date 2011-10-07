using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace carWindow
{
    public partial class GproC : Form
    {
        public GproC()
        {
            InitializeComponent();

            if (GPROCalc.Properties.Settings.Default.Language == "EN")
            {
                en.Checked = true;
                mudaParaEN();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double calc = (Convert.ToDouble(conc.Text) * 1 / 6) + (Convert.ToDouble(tal.Text) * 1 / 4) + (Convert.ToDouble(agr.Text) * 1 / 7) +
                    (Convert.ToDouble(exp.Text) * 1 / 12) + (Convert.ToDouble(ti.Text) * 1 / 8) + (Convert.ToDouble(stam.Text) * 1 / 7) +
                    (Convert.ToDouble(cari.Text) * 1 / 12) - (Convert.ToDouble(peso.Text) * 1 / 12);
                calc = Math.Ceiling(calc);
                calc += (Convert.ToDouble(motv.Text) * 1 / 12);
                calc = Math.Ceiling(calc);
                resul.Text = calc.ToString();
            }
            catch { }
        }

        private void sec_molh_Click(object sender, EventArgs e)
        {
            try
            {
                int _asaD = Convert.ToInt32(asaD.Text) + 135;
                int _asaT = Convert.ToInt32(asaT.Text) + 135;
                int _motor = Convert.ToInt32(motor.Text) - 100;
                int _freios = Convert.ToInt32(freios.Text) + 50;
                int _cambios = Convert.ToInt32(cambios.Text) - 100;
                int _suspensao = Convert.ToInt32(suspensao.Text) - 100;

                if (_asaD > 999) _asaD = 999;
                if (_asaT > 999) _asaT = 999;
                if (_motor > 999) _motor = 999;
                if (_freios > 999) _freios = 999;
                if (_cambios > 999) _cambios = 999;
                if (_suspensao > 999) _suspensao = 999;

                if (_asaD < 0) _asaD = 0;
                if (_asaT < 0) _asaT = 0;
                if (_motor < 0) _motor = 0;
                if (_freios < 0) _freios = 0;
                if (_cambios < 0) _cambios = 0;
                if (_suspensao < 0) _suspensao = 0;

                asaD2.Text = (_asaD).ToString();
                asaT2.Text = (_asaT).ToString();
                motor2.Text = (_motor).ToString();
                freios2.Text = (_freios).ToString();
                cambio2.Text = (_cambios).ToString();
                suspensao2.Text = (_suspensao).ToString();

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int difTemp = Convert.ToInt32(t2.Text) - Convert.ToInt32(t1.Text);
                int difHum = Convert.ToInt32(h2.Text) - Convert.ToInt32(h1.Text);

                double _asaD = Math.Ceiling(Convert.ToDouble(asaD.Text) + (4 * difTemp));
                double _asaT = Math.Ceiling(Convert.ToDouble(asaT.Text) + (4 * difTemp));
                double _motor = Math.Ceiling(Convert.ToDouble(motor.Text) + ((-2.5) * difTemp) + (-0.5 * difHum));
                double _freios = Math.Ceiling(Convert.ToDouble(freios.Text) + (5 * difTemp) + (0.5 * difHum));
                double _cambios = Math.Ceiling(Convert.ToDouble(cambios.Text) + ((-2.5) * difTemp) + (-1 * difHum));
                double _suspensao = Math.Ceiling(Convert.ToDouble(suspensao.Text) + (-5 * difTemp) + (-0.5 * difHum));

                if (_asaD > 999) _asaD = 999;
                    else if (_asaD < 0) _asaD = 0;
                if (_asaT > 999) _asaT = 999;
                    else if (_asaT < 0) _asaT = 0;
                if (_motor > 999) _motor = 999;
                    else if (_motor < 0) _motor = 0;
                if (_freios > 999) _freios = 999;
                    else if (_freios < 0) _freios = 0;
                if (_cambios > 999) _cambios = 999;
                    else if (_cambios < 0) _cambios = 0;
                if (_suspensao > 999) _suspensao = 999;
                    else if (_suspensao < 0) _suspensao = 0;

                asaD3.Text = (_asaD).ToString();
                asaT3.Text = (_asaT).ToString();
                motor3.Text = (_motor).ToString();
                freios3.Text = (_freios).ToString();
                cambios3.Text = (_cambios).ToString();
                suspensao3.Text = (_suspensao).ToString();
            }
            catch { }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.Show();
            
        }


        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    button1_Click(sender, e);
                    calc_window_Click(sender, e);
                }
            }
        }


        private void motv_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.motv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void cari_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void peso_KeyPress(object sender, KeyPressEventArgs e)
        {
           this.peso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void stam_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.stam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void ti_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void exp_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.exp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void agr_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.agr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void tal_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.tal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void conc_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.conc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void en_CheckedChanged(object sender, EventArgs e)
        {
            mudaParaEN();
        }
        private void pt_CheckedChanged(object sender, EventArgs e)
        {
            mudaParaPT();
        }
        private void mudaParaEN()
        {
            englishToolStripMenuItem.Checked = true;
            portugêsToolStripMenuItem.Checked = false;
            GPROCalc.Properties.Settings.Default.Language = "EN";
            GPROCalc.Properties.Settings.Default.Save();


            //Label
            label10.Text = "Technical insight";
            label11.Text = "Happy Zone";
            label10.Text = "Value to Add/Subtract";
            resulL.Text = "Total";
            label9.Text = "Motivation";
            label8.Text = "Weight";
            label7.Text = "Charisma";
            label6.Text = "Stamina";
            label5.Text = "Tech. insight";
            label4.Text = "Experience";
            label3.Text = "Aggressiveness";
            label2.Text = "Talent";
            label1.Text = "Concentration";
            label12.Text = "Front wing";
            label13.Text = "Rear wing";
            label14.Text = "Engine";
            label15.Text = "Brakes";
            label16.Text = "Gear";
            label17.Text = "Suspension";
            label21.Text = "Humidity";
            label20.Text = "Humidity";
            label19.Text = "Temperature";
            label18.Text = "Temperature";
            lOpacidade.Text = "Opacity";

            //Buttons
            sec_molh.Text = "Dry --> Wet";
            molh_sec.Text = "Wet --> Dry";
            button3.Text = "Calculate";
            button1.Text = "Calculate";
            calc_window.Text = "Calculate";

            //groupbox
            q1q2L.Text = "Convert from Q1 to Q2";
            groupBox3.Text = "Rain";
            groupBox4.Text = "Qualification 1";
            groupBox5.Text = "Qualification 2";
            groupBox6.Text = "Overall";
            groupBox1.Text = "Car Setup";
            Lang.Text = "Language";
            Lol.Text = "Pilot";
            groupBox7.Text = "Setup Window";
            groupBox2.Text = "Other";

            //Box
            checkBox1.Text = "Always on top";

            //Tabpage
            piloto.Text = "Pilot";
            conversor.Text = "Converter";
            Opcoes.Text = "Options";

            //Menu
            fileToolStripMenuItem.Text = "&File";
            gravarToolStripMenuItem.Text = "&Save";
            exitToolStripMenuItem.Text = "&Exit";
            helpToolStripMenuItem.Text = "&Help";
            aboutToolStripMenuItem.Text = "&About";
            abrirToolStripMenuItem.Text = "&Open";
            opçõesToolStripMenuItem.Text = "O&ptions";
            línguaToolStripMenuItem.Text = "&Language";
            portugêsToolStripMenuItem.Text = "Por&tuguese";
            englishToolStripMenuItem.Text = "E&nglish";
            sempreNoTopoToolStripMenuItem.Text = "A&lways on Top";

            //Text
            textoWindow.Text = ("When configurating the car ajustments, find the max or minimum value that the pillot is happy with.\n\nThe pilot will be happy with the car ajustment if it is inside the Happy Zone margin.\n\nNext, if you found the max value, subtract the ammount calculated, and if you found the minimum, add the value.");

        }

        private void mudaParaPT()
        {
            englishToolStripMenuItem.Checked = false;
            portugêsToolStripMenuItem.Checked = true;
            GPROCalc.Properties.Settings.Default.Language = "PT";
            GPROCalc.Properties.Settings.Default.Save();


            //Labbel
            resulL.Text = "Total";
            label9.Text = "Motivação";
            label8.Text = "Peso";
            label7.Text = "Carisma";
            label6.Text = "Resistência";
            label5.Text = "Conh. Técnico";
            label4.Text = "Experiência";
            label3.Text = "Agressividade";
            label2.Text = "Talento";
            label1.Text = "Concentração";
            label11.Text = "Zona de felicidade";
            label10.Text = "Valor a Subtrair/Somar";
            label12.Text = "Asa Dianteira";
            label13.Text = "Asa Traseira";
            label14.Text = "Motor";
            label15.Text = "Freios";
            label16.Text = "Câmbio";
            label17.Text = "Suspensão";
            label21.Text = "Humidade";
            label20.Text = "Humidade";
            label19.Text = "Temperatura";
            label18.Text = "Temperatura";
            lOpacidade.Text = "Opacidade";

            //botoes
            button1.Text = "Calcular";
            sec_molh.Text = "Seco --> Molhado";
            button3.Text = "Calcular";
            molh_sec.Text = "Molhado --> Seco";
            calc_window.Text = "Calcular";

            //groupbox
            groupBox1.Text = "Ajuste do Carro";
            q1q2L.Text = "Conversor de Q1 para Q2";
            groupBox3.Text = "Chuva";
            groupBox4.Text = "Qualificação 1";
            groupBox5.Text = "Qualificação 2";
            Lol.Text = "Piloto";
            groupBox6.Text = "Total";
            groupBox7.Text = "Janela de Ajuste";
            Lang.Text = "Língua";
            groupBox2.Text = "Outros";

            //Tab
            piloto.Text = "Piloto";
            Opcoes.Text = "Opções";
            conversor.Text = "Conversor";

            //Box
            checkBox1.Text = "Sempre no topo";

            //Menu
            fileToolStripMenuItem.Text = "&Ficheiro";
            abrirToolStripMenuItem.Text = "A&brir";
            gravarToolStripMenuItem.Text = "&Gravar";
            exitToolStripMenuItem.Text = "&Sair";
            opçõesToolStripMenuItem.Text = "&Opções";
            línguaToolStripMenuItem.Text = "&Língua";
            portugêsToolStripMenuItem.Text = "&Português";
            englishToolStripMenuItem.Text = "&English";
            helpToolStripMenuItem.Text = "&Ajuda";
            aboutToolStripMenuItem.Text = "S&obre";
            sempreNoTopoToolStripMenuItem.Text = "Sempre no &Topo";

            //Text
            textoWindow.Text = ("Quando estiver a calcular os valores dos ajustes do carro, encontra o valor máximo, ou mínimo, em que o piloto está sastifeito com os ajustes.\n\nO piloto estará feliz com a afinação dentro da margem do valor da caixa Zona de felicidade.\n\nDe seguida, caso se tenha encontrado o valor máximo, subtrair o valor indicado, e caso se tenha encontrado o mínimo, somar.");
        }

        private void gravarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != "")
            {

                TextWriter fs = new StreamWriter(saveFileDialog1.FileName);

                //save
                try
                {
                    fs.WriteLine("//GPRO calc file");
                    fs.WriteLine("{0}", conc.Text);
                    fs.WriteLine("{0}", tal.Text);
                    fs.WriteLine("{0}", agr.Text);
                    fs.WriteLine("{0}", exp.Text);
                    fs.WriteLine("{0}", ti.Text);
                    fs.WriteLine("{0}", stam.Text);
                    fs.WriteLine("{0}", cari.Text);
                    fs.WriteLine("{0}", motv.Text);
                    fs.WriteLine("{0}", peso.Text);

                    fs.WriteLine("{0}", asaD.Text);
                    fs.WriteLine("{0}", asaT.Text);
                    fs.WriteLine("{0}", motor.Text);
                    fs.WriteLine("{0}", freios.Text);
                    fs.WriteLine("{0}", cambios.Text);
                    fs.WriteLine("{0}", suspensao.Text);

                    fs.WriteLine("{0}", t1.Text);
                    fs.WriteLine("{0}", t2.Text);
                    fs.WriteLine("{0}", h1.Text);
                    fs.WriteLine("{0}", h2.Text);
                    
                }
                catch { }
                fs.Close();
            }
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                //read
                if (file.ReadLine() == "//GPRO calc file")
                {
                    try
                    {
                        conc.Text = file.ReadLine();
                        tal.Text = file.ReadLine();
                        agr.Text = file.ReadLine();
                        exp.Text = file.ReadLine();
                        ti.Text = file.ReadLine();
                        stam.Text = file.ReadLine();
                        cari.Text = file.ReadLine();
                        motv.Text = file.ReadLine();
                        peso.Text = file.ReadLine();

                        asaD.Text = file.ReadLine();
                        asaT.Text = file.ReadLine();
                        motor.Text = file.ReadLine();
                        freios.Text = file.ReadLine();
                        cambios.Text = file.ReadLine();
                        suspensao.Text = file.ReadLine();

                        t1.Text = file.ReadLine();
                        t2.Text = file.ReadLine();
                        h1.Text = file.ReadLine();
                        h2.Text = file.ReadLine();
                    }
                    catch { }
                }
                else { MessageBox.Show("Invalid File!"); }
                file.Close();

                calc_window_Click(sender, e);
                button1_Click(sender, e);
                button3_Click(sender, e);
            }
        }

        private void molh_sec_Click(object sender, EventArgs e)
        {
            try
            {
                int _asaD = Convert.ToInt32(asaD.Text) - 135;
                int _asaT = Convert.ToInt32(asaT.Text) - 135;
                int _motor = Convert.ToInt32(motor.Text) + 100;
                int _freios = Convert.ToInt32(freios.Text) - 50;
                int _cambios = Convert.ToInt32(cambios.Text) + 100;
                int _suspensao = Convert.ToInt32(suspensao.Text) + 100;

                if (_asaD > 999) _asaD = 999;
                if (_asaT > 999) _asaT = 999;
                if (_motor > 999) _motor = 999;
                if (_freios > 999) _freios = 999;
                if (_cambios > 999) _cambios = 999;
                if (_suspensao > 999) _suspensao = 999;

                if (_asaD < 0) _asaD = 0;
                if (_asaT < 0) _asaT = 0;
                if (_motor < 0) _motor = 0;
                if (_freios < 0) _freios = 0;
                if (_cambios < 0) _cambios = 0;
                if (_suspensao < 0) _suspensao = 0;

                asaD2.Text = (_asaD).ToString();
                asaT2.Text = (_asaT).ToString();
                motor2.Text = (_motor).ToString();
                freios2.Text = (_freios).ToString();
                cambio2.Text = (_cambios).ToString();
                suspensao2.Text = (_suspensao).ToString();

            }
            catch { }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_CheckedChanged(sender, e);
            en.Checked = true;
        }

        private void portugêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt_CheckedChanged(sender, e);
            pt.Checked = true;
        }

        private void calc_window_Click(object sender, EventArgs e)
        {
            try
            {
                double exp = Convert.ToDouble(ti.Text);
                textBox1.Text = (Math.Ceiling((exp * -0.2931) + 130.61)).ToString();
                textBox2.Text = Math.Ceiling((((exp * -0.2931) + 130.61) / 2)).ToString();
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);

            linkLabel1.LinkColor = Color.Black;
            linkLabel1.LinkVisited = true;
        }

        private void GproC_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Remove(linkLabel1.Links[0]);
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "http://gpro.net/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                GproC.ActiveForm.TopMost = true;
                sempreNoTopoToolStripMenuItem.Checked = true;
                
            }
            else if (checkBox1.Checked == false)
            {
                GproC.ActiveForm.TopMost = false;
                sempreNoTopoToolStripMenuItem.Checked = false;
            }
                
        }

        private void sempreNoTopoToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (sempreNoTopoToolStripMenuItem.Checked == true)
            {
                GproC.ActiveForm.TopMost = false;
                checkBox1.Checked = false;
                sempreNoTopoToolStripMenuItem.Checked = false;
            }
            else if (sempreNoTopoToolStripMenuItem.Checked == false)
            {
                GproC.ActiveForm.TopMost = true;
                checkBox1.Checked = true;
                sempreNoTopoToolStripMenuItem.Checked = true;
            }
        }

        private void tOpacidade_Scroll(object sender, EventArgs e)
        {
            GproC.ActiveForm.Opacity = (Double)tOpacidade.Value/100;
            label22.Text = tOpacidade.Value.ToString() + " %";
        }

        private void tOpacidade_ValueChanged(object sender, EventArgs e)
        {
            GproC.ActiveForm.Opacity = (Double)tOpacidade.Value/100;
            label22.Text = tOpacidade.Value.ToString() + " %";
        }

    }
}

