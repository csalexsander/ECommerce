using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ECommerce_Administrator.TagHelpers
{
    public class EcForm : TagHelper
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public string Inicio { get; set; }

        public string Sucesso { get; set; }

        public string Falha { get; set; }

        public string Completo { get; set; }

        public bool AceitaArquivos { get; set; }

        public string Class { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "form";
            output.Attributes.SetAttribute("class", Class);

            string url = string.Empty;

            if (!string.IsNullOrEmpty(Controller))
            {
                url = $"/{Controller}";
            }

            if (!string.IsNullOrEmpty(Action))
            {
                url += $"/{Action}";
            }

            if (AceitaArquivos)
            {
                output.Attributes.SetAttribute("enctype", "multipart/form-data");
            }

            output.Attributes.SetAttribute("action", url);
            output.Attributes.SetAttribute("data-ajax", "true");
            output.Attributes.SetAttribute("data-ajax-method", "POST");
            output.Attributes.SetAttribute("data-ajax-begin", Inicio);
            output.Attributes.SetAttribute("data-ajax-success", Sucesso);
            output.Attributes.SetAttribute("data-ajax-failure", Falha);
            output.Attributes.SetAttribute("data-ajax-complete", Completo);
        }
    }
}
