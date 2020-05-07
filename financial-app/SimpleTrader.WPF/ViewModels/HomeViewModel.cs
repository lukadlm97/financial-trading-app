using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    class HomeViewModel:ViewModelBase
    {
        public MajorIndexViewModel MajorIndexViewModel { get; set; }

        public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
        {
            MajorIndexViewModel = majorIndexViewModel;
        }

    }
}
