using BarbershopClient.Models;
using System.Net;

namespace BarbershopClient.Views;


    public partial class AddBarberPage : ContentPage
    {
        public AddBarberPage()
        {
            InitializeComponent();
        }

        private async void OnPickPhotoClicked(object sender, EventArgs e)
        {
            // Здесь будет код для выбора фото (используем Media Picker или аналогичный компонент)
        }

        private async void OnAddBarberClicked(object sender, EventArgs e)
        {
            var barber = new BarberVM
            {
                Name = NameEntry.Text,
                BIO = BioEntry.Text,
                // Здесь добавим логику для сохранения фото
            };

            // Отправляем данные в API для создания барбера
            var response = await AddBarberAsync(barber);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Успех", "Барбер добавлен", "ОК");
            }
            else
            {
                await DisplayAlert("Ошибка", "Не удалось добавить барбера", "ОК");
            }
        }

        private async Task<HttpResponseMessage> AddBarberAsync(BarberVM barber)
        {
            // Тут должен быть код для отправки данных в API
            // Пример (используем HttpClient или Refit):
            // var client = new HttpClient();
            // var response = await client.PostAsJsonAsync("api/admin/barbers", barber);
            // return response;

            return new HttpResponseMessage(HttpStatusCode.OK); // для примера
        }
    }