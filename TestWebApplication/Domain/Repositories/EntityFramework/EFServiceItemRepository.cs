using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain.Entities;
using TestWebApplication.Domain.Repositories.Abstract;

namespace TestWebApplication.Domain.Repositories.EntityFramework
{
	public class EFServiceItemRepository : IServiceItemRepository
	{
		private readonly AppDbContext context;
		public EFServiceItemRepository(AppDbContext context) =>
			this.context = context;

		public IQueryable<ServiceItem> Get() =>
			context.ServiceItems;

		public ServiceItem GetById(Guid id) =>
			context.ServiceItems.FirstOrDefault(x => x.Id == id);


		public void Save(ServiceItem entity)
		{
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void Delete(Guid id)
		{
			context.ServiceItems.Remove(new ServiceItem() { Id = id });
			context.SaveChanges();
		}
	}
}
