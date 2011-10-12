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
    public partial class GproCalc : Form
    {
        public GproCalc()
        {
            InitializeComponent();

            if (GPROCalc.Properties.Settings.Default.Language == "EN")
            {
                en.Checked = true;
                mudaParaEN();
            }

            if (GPROCalc.Properties.Settings.Default.AlwaysOnTop == true)
            {
                sempreTopo();
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
                tBoxTotal.Text = calc.ToString();
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
                int difTemp = Convert.ToInt32(tBoxTemp2.Text) - Convert.ToInt32(tBoxTemp1.Text);
                int difHum = Convert.ToInt32(tBoxHum2.Text) - Convert.ToInt32(tBoxHum1.Text);

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
            lValor.Text = "Technical insight";
            lFelicidade.Text = "Happy Zone";
            lValor.Text = "Value to Add/Subtract";
            lTotal.Text = "Total";
            lMotiv.Text = "Motivation";
            lPeso.Text = "Weight";
            lCarisma.Text = "Charisma";
            lResist.Text = "Stamina";
            lCTecn.Text = "Tech. insight";
            lExp.Text = "Experience";
            lAgress.Text = "Aggressiveness";
            lTalento.Text = "Talent";
            lConcentra.Text = "Concentration";
            lAsaD.Text = "Front wing";
            lAsaT.Text = "Rear wing";
            lMotor.Text = "Engine";
            lFreios.Text = "Brakes";
            lCambio.Text = "Gear";
            lSuspensao.Text = "Suspension";
            lHum2.Text = "Humidity";
            lHum1.Text = "Humidity";
            lTemp2.Text = "Temperature";
            lTemp1.Text = "Temperature";
            lOpacidade.Text = "Opacity";

            //Buttons
            bSec_molh.Text = "Dry --> Wet";
            bMolh_sec.Text = "Wet --> Dry";
            bCalcTempHum.Text = "Calculate";
            bCalculaTotal.Text = "Calculate";
            bCalcAjuste.Text = "Calculate";
            bMetePrincipal.Text = "Copy to Main Ajustment";

            //groupbox
            gBoxQ1Q2.Text = "Convert from Q1 to Q2";
            gBoxRain.Text = "Rain";
            gBoxQ1.Text = "Qualification 1";
            gBoxQ2.Text = "Qualification 2";
            gBoxTotal.Text = "Overall";
            gBoxCarro.Text = "Car Setup";
            Lang.Text = "Language";
            gBoxPiloto.Text = "Pilot";
            gBoxAjust.Text = "Setup Window";
            gBoxOtherOptions.Text = "Other";

            //Box
            cBoxTopo.Text = "Always on top";

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
            txtAjuste.Text = ("When configurating the car ajustments, find the max or minimum value that the pillot is happy with.\n\nThe pilot will be happy with the car ajustment if it is inside the Happy Zone margin.\n\nNext, if you found the max value, subtract the ammount calculated, and if you found the minimum, add the value.");

        }

        private void mudaParaPT()
        {
            englishToolStripMenuItem.Checked = false;
            portugêsToolStripMenuItem.Checked = true;
            GPROCalc.Properties.Settings.Default.Language = "PT";
            GPROCalc.Properties.Settings.Default.Save();


            //Labbel
            lTotal.Text = "Total";
            lMotiv.Text = "Motivação";
            lPeso.Text = "Peso";
            lCarisma.Text = "Carisma";
            lResist.Text = "Resistência";
            lCTecn.Text = "Conh. Técnico";
            lExp.Text = "Experiência";
            lAgress.Text = "Agressividade";
            lTalento.Text = "Talento";
            lConcentra.Text = "Concentração";
            lFelicidade.Text = "Zona de felicidade";
            lValor.Text = "Valor a Subtrair/Somar";
            lAsaD.Text = "Asa Dianteira";
            lAsaT.Text = "Asa Traseira";
            lMotor.Text = "Motor";
            lFreios.Text = "Freios";
            lCambio.Text = "Câmbio";
            lSuspensao.Text = "Suspensão";
            lHum2.Text = "Humidade";
            lHum1.Text = "Humidade";
            lTemp2.Text = "Temperatura";
            lTemp1.Text = "Temperatura";
            lOpacidade.Text = "Opacidade";

            //botoes
            bCalculaTotal.Text = "Calcular";
            bSec_molh.Text = "Seco --> Molhado";
            bCalcTempHum.Text = "Calcular";
            bMolh_sec.Text = "Molhado --> Seco";
            bCalcAjuste.Text = "Calcular";
            bMetePrincipal.Text = "Copiar para Ajuste Principal";

            //groupbox
            gBoxCarro.Text = "Ajuste do Carro";
            gBoxQ1Q2.Text = "Conversor de Q1 para Q2";
            gBoxRain.Text = "Chuva";
            gBoxQ1.Text = "Qualificação 1";
            gBoxQ2.Text = "Qualificação 2";
            gBoxPiloto.Text = "Piloto";
            gBoxTotal.Text = "Total";
            gBoxAjust.Text = "Janela de Ajuste";
            Lang.Text = "Língua";
            gBoxOtherOptions.Text = "Outros";

            //Tab
            piloto.Text = "Piloto";
            Opcoes.Text = "Opções";
            conversor.Text = "Conversor";

            //Box
            cBoxTopo.Text = "Sempre no topo";

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
            txtAjuste.Text = ("Quando estiver a calcular os valores dos ajustes do carro, encontra o valor máximo, ou mínimo, em que o piloto está sastifeito com os ajustes.\n\nO piloto estará feliz com a afinação dentro da margem do valor da caixa Zona de felicidade.\n\nDe seguida, caso se tenha encontrado o valor máximo, subtrair o valor indicado, e caso se tenha encontrado o mínimo, somar.");
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

                    fs.WriteLine("{0}", tBoxTemp1.Text);
                    fs.WriteLine("{0}", tBoxTemp2.Text);
                    fs.WriteLine("{0}", tBoxHum1.Text);
                    fs.WriteLine("{0}", tBoxHum2.Text);
                    
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

                        tBoxTemp1.Text = file.ReadLine();
                        tBoxTemp2.Text = file.ReadLine();
                        tBoxHum1.Text = file.ReadLine();
                        tBoxHum2.Text = file.ReadLine();
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
                tBoxFelicidade.Text = (Math.Ceiling((exp * -0.2931) + 130.61)).ToString();
                tBoxValor.Text = Math.Ceiling((((exp * -0.2931) + 130.61) / 2)).ToString();
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);

            linkGpro.LinkColor = Color.Black;
            linkGpro.LinkVisited = true;
        }

        private void GproC_Load(object sender, EventArgs e)
        {
            linkGpro.Links.Remove(linkGpro.Links[0]);
            linkGpro.Links.Add(0, linkGpro.Text.Length, "http://gpro.net/");
        }

        private void sempreTopo()
        {
            if (cBoxTopo.Checked == true)
            {
                GproCalc.ActiveForm.TopMost = true;
                sempreNoTopoToolStripMenuItem.Checked = true;
                GPROCalc.Properties.Settings.Default.AlwaysOnTop = true;
            }
            else if (cBoxTopo.Checked == false)
            {
                GproCalc.ActiveForm.TopMost = false;
                sempreNoTopoToolStripMenuItem.Checked = false;
                GPROCalc.Properties.Settings.Default.AlwaysOnTop = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sempreTopo(); 
        }

        private void sempreNoTopoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cBoxTopo.Checked == true)
                cBoxTopo.Checked = false;
            else 
                if (cBoxTopo.Checked == false)
                    cBoxTopo.Checked = true;

            sempreTopo();
        }

        private void tOpacidade_Scroll(object sender, EventArgs e)
        {
            GproCalc.ActiveForm.Opacity = (Double)sliderOpacidade.Value/100;
            lPercentagem.Text = sliderOpacidade.Value.ToString() + " %";
        }

        private void tOpacidade_ValueChanged(object sender, EventArgs e)
        {
            GproCalc.ActiveForm.Opacity = (Double)sliderOpacidade.Value/100;
            lPercentagem.Text = sliderOpacidade.Value.ToString() + " %";
        }

        private void asaD3_TextChanged(object sender, EventArgs e)
        {

        }

        private void asaT3_TextChanged(object sender, EventArgs e)
        {

        }

        private void motor3_TextChanged(object sender, EventArgs e)
        {

        }

        private void freios3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cambios3_TextChanged(object sender, EventArgs e)
        {

        }

        private void suspensao3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bMetePrincipal_Click(object sender, EventArgs e)
        {
            asaD.Text = asaD3.Text;
            asaT.Text = asaT3.Text;
            motor.Text = motor3.Text;
            freios.Text = freios3.Text;
            cambios.Text = cambios3.Text;
            suspensao.Text = suspensao3.Text;
        }

    }
}

