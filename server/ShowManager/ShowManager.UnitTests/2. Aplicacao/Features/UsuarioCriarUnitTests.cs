using AutoMapper;
using MediatR;
using Moq;
using ShowManager.Application.Features.Usuarios;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Criptografia;

namespace ShowManager.UnitTests._2._Aplicacao.Features;

public class UsuarioCriarUnitTests
{
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly Mock<SenhaEncriptador> _senhaEncriptadorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UsuarioCriar.Handler _handler;

    public UsuarioCriarUnitTests()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _senhaEncriptadorMock = new Mock<SenhaEncriptador>("minhaChaveSecreta");
        _mapperMock = new Mock<IMapper>();
        _handler = new UsuarioCriar.Handler(_usuarioRepositoryMock.Object, _mapperMock.Object, _senhaEncriptadorMock.Object);
    }

    [Fact]
    public async Task CriarUsuario_Com_DadosCorretos_Deve_CriarUsuario()
    {
        // Arrange
        var command = new UsuarioCriar.Command
        {
            Nome = "Test User",
            Email = "test@example.com",
            Senha = "password123"
        };

        var usuario = new Usuario(command.Nome, command.Email, command.Senha);

        _mapperMock
            .Setup(m => m.Map<Usuario>(command))
            .Returns(usuario);

        _usuarioRepositoryMock
            .Setup(r => r.Adicionar(usuario, true))
            .Returns(Task.CompletedTask);

        _senhaEncriptadorMock
           .Setup(r => r.Encriptar(It.IsAny<string>()))
           .Returns("senhacriptografada");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);

        _mapperMock.Verify(m => m.Map<Usuario>(command), Times.Once);
        _senhaEncriptadorMock.Verify(m => m.Encriptar(It.IsAny<string>()), Times.Once);
        _usuarioRepositoryMock.Verify(r => r.Adicionar(usuario, true), Times.Once);
    }

    [Fact]
    public async Task CriarUsuario_Com_ErroAoSalvarNoBanco_Deve_RetornarExcecao()
    {
        // Arrange
        var command = new UsuarioCriar.Command
        {
            Nome = "Test",
            Email = "test@example.com",
            Senha = "secret"
        };

        var usuario = new Usuario(command.Nome, command.Email, command.Senha);

        _mapperMock.Setup(m => m.Map<Usuario>(command)).Returns(usuario);
        _senhaEncriptadorMock
            .Setup(r => r.Encriptar(It.IsAny<string>()))
            .Returns("senhacriptografada");
        _usuarioRepositoryMock
            .Setup(r => r.Adicionar(usuario, true))
            .ThrowsAsync(new Exception("Database error"));

        //Assert
        var result = _handler.Handle(command, CancellationToken.None);

        await Assert.ThrowsAsync<Exception>(() => result);
    }
}