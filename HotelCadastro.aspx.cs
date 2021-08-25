using System;
using System.Web.UI;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace expenseOnHotel
{
    public partial class _HotelCadastro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string Cadastrar(string hotelName, string hotelEvaluation, string hotelDescription, string hotelAddress, string hotelCEP, string hotelComplement, string hotelAmenities)
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
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DESENV03\Desktop\expenseOnHotel\App_Data\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection dbConnection = new SqlConnection(con);

            //query para inserir os dados
            SqlCommand command = new SqlCommand("INSERT INTO Hotels VALUES('" + hotelName + "', '" + hotelEvaluation + "', '" + hotelDescription + "', '" +
                hotelAddress + "', '" + hotelCEP + "', '" + hotelComplement + "', '" + hotelAmenities + "')", dbConnection);
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