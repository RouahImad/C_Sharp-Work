namespace TpCalculette
{

    public class Ouvrage
    {
        private string ISBN;
        private string titre;
        private string auteur;

        public Ouvrage()
        {
            this.ISBN = null;
            this.titre = null;
            this.auteur = null;
        }

        public Ouvrage(string isbn, string titre, string auteur)
        {
            this.ISBN = isbn;
            this.titre = titre;
            this.auteur = auteur;
        }

        public override string ToString()
        {
            return titre;
        }

        public string GetISBN() { return ISBN; }
        public void SetISBN(string value) { ISBN = value; }

        public string GetTitre() { return titre; }
        public void SetTitre(string value) { titre = value; }

        public string GetAuteur() { return auteur; }
        public void SetAuteur(string value) { auteur = value; }

    }
}
