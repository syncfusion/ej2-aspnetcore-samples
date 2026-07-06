namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class DropDownModel
    {
        public object scrollLimits()
        {

            List<object> scrollLimits = new List<object>();

            scrollLimits.Add(new

            {

                text = "Infinity",

                value = "Infinity"

            });

            scrollLimits.Add(new

            {

                text = "Diagram",

                value = "Diagram"

            });

            scrollLimits.Add(new

            {

                text = "Limited",

                value = "Limited"

            });

            return scrollLimits;

        }
    }
}
