namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class DecoratorShape
    {
        public object decoratorShape()
        {

            List<object> decoratorShape = new List<object>();

            decoratorShape.Add(new

            {

                text = "None",

                value = "None"

            });

            decoratorShape.Add(new

            {

                text = "Square",

                value = "Square"

            });

            decoratorShape.Add(new

            {

                text = "Circle",

                value = "Circle"

            });

            decoratorShape.Add(new

            {

                text = "Diamond",

                value = "Diamond"

            });

            decoratorShape.Add(new

            {

                text = "Arrow",

                value = "Arrow"

            });         

            decoratorShape.Add(new

            {

                text = "Open Arrow",

                value = "OpenArrow"

            });

            decoratorShape.Add(new

            {

                text = "Fletch",

                value = "Fletch"

            });

            decoratorShape.Add(new

            {

                text = "Open Fetch",

                value = "OpenFetch"

            });

            decoratorShape.Add(new

            {

                text = "Indented Arrow",

                value = "IndentedArrow"

            });

            decoratorShape.Add(new

            {

                text = "Outdented Arrow",

                value = "OutdentedArrow"

            });

            decoratorShape.Add(new

            {

                text = "Double Arrow",

                value = "DoubleArrow"

            });
            return decoratorShape;

        }
    }
}
