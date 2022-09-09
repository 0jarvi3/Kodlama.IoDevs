using Application.Futures.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;

namespace Application.Futures.ProgrammingLanguages.Models;

public class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}