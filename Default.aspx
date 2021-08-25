<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="expenseOnHotel._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>EXPENSEON HOTEL</h1>
        <p class="lead">Página fictícia criada para vaga de Desenvolvedor .NET da empresa <a href="https://expenseon.com/">Expense On</a>, com os objetivos informados abaixo</p>
        <p>Este projeto tem as seguintes funções:</p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Cadastro de hoteis</h2>
            <p>Uma das funcionalidades é realizar o cadastro e as devidas atualizações. </p>
            <a href="HotelCadastro.aspx" class="btn btn-block btn-primary">Cadastros</a>
        </div>
        <div class="col-md-4">
            <h2>Lista de hotéis</h2>
            <p>Outra funcionalidade é a listagem de todos os hotéis cadastrados.</p>
            <a href="HotelLista.aspx" class="btn btn-block btn-info">Lista</a>
        </div>
        <div class="col-md-4">
            <h2>Pesquisas</h2>
            <p>Também é possível pesquisar os hotéis por nomes/comodidades.</p>
            <a href="HotelPesquisa.aspx" class="btn btn-block btn-info">Pesquisas</a>
        </div>
    </div>
</asp:Content>
