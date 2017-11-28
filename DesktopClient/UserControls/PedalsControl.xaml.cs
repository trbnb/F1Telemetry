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
using F1Telemetry.Models;

namespace DesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for PedalsControl.xaml
    /// </summary>
    public partial class PedalsControl : UserControl
    {
        public static readonly DependencyProperty PedalsDependencyProperty = DependencyProperty.Register(nameof(Pedals), typeof(Pedals), typeof(PedalsControl));

        public Pedals Pedals
        {
            get => (Pedals) GetValue(PedalsDependencyProperty);
            set => SetValue(PedalsDependencyProperty, value);
        }

        public PedalsControl()
        {
            InitializeComponent();
        }
    }
}
