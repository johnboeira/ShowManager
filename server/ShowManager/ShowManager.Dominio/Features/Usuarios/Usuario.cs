using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public class Usuario : Entidade
{
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}