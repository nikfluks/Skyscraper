using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSTG_latinski_kvadrat
{
    public class CrtanjeMatrice
    {
        int dimenzijaMatrice;
        Panel pnlMatrica = null;

        public CrtanjeMatrice(int dimenzijaMatrice)
        {
            this.dimenzijaMatrice = dimenzijaMatrice;
            pnlMatrica = new Panel();
            pnlMatrica.AutoSize = true;
            pnlMatrica.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public Panel NacrtajMatricu()
        {
            NacrtajRetke();
            NacrtajStupce();
            NacrtajCelije();
            return pnlMatrica;
        }

        private void NacrtajRetke()
        {
            int y = 50;

            for (int i = 1; i <= dimenzijaMatrice; i++)
            {
                RichTextBox richLijevo = new RichTextBox();
                richLijevo.Text = "Li";
                richLijevo.Tag = "Li-" + i + "-" + 0;
                richLijevo.ReadOnly = true;
                richLijevo.Location = new Point(10, y);
                richLijevo.Size = new Size(60, 40);
                richLijevo.Multiline = true;
                richLijevo.TabStop = false;
                richLijevo.Font = new Font("Arial", 14, FontStyle.Bold);

                y += 45;

                pnlMatrica.Controls.Add(richLijevo);
            }
            /*
            Label labelaIs = new Label();
            labelaIs.Text = "Bj";
            labelaIs.Location = new Point(10, y + 10); //+10 je radi estetike da bude razmak izmedu obicnih celija
            labelaIs.Size = new Size(30, 15);
            */
            if (pnlMatrica.Height < y)//ako je panel pre niski, povecamo ga
            {
                pnlMatrica.Height = y + 45;
            }

            //pnlMatrica.Controls.Add(labelaIs);
        }

        private void NacrtajStupce()
        {
            int x = 90;

            for (int i = 1; i <= dimenzijaMatrice; i++)
            {
                RichTextBox richGore = new RichTextBox();
                richGore.Text = "Go";
                richGore.Tag = "Go-" + 0 + "-" + i;
                richGore.ReadOnly = true;
                richGore.Location = new Point(x, 0);
                richGore.Size = new Size(60, 40);
                richGore.Multiline = true;
                richGore.TabStop = false;
                richGore.Font = new Font("Arial", 14, FontStyle.Bold);

                x += 65;

                pnlMatrica.Controls.Add(richGore);
            }
            /*
            Label labelaOd = new Label();
            labelaOd.Text = "Ai";
            labelaOd.Location = new Point(x + 10, 10); //+10 je radi estetike da bude razmak izmedu obicnih celija
            labelaOd.Size = new Size(30, 15);
            */
            if (pnlMatrica.Width < x)//ako je panel pre uski, povecamo ga
            {
                pnlMatrica.Width = x + 65;
            }

            //pnlMatrica.Controls.Add(labelaOd);
        }

        private void NacrtajCelije()
        {
            int x = 90;
            int y = 50;

            for (int i = 1; i <= dimenzijaMatrice + 1; i++)//broj ishodišta/redova, +1 je za Bj
            {
                bool zadnji = false;

                for (int j = 1; j <= dimenzijaMatrice + 1; j++)//broj odredišta/stupaca, +1 je za Ai
                {
                    RichTextBox celija = new RichTextBox();
                    celija.Click += delegate
                    {
                        celija.SelectAll();
                    };


                    if (i == dimenzijaMatrice + 1 && j == dimenzijaMatrice + 1)//provjera je li trenutna celija zadnja
                    {
                        celija.Tag = "Sum-" + i + "-" + j;
                        //celija.ReadOnly = true;
                        celija.Visible = false;
                        x += 10;
                    }

                    else if (i == dimenzijaMatrice + 1)//provjera je li redak zadnji
                    {
                        celija.Text = "Do";
                        celija.Tag = "Do-" + i + "-" + j;
                        celija.ReadOnly = true;
                        celija.TabStop = false;
                        celija.Font = new Font("Arial", 14, FontStyle.Bold);

                        if (!zadnji)
                        {
                            zadnji = true;
                            y += 10;
                        }
                    }

                    else if (j == dimenzijaMatrice + 1)//provjera je li stupac zadnji
                    {
                        celija.Text = "De";
                        celija.Tag = "De-" + i + "-" + j;
                        celija.ReadOnly = true;
                        celija.TabStop = false;
                        celija.Font = new Font("Arial", 14, FontStyle.Bold);

                        if (!zadnji)
                        {
                            zadnji = true;
                            x += 10;
                        }
                    }

                    else//sve ostale celije
                    {
                        celija.Tag = "Obicna-" + i + "-" + j;
                        celija.ReadOnly = false;
                        celija.Font = new Font("Arial", 12);
                        celija.SelectAll();
                        celija.SelectionAlignment = HorizontalAlignment.Center;
                    }

                    celija.Location = new Point(x, y);
                    celija.Size = new Size(60, 40);
                    celija.Multiline = true;

                    pnlMatrica.Controls.Add(celija);

                    if (j == dimenzijaMatrice + 1) //ako smo dosli do kraja reda, prebacujemo se u novi red
                    {
                        x = 90;
                        y += 45;
                    }

                    else //inace se samo pomicemo udesno
                    {
                        x += 65;
                    }
                }
            }
        }
    }
}
