using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTG_latinski_kvadrat
{
    public class BrojZgrada
    {
        public List<Celija> listaCelija;
        int dimenzijaMatrice;
        public static int[,] matrica;

        public BrojZgrada(List<Celija> listaCelija, int dimenzijaMatrice)
        {
            this.listaCelija = listaCelija;
            this.dimenzijaMatrice = dimenzijaMatrice;
        }

        public List<Celija> IzracunajBrojVidljivZgrada()
        {
            matrica = new int[dimenzijaMatrice, dimenzijaMatrice];

            for (int i = 0; i < dimenzijaMatrice; i++)
            {
                for (int j = 0; j < dimenzijaMatrice; j++)
                {
                    foreach (Celija celija in listaCelija)
                    {
                        if (celija.opis == "Obicna" && celija.red == i + 1 && celija.stupac == j + 1)
                        {
                            matrica[i,j] = celija.vrijednost;
                        }
                    }
                }
            }

            int max = 0;
            int brojac = 0;

            foreach (Celija celijaRubna in listaCelija)
            {
                if (celijaRubna.opis == "Go")
                {
                    int j = celijaRubna.stupac - 1;
                    brojac = 0;
                    max = 0;

                    for (int i = 0; i < dimenzijaMatrice; i++)
                    {
                        if (matrica[i, j] > max)
                        {
                            max = matrica[i, j];
                            brojac++;
                        }
                    }
                    celijaRubna.vrijednost = brojac;
                }
                else if (celijaRubna.opis == "Do")
                {
                    int j = celijaRubna.stupac - 1;
                    brojac = 0;
                    max = 0;

                    for (int i = dimenzijaMatrice-1; i >= 0; i--)
                    {
                        if (matrica[i,j] > max)
                        {
                            max = matrica[i, j];
                            brojac++;
                        }
                    }
                    celijaRubna.vrijednost = brojac;
                }
                else if (celijaRubna.opis == "Li")
                {
                    int i = celijaRubna.red - 1;
                    brojac = 0;
                    max = 0;

                    for (int j = 0; j < dimenzijaMatrice; j++)
                    {
                        if (matrica[i, j] > max)
                        {
                            max = matrica[i, j];
                            brojac++;
                        }
                    }
                    celijaRubna.vrijednost = brojac;
                }
                else if (celijaRubna.opis == "De")
                {
                    int i = celijaRubna.red - 1;
                    brojac = 0;
                    max = 0;

                    for (int j = dimenzijaMatrice-1; j >= 0; j--)
                    {
                        if (matrica[i, j] > max)
                        {
                            max = matrica[i, j];
                            brojac++;
                        }
                    }
                    celijaRubna.vrijednost = brojac;
                }
            }
            return listaCelija;      
        }
    }
}
