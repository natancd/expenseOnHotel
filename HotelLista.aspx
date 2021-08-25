<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelLista.aspx.cs" Inherits="expenseOnHotel._HotelLista" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <div class="jumbotron">
        <h1>Lista de Hotéis cadastrados</h1>
        <p class="lead">Página para visualização de todos os hotéis cadastrados, ordenados por ordem do nome do Hotel.</p>
        <p>Dropdown para ordenar por outros campos em manutenção.</p>
    </div>
    <div class="container">
        <div runat="server" id="listaDados" style="width: 70%; margin: 0 auto"></div>
    </div>    
</asp:Content>
