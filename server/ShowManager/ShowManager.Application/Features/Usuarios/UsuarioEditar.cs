using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Criptografia;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioEditar
{
    public class Command : IRequest
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("Nome é obrigatório.")
                    .MaximumLength(100).WithMessage("Nome pode ter no máximo 100 caracteres.");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email é obrigatório.")
                    .EmailAddress().WithMessage("Email inválido.");

                RuleFor(x => x.Senha)
                    .NotEmpty().WithMessage("Senha é obrigatória.")
                    .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
            }
        }
    }

    public class Handler(IUsuarioRepository _usuarioRepository, IMapper _mapper, SenhaEncriptador _senhaEncriptador) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(command);

            var senhaCriptografada = _senhaEncriptador.Encriptar(usuario.Senha);

            usuario.DefinirSenha(senhaCriptografada);

            await _usuarioRepository.AtualizarAsync(usuario);

            return await Unit.Task;
        }
    }
}