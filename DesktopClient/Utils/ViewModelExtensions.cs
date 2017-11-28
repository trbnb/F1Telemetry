using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DesktopClient.Utils
{
    public static class ViewModelExtensions
    {
        public static void RaisePropertiesChanged(this ObservableObject viewModel, params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                viewModel.RaisePropertyChanged(propertyName);
            }
        }
    }
}
