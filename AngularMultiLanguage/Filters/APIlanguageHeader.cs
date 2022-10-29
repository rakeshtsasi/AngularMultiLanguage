using AngularMultiLanguage.Constants;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AngularMultiLanguage.Filters
{
    public class APIlanguageHeader : IOperationFilter
    {
        private readonly IServiceProvider _serviceProvider;
        public APIlanguageHeader(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Apply(OpenApiOperation operation,
            OperationFilterContext context)
        {
            if (operation.Parameters is null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(
                new OpenApiParameter
                {
                    Name= AppConstants.LANGHEADER,
                    In=ParameterLocation.Header,
                    Description="Accepted languages",
                    Required=false,
                    Schema=new OpenApiSchema()
                    {
                        Enum = (IList<IOpenApiAny>)
                        (_serviceProvider.GetService(
                            typeof(IOptions<RequestLocalizationOptions>))
                        as IOptions<RequestLocalizationOptions>)
                        !.Value!.SupportedUICultures!.Select(
                            x=>new OpenApiString(x.Name))!.ToList<IOpenApiAny>()
                        
                    }
                });
        }
    }
}
