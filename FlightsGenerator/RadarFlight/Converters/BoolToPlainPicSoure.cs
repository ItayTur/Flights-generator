using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace RadarFlight.Converters
{
    /// <summary>
    /// Contains the convertion from bool to plain image.
    /// </summary>
    public class BoolToPlainPicSoure : IValueConverter
    {
        /// <summary>
        /// Convert from bool type to plain img source.
        /// </summary>
        /// <param name="value">The bool varible.</param>
        /// <param name="targetType">The img source the value converting to.</param>
        /// <returns>The converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BitmapImage source = new BitmapImage();
            if (value is bool isDeparture)
            {
                if (isDeparture)
                {
                    source.UriSource = new Uri("ms-appx:///Assets/DeparturePlain.png");
                }
                else
                {
                    source.UriSource = new Uri("ms-appx:///Assets/ArivePlain.png");
                }
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
