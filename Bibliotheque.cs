using System;
using System.Collections.Generic;

namespace TpCalculette
{
    public class Bibliotheque
    {
        private List<Ouvrage> ouvrages;

        public Bibliotheque()
        {
            ouvrages = SqlModel.GetData();
        }

        public List<Ouvrage> GetOuvrages() { return ouvrages; }
        public Ouvrage GetOuvrage(string ISBN) { return SqlModel.GetOuvrage(ISBN); }

        public int AjouterOuvrage(Ouvrage ouvrage)
        {
            int n = SqlModel.InsertQuery(ouvrage.GetISBN(), ouvrage.GetTitre(), ouvrage.GetAuteur());
            if (n > 0)
            {
                ouvrage = SqlModel.GetOuvrage(ouvrage.GetISBN());
                ouvrages.Add(ouvrage);
            }
            return n;
        }

        public int ModifierOuvrage(string ISBN, Ouvrage ouvrage)
        {
            int n = SqlModel.UpdateQuery(ISBN, ouvrage.GetISBN(), ouvrage.GetTitre(), ouvrage.GetAuteur());
            if (n > 0)
            {
                Ouvrage updatedOuvrage = SqlModel.GetOuvrage(ouvrage.GetISBN());
                if (updatedOuvrage != null)
                {
                    Ouvrage existingOuvrage = ouvrages.Find(x => x.GetISBN() == ISBN);
                    if (existingOuvrage != null)
                    {
                        existingOuvrage.SetISBN(updatedOuvrage.GetISBN());
                        existingOuvrage.SetTitre(updatedOuvrage.GetTitre());
                        existingOuvrage.SetAuteur(updatedOuvrage.GetAuteur());
                    }
                }

            }
            return n;
        }

        public int SupprimerOuvrage(Ouvrage ouvrage)
        {
            int n = SqlModel.DeleteQuery(ouvrage.GetISBN());
            if (n > 0)
            {
                ouvrages.Remove(ouvrage);
            }
            return n;
        }
    }
}
