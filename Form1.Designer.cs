
namespace TpCalculette
{
    partial class frmCalculette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.booksList = new System.Windows.Forms.ComboBox();
            this.btn_ajouter = new System.Windows.Forms.Button();
            this.btn_modifier = new System.Windows.Forms.Button();
            this.btn_supprimer = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.text_id = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_titre = new System.Windows.Forms.Label();
            this.text_titre = new System.Windows.Forms.TextBox();
            this.lbl_auteur = new System.Windows.Forms.Label();
            this.text_auteur = new System.Windows.Forms.TextBox();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_feedback = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // booksList
            // 
            this.booksList.FormattingEnabled = true;
            this.booksList.Location = new System.Drawing.Point(55, 28);
            this.booksList.Name = "booksList";
            this.booksList.Size = new System.Drawing.Size(406, 28);
            this.booksList.TabIndex = 0;
            this.booksList.SelectedIndexChanged += new System.EventHandler(this.booksList_SelectedIndexChanged);
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Location = new System.Drawing.Point(55, 303);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(75, 41);
            this.btn_ajouter.TabIndex = 1;
            this.btn_ajouter.Text = "Ajouter";
            this.btn_ajouter.UseVisualStyleBackColor = true;
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.Location = new System.Drawing.Point(181, 303);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(75, 41);
            this.btn_modifier.TabIndex = 2;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // btn_supprimer
            // 
            this.btn_supprimer.Location = new System.Drawing.Point(310, 303);
            this.btn_supprimer.Name = "btn_supprimer";
            this.btn_supprimer.Size = new System.Drawing.Size(100, 41);
            this.btn_supprimer.TabIndex = 3;
            this.btn_supprimer.Text = "Supprimer";
            this.btn_supprimer.UseVisualStyleBackColor = true;
            this.btn_supprimer.Click += new System.EventHandler(this.btn_supprimer_Click);
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(459, 303);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(75, 41);
            this.btn_valider.TabIndex = 4;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(581, 303);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(75, 41);
            this.btn_annuler.TabIndex = 5;
            this.btn_annuler.Text = "Annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // text_id
            // 
            this.text_id.Location = new System.Drawing.Point(126, 95);
            this.text_id.Name = "text_id";
            this.text_id.Size = new System.Drawing.Size(239, 26);
            this.text_id.TabIndex = 6;
            this.text_id.Leave += new System.EventHandler(this.text_id_Leave);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(55, 95);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(59, 20);
            this.lbl_id.TabIndex = 7;
            this.lbl_id.Text = "ISBN : ";
            // 
            // lbl_titre
            // 
            this.lbl_titre.AutoSize = true;
            this.lbl_titre.Location = new System.Drawing.Point(55, 149);
            this.lbl_titre.Name = "lbl_titre";
            this.lbl_titre.Size = new System.Drawing.Size(48, 20);
            this.lbl_titre.TabIndex = 9;
            this.lbl_titre.Text = "Titre :";
            // 
            // text_titre
            // 
            this.text_titre.Location = new System.Drawing.Point(126, 149);
            this.text_titre.Name = "text_titre";
            this.text_titre.Size = new System.Drawing.Size(239, 26);
            this.text_titre.TabIndex = 8;
            this.text_titre.Leave += new System.EventHandler(this.text_titre_Leave);
            // 
            // lbl_auteur
            // 
            this.lbl_auteur.AutoSize = true;
            this.lbl_auteur.Location = new System.Drawing.Point(55, 204);
            this.lbl_auteur.Name = "lbl_auteur";
            this.lbl_auteur.Size = new System.Drawing.Size(65, 20);
            this.lbl_auteur.TabIndex = 11;
            this.lbl_auteur.Text = "Auteur :";
            // 
            // text_auteur
            // 
            this.text_auteur.Location = new System.Drawing.Point(126, 204);
            this.text_auteur.Name = "text_auteur";
            this.text_auteur.Size = new System.Drawing.Size(239, 26);
            this.text_auteur.TabIndex = 10;
            this.text_auteur.Leave += new System.EventHandler(this.text_auteur_Leave);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(TpCalculette.Program);
            // 
            // lbl_feedback
            // 
            this.lbl_feedback.AutoSize = true;
            this.lbl_feedback.Location = new System.Drawing.Point(705, 323);
            this.lbl_feedback.Name = "lbl_feedback";
            this.lbl_feedback.Size = new System.Drawing.Size(0, 20);
            this.lbl_feedback.TabIndex = 12;
            // 
            // frmCalculette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.lbl_feedback);
            this.Controls.Add(this.lbl_auteur);
            this.Controls.Add(this.text_auteur);
            this.Controls.Add(this.lbl_titre);
            this.Controls.Add(this.text_titre);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.text_id);
            this.Controls.Add(this.btn_annuler);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_supprimer);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.btn_ajouter);
            this.Controls.Add(this.booksList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCalculette";
            this.Text = "Bibliotheque";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.ComboBox booksList;
        private System.Windows.Forms.Button btn_ajouter;
        private System.Windows.Forms.Button btn_modifier;
        private System.Windows.Forms.Button btn_supprimer;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.TextBox text_id;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_titre;
        private System.Windows.Forms.TextBox text_titre;
        private System.Windows.Forms.Label lbl_auteur;
        private System.Windows.Forms.TextBox text_auteur;
        private System.Windows.Forms.Label lbl_feedback;
    }
}

