using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Cinema
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropdownList_SelectedIndexChanged(sender, e);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(Cinema);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Insert into Sale(Nome, Cognome, SalaSud, SalaNord, SalaEst, Ridotto) " +
                    "Values (@Nome,@Cognome,@SalaSud,@SalaNord,@SalaEst,@Ridotto)";

                command.Parameters.AddWithValue("@Nome", Nome.Text);
                command.Parameters.AddWithValue("@Cognome", Cognome.Text);
                command.Parameters.AddWithValue("@SalaSud", Sud.Value);
                command.Parameters.AddWithValue("@SalaNord", Nord.Value);
                command.Parameters.AddWithValue("@SalaEst", Est.Value);
                command.Parameters.AddWithValue("@Ridotto", CheckBox1.Checked);

                command.ExecuteNonQuery();

                Response.Write("Inserito con successo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void DropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList2.SelectedItem.Text)
            {
                case "Sala Nord":
                    Nord.Value = "1";
                    Est.Value = "0";
                    Sud.Value = "0";
                    break;
                case "Sala Sud":
                    Nord.Value = "0";
                    Est.Value = "0";
                    Sud.Value = "1";
                    break;
                case "Sala Est":
                    Nord.Value = "0";
                    Est.Value = "1";
                    Sud.Value = "0";
                    break;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();


                SqlCommand command1 = new SqlCommand();
                command1.Connection = conn;
                command1.CommandText = "Select Count(SalaEst) from Sale where SalaEst = 1";
                SqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    int SalaEst = reader1.GetInt32(0);
                    Dettagli.InnerHtml = "Prenotazioni confermate in Sala Est: " + SalaEst;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand();
                command2.Connection = conn;
                command2.CommandText = "Select Count(SalaEst) from Sale where Salaest = 1 and Ridotto = 1";
                SqlDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    int Ridotti = reader2.GetInt32(0);
                    Dettagli.InnerHtml += "<br /> Prenotazioni ridotte in Sala Est: " + Ridotti;
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();


                SqlCommand command1 = new SqlCommand();
                command1.Connection = conn;
                command1.CommandText = "Select Count(SalaSud) from Sale where SalaSud = 1";
                SqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    int SalaSud = reader1.GetInt32(0);
                    Dettagli.InnerHtml = "Prenotazioni confermate in Sala Sud: " + SalaSud;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand();
                command2.Connection = conn;
                command2.CommandText = "Select Count(SalaSud) from Sale where SalaSud = 1 and Ridotto = 1";
                SqlDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    int Ridotti = reader2.GetInt32(0);
                    Dettagli.InnerHtml += "<br /> Prenotazioni ridotte in Sala Sud: " + Ridotti;
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();


                SqlCommand command1 = new SqlCommand();
                command1.Connection = conn;
                command1.CommandText = "Select Count(SalaNord) from Sale where SalaNord = 1";
                SqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    int SalaNord = reader1.GetInt32(0);
                    Dettagli.InnerHtml = "Prenotazioni confermate in Sala Nord: " + SalaNord;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand();
                command2.Connection = conn;
                command2.CommandText = "Select Count(SalaNord) from Sale where SalaNord = 1 and Ridotto = 1";
                SqlDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    int Ridotti = reader2.GetInt32(0);
                    Dettagli.InnerHtml += "<br /> Prenotazioni ridotte in Sala Nord: " + Ridotti;
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}