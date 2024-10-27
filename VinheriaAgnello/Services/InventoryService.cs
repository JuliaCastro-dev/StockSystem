using System.Collections.Generic;
using static VinheriaAgnello.Models.InventoryMovement;
using VinheriaAgnello.Interfaces;
using VinheriaAgnello.Models;

public class InventoryService
{
    private readonly List<Stock> _stocks = new();
    private readonly List<InventoryMovement> _movements = new();

    public void AddStock(Wine product, int quantity)
    {
        var stock = _stocks.Find(s => s.Product.Id == product.Id);
        if (stock == null)
        {
            stock = new Stock(Guid.NewGuid(), product, quantity);
            _stocks.Add(stock);
        }
        else
        {
            stock.AddQuantity(quantity);
        }

        var movement = new InventoryMovement(Guid.NewGuid(), product, quantity, DateTime.UtcNow, MovementType.Entrada);
        _movements.Add(movement);
    }

    public void RemoveStock(Wine product, int quantity)
    {
        var stock = _stocks.Find(s => s.Product.Id == product.Id);
        if (stock == null || stock.Quantity < quantity)
            throw new InvalidOperationException("Estoque insuficiente para o produto.");

        stock.RemoveQuantity(quantity);
        var movement = new InventoryMovement(Guid.NewGuid(), product, -quantity, DateTime.UtcNow, MovementType.Saida);
        _movements.Add(movement);
    }

    public int CheckStock(Wine product)
    {
        var stock = _stocks.Find(s => s.Product.Id == product.Id);
        return stock?.Quantity ?? 0;
    }
}
