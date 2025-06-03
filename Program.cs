using ClubeDeLeitura.Emprestimo;
using ClubeDeLeitura.ModeloAmigo;
using ClubeDeLeitura.ModuloRevista;
using ClubeDeLeitura.ModuloCaixa;

TelaAmigo menuAmigos = new();
TelaCaixa menuCaixa = new();
TelaRevista menuRevista = new();
TelaEmprestimo menuEmprestimo = new();

while (true)
{
    Console.WriteLine("\n1. Amigos\n2. Caixas \nRevistas \n0. Sair");
    switch (Console.ReadLine())
    {
        case "1": 
            menuAmigos.ExibirMenu();
            break;
        case "2": 
            menuCaixa.ExibirMenu();
            break;
        case "3":
            menuRevista.ExibirMenu();
            break;
        case "4":
            menuEmprestimo.ExibirMenu();
            break;
        case "0": 
            return;
        default: 
            Console.WriteLine("Opção inválida."); 
            break;
    }
}
