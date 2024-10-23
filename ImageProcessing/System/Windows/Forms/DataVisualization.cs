using System.Drawing;

namespace System.Windows.Forms
{
    internal class DataVisualization
    {
        internal class Charting
        {
            internal class Chart
            {
                public object ChartAreas { get; internal set; }
                public Point Location { get; internal set; }
                public Size Size { get; internal set; }
                public string Name { get; internal set; }
                public object Series { get; internal set; }
                public int TabIndex { get; internal set; }
                public string Text { get; internal set; }
            }

            internal class ChartArea
            {
                public ChartArea(string v)
                {
                }
            }
        }
    }
}