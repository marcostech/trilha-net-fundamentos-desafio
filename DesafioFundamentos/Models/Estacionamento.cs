namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        // Implementado!!!!!
        Console.WriteLine("Digite a placa do veículo para estacionar:\nex:ABC-9999");
        string placa = Console.ReadLine();
        placa = placa.Replace("-", "");
        placa = placa.ToUpper();
        bool placaValida = ValidadorDePlacas.ValidarPlaca(placa);        
        if(placaValida && !veiculos.Contains(placa)){
            veiculos.Add(placa);
            Console.WriteLine($"\nVeículo estacionado: {placa}");           
        } 
        else
        {
            if(!placaValida) 
            {
                Console.WriteLine($"\nErro ao cadastrar, placa '{placa}' inválida");
            }
            if(veiculos.Contains(placa)) {
                Console.WriteLine($"\nErro ao cadastrar, veiculo '{placa}' duplicado");
            }            
        }        
    }

    public void RemoverVeiculo()
    {
        ListarVeiculos();
        if (veiculos.Any())
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
                
            string placa = Console.ReadLine();        
            placa = placa.Replace("-", "");
            placa = placa.ToUpper();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*    
                uint horas = 0;
                bool inputVerifier = false;
                while(!inputVerifier){
                    //Se o parse for bem suscedido retorna true e sai do laço
                    inputVerifier = uint.TryParse(Console.ReadLine(), out horas);                
                    if(!inputVerifier) {
                        Console.WriteLine("\nNúmero inválido, não use caracteres especiais");
                    }
                }

                decimal valorTotal = GetPrecoInicial() + GetPrecoPorHora() * horas ;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);
                Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }    
        }    
    }

    public void ListarVeiculos()
    {
        // Verifica se há veículos no estacionamento
        if (veiculos.Any())
        {
            Console.Clear(); 
            Console.WriteLine("Os veículos estacionados são:");
            // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
            // *IMPLEMENTE AQUI*                       
            foreach(var item in veiculos) {
                Console.WriteLine($"Placa: {item}");
            }               
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }

    public int ContaVeiculos(){
        return veiculos.Count;
    }
    
    public decimal GetPrecoInicial(){
        return precoInicial;
    }

    public decimal GetPrecoPorHora(){
        return precoPorHora;
    }

    public void SetPrecoInicial(decimal novoPreco){
        precoInicial = novoPreco;
    }

    public void SetPrecoPorHora(decimal novoPreco){
        precoPorHora = novoPreco;
    }
}
