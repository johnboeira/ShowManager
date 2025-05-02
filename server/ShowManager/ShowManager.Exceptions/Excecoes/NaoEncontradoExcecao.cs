using ShowManager.Exceptions.Shared;

namespace ShowManager.Exceptions.Excecoes;

public class NaoEncontradoExcecao : ExcecaoDeNegocio
{
    public NaoEncontradoExcecao(string mensagem) : base(mensagem)
    {
    }
}