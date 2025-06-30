using CsBindingsHTML.Elements;

namespace CsBindingsHTML;

static internal class Program
{
	private static void Main(string[] args)
	{
		HTML page = GeneratePage();
		string pageContent = page.Build();
		Console.WriteLine(pageContent);
		File.WriteAllText("index.html", pageContent);
	}

	private static HTML GeneratePage()
	{
		return new HTML(
			lang: "en",
			head: new Head(
				title: "My Page",
				// charset: "UTF-8",
				children:
				[
					Meta.Name("viewport", "width=device-width, initial-scale=1.0"),
					Meta.HTTPEquiv("X-Clacks-Overhead", "GNU Terry Pratchett"),
					new Style("""
					          p {
					          	color: red;
					          }

					          .card {
					          	border: 1px solid black;
					          	padding: 10px;
					          	margin: 10px;
					          }

					          .card__title {
					          	font-size: 1.5em;
					          	margin-bottom: 10px;
					          }

					          .card__title span {
					          	font-size: 1em;
					          	color: gray;
					          }

					          .main-heading {
					          	color: blue;
					          }
					          """),
					new Script("""
					           console.log("Hello, world!");
					           """),
				]
			),
			body: new Body(
				children:
				[
					new H1("Welcome to My Page", classes: ["main-heading"]),
					new P("hello world"),
					new H2("This is a subheading"),
					new P(new PlainText("hello world")),
					new H2("This is a subheading 2"),
					new P(["one", "two", "three"]),
					GenerateCard(),
				]
			)
		);
	}

	private static IFlowElement GenerateCard()
	{
		return new Div(
			classes: ["card"],
			children:
			[
				new H2(["Card Title", new Span("Subtitle")], classes: ["card__title"]),
				new P("This is a card description."),
			]
		);
	}
}
