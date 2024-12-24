using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TpCalculette
{
    internal class SqlModel
    {
        private static string chaine = "Server=localhost\\SQLEXPRESS;Database=Tp_gui ;Trusted_Connection=True";
        private static SqlConnection cnx = new SqlConnection(chaine);
        private static SqlCommand cmd = new SqlCommand();
        private static SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        public static List<Ouvrage> GetData()
        {
            List<Ouvrage> ouvrages = new List<Ouvrage>();
            try
            {
                cnx.Open();
                cmd.CommandText = "SELECT * FROM ouvrages";
                cmd.Connection = cnx;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ouvrages = dt.Rows.Cast<DataRow>()
                    .Select(row => new Ouvrage(row["ISBN"].ToString(), row["titre"].ToString(), row["auteur"].ToString()))
                    .ToList();
            }
            catch (Exception ex) { return null; }
            finally { cnx.Close(); }
            return ouvrages;
        }
        public static Ouvrage GetOuvrage(string ISBN)
        {
            Ouvrage ouvrage = null;
            try
            {
                cnx.Open();
                cmd.CommandText = "SELECT * FROM ouvrages WHERE ISBN = '" + ISBN + "'";
                cmd.Connection = cnx;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ouvrage = dt.Rows.Cast<DataRow>()
                    .Select(row => new Ouvrage(row["ISBN"].ToString(), row["titre"].ToString(), row["auteur"].ToString()))
                    .FirstOrDefault();
            }
            catch (Exception ex) { return null; }
            finally { cnx.Close(); }
            return ouvrage;
        }
        public static int InsertQuery(string ISBN, string titre, string auteur)
        {
            int result = 0;
            try
            {
                cnx.Open();
                cmd.CommandText = "INSERT INTO ouvrages (ISBN, titre, auteur) VALUES ('" + ISBN + "', '" + titre + "', '" + auteur + "')";
                cmd.Connection = cnx;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { return 0; }
            finally { cnx.Close(); }
            return result;
        }
        public static int UpdateQuery(string ISBN, string NewISBN, string titre, string auteur)
        {
            int result = 0;
            try
            {
                cnx.Open();
                cmd.CommandText = "UPDATE ouvrages SET ISBN = '" + NewISBN + "', titre = '" + titre + "', auteur = '" + auteur + "' WHERE ISBN = '" + ISBN + "'";
                cmd.Connection = cnx;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { return 0; }
            finally { cnx.Close(); }
            return result;
        }
        public static int DeleteQuery(string ISBN)
        {
            {
                int result = 0;
                try
                {
                    cnx.Open();
                    cmd.CommandText = "DELETE FROM ouvrages WHERE ISBN = '" + ISBN + "'";
                    cmd.Connection = cnx;
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { return 0; }
                finally { cnx.Close(); }

                return result;
            }
        }
    }
}
