using System;
using VinheriaAgnello.Models;

public class Program
{
    public static void Main()
    {

        var inventoryService = new InventoryService();

        Wine redWine = new Wine(Guid.NewGuid(), "Red Wine", "Tinto", "2019", 750, 45.00);
        Wine whiteWine = new Wine(Guid.NewGuid(), "White Wine", "Branco", "2021", 750, 50.00);

        inventoryService.AddStock(redWine, 100);
        inventoryService.AddStock(whiteWine, 50);

        Console.WriteLine("Bem-vindo ao sistema de estoque da vinheria!");


        while (true)
        {
            Console.WriteLine("Escolha o produto:");
            Console.WriteLine("1 - Red Wine");
            Console.WriteLine("2 - White Wine");
            Console.Write("Opção: ");

            var productOption = Console.ReadLine();

            Wine selectedWine = productOption switch
            {
                "1" => redWine,
                "2" => whiteWine,
                _ => null
            };

            if (selectedWine == null)
            {
                Console.WriteLine("Produto inválido. Tente novamente.");
                continue;
            }

            Console.WriteLine("Escolha o tipo de transação:");
            Console.WriteLine("1 - Entrada (Adicionar ao estoque)");
            Console.WriteLine("2 - Saída (Remover do estoque)");
            Console.Write("Opção: ");
            var transactionType = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantidade inválida. Tente novamente.");
                continue;
            }

            try
            {
                // Realiza a transação conforme o tipo escolhido
                if (transactionType == "1")
                {
                    inventoryService.AddStock(selectedWine, quantity);
                    Console.WriteLine($"{quantity} unidades de {selectedWine.Name} adicionadas ao estoque.");
                }
                else if (transactionType == "2")
                {
                    inventoryService.RemoveStock(selectedWine, quantity);
                    Console.WriteLine($"{quantity} unidades de {selectedWine.Name} removidas do estoque.");
                }
                else
                {
                    Console.WriteLine("Tipo de transação inválido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar a transação: {ex.Message}");
            }

            Console.WriteLine($"Estoque atual de {selectedWine.Name}: {inventoryService.CheckStock(selectedWine)} garrafas");

            Console.WriteLine("Deseja realizar outra operação? (s/n)");
            var continueOption = Console.ReadLine();
            if (continueOption?.ToLower() != "s")
            {
                Console.WriteLine("Encerrando o sistema de estoque. Até logo!");
                break;
            }
        }
    }
}