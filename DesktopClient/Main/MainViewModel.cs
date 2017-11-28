using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLogic.Sessions;
using DesktopClient.Utils;
using F1Telemetry.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using Models;

namespace DesktopClient.Main
{
    public class MainViewModel : ViewModelBase
    {
        private const double MphToKmhMultiplier = 1.609344;

        private SessionType _sessionType = SessionType.File;
        public SessionType SessionType
        {
            get => _sessionType;
            set
            {
                _sessionType = value;

                this.RaisePropertiesChanged(
                    nameof(SessionType),
                    nameof(IsLiveSession),
                    nameof(IsFileSession)
                );
            }
        }

        public bool IsLiveSession => SessionType == SessionType.Live;
        public bool IsFileSession => SessionType == SessionType.File;

        public RelayCommand SetToLiveSessionCommand { get; }
        public RelayCommand SetToFileSessionCommand { get; }

        private Session _session = null;

        public RelayCommand StartCommand { get; }
        public RelayCommand PauseCommand { get; }

        public SessionData SessionData { get; private set; }

        public int Speed => Convert.ToInt32(SessionData?.SessionLiveData.LastOrDefault()?.Speed * 3.6 ?? 0);
        public string SpeedText => $"{Speed} kmh";

        public CarData PlayerCarData => SessionData?.CarData[SessionData.PlayerCarIndex];
        public TimeSpan? Sector1Time => PlayerCarData?.Laptimes.LastOrDefault()?.Sector1;
        public TimeSpan? Sector2Time => PlayerCarData?.Laptimes.LastOrDefault()?.Sector2;
        public TimeSpan? Sector3Time => PlayerCarData?.Laptimes.LastOrDefault()?.Sector3;
        public TimeSpan? TotalLaptime => SessionData?.SessionLiveData.LastOrDefault()?.LapTime;

        public Pedals Pedals => SessionData?.SessionLiveData.Last().Pedals;
        public int EngineRpm => (int) SessionData.SessionLiveData.Last().EngineRate;

        public List<CarViewModel> DriversInPositions => SessionData?.CarData
            .Select(e => new CarViewModel(e))
            .OrderBy(e => e.LatestLiveData.CarPosition)
            .ToList();

        public MainViewModel()
        {
            SetToLiveSessionCommand = new RelayCommand(SetToLiveSession);
            SetToFileSessionCommand = new RelayCommand(SetToFileSession);

            StartCommand = new RelayCommand(StartSession, () => _session != null && !_session.IsRunning);
            PauseCommand = new RelayCommand(PauseSession, () => _session != null && _session.IsRunning);

            SetToFileSession();
            StartSession();
        }

        private void SetToLiveSession()
        {
            if (IsLiveSession && _session != null)
            {
                return;
            }
            
            PauseSession();

            _session = new UdpSession(IPAddress.Any, 20777);
            _session.SessionDataUpdated += (_, data) => OnSessionDataUpdated(data);
            SessionType = SessionType.Live;
            SessionData = null;

            RefreshStartAndPauseCommands();
        }

        private void SetToFileSession()
        {
            if (IsFileSession && _session != null)
            {
                return;
            }

            var dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog();

            if (dialogResult != true)
            {
                return;
            }

            var filePath = dialog.FileName;

            PauseSession();

            _session = new FileSession(filePath, true, 50);
            _session.SessionDataUpdated += (_, data) => OnSessionDataUpdated(data);
            SessionType = SessionType.File;
            SessionData = null;

            RefreshStartAndPauseCommands();
        }

        private void StartSession()
        {
            _session.Start();
            RefreshStartAndPauseCommands();
        }

        private void PauseSession()
        {
            _session?.Pause();
            RefreshStartAndPauseCommands();
        }

        private void RefreshStartAndPauseCommands()
        {
            StartCommand.RaiseCanExecuteChanged();
            PauseCommand.RaiseCanExecuteChanged();
        }

        private void OnSessionDataUpdated(SessionData e)
        {
            SessionData = e;
            RaisePropertyChanged(nameof(SpeedText));
            RaisePropertyChanged(nameof(Speed));
            RaisePropertyChanged(nameof(Sector1Time));
            RaisePropertyChanged(nameof(Sector2Time));
            RaisePropertyChanged(nameof(Sector3Time));
            RaisePropertyChanged(nameof(TotalLaptime));
            RaisePropertyChanged(nameof(DriversInPositions));
            RaisePropertyChanged(nameof(Pedals));
            RaisePropertyChanged(nameof(EngineRpm));
        }
    }
}
