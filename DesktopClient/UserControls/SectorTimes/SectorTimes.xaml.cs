using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopClient.UserControls.SectorTimes
{
    /// <summary>
    /// Interaction logic for SectorTimes.xaml
    /// </summary>
    public partial class SectorTimes : UserControl
    {
        public static readonly DependencyProperty Sector1DependencyProperty = DependencyProperty.Register("Sector1", typeof(TimeSpan?), typeof(SectorTimes));
        public static readonly DependencyProperty Sector2DependencyProperty = DependencyProperty.Register("Sector2", typeof(TimeSpan?), typeof(SectorTimes));
        public static readonly DependencyProperty Sector3DependencyProperty = DependencyProperty.Register("Sector3", typeof(TimeSpan?), typeof(SectorTimes));
        public static readonly DependencyProperty TotalDependencyProperty = DependencyProperty.Register("Total", typeof(TimeSpan?), typeof(SectorTimes));
       
        public TimeSpan? Sector1
        {
            get => (TimeSpan?) GetValue(Sector1DependencyProperty);
            set => SetValue(Sector1DependencyProperty, value);
        }

        public TimeSpan? Sector2
        {
            get => (TimeSpan?)GetValue(Sector2DependencyProperty);
            set => SetValue(Sector2DependencyProperty, value);
        }

        public TimeSpan? Sector3
        {
            get => (TimeSpan?)GetValue(Sector3DependencyProperty);
            set => SetValue(Sector3DependencyProperty, value);
        }

        public TimeSpan? Total
        {
            get => (TimeSpan?)GetValue(TotalDependencyProperty);
            set => SetValue(TotalDependencyProperty, value);
        }

        public SectorTimes()
        {
            InitializeComponent();
        }
    }
}
