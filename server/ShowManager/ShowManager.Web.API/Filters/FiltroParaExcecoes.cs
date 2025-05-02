using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ShowManager.Exceptions.Shared;
using ShowManager.Exceptions.Excecoes;

namespace ShowManager.Web.API.Filters;

public class FiltroParaExcecoes : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExcecaoDeNegocio)
            ResolveExcecaoDeNegocio(context);
        else
            LancaExcecaoNaoTratada(context);
    }

    private void ResolveExcecaoDeNegocio(ExceptionContext context)
    {
        if (context.Exception.GetType() == typeof(NaoEncontradoExcecao))
        {
            var exception = context.Exception as NaoEncontradoExcecao;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(exception!.Message);
        }
    }

    private void LancaExcecaoNaoTratada(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(context.Exception.Message);
    }
}