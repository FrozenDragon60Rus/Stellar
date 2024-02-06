using NuGet.Protocol;
using TestWebApplication.Domain.Repositories.Abstract;

namespace TestWebApplication.Domain
{
	public class DataManager
	{
		IServiceItemRepository ServiceItems {  get; set; }
		ITextFieldRepository TextFields { get; set; }

		public DataManager(IServiceItemRepository repository, ITextFieldRepository textFieldRepository)
		{
			ServiceItems = repository;
			TextFields = textFieldRepository;
		}
	}
}
