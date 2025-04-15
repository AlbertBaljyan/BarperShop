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
            // ����� ����� ��� ��� ������ ���� (���������� Media Picker ��� ����������� ���������)
        }

        private async void OnAddBarberClicked(object sender, EventArgs e)
        {
            var barber = new BarberVM
            {
                Name = NameEntry.Text,
                BIO = BioEntry.Text,
                // ����� ������� ������ ��� ���������� ����
            };

            // ���������� ������ � API ��� �������� �������
            var response = await AddBarberAsync(barber);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("�����", "������ ��������", "��");
            }
            else
            {
                await DisplayAlert("������", "�� ������� �������� �������", "��");
            }
        }

        private async Task<HttpResponseMessage> AddBarberAsync(BarberVM barber)
        {
            // ��� ������ ���� ��� ��� �������� ������ � API
            // ������ (���������� HttpClient ��� Refit):
            // var client = new HttpClient();
            // var response = await client.PostAsJsonAsync("api/admin/barbers", barber);
            // return response;

            return new HttpResponseMessage(HttpStatusCode.OK); // ��� �������
        }
    }