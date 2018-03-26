namespace Sitecore.Support.XA.Foundation.JsonVariants.Renderers
{
  using Sitecore.StringExtensions;
  using Sitecore.XA.Foundation.JsonVariants.Renderers;
  using System.Collections.Generic;
  using System.Text;

  public class JsonRenderer : IJsonRenderer
  {
    public List<string> Values = new List<string>();

    public string Name
    {
      get;
      set;
    }

    public string Value
    {
      get;
      set;
    }

    public JsonValueType ValueType
    {
      get;
      set;
    }

    protected virtual string OpenBracket => "{";

    protected virtual string CloseBracket => "}";

    protected virtual string Comma => ",";

    protected virtual string Colon => ":";

    protected virtual string NameString => $"\"{this.Name}\"";

    protected virtual string OpenSquareBracket => "[";

    protected virtual string CloseSquareBracket => "]";

    public JsonRenderer(string name, string value, JsonValueType valueType)
    {
      this.Name = name;
      this.Value = value;
      this.ValueType = valueType;
    }

    public JsonRenderer(string name, IEnumerable<string> values, JsonValueType valueType)
    {
      this.Name = name;
      this.Values.AddRange(values);
      this.ValueType = valueType;
    }

    public virtual string ToJsonString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.NameString);
      stringBuilder.Append(this.Colon);
      stringBuilder.Append(this.ValueString());
      return stringBuilder.ToString();
    }

    public virtual string ValueString()
    {
      JsonValueType valueType = this.ValueType;
      if (valueType.Equals(JsonValueType.Empty))
      {
        return this.Value;
      }
      string result = $"\"{this.Value}\"";
      #region Modified code
      string text;
      #endregion
      #region Added code
      if (valueType.Equals(JsonValueType.Array))
      {
        StringBuilder textB = new StringBuilder();
        for (int i = 0; i < Values.Count; i++)
        {
          if (!Values[i].StartsWith((OpenBracket))) //for Multilist field
          {
            textB.Append(OpenBracket);
            textB.Append(Values[i]);
            textB.Append(CloseBracket);

          }
          else
          {
            textB.Append(Values[i]);
          }
          if (i != Values.Count - 1)
            textB.Append(Comma);
        }
        text = textB.ToString();
      }
      else
      {
        text = string.Join(this.Comma, this.Values);
      }
      #endregion
      if (this.Name.IsNullOrEmpty())
      {
        valueType = this.ValueType;
        if (!valueType.Equals(JsonValueType.String))
        {
          return text;
        }
      }
      valueType = this.ValueType;
      if (valueType.Equals(JsonValueType.Object))
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(this.OpenBracket);
        stringBuilder.Append(text);
        stringBuilder.Append(this.CloseBracket);
        result = stringBuilder.ToString();
      }
      valueType = this.ValueType;
      if (valueType.Equals(JsonValueType.Array))
      {
        StringBuilder stringBuilder2 = new StringBuilder();
        stringBuilder2.Append(this.OpenSquareBracket);
        stringBuilder2.Append(text);
        stringBuilder2.Append(this.CloseSquareBracket);
        result = stringBuilder2.ToString();
      }
      valueType = this.ValueType;
      if (valueType.Equals(JsonValueType.Boolean))
      {
        result = $"{this.Value.ToLower()}";
      }
      return result;
    }
  }
}