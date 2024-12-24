using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpCalculette
{
    public partial class frmCalculette : Form
    {
        private Bibliotheque Bib;
        private List<Ouvrage> ouvrages;
        private int selectedIndex;
        private int action;
        private bool textIdFilled, textTitreFilled, textAuteurFilled;
        private Timer feedbackTimer;

        public frmCalculette()
        {
            InitializeComponent();
            Bib = new Bibliotheque();
            ouvrages = new List<Ouvrage>();

            selectedIndex = -1;
            action = 0; // ajouter = 1, modifier = 2, supprimer = 3
            textIdFilled = false;
            textTitreFilled = false;
            textAuteurFilled = false;

            feedbackTimer = new Timer();
            feedbackTimer.Interval = 3000; // 3 seconds
            feedbackTimer.Tick += FeedbackTimer_Tick;
        }
        public frmCalculette(Bibliotheque biblio)
        {
            InitializeComponent();
            Bib = biblio;
            ouvrages = Bib.GetOuvrages();


            selectedIndex = -1;
            action = 0; // ajouter = 1, modifier = 2, supprimer = 3
            textIdFilled = false;
            textTitreFilled = false;
            textAuteurFilled = false;

            feedbackTimer = new Timer();
            feedbackTimer.Interval = 3000; // 3 seconds
            feedbackTimer.Tick += FeedbackTimer_Tick;
        }

        private void FeedbackTimer_Tick(object sender, EventArgs e)
        {
            lbl_feedback.Text = string.Empty;
            feedbackTimer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ouvrages.ForEach(livre => booksList.Items.Add(livre));
            initialState();

        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            stateNewBook();
            viderChamps(); 
            action = 1;
            booksList.SelectedIndex = -1;
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            stateModifiedBook();
            action = 2;
            textIdFilled = true;
            textTitreFilled = true;
            textAuteurFilled = true;
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            stateDeletedBook();
            action = 3;
            btn_annuler.Focus();
        }

        private void btn_valider_Click(object sender, EventArgs e) 
        {
            const int maxIsbnLength = 50;
            int rowsAffected = 0;
            switch (action)
            {
                case 1:
                    if(ValidateTextBoxes())
                    {
                        string truncatedIsbn = text_id.Text.Length > maxIsbnLength ? text_id.Text.Substring(0, maxIsbnLength) : text_id.Text;
                        Ouvrage ouvrage = new Ouvrage(truncatedIsbn, text_titre.Text, text_auteur.Text);
                        rowsAffected = Bib.AjouterOuvrage(ouvrage);
                        if (rowsAffected > 0)
                        {
                            booksList.Items.Add(ouvrage);

                            selectedIndex = ouvrages.Count - 1;
                            booksList.SelectedIndex = selectedIndex;
                            stateSelectedBook();
                            loadText();
                        }
                    }
                    break;
                case 2:
                    if (selectedIndex >= 0)
                    {
                        if (ValidateTextBoxes())
                        {
                            Ouvrage selectedLivre = ouvrages[selectedIndex];

                            if (ouvrages[selectedIndex].GetISBN() != text_id.Text ||
                                ouvrages[selectedIndex].GetTitre() != text_titre.Text ||
                                ouvrages[selectedIndex].GetAuteur() != text_auteur.Text)
                            {
                                string truncatedIsbn = text_id.Text.Length > maxIsbnLength ? text_id.Text.Substring(0, maxIsbnLength) : text_id.Text;
                                Ouvrage newOuvrage = new Ouvrage(truncatedIsbn, text_titre.Text, text_auteur.Text);
                                rowsAffected = Bib.ModifierOuvrage(ouvrages[selectedIndex].GetISBN(), newOuvrage);
                                if (rowsAffected > 0)
                                {
                                    booksList.Items[selectedIndex] = newOuvrage;

                                    stateSelectedBook();
                                    loadText();
                                }
                            }
                            else
                            {
                                btn_annuler.PerformClick();
                            }
                        }
                    }
                    break;
                case 3:
                    if (selectedIndex >= 0)
                    {
                        rowsAffected = Bib.SupprimerOuvrage(ouvrages[selectedIndex]);
                        if (rowsAffected > 0)
                        {
                            booksList.Items.RemoveAt(selectedIndex);

                            selectedIndex = -1;
                            initialState();
                            viderChamps();
                        }
                    }
                    break;
                default:
                    initialState();
                    break;
            }
            if (action != 0)
            {
                lbl_feedback.Text = $"{rowsAffected} row(s) affected.";
                lbl_feedback.ForeColor = rowsAffected > 0 ? Color.Green : Color.Red;
                feedbackTimer.Start();
            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            ResetColorTextBox(text_id);
            ResetColorTextBox(text_titre);
            ResetColorTextBox(text_auteur);
            if (selectedIndex >= 0)
            {
                stateSelectedBook();
                text_id.Text = ouvrages[selectedIndex].GetISBN();
                text_titre.Text = ouvrages[selectedIndex].GetTitre();
                text_auteur.Text = ouvrages[selectedIndex].GetAuteur();
            }
            else
            {
                initialState();
                viderChamps();
            }
        }

        private void booksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = booksList.SelectedIndex;

            if (selectedIndex >= 0)
            {
                stateSelectedBook();
                text_id.Text = ouvrages[selectedIndex].GetISBN();
                text_titre.Text = ouvrages[selectedIndex].GetTitre();
                text_auteur.Text = ouvrages[selectedIndex].GetAuteur();
            }
        }

        private void text_id_Leave(object sender, EventArgs e)
        {
            if (text_id.Text.Length > 0)
            {
                text_id.BackColor = SystemColors.Window;
                text_id.ForeColor = SystemColors.WindowText;
                textIdFilled = true;
            }
            else
            {
                textIdFilled = false;
            }
        }

        private void text_titre_Leave(object sender, EventArgs e)
        {
            if (text_titre.Text.Length > 0)
            {
                text_titre.BackColor = SystemColors.Window;
                text_titre.ForeColor = SystemColors.WindowText;
                textTitreFilled = true;
            }
            else
            {
                textTitreFilled = false;
            }
        }

        private void text_auteur_Leave(object sender, EventArgs e)
        {
            if (text_auteur.Text.Length > 0)
            {
                text_auteur.BackColor = SystemColors.Window;
                text_auteur.ForeColor = SystemColors.WindowText;
                textAuteurFilled = true;
            }
            else
            {
                textAuteurFilled = false;
            }
        }

        private void initialState()
        {
            booksList.Enabled = true;
            changeTextState(false);

            btn_ajouter.Enabled = true;
            btn_modifier.Enabled = false;
            btn_supprimer.Enabled = false;

            btn_valider.Enabled = false;
            btn_annuler.Enabled = false;
        }

        private void stateSelectedBook()
        {
            booksList.Enabled = true;
            changeTextState(false);

            btn_ajouter.Enabled = true;
            btn_modifier.Enabled = true;
            btn_supprimer.Enabled = true;

            btn_valider.Enabled = false;
            btn_annuler.Enabled = false;
        }

        private void stateNewBook()
        {
            booksList.Enabled = false;
            changeTextState(true);

            btn_ajouter.Enabled = false;
            btn_modifier.Enabled = false;
            btn_supprimer.Enabled = false;

            btn_valider.Enabled = true;
            btn_annuler.Enabled = true;
        }

        private void stateModifiedBook()
        {
            booksList.Enabled = false;
            changeTextState(true);

            btn_ajouter.Enabled = false;
            btn_modifier.Enabled = false;
            btn_supprimer.Enabled = false;

            btn_valider.Enabled = true;
            btn_annuler.Enabled = true;
        }

        private void stateDeletedBook()
        {
            booksList.Enabled = false;
            changeTextState(false);

            btn_ajouter.Enabled = false;
            btn_modifier.Enabled = false;
            btn_supprimer.Enabled = false;

            btn_valider.Enabled = true;
            btn_annuler.Enabled = true;
        }

        private void changeTextState(bool state)
        {
            text_id.Enabled = state;
            text_titre.Enabled = state;
            text_auteur.Enabled = state;
        }

        private void viderChamps()
        {
            text_id.Text = "";
            text_titre.Text = "";
            text_auteur.Text = "";
        }

        private void loadText()
        {
            if(selectedIndex >= 0)
            {
                text_id.Text = ouvrages[selectedIndex].GetISBN();
                text_titre.Text = ouvrages[selectedIndex].GetTitre();
                text_auteur.Text = ouvrages[selectedIndex].GetAuteur();
            }
        }

        private bool ValidateTextBoxes()
        {
            if(textIdFilled && textTitreFilled && textAuteurFilled)
            {
                return true;
            }

            if (textIdFilled == false)
            {
                HighlightTextBox(text_id, textIdFilled);
                text_id.Focus();
            }else if(textTitreFilled == false)
            {
                HighlightTextBox(text_titre, textTitreFilled);
                text_titre.Focus();
            }
            else if (textAuteurFilled == false)
            {
                HighlightTextBox(text_auteur, textAuteurFilled);
                text_auteur.Focus();
            }

            return false;
        }
        private void HighlightTextBox(TextBox textBox, bool isFilled)
        {
            if (!isFilled)
            {
                textBox.BackColor = Color.Red;
                textBox.ForeColor = Color.White;
            }
        }
        private void ResetColorTextBox(TextBox textBox)
        {
            textBox.BackColor = SystemColors.Window;
            textBox.ForeColor = SystemColors.WindowText;
        }
    }
}
