using BarbershopClient.Models;
using BarbershopClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopClient
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly BarberApiService _apiService;
        public ObservableCollection<BarberDto> Barbers { get; set; } = new();

        public MainPageViewModel(BarberApiService apiService)
        {
            _apiService = apiService;
            LoadBarbers();
        }

        private async void LoadBarbers()
        {
            var barbers = await _apiService.GetBarbersAsync();
            foreach (var barber in barbers)
                Barbers.Add(barber);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
