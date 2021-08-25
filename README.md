# Algumas considerações:

* Projeto desenvolvido em Visual Studio 2019.
* Devido ao tempo que me permiti para elaborar, alguns layouts não estão muito amigáveis, mas é algo relacionado ao bootstrap, que infelizmente não consegui configurar a tempo. Gostaria de finalizar o front-end e polir mais o back-end, pois ainda há muitas pontas soltas
* O projeto está rodando com o SQL Server da própria IDE, portanto somente há o script de criação da tabela na pasta Scripts. Os outros comandos são realizados dentro do próprio código.
* Para compilar, foi necessário fazer algumas mudanças (talvez não seja preciso ao rodar em seu computador nem vá inteferir com o andamento): 
em ```App_Start > RouteConfig.cs ```, foi alterado o código para ```settings.AutoRedirectMode = RedirectMode.Off;```;
em ```App_Data``` está o mdf já criado e testado, mas fiz o DROP Table para mante-la limpa.
* Talvez seja necessário alterar o caminho nas telas, onde está sinalizado no comentário referente ao ```const string fileName = @}"C:\Users\natan\Desktop\expenseOnHotel\expenseOnHotel\App_Data\Database1.mdf";``` 
logo no início do código há uma constante chamada ```const string fileName```. Se for necessário, altere este caminho para o local onde está salvo o arquivo ```Database1.mdf```. 
uma forma de fazer isso sem pesquisar onde está o arquivo é clicar com o botão direito na Database1, no Server Explorer, e clicar em Propriedades... no Connection String haverá um caminho similar a este: ```Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Users\natan\Desktop\New folder\expenseOnHotel\Database1.mdf&quot;;Integrated Security=True```. basta somente copiar o valor do ```AttachDbFilename``` e substituir na constante das duas classes citadas anteriormente, mantendo o ```@```.
* Referente as telas: não consegui descobrir o motivo pelo qual o input (Bootstrap Textbox) não está em seu comprimento total, mesmo colocando width maior

# Telas

* Site.master.cs / Default.aspx - Tela inicial. Nela há 3 botões (tanto no header como no body, ainda não ajustados no CSS nem no Bootstrap): Cadastros, Lista e Pesquisas:
* Cadastros: HotelCadastro.aspx - Tela de cadastro do hotel com Nome, Avaliação, Descrição, Endereço (com CEP e Complemento) e Comodidades pre-definidas. Não foi adicionada a Cidade nem Estado, pois posteriormente serão automaticamente preenchidos somente com o CEP, através de uma API;
* Lista: HotelLista.aspx - Tela que automaticamente lista os hoteis cadastrados no sistema, somente. Minha ideia seria colocar um dropdown para filtrar por Nome, Avaliação ou quantidade de Comodidades;
* Pesquisas: HotelPesquisa.aspx - Tela que realiza as consultas de acordo com o nome e/ou comodidades. Pode ser pesquisado qualquer valor que a consulta na DB é por ```like```. Em caso de campo em branco, a consulta considera todos;
Nesta mesma tela, ao realizar a consulta, dois botões estarão aparecendo: na cor azul para edição do hotel e em vermelho para exclusão. Há confirmações para os dois.
* Edição: HotelUpdate.aspx?=id[parametro] - A tela carrega de acordo com o hotel selecionado anteriormente (em Pesquisas). Infelizmente não consegui achar uma solução até o momento do envio deste para listar os switches (checkbox) que já estavam selecionados anteriormente, mas vou trabalhar mais tarde para finalizar esta etapa.
Ao confirmar no botão, a database é atualizada com os novos valores (e devidas validações).
