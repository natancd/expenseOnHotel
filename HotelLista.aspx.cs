using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expenseOnHotel
{
    public partial class _HotelLista : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInformations();
        }

        public void LoadInformations()
        {
            //ALTERAR AQUI O FILENAME PARA A POSTA O LOCAL DO ARQUIVO EM SEU COMPUTADOR
            const string fileName = @"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";
            //conexão com db no VS            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + fileName + ";Integrated Security=True";           
            SqlConnection dbConnection = new SqlConnection(con);

            //query para selecionar os dados            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT HotelName, HotelEvaluation FROM Hotels ORDER BY HotelName ASC");

            SqlCommand command = new SqlCommand(sb.ToString(), dbConnection);

            //criação das tabelas para exibir na tela
            int count = 1;
            string retorno = "<table class='table' align='center'>";
            retorno += "<thead>";
            retorno += "<tr>";
            retorno += "<th scope='col'>#</th> ";
            retorno += "<th scope='col'>Nome do Hotel </th> ";
            retorno += "<th scope='col'>Avaliação </th> ";
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
                        string hotelName = reader.GetValue(0).ToString();
                        string hotelEvaluation = reader.GetValue(1).ToString();
                        retorno += "<tr>";
                        retorno += "<th scope='row'>" + count + "</th>";
                        retorno += "<td>" + hotelName + "</td>";
                        retorno += "<td>" + hotelEvaluation + "</td>";
                        retorno += "</tr>";
                        count++;
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
            
            listaDados.InnerHtml = retorno;
        }
    }
}
