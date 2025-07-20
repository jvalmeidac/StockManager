namespace StockManager.Dominio.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string SenhaHash { get; set; }
    
    public Guid FuncaoAcessoId { get; set; }
    public FuncaoAcesso FuncaoAcesso { get; set; }
}