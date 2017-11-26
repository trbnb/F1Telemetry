using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLogic.Sessions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;

namespace DesktopClient.Main
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Session session = new FileSession(@"C:\Users\Thorben\Desktop\F1Telemetry\renault_last_safety_car.txt", false, 50);

        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }

        public MainViewModel()
        {
            session.SessionDataUpdated += (_, data) => OnSessionDataUpdated(data);

            StartCommand = new RelayCommand(() => session.Start());
            PauseCommand = new RelayCommand(() => session.Pause());
        }

        private void OnSessionDataUpdated(SessionData e)
        {

        }
    }
}
