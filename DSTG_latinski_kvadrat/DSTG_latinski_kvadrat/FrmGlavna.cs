using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSTG_latinski_kvadrat
{
    public partial class FrmGlavna : Form
    {
        Panel pnlMatrica = null;
        List<Celija> listaCelija = null;
        int dimenzijaMatrice;
        static Random rnd = new Random(DateTime.Today.Millisecond);
        bool prikaziRjesenje = true;

        public FrmGlavna()
        {
            InitializeComponent();
            listaCelija = new List<Celija>();
        }

        private void btnKreirajTablicu_Click(object sender, EventArgs e)
        {
            try
            {
                dimenzijaMatrice = int.Parse(txtVelicinaTablice.Text);

                if (dimenzijaMatrice <= 0)
                {
                    MessageBox.Show("Pogrešan unos!" + Environment.NewLine + "Niste unijeli pozitivan broj!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pogrešan unos!" + Environment.NewLine + "Niste unijeli (cijeli) broj!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnProvjeri.Enabled = true;
            btnPrikaziRjesenje.Enabled = true;

            NarcrtajMatricu();
            StaviCelijeUListu();
            PronadiPravePermutacije(1);//po defaultu pocinjemo od 1. reda upisivati vrijednosti
            //PrikaziVrijednosti();

            BrojZgrada brojZgrada = new BrojZgrada(listaCelija,dimenzijaMatrice);
            listaCelija = brojZgrada.IzracunajBrojVidljivZgrada();
            PrikaziRubneVrijednosti();

            if (checkIspravljanje.Checked)
            {
                DodajTextChangedEvent();
            }
        }

        private void PrikaziVrijednosti()
        {
            string[] trenutniRichTxt = new string[3];
            foreach (Control kontrola in pnlMatrica.Controls)
            {
                if (typeof(RichTextBox) == kontrola.GetType())
                {
                    trenutniRichTxt = kontrola.Tag.ToString().Split('-');//opis-red-stupac

                    if (trenutniRichTxt[0] == "Obicna")
                    {
                        foreach (Celija celija in listaCelija.ToList())
                        {
                            if (celija.red == int.Parse(trenutniRichTxt[1]) && celija.stupac == int.Parse(trenutniRichTxt[2]))
                            {
                                if (prikaziRjesenje)
                                {
                                    kontrola.Text = celija.vrijednost.ToString();
                                }
                                else
                                {
                                    kontrola.Text = "";
                                }
                            }
                        }
                    }
                }
            }
            prikaziRjesenje = !prikaziRjesenje;
        }

        private void PrikaziRubneVrijednosti()
        {
            string[] trenutniRichTxt = new string[3];
            foreach (Control kontrola in pnlMatrica.Controls)
            {
                if (typeof(RichTextBox) == kontrola.GetType())
                {
                    RichTextBox richText = (RichTextBox)kontrola;
                    trenutniRichTxt = richText.Tag.ToString().Split('-');//opis-red-stupac

                    if (trenutniRichTxt[0] != "Obicna")
                    {
                        foreach (Celija celija in listaCelija.ToList())
                        {
                            if (celija.red == int.Parse(trenutniRichTxt[1]) && celija.stupac == int.Parse(trenutniRichTxt[2]))
                            {
                                richText.Text = celija.vrijednost.ToString();
                                richText.SelectAll();
                                richText.SelectionAlignment = HorizontalAlignment.Center;
                            }
                        }
                    }
                }
            }
        }

        private void NarcrtajMatricu()
        {
            if (pnlMatrica != null)
            {
                pnlMatrica.Dispose();
            }

            CrtanjeMatrice crtanje = new CrtanjeMatrice(dimenzijaMatrice);
            pnlMatrica = crtanje.NacrtajMatricu();
            pnlMatrica.Location = new Point(40, 150);
            pnlMatrica.TabIndex = 3;
            pnlMatrica.TabStop = true;
            this.Controls.Add(pnlMatrica);
        }

        private void StaviCelijeUListu()
        {
            listaCelija.Clear();
            string[] trenutnaCelija = new string[3];

            foreach (Control kontrola in pnlMatrica.Controls)
            {
                if (typeof(RichTextBox) == kontrola.GetType())
                {
                    trenutnaCelija = kontrola.Tag.ToString().Split('-');//opis-red-stupac
                    Celija novaCelija = new Celija(trenutnaCelija[0], int.Parse(trenutnaCelija[1]), int.Parse(trenutnaCelija[2]));
                    listaCelija.Add(novaCelija);
                }
            }
        }

        private void PronadiPravePermutacije(int pocetniRed)
        {
            int slucajniBroj = 0;
            int brojSlucajnihBrojeva = 0;
            bool postoji = true;

            for (int i = pocetniRed; i <= dimenzijaMatrice; i++)
            {
                foreach (Celija celija in listaCelija.ToList())
                {
                    brojSlucajnihBrojeva = 0;
                    if (celija.opis == "Obicna" && celija.red == i)
                    {
                        postoji = true;

                        while (postoji && brojSlucajnihBrojeva < 1000)//1000 put trazimo preko rnd
                        {
                            slucajniBroj = rnd.Next(1, dimenzijaMatrice + 1);
                            postoji = PostojiURedu(celija.red, slucajniBroj) || PostojiUStupcu(celija.stupac, slucajniBroj);

                            brojSlucajnihBrojeva++;
                        }
                        //nakon 1000 pokusaja idemo ponovo upisati vrijednosti za trenutni red
                        if (brojSlucajnihBrojeva >= 1000 && postoji)
                        {
                            RestartajVrijednosti(celija.red);
                            PronadiPravePermutacije(celija.red);
                        }
                        else
                        {
                            celija.vrijednost = slucajniBroj;
                        }
                    }
                }
            }
        }

        private void RestartajVrijednosti(int red)
        {
            foreach (Celija celija in listaCelija.ToList())
            {
                if (celija.opis == "Obicna" && celija.red == red)
                {
                    celija.vrijednost = -1;
                }
            }
        }

        private bool PostojiURedu(int red, int slucajni)//postoji li vec ta vrijednost u redu
        {
            bool postoji = false;
            foreach (Celija c in listaCelija.ToList())
            {
                if (c != null)
                {
                    if (c.opis == "Obicna" && red == c.red)
                    {
                        if (slucajni == c.vrijednost)
                        {
                            postoji = true;
                            break;
                        }
                    }
                }
            }
            return postoji;
        }

        private bool PostojiUStupcu(int stupac, int slucajni)//postoji li vec ta vrijednost u stupcu
        {
            bool postoji = false;
            foreach (Celija c in listaCelija.ToList())
            {
                if (c != null)
                {
                    if (c.opis == "Obicna" && stupac == c.stupac)
                    {
                        if (slucajni == c.vrijednost)
                        {
                            postoji = true;
                            break;
                        }
                    }
                }
            }
            return postoji;
        }

        private void btnProvjeri_Click(object sender, EventArgs e)
        {
            ProvjeriVrijednosti();
        }

        private string ProvjeriSvaPolja()
        {
            string porukaPogreske = "";
            string[] trenutniRichTxt = new string[3];

            foreach (Control kontrola in pnlMatrica.Controls)
            {
                if (typeof(RichTextBox) == kontrola.GetType())
                {
                    trenutniRichTxt = kontrola.Tag.ToString().Split('-');//opis-red-stupac
                    if (trenutniRichTxt[0] == "Obicna")
                    {
                        if (kontrola.Text != "")
                        {
                            int broj;
                            if (int.TryParse(kontrola.Text, out broj))
                            {
                                if (broj <= 0 || broj > dimenzijaMatrice)
                                {
                                    porukaPogreske = "Svi brojevi moraju biti u rasponu od [ 1, " + dimenzijaMatrice + " ]";
                                }
                            }
                            else
                            {
                                porukaPogreske = "Sva polja moraju sadržavati brojeve!";
                            }
                        }
                        else
                        {
                            porukaPogreske = "Sva polja moraju biti popunjena!";
                            break;
                        }
                    }
                }
            }
            return porukaPogreske;
        }

        private void ProvjeriVrijednosti()
        {
            string porukaGreske = ProvjeriSvaPolja();
            if (porukaGreske == "")//nema greski
            {
                bool sveTocno = true;

                string[] trenutniRichTxt = new string[3];
                foreach (Control kontrola in pnlMatrica.Controls)
                {
                    if (typeof(RichTextBox) == kontrola.GetType())
                    {
                        trenutniRichTxt = kontrola.Tag.ToString().Split('-');//opis-red-stupac

                        if (trenutniRichTxt[0] == "Obicna")
                        {
                            foreach (Celija celija in listaCelija.ToList())
                            {
                                if (celija.red == int.Parse(trenutniRichTxt[1]) && celija.stupac == int.Parse(trenutniRichTxt[2]))
                                {
                                    if (int.Parse(kontrola.Text) != celija.vrijednost)
                                    {
                                        sveTocno = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (sveTocno)
                {
                    MessageBox.Show("Čestitam, uspješno ste rješili ovaj zadatak!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nažalost, niste uspjeli rješiti ovaj zadatak!" + Environment.NewLine + "Pokušajte ponovo!", "Neuspjeh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(porukaGreske, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrikaziRjesenje_Click(object sender, EventArgs e)
        {
            PrikaziVrijednosti();
        }

        private void DodajTextChangedEvent()
        {
            string[] trenutniRichTxt = new string[3];

            foreach (Control kontrola in pnlMatrica.Controls)
            {
                if (typeof(RichTextBox) == kontrola.GetType())
                {
                    trenutniRichTxt = kontrola.Tag.ToString().Split('-');//opis-red-stupac

                    if (trenutniRichTxt[0] == "Obicna")
                    {
                        kontrola.TextChanged += ProvjeriPolje;
                    }
                }
            }
        }

        private void ProvjeriPolje(object sender, EventArgs e)
        {
            string[] trenutniRichTxt = new string[3];
            RichTextBox richTxt = (RichTextBox)sender;
            trenutniRichTxt = richTxt.Tag.ToString().Split('-');
            int broj;

            if (richTxt.Text != "")
            {
                if (int.TryParse(richTxt.Text, out broj))
                {
                    if ((broj > 0 && broj <= dimenzijaMatrice))
                    {
                        if (int.Parse(richTxt.Text) == BrojZgrada.matrica[int.Parse(trenutniRichTxt[1]) - 1, int.Parse(trenutniRichTxt[2]) - 1])
                        {
                            richTxt.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            richTxt.BackColor = Color.IndianRed;
                        }
                    }
                    else
                    {
                        //kontrola.Text = "";
                        richTxt.BackColor = Color.IndianRed;
                        MessageBox.Show("Morate unijeti broj u rasponu [ 1, " + dimenzijaMatrice + " ]", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //kontrola.Text = "";
                    richTxt.BackColor = Color.IndianRed;
                    MessageBox.Show("Morate unijeti broj!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                richTxt.BackColor = Color.White;
            }
        }

        private void txtVelicinaTablice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKreirajTablicu.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {
            btnProvjeri.Enabled = false;
            btnPrikaziRjesenje.Enabled = false;
        }
    }
}
