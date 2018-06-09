using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.WebServices.WebClient.Abstractions
{
    public interface ITimeStampConverter
    {
        DateTime ConvertToDateTime(double timestamp);
    }
}
