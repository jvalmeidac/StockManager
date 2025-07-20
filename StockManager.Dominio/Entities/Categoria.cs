﻿namespace StockManager.Dominio.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Produto> Produtos { get; set; } = [];
}