using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
bool inputVerifier = false;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

//Verificador do Input "preço inicial"
Console.WriteLine("Digite o preço inicial:");                  
while(!inputVerifier){
    //Se o parse for bem suscedido retorna true e sai do laço
    inputVerifier = decimal.TryParse(Console.ReadLine(), out precoInicial);
    if(!inputVerifier) {
        Console.WriteLine("Número inválido, não use caracteres especiais");
    }
}

//Limpar flag para reutilizar variavel
inputVerifier = false;

//Verificador do Input "preço por hora"
Console.WriteLine("Agora digite o preço por hora:");
while(!inputVerifier){
    inputVerifier = decimal.TryParse(Console.ReadLine(), out precoPorHora);
    if(!inputVerifier) {
        Console.WriteLine("Número inválido, não use caracteres especiais");
    }
}
inputVerifier = false;

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;
bool confirmarSaida = false;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Alterar preços");
    Console.WriteLine("5 - Encerrar");
    Console.WriteLine($"\nPreço inicial: {es.GetPrecoInicial():C}");
    Console.WriteLine($"Preço por hora: {es.GetPrecoPorHora():C}");
    Console.WriteLine($"Total de veiculos estacionados: {es.ContaVeiculos()}");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            //Verificador do Input "preço inicial"
            Console.WriteLine("Digite o preço inicial:");                  
            while(!inputVerifier){
                //Se o parse for bem suscedido retorna true e sai do laço
                inputVerifier = decimal.TryParse(Console.ReadLine(), out precoInicial);                
                if(!inputVerifier) {
                    Console.WriteLine("Número inválido, não use caracteres especiais");
                }
            }
            es.SetPrecoInicial(precoInicial);

            //Limpar flag para reutilizar variavel
            inputVerifier = false;

            //Verificador do Input "preço por hora"
            Console.WriteLine("Agora digite o preço por hora:");
            while(!inputVerifier){
                inputVerifier = decimal.TryParse(Console.ReadLine(), out precoPorHora);
                if(!inputVerifier) {
                    Console.WriteLine("Número inválido, não use caracteres especiais");
                }
            }
            es.SetPrecoPorHora(precoPorHora);
            inputVerifier = false;
            break;

        case "5":   
            confirmarSaida = true;         
            while(confirmarSaida) {                
                Console.WriteLine("Deseja mesmo sair? s/n");
                switch (Console.ReadLine()) { 
                    case "s":
                        exibirMenu = false;
                        confirmarSaida = false;
                    break;

                    case "n":
                        confirmarSaida = false;
                    break;

                    default:
                    Console.WriteLine("Opção inválida, tente 's' para sair ou 'n' para voltar");
                    break;
                }
            }
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

Console.WriteLine("O programa se encerrou");
