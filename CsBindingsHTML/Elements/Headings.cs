namespace CsBindingsHTML.Elements;

public abstract class H : IFlowElement, IHeadingElement, IClassElement
{
	public HashSet<string> Classes { get; set; }

	private readonly int _level;
	private readonly IReadOnlyList<PhrasingElement> _children;

	protected H(int level, PhrasingElement child, IReadOnlyList<string>? classes = null)
	{
		_level = level;
		_children = [child];
		Classes = classes.GenerateClasses();
	}

	protected H(int level, IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null)
	{
		_level = level;
		_children = [..children];
		Classes = classes.GenerateClasses();
	}

	public string Build()
	{
		string classes = Classes.BuildClasses();
		string content = _children.BuildElements();
		return $"<h{_level}{classes}>{content}</h{_level}>";
	}
}
public class H1 : H
{
	public H1(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(1, child, classes) {}
	public H1(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(1, children, classes) {}
}
public class H2 : H
{
	public H2(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(2, child, classes) {}
	public H2(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(2, children, classes) {}
}
public class H3 : H
{
	public H3(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(3, child, classes) {}
	public H3(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(3, children, classes) {}
}
public class H4 : H
{
	public H4(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(4, child, classes) {}
	public H4(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(4, children, classes) {}
}
public class H5 : H
{
	public H5(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(5, child, classes) {}
	public H5(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(5, children, classes) {}
}
public class H6 : H
{
	public H6(PhrasingElement child, IReadOnlyList<string>? classes = null) : base(6, child, classes) {}
	public H6(IReadOnlyList<PhrasingElement> children, IReadOnlyList<string>? classes = null) : base(6, children, classes) {}
}
