using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Common;
using Imobiliaria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Infrastructure.Repositories;

public class ImovelRepository(AppDbContext dbContext)
{
    private readonly AppDbContext _context = dbContext;

    public async Task<Result<Imovel>> CreateImovelAsync(Imovel imovel)
    {
        try
        {
            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();
            return Result.Success(imovel);
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result<Imovel?>> GetImovelByIdAsync(int id)
    {
        try
        {
            var imovel = await _context.Imoveis.FirstOrDefaultAsync(x => x.Id == id); //Pesquisar porque não usar FindAsync
            return Result.Success(imovel);
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel?>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result<List<Imovel>>> GetAllAsync()
    {
        try
        {             
            var listaImovies = await _context.Imoveis.ToListAsync();
            return Result.Success(listaImovies);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Imovel>>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result> UpdateAsync(Imovel imovel)
    {
        try
        {
            _context.Imoveis.Update(imovel);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure<Imovel>(Error.InternalServerError(ex.Message));
        }
    }
    public async Task<Result> DeleteImovelAsync(int id)
    {
        try
        {
            var imovel = await GetImovelByIdAsync(id);
            if (imovel.IsFailure || imovel.Value == null)
            {
                return Result.Failure(Error.NotFound("Imóvel não encontrado."));
            }
            _context.Imoveis.Remove(imovel.Value);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
