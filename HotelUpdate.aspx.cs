using System;
using System.Web.UI;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace expenseOnHotel
{
    public partial class _HotelUpdate : Page
    {
        static string hotelID;
        protected void Page_Load(object sender, EventArgs e)
        {
            hotelID = Request["id"];

            LoadHotel(Convert.ToInt32(hotelID));
        }
        public void LoadHotel(int hotelID)
        {
            //ALTERAR AQUI O FILENAME PARA A POSTA O LOCAL DO ARQUIVO EM SEU COMPUTADOR
            const string fileName = @"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";
            //conexão com db no VS            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fileName + ";Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(con);

            //query para selecionar os dados            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Hotels WHERE HotelID = " + hotelID);

            SqlCommand command = new SqlCommand(sb.ToString(), dbConnection);

            //tenta inserir os dados conectando na database
            try
            {
                dbConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hotelName.Value = reader.GetValue(1).ToString();
                        hotelEvaluation.SelectedIndex = Convert.ToInt32(reader.GetValue(2));
                        hotelDescription.Value = reader.GetValue(3).ToString();
                        hotelAddress.Value = reader.GetValue(4).ToString();
                        hotelCEP.Value = reader.GetValue(5).ToString();
                        hotelComplement.Value = reader.GetValue(6).ToString();
                        string temporaryHotelAmenities = reader.GetValue(7).ToString();
                        foreach(var amenities in temporaryHotelAmenities)
                        {

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Algo deu errado... ", ex);
            }
            finally
            {
                dbConnection.Close();
            }
        }
        [WebMethod]
        public static string Atualizar(string hotelName, string hotelEvaluation, string hotelDescription, string hotelAddress, string hotelCEP, string hotelComplement, string hotelAmenities)
        {
            string confirmationMessage;
            confirmationMessage = ValidateInput(hotelName, hotelEvaluation, hotelDescription, hotelAddress, hotelCEP, hotelComplement);

            if (confirmationMessage != "OK")
            {
                return confirmationMessage;
            }

            //ALTERAR AQUI O FILENAME PARA A POSTA O LOCAL DO ARQUIVO EM SEU COMPUTADOR
            const string fileName = @"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";

            //conexão com db no VS            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fileName + ";Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(con);

            //query para inserir os dados
            SqlCommand command = new SqlCommand("UPDATE Hotels SET HotelName = '" + hotelName + "', HotelEvaluation = '" + hotelEvaluation + "', HotelDescription = '" + hotelDescription + "', " +
                "HotelAddress = '" + hotelAddress + "', HotelCEP = '" + hotelCEP + "', HotelComplement = '" + hotelComplement + "', HotelAmenities = '" + hotelAmenities + "' WHERE HotelID = " + hotelID, dbConnection);
            //tenta inserir os dados conectando na database
            try
            {
                dbConnection.Open();
                int resultado = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DataException("Algo deu errado... ", ex);
            }

            return "";
        }

        private static string ValidateInput(string hotelName, string hotelEvaluation, string hotelDescription, string hotelAddress, string hotelCEP, string hotelComplement)
        {
            Regex regex = new Regex("^[0-9]+$");
            const int MINIMUM_LENGTH = 3;

            if (hotelName == "" || hotelName.Length < MINIMUM_LENGTH)
            {
                return "O nome do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelName.Contains(" /;<>@#$%8()\\"))
            {
                return "O nome do Hotel não pode conter caracteres especiais!";
            }
            if (hotelEvaluation == "Escolha uma Avaliação (Estrela)")
            {
                return "A avaliação deve ser selecionada!";
            }
            if (hotelDescription.Contains("/;<>@#$%8()\\"))
            {
                return "A descrição do Hotel não pode conter caracteres especiais!";
            }
            if (hotelDescription == "" || hotelDescription.Length < MINIMUM_LENGTH)
            {
                return "A descrição do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelAddress.Contains("/;<>@#$%8()\\"))
            {
                return "O endereço do Hotel não pode conter caracteres especiais!";
            }
            if (hotelAddress == "" || hotelAddress.Length < MINIMUM_LENGTH)
            {
                return "O endereço do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (!regex.IsMatch(hotelCEP))
            {
                return "O CEP do Hotel deve conter somente números!";
            }
            if (hotelCEP == "" || hotelCEP.Length != 8)
            {
                return "O CEP deve conter 8 caracteres numéricos apenas!";
            }

            return "OK";
        }
    }
}