using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class PresetColors
    {
        public string Type { get; set; }
        public string[] Value { get; set; }

        public List<PresetColors> CirclePalettes()
        {
            List<PresetColors> circle = new List<PresetColors>();
            circle.Add(new PresetColors { Type = "Custom", Value = new string[] {"#f44336", "#e91e63", "#9c27b0", "#673ab7", "#2196f3", "#03a9f4", "#00bcd4",
                "#009688", "#8bc34a", "#cddc39", "#ffeb3b", "#ffc107"} });
            return circle;
        }

        public List<PresetColors> SquarePalettes()
        {
            List<PresetColors> square = new List<PresetColors>();
            square.Add(new PresetColors { Type = "Custom", Value = new string[] {"#b80000", "#db3e00", "#fccb00", "#008b02",
                "#006b76", "#1273de", "#004dcf", "#5300eb", "#eb9694", "#fad0c3", "#fef3bd", "#c1e1c5",
                "#bedadc", "#c4def6", "#bed3f3", "#d4c4fb"} });
            return square;
        }

        public List<PresetColors> RoundedPalettes()
        {
             List <PresetColors> round = new List<PresetColors>();
            round.Add(new PresetColors { Type = "Custom", Value = new string[] {"#ff6900", "#fcb900", "#7bdcb5", "#00d084",
                "#8ed1fc", "#0693e3", "#abb8c3", "#eb144c", "#f78da7", "#9900ef"} });
            return round;
        }

        public List<PresetColors> ScrollPalettes()
        {
             List <PresetColors> scroll = new List<PresetColors>();
            scroll.Add(new PresetColors { Type = "Custom1", Value = new string[] {"#ef9a9a", "#e57373", "#ef5350",
                "#f44336", "#f48fb1", "#f06292", "#ec407a", "#e91e63", "#ce93d8",
                "#ba68c8", "#ab47bc", "#9c27b0", "#b39ddb", "#9575cd", "#7e57c2", "#673AB7"} });
            scroll.Add(new PresetColors { Type = "Custom2", Value = new string[] {"#9FA8DA", "#7986CB", "#5C6BC0", "#3F51B5",
                "#90CAF9", "#64B5F6", "#42A5F5", "#2196F3", "#81D4FA", "#4FC3F7", "#29B6F6", "#03A9F4",
                "#80DEEA", "#4DD0E1", "#26C6DA", "#00BCD4"} });
            scroll.Add(new PresetColors { Type = "Custom3", Value = new string[] {"#80CBC4", "#4DB6AC", "#26A69A", "#009688",
                "#A5D6A7", "#81C784", "#66BB6A", "#4CAF50", "#C5E1A5", "#AED581", "#9CCC65", "#8BC34A", "#E6EE9C",
                "#DCE775", "#D4E157", "#CDDC39"} });
            scroll.Add(new PresetColors { Type = "Custom4", Value = new string[] {"#FFF59D", "#FFF176", "#FFEE58", "#FFEB3B",
                "#FFE082", "#FFD54F", "#FFCA28", "#FFC107", "#FFCC80", "#FFB74D", "#FFA726", "#FF9800", "#FFAB91",
                "#FF8A65", "#FF7043", "#FF5722"} });
            return scroll;
        }
    }
}
