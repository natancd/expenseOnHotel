<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelUpdate.aspx.cs" Inherits="expenseOnHotel._HotelUpdate" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <div class="jumbotron">
        <h1>Cadastro de Hotel</h1>
        <p class="lead">Página para atualização do hotel no banco de dados.</p>
    </div>
    <div class="container">
        <div class="input-group input-group-lg">
            <span id="lblHotelName" class="input-group-text">Nome do Hotel</span>
            <input runat="server" id="hotelName" type="text" class="form-control col-lg-10" required>
            <span class="input-group-text" id="lblHotelEvaluation">Avaliação</span>
            <select runat="server" id="hotelEvaluation" class="form-select">
                <option selected>Escolha uma Avaliação (Estrela)</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
            </select>
        </div>
        <div class="input-group input-group-lg">
            <span id="lblHotelDescription" class="input-group-text">Descrição</span>
            <input runat="server" id="hotelDescription" type="text" class="form-control" required>
        </div>
        <div class="input-group input-group-lg">
            <span id="lblHotelAddress" class="input-group-text">Endereço</span>
            <input runat="server" id="hotelAddress" type="text" class="form-control">
            <span id="lblHotelCEP" class="input-group-text">CEP</span>
            <input runat="server" id="hotelCEP" type="text" class="form-control">
            <span id="lblHotelComplement" class="input-group-text">Complemento</span>
            <input runat="server" id="hotelComplement" type="text" class="form-control">
        </div>
        <div class="input-group input-group-lg">
            <span id="lblComodidades" class="input-group-text">Comodidades</span>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeEstacionamento">
                <label class="form-check-label" for="comodidadeEstacionamento">Estacionamento</label>
            </div>
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadePiscina">
                <label class="form-check-label" for="comodidadePiscina">Piscina</label>
            </div>

            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeSauna">
                <label class="form-check-label" for="comodidadeSauna">Sauna</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeWifi">
                <label class="form-check-label" for="comodidadeWifi">Wi-fi</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeRestaurante">
                <label class="form-check-label" for="comodidadeRestaurante">Restaurante</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeBar">
                <label class="form-check-label" for="comodidadeBar">Bar</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeSalaDeJogos">
                <label class="form-check-label" for="comodidadeSalaDeJogos">Sala de Jogos</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeArCondicionado">
                <label class="form-check-label" for="comodidadeArCondicionado">Ar-condicionado</label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <div class="form-check form-switch" style="padding-top: 10px; padding-right: 10px">
                <input runat="server" class="form-check-input" name="hotelCheckbox" type="checkbox" id="comodidadeFrigobar">
                <label class="form-check-label" for="comodidadeFrigobar">Frigobar</label>
            </div>
        </div>
        <br />
        <div style="text-align:center">
            <button type="submit" class="btn btn-success btn-lg" onclick="atualizarHotel(); return false;">Atualizar Hotel</button>
        </div>        
    </div>    

    <script>
        function atualizarHotel() {

            let hotelName = document.querySelector('#MainContent_hotelName').value;
            let hotelEvaluation = document.querySelector('#MainContent_hotelEvaluation').value;
            let hotelDescription = document.querySelector('#MainContent_hotelDescription').value;
            let hotelAddress = document.querySelector('#MainContent_hotelAddress').value;
            let hotelCEP = document.querySelector('#MainContent_hotelCEP').value;
            let hotelComplement = document.querySelector('#MainContent_hotelComplement').value;
            let hotelAmenities = []
            let checkboxes = document.querySelectorAll("[type=checkbox]");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    hotelAmenities.push(checkboxes[i].nextElementSibling.innerText);
                }
            }

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "/HotelUpdate.aspx/Atualizar",
                data: "{'hotelName':'" + hotelName + "', 'hotelEvaluation':'" + hotelEvaluation + "', 'hotelDescription':'" + hotelDescription + "', 'hotelAddress':'" + hotelAddress +
                    "', 'hotelCEP':'" + hotelCEP + "', 'hotelComplement':'" + hotelComplement + "', 'hotelAmenities':'" + hotelAmenities + "'}",
                success: function (result) {
                    let retorno = result.d;
                    let cadastroOK = "Hotel atualizado com sucesso!";

                    if (retorno == "OK") {
                        window.alert(cadastroOK);
                    }
                    else {
                        window.alert(retorno);
                    }
                }
            });
        }
    </script>
</asp:Content>

