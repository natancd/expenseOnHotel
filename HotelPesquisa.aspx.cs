using System;
using System.Web.UI;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace expenseOnHotel
{
    public partial class _HotelPesquisa : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string Buscar(string hotelName, string hotelAmenities)
        {
            //ALTERAR AQUI O FILENAME PARA A POSTA O LOCAL DO ARQUIVO EM SEU COMPUTADOR
            const string fileName = @"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";
            //conexão com db no VS            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fileName + ";Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(con);

            //query para selecionar os dados            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Hotels ");
            if (hotelName.Trim() != "")
            {
                sb.Append("WHERE HotelName like '%" + hotelName + "%' ");
            }
            if (hotelAmenities.Trim() != "")
            {
                if (hotelName.Trim() != "")
                {
                    sb.Append(" AND ");
                }
                else
                {
                    sb.Append(" WHERE ");
                }
                sb.Append(" HotelAmenities like '%" + hotelAmenities + "%' ");
            }
            sb.Append("ORDER BY HotelName ASC");

            SqlCommand command = new SqlCommand(sb.ToString(), dbConnection);

            //criação das tabelas para exibir na tela
            int count = 1;
            string retorno = "<table class='table' align='center'>";
            retorno += "<thead>";
            retorno += "<tr>";
            retorno += "<th scope='col'>Atualizar</th> ";
            retorno += "<th scope='col'>Excluir</th> ";
            retorno += "<th scope='col'>#</th> ";
            retorno += "<th scope='col'>Nome do Hotel </th> ";
            retorno += "<th scope='col'>Avaliação </th> ";
            retorno += "<th scope='col'>Resumo do Hotel </th> ";
            retorno += "<th scope='col'>Endereço </th> ";
            retorno += "<th scope='col'>Comodidades </th> ";
            retorno += "</tr>";
            retorno += "</thead>";
            retorno += "<tbody>";

            //tenta inserir os dados conectando na database
            try
            {
                dbConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string hotelID = reader.GetValue(0).ToString();
                        string temporaryHotelName = reader.GetValue(1).ToString();
                        string temporaryHotelEvaluation = reader.GetValue(2).ToString();
                        string temporaryHotelDescription = reader.GetValue(3).ToString();
                        string temporaryHotelAddress = reader.GetValue(4).ToString() + "," + reader.GetValue(5).ToString() + ", " + reader.GetValue(6).ToString();
                        string temporaryHotelAmenities = reader.GetValue(7).ToString();

                        retorno += "<tr>";
                        retorno += "<td style='text-align:center'><button type='button' class='btn btn-primary btn-sm' onclick='updateHotel(" + hotelID + ");'></button></td>";
                        retorno += "<td style='text-align:center'><button type='button' class='btn btn-danger btn-sm' onclick='deleteHotel(" + hotelID + ");'></button></td>";
                        retorno += "<th scope='row'>" + count + "</th>";
                        retorno += "<td>" + temporaryHotelName + "</td>";
                        retorno += "<td>" + temporaryHotelEvaluation + "</td>";
                        retorno += "<td>" + temporaryHotelDescription + "</td>";
                        retorno += "<td>" + temporaryHotelAddress + "</td>";
                        retorno += "<td>" + temporaryHotelAmenities + "</td>";
                        retorno += "</tr>";
                        count++;
                    }
                    if (reader.HasRows == false)
                    {
                        return "Nenhum hotel encontrado com os parâmetros informados...";
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
            return retorno;
        }

        [WebMethod]
        public static string Excluir(int hotelID)
        {
            //ALTERAR AQUI O FILENAME PARA A POSTA O LOCAL DO ARQUIVO EM SEU COMPUTADOR
            const string fileName = @"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";
            //conexão com db no VS            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fileName + ";Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(con);

            //query para selecionar os dados            
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM Hotels WHERE HotelID = '" + hotelID + "'");

            SqlCommand command = new SqlCommand(sb.ToString(), dbConnection);
            //tenta apagar os dados conectando na database
            try
            {
                dbConnection.Open();
                int resultado = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DataException("Algo deu errado... ", ex);
            }
            return "Hotel # " + hotelID + " excluído com sucesso!";
        }
    }
}