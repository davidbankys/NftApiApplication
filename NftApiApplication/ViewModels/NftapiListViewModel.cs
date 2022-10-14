using System.Threading.Tasks;
using NftApiApplication.Models;
using NftApiApplication.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace NftApiApplication.ViewModels
{
    
    internal class NftapiListViewModel
    {
        public INftapiDataStore<Nftapi> DataStore => DependencyService.Get<INftapiDataStore<Employee>>();
        public ObservableRangeCollection<Nftapi> Nftapi { get; set; }
        public AsyncCommand PageAppearingCommand { get; }

        public NftapiListViewModel()
        {
            Nftapi = new ObservableRangeCollection<Nftapi>();
            PageAppearingCommand = new AsyncCommand(PageAppearing);
        }

        public async Task Refresh()
        {
            var nftapis = await DataStore.GetNftapisAsync(20);

            Employees.AddRange(nftapis);
        }

        async Task PageAppearing()
        {
            await Refresh();
        }
    }
}