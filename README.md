<div align="center">
  <img src="https://raw.githubusercontent.com/tomchen/stack-icons/master/logos/c-sharp.svg" width="100px" height="100px"/>
  <img src="https://raw.githubusercontent.com/gilbarbara/logos/bea0759cf5fbfaad7e92e6032ff9481dd82de561/logos/dotnet.svg" width="100px" height="100px"/>
  <h1>MVC Games C# (Model-View-Controller)</h1>
</div>
<br />
<h2>Sobre o projeto:</h2>
<br />
<p>Este projeto é um site de cadastro de seus Games prediletos, podendo criá-los, editá-los e apagá-los.</p>
<br />
<h2>Tecnologiass Utilizadas:</h2>
<ul>
  <li>Padrão MVC para aplicação Web</li>
  <li>AspNet</li>
  <li>SQL Server</li>
  <li>EntityFrameworkCore (para montar a estrutura do banco de dados)</li>
  <li>EntityFrameworkCore.Design</li>
  <li>EntityFrameworkCore.SqlServer (Provedor de Banco de Dados SQL Server para o Entity Framework Core)</li>
  <li>EntityFrameworkCore.Tools (Ferramentas do Entity para o NuGet Package Manager no Visual Studio)</li>
  <li>AspNetCore.Mvc.Razor.RuntimeCompilation (com isso, não é preciso uma nova build da aplicação, apenas atualizar o localhost)</li>
  <li>DataTables - Plug-in de tabela para JQuery</li>
</ul>

<h2>No terminal do Package Manager:</h2>
<p>Após criar uma Model com o modelo dos dados e um contexto do banco de dados, siga os seguintes passos:</p>
<ul>
  <li>Execute este comando para criar a migration: Add-Migration NomeDaMigration -Context NomeDoContexto</li>
  <li>Para executar a criação do banco de dados: Update-Database -Context NomeDoContexto</li>
</ul>

<h2>Configurando o Banco de Dados:</h2>

<br />
<p>No arquivo <strong>appsettings.json</strong>, insira este bloco de código:</p>
<pre>
  "ConnectionStrings": {
    "DataBase": "Server=NomeDoServidor;Database=NomeDoBancoDeDados;User Id=NomeDeUsuario;Password=Senha"
  },
</pre>

<br />

<p>Ficará desta maneira:</p>
<pre>
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "DataBase": "Server=NomeDoServidor;Database=NomeDoBancoDeDados;User Id=NomeDeUsuario;Password=Senha"
  },
  "AllowedHosts": "*"
}
</pre>

<h2>Configuração do DataTables:</h2>
<p>Vá até o arquivo desse diretório: Views\Shared\<strong>_Layout.cshtml</strong> e insira:</p>
<pre>
  &ltlink href="https://cdn.datatables.net/v/dt/dt-1.13.6/datatables.min.css" rel="stylesheet"/&gt;
  <script src="https://cdn.datatables.net/v/dt/dt-1.13.6/datatables.min.js"></script>
</pre>
<br />
<p>Logo após, vá até o arquivo desse diretório: wwwroot\js\<strong>site.js</strong> e insira este bloco de código:</p>
<pre>
  $(document).ready(function () {
    getDatatable("#tabela1");
    getDatatable("#tabela2");
  })

  function getDatatable(id) {
      $(id).DataTable({
          "ordering": true,
          "paging": true,
          "searching": true,
          "oLanguage": {
              "sEmptyTable": "Nenhum registro encontrado na tabela",
              "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
              "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
              "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
              "sInfoPostFix": "",
              "sInfoThousands": ".",
              "sLengthMenu": "Mostrar _MENU_ registros por pagina",
              "sLoadingRecords": "Carregando...",
              "sProcessing": "Processando...",
              "sZeroRecords": "Nenhum registro encontrado",
              "sSearch": "Pesquisar",
              "oPaginate": {
                  "sNext": "Proximo",
                  "sPrevious": "Anterior",
                  "sFirst": "Primeiro",
                  "sLast": "Ultimo"
              },
              "oAria": {
                  "sSortAscending": ": Ordenar colunas de forma ascendente",
                  "sSortDescending": ": Ordenar colunas de forma descendente"
              }
          }
      });
    }
</pre>
<p>Desta forma podemos utilizar inúmeros Id's para uma formatação de tabela, sem repetições</p>



