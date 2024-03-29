using NuGet.Protocol;
using TestWebApplication.Domain.Repositories.Abstract;

namespace TestWebApplication.Domain
{
	public class DataManager(IServiceItemRepository repository, 
							 ITextFieldRepository textFieldRepository)
	{
		public IServiceItemRepository ServiceItems {  get; set; } = repository;
		public ITextFieldRepository TextFields { get; set; } = textFieldRepository;
	}
}
