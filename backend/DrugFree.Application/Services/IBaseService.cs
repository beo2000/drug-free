namespace DrugFree.Application.Services;

public interface IBaseService<TDto> where TDto : class
{
    Task<TDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> CreateAsync(TDto dto);
    Task UpdateAsync(Guid id, TDto dto);
    Task DeleteAsync(Guid id);
} 