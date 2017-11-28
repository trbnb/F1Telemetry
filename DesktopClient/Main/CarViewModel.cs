using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1Telemetry.Models;
using GalaSoft.MvvmLight;

namespace DesktopClient.Main
{
    public class CarViewModel : ViewModelBase
    {
        public CarData CarData { get; }

        public CarLiveData LatestLiveData => CarData.CarLiveData.Last();
        public string DriverName => CarData.Driver.Name ?? "Thorben Buchta";
        public bool IsInPits => LatestLiveData.PitStatus == PitStatus.PITTING;

        public CarViewModel(CarData carData)
        {
            CarData = carData;
        }
    }
}
