namespace Sitecore.Support.XA.Foundation.JsonVariants.Renderers
{
  using Sitecore.XA.Foundation.JsonVariants.Renderers;
  using System.Collections.Generic;

  public class JsonHighlightDecoratorRenderer : JsonRenderer
  {
    protected override string CloseBracket => $"<span class=\"token punctuation close bracket\">{base.CloseBracket}</span>";

    protected override string OpenBracket => $"<span class=\"token punctuation open bracket\">{base.OpenBracket}</span>";

    protected override string Comma => $"<span class=\"token punctuation comma\">{base.Comma}</span>";

    protected override string Colon => $"<span class=\"token punctuation colon\">{base.Colon}</span>";

    protected override string NameString => $"<span class=\"token property\">{base.NameString}</span>";

    protected override string OpenSquareBracket => $"<span class=\"token punctuation open bracket square\">{base.OpenSquareBracket}</span>";

    protected override string CloseSquareBracket => $"<span class=\"token punctuation close bracket square\">{base.CloseSquareBracket}</span>";

    public JsonHighlightDecoratorRenderer(string name, string value, JsonValueType objectValue)
        : base(name, value, objectValue)
    {
    }

    public JsonHighlightDecoratorRenderer(string name, IEnumerable<string> values, JsonValueType valueType)
        : base(name, values, valueType)
    {
    }

    public override string ValueString()
    {
      if (base.ValueType.Equals(JsonValueType.String))
      {
        return $"<span class=\"token string\">{base.ValueString()}</span>";
      }
      return base.ValueString();
    }
  }
}