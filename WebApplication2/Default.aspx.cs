using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nom1 = nom.Text;

            // Récupération de la chaîne de connexion dans Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MAConnexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO etudiant (Nom) VALUES (@Nom)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nom",nom1);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    LabelMessage.Text = "Inscription réussie !";
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    LabelMessage.Text = "Erreur : " + ex.Message;

                }
            }

        }

        protected void nom_TextChanged(object sender, EventArgs e)
        {
            // Tu peux mettre un traitement ici si nécessaire, ou laisser vide
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string nom1 = nom.Text;

            // Récupération de la chaîne de connexion dans Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MAConnexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM etudiant WHERE Nom = @Nom";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nom", nom1);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    LabelMessage.Text = "suppression réussie !";
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    LabelMessage.Text = "Erreur : " + ex.Message;

                }
            }

        }
    }

    

    }