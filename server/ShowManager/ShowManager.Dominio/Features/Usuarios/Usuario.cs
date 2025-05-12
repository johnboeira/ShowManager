using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public class Usuario : Entidade
{
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;

    public Usuario(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public void DefinirSenha(string senha)
    {
        Senha = senha;
    }
}