<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelPesquisa.aspx.cs" Inherits="expenseOnHotel._HotelPesquisa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Pesquisa de Hotéis cadastrados</h1>
        <p class="lead">Página para consultar os hotéis cadastrados, de acordo com o filtro de pesquisa.</p>
        <p>Se o campo estiver em branco, não será considerado.</p>
        <p>Aqui vocë pode editar ou excluir um hotel, também. Basta clicar no ícone no início da tabela.</p>
    </div>
    <div class="container">
        <div class="input-group input-group-lg">
            <span id="lblHotelName" class="input-group-text">Nome do Hotel</span>
            <input id="hotelName" type="text" class="form-control col-lg-10">
            <span id="lblHotelAmenities" class="input-group-text">Comodidades</span>
            <input id="hotelAmenities" type="text" class="form-control col-lg-10">
        </div>
    </div>
    <div style="text-align: center">
        <button type="submit" class="btn btn-success btn-lg" onclick="searchHotel(); return false;">Pesquisar Hotel(is)</button>
    </div>
    <div class="container">
        <div runat="server" id="listaDados" style="width: 70%; margin: 0 auto"></div>
    </div>
    <script>
        function searchHotel() {

            let hotelName = document.querySelector('#hotelName').value;
            let hotelAmenities = document.querySelector('#hotelAmenities').value;

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "/HotelPesquisa.aspx/Buscar",
                data: "{'hotelName':'" + hotelName + "', 'hotelAmenities':'" + hotelAmenities + "'}",
                success: function (result) {
                    let retorno = result.d;
                    document.getElementById('MainContent_listaDados').innerHTML = retorno;
                }
            });
        }

        function updateHotel(hotelID) {
            if (confirm('Deseja atualizar este cadastro?')) {
                window.location.href = '/HotelUpdate.aspx?id=' + hotelID;    
            }
        }
        function deleteHotel(hotelID) {
            if (confirm('Deseja realmente excluir este cadastro?')) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/HotelPesquisa.aspx/Excluir",
                    data: "{'hotelID':'" + hotelID + "'}",
                    success: function (result) {
                        let retorno = result.d;
                        window.alert(retorno);
                        location.reload();
                    }
                });
            }
        }
    </script>
</asp:Content>
