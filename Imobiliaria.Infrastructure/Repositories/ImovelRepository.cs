using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Interfaces;
using Imobiliaria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Infrastructure.Repositories;

public class ImovelRepository(AppDbContext dbContext) : IImovelRepository
{
    private readonly AppDbContext _context = dbContext;

    public async Task<Result<Imovel>> CriarImovelAsync(Imovel imovel)
    {
        try
        {
            _context.IMOVEIS.Add(imovel);
            await _context.SaveChangesAsync();
            return Result.Success(imovel);
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result<Imovel?>> BuscarImovelByIdAsync(int id)
    {
        try
        {
            var imovel = await _context.IMOVEIS.FindAsync(id);
            return Result.Success(imovel);
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel?>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result<List<Imovel>>> BuscarTodosAsync()
    {
        try
        {
            var listaImovies = await _context.IMOVEIS.ToListAsync();
            return Result.Success(listaImovies);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Imovel>>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result> AtualizarAsync(int id, Imovel imovel)
    {
        try
        {
            _context.IMOVEIS.Entry(imovel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result> DeletarImovelAsync(int id)
    {
        try
        {
            var imovel = await BuscarImovelByIdAsync(id);
            if (imovel.IsFailure || imovel.Value == null)
            {
                return Result.Failure(Error.NotFound("Imóvel não encontrado."));
            }
            _context.IMOVEIS.Remove(imovel.Value);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
