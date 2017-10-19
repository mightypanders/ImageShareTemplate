using ImageShareTemplate.ImageProvider;

namespace ImageShareTemplate
{
    public class ShareOption
    {
        /// <summary>
        /// The proportion horizontal ratio. 
        /// </summary>
        public double RatioX { get; set; }

        /// <summary>
        /// The proportion vertical ratio. 
        /// </summary>
        public double RatioY { get; set; }

        /// <summary>
        /// We have separate area to render item on main image to four quadrant.
        /// 
        ///  +---------+---------+
        ///  |         |         |
        ///  | Block 1 | Block 2 |
        ///  |         |         |
        ///  +---------+---------+
        ///  |         |         |
        ///  | Block 3 | Block 4 |
        ///  |         |         |
        ///  +---------+---------+
        ///
        /// </summary>
        public IBlock Block1 { get; set; }
        public IBlock Block2 { get; set; }
        public IBlock Block3 { get; set; }
        public IBlock Block4 { get; set; }

        /// <summary>
        /// Main image this will be background.
        /// </summary>
        public byte[] ImageSource { get; set; }

        /// <summary>
        /// The font of the string we want to draw. Tahoma is the default.
        /// </summary>
        public string Font{get;set;} = "Tahoma";

        /// <summary>
        /// The size of the font we want to draw. The default is 56pt.
        ///</summary>
        public int FontSize{get;set;} = 56;

        /// <summary>
        /// The style of the font we want to draw. The default is "Regular".
        ///</summary>
        public SixLabors.Fonts.FontStyle FontStyle{get;set;} = SixLabors.Fonts.FontStyle.Regular;

        /// <summary>
        /// Target image result follow provider specification.
        /// </summary>
        public IImageProvider ImageProvider { get; set; }

    }
}
