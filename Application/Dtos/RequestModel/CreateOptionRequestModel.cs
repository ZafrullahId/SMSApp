using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace Application.Dtos.RequestModel
{
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class CreateOptionRequestModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class UpdateOptionRequestModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class MetadataValueModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var values = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (values.Length == 0)
                return Task.CompletedTask;
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            var deserialized = JsonSerializer.Deserialize(values.FirstValue, bindingContext.ModelType, options);

            bindingContext.Result = ModelBindingResult.Success(deserialized);
            return Task.CompletedTask;
        }
    }
}