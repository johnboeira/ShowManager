using System.Text.RegularExpressions;

namespace ShowManager.Dominio.Shared;

public sealed class Documento : Entidade
{
    public string ValorIdentidade { get; }
    public TipoDocumento Tipo { get; }
    public string NomeCompleto { get; }

    public Documento()
    {
    }

    public Documento(string valorIdentidade, string nomeCompleto)
    {
        valorIdentidade = valorIdentidade?.Trim().Replace(".", "").Replace("-", "").Replace("/", "") ?? throw new ArgumentNullException(nameof(valorIdentidade));
        NomeCompleto = nomeCompleto ?? throw new ArgumentNullException(nameof(nomeCompleto));

        if (EhCpf(valorIdentidade))
        {
            if (!ValidarCpf(valorIdentidade))
                throw new ArgumentException("CPF inválido.", nameof(valorIdentidade));
            Tipo = TipoDocumento.CPF;
        }
        else if (EhCnpj(valorIdentidade))
        {
            if (!ValidarCnpj(valorIdentidade))
                throw new ArgumentException("CNPJ inválido.", nameof(valorIdentidade));
            Tipo = TipoDocumento.CNPJ;
        }
        else
        {
            throw new ArgumentException("Documento deve ser CPF ou CNPJ válido.", nameof(valorIdentidade));
        }

        ValorIdentidade = valorIdentidade;
    }

    private static bool EhCpf(string valor) => valor.Length == 11 && Regex.IsMatch(valor, @"^\d{11}$");

    private static bool EhCnpj(string valor) => valor.Length == 14 && Regex.IsMatch(valor, @"^\d{14}$");

    // Métodos de validação simplificados (substitua por validação real se necessário)
    private static bool ValidarCpf(string cpf)
    {
        // Adicione aqui a validação real de CPF
        return true;
    }

    private static bool ValidarCnpj(string cnpj)
    {
        // Adicione aqui a validação real de CNPJ
        return true;
    }

    public override string ToString() => ValorIdentidade;
}

public enum TipoDocumento
{
    CPF,
    CNPJ
}