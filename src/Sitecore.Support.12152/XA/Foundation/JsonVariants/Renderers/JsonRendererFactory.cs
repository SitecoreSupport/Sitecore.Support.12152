namespace Sitecore.Support.XA.Foundation.JsonVariants.Renderers
{
  using Sitecore;
  using Sitecore.XA.Foundation.JsonVariants.Renderers;
  using System.Collections.Generic;

  public class JsonRendererFactory : IJsonRendererFactory
  {
    public IJsonRenderer Create(string name, string value, JsonValueType valueType)
    {
      if (Context.PageMode.IsExperienceEditorEditing)
      {
        return new Sitecore.Support.XA.Foundation.JsonVariants.Renderers.JsonHighlightDecoratorRenderer(name, value, valueType);
      }
      return new Sitecore.Support.XA.Foundation.JsonVariants.Renderers.JsonRenderer(name, value, valueType);
    }

    public IJsonRenderer Create(string name, IEnumerable<string> values, JsonValueType valueType)
    {
      if (Context.PageMode.IsExperienceEditorEditing)
      {
        return new Sitecore.Support.XA.Foundation.JsonVariants.Renderers.JsonHighlightDecoratorRenderer(name, values, valueType);
      }
      return new Sitecore.Support.XA.Foundation.JsonVariants.Renderers.JsonRenderer(name, values, valueType);
    }
  }
}