using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TestWebApplication.Areas.Admin
{
    public class AdminAreaAutorization(string area, 
                                       string policy) 
        : IControllerModelConvention
    {
        private readonly string area = area;
        private readonly string policy = policy;

#pragma warning disable CS8602
        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(a =>
                    a is AreaAttribute &&
                    (a as AreaAttribute).RouteValue
                                        .Equals(area,
                                                StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(r =>
                    r.Key.Equals("area",
                                 StringComparison.OrdinalIgnoreCase) &&
                    r.Value.Equals(area,
                                   StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
