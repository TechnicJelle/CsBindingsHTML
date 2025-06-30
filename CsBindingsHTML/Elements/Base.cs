namespace CsBindingsHTML.Elements;

public interface IElement
{
	string Build();
}
public static class ElementExtensions
{
	public static string BuildElements(this IReadOnlyList<IElement> elements, string separator = "\n") =>
		string.Join(separator, elements.Select(element => element.Build()));
}
// public interface IAttributeElement
// {
// 	Dictionary<string, string> Attributes { get; set; }
// }
public interface IClassElement
{
	HashSet<string> Classes { get; set; }
}
public static class ClassElementExtensions
{
	public static HashSet<string> GenerateClasses(this IReadOnlyList<string>? classes) =>
		classes != null
			? [..classes]
			: [];

	public static string BuildClasses(this HashSet<string> classes) =>
		classes.Count == 0
			? string.Empty
			: $" class=\"{string.Join(" ", classes)}\"";
}
public interface IFlowElement : IElement;
public interface IInteractiveElement : IFlowElement;
public interface IHeadingElement : IFlowElement;
public interface IEmbeddedElement : IFlowElement;
public abstract class PhrasingElement : IFlowElement
{
	public abstract string Build();

	public static implicit operator PhrasingElement(string s) => new PlainText(s);
}
public interface ISectioningElement : IFlowElement;
public interface IMetadataElement : IElement;
public class PlainText(string str) : PhrasingElement, IFlowElement
{
	public override string Build()
	{
		return str;
	}

	public static implicit operator PlainText(string s) => new(s);
}
public class HTML(string lang, Head head, Body body) : IElement
{
	public string Build()
	{
		return $"""
		        <!DOCTYPE html>
		        <html lang="{lang}">
		        {head.Build()}
		        {body.Build()}
		        </html>
		        """;
	}
}
