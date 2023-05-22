using InterfacePOO;


List<IConta> contas = new List<IConta>();
bool sair = false;
while (!sair)
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1 - Criar conta corrente");
    Console.WriteLine("2 - Criar conta salário");
    Console.WriteLine("3 - Sacar");
    Console.WriteLine("4 - Depositar");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("=============");
    Console.Write("Escolha uma opção: ");

    int opcao;
    if (int.TryParse(Console.ReadLine(), out opcao))
    {
        switch (opcao)
        {
            case 1:
                CriarConta("corrente");
                break;
            case 2:
                CriarConta("salário");
                break;
            case 3:
                Sacar();
                break;
            case 4:
                Depositar();
                break;
            case 5:
                sair = true;
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }

    Console.WriteLine();
}

void CriarConta(string tipoConta)
{
    Console.Write("Digite o número da conta: ");
    int numeroConta = int.Parse(Console.ReadLine());

    // Verifica se a conta já existe
    if (contas.Exists(c => c.Numero == numeroConta))
    {
        Console.WriteLine("A conta já existe. Tente novamente.");
        return;
    }
    if(tipoConta == "corrente")
    {
        Corrente contaCorrente = new Corrente();
        contaCorrente.Numero = numeroConta;
        contaCorrente.Saldo = 0;
        Console.WriteLine("Digite o cpf do dono da conta");
        contaCorrente.Cliente.Cpf = Console.ReadLine();
        Console.WriteLine("Digite o nome do dono da conta");
        contaCorrente.Cliente.Nome = Console.ReadLine();
        contas.Add(contaCorrente);
    } else
    {
        Salario contaSalario = new Salario();
        contaSalario.Numero = numeroConta;
        contaSalario.Saldo = 0;
        Console.WriteLine("Digite o cpf do dono da conta");
        contaSalario.Cliente.Cpf = Console.ReadLine();
        Console.WriteLine("Digite o nome do dono da conta");
        contaSalario.Cliente.Nome = Console.ReadLine();
        contas.Add(contaSalario);
    }

    Console.WriteLine($"Conta {tipoConta} criada com sucesso.");
}

void Sacar()
{
    Console.WriteLine("=== Contas ===");
    ListarContas();

    Console.Write("Digite o número da conta: ");
    int numeroConta = int.Parse(Console.ReadLine());

    IConta conta = contas.Find(c => c.Numero == numeroConta);

    if (conta == null)
    {
        Console.WriteLine("Conta não encontrada. Tente novamente.");
        return;
    }

    Console.Write("Digite o valor a sacar: ");
    double valor = double.Parse(Console.ReadLine());

    conta.Sacar(valor);
}

void Depositar()
{
    Console.WriteLine("=== Contas ===");
    ListarContas();

    Console.Write("Digite o número da conta: ");
    int numeroConta = int.Parse(Console.ReadLine());

    IConta conta = contas.Find(c => c.Numero == numeroConta);

    if (conta == null)
    {
        Console.WriteLine("Conta não encontrada. Tente novamente.");
        return;
    }

    Console.Write("Digite o valor a depositar: ");
    double valor = double.Parse(Console.ReadLine());

    conta.Depositar(valor);
    Console.WriteLine("Depósito realizado com sucesso.");
}

void ListarContas()
{
    foreach (var conta in contas)
    {
        Console.WriteLine($"Conta: {conta.Numero} - Saldo: {conta.Saldo}");
    }
}
