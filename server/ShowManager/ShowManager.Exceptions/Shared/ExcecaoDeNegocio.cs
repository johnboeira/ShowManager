namespace ShowManager.Exceptions.Shared;

public class ExcecaoDeNegocio : Exception
{
    public ExcecaoDeNegocio(string mensagem) : base(mensagem)
    {
    }
}