namespace CsBindingsHTML.Elements;

public class Body(IReadOnlyList<IFlowElement> children) : IElement
{
	private readonly IReadOnlyList<IFlowElement> _children = [..children];

	public string Build()
	{
		string content = _children.BuildElements();
		return $"""
		        <body>

		        {content}

		        </body>
		        """;
	}
}
public class P : IFlowElement, IClassElement
{
	public HashSet<string> Classes { get; set; }

	private readonly IReadOnlyList<PhrasingElement> _children;

	public P(PhrasingElement child, IReadOnlyList<string>? classes = null)
	{
		_children = [child];
		Classes = classes.GenerateClasses();
	}

	public P(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null)
	{
		_children = [..children];
		Classes = classes.GenerateClasses();
	}

	public string Build()
	{
		string classes = Classes.BuildClasses();
		string content = _children.BuildElements("\n");
		return $"<p{classes}>{content}</p>";
	}
}
public class Span : PhrasingElement, IFlowElement, IClassElement
{
	public HashSet<string> Classes { get; set; }

	private readonly IReadOnlyList<PhrasingElement> _children;

	public Span(PhrasingElement child, IReadOnlyList<string>? classes = null)
	{
		_children = [child];
		Classes = classes.GenerateClasses();
	}

	public Span(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null)
	{
		_children = [..children];
		Classes = classes.GenerateClasses();
	}

	public override string Build()
	{
		string classes = Classes.BuildClasses();
		string content = _children.BuildElements("");
		return $"<span{classes}>{content}</span>";
	}
}
public class Div : IFlowElement, IClassElement
{
	public HashSet<string> Classes { get; set; }

	private readonly IReadOnlyList<IFlowElement> _children;

	public Div(IFlowElement child, IReadOnlyList<string>? classes = null)
	{
		_children = [child];
		Classes = classes.GenerateClasses();
	}

	public Div(IReadOnlyList<IFlowElement> children, IReadOnlyList<string>? classes = null)
	{
		_children = [..children];
		Classes = classes.GenerateClasses();
	}

	public string Build()
	{
		string classes = Classes.BuildClasses();
		string content = _children.BuildElements();
		return $"<div{classes}>\n{content}\n</div>";
	}
}
