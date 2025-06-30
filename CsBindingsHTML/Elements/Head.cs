using JetBrains.Annotations;

namespace CsBindingsHTML.Elements;

public class Head(string title, string charset = "UTF-8", params IReadOnlyList<IMetadataElement> children) : IElement
{
	private readonly IReadOnlyList<IMetadataElement> _children = [..children];

	public string Build()
	{
		string content = _children.Count == 0
			? ""
			: $"\n\t{_children.BuildElements()}\n";
		return $"<head>\n\t<title>{title}</title>\n\t<meta charset=\"{charset}\">{content}</head>";
	}
}
public class Meta(string key, string value, string content) : IMetadataElement
{
	public static Meta Name(string name, string content)
	{
		return new Meta("name", name, content);
	}

	public static Meta HTTPEquiv(string httpEquiv, string content)
	{
		return new Meta("http-equiv", httpEquiv, content);
	}

	public string Build()
	{
		return $"<meta {key}=\"{value}\" content=\"{content}\">";
	}
}
public class Style : IMetadataElement
{
	private readonly string _content;
	public Style([LanguageInjection(InjectedLanguage.CSS)] string content)
	{
		_content = content;
	}
	public string Build()
	{
		return $"<style>\n{_content}\n\t</style>";
	}
}
public class Script : PhrasingElement, IMetadataElement, IFlowElement
{
	private readonly string _content;
	public Script([LanguageInjection(InjectedLanguage.JAVASCRIPT)] string content)
	{
		_content = content;
	}
	public override string Build()
	{
		return $"<script>\n{_content}\n\t</script>";
	}
}
