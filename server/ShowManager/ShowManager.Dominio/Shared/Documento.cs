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
                throw new ArgumentException("CPF inv�lido.", nameof(valorIdentidade));
            Tipo = TipoDocumento.CPF;
        }
        else if (EhCnpj(valorIdentidade))
        {
            if (!ValidarCnpj(valorIdentidade))
                throw new ArgumentException("CNPJ inv�lido.", nameof(valorIdentidade));
            Tipo = TipoDocumento.CNPJ;
        }
        else
        {
            throw new ArgumentException("Documento deve ser CPF ou CNPJ v�lido.", nameof(valorIdentidade));
        }

        ValorIdentidade = valorIdentidade;
    }

    private static bool EhCpf(string valor) => valor.Length == 11 && Regex.IsMatch(valor, @"^\d{11}$");

    private static bool EhCnpj(string valor) => valor.Length == 14 && Regex.IsMatch(valor, @"^\d{14}$");

    // M�todos de valida��o simplificados (substitua por valida��o real se necess�rio)
    private static bool ValidarCpf(string cpf)
    {
        // Adicione aqui a valida��o real de CPF
        return true;
    }

    private static bool ValidarCnpj(string cnpj)
    {
        // Adicione aqui a valida��o real de CNPJ
        return true;
    }

    public override string ToString() => ValorIdentidade;
}

public enum TipoDocumento
{
    CPF,
    CNPJ
}