using SimpleTrader.FinancialModelingPropAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    class SimpleTraderViewModelAbstractFactory : ISimpleTraderViewModelAbstractFactory
    {
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                   return new HomeViewModel(MajorIndexListingViewModel.LoadMajorIndexViewModel(new MajorIndexService()));
                    break;
                case ViewType.Portfolio:
                    return new PortfolioViewModel();
                    break;
                default:
                    throw new ArgumentException("The viewType does not have a VewModel.","viewType");
            }
        }
    }
}
