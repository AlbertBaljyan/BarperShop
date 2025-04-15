using System.Net;

namespace BarbershopClient.Views;

public partial class AddServicePage : ContentPage
{
    public AddServicePage()
    {
        InitializeComponent();
    }

    private async void OnAddServiceClicked(object sender, EventArgs e)
    {
        var service = new Service
        {
            Name = ServiceNameEntry.Text,
            PricesByLevel = new Dictionary<string, decimal>
            {
                { "Junior", decimal.Parse(PriceEntry.Text) }
            },
            DurationsByLevel = new Dictionary<string, TimeSpan>
            {
                { "Junior", TimeSpan.FromMinutes(int.Parse(DurationEntry.Text)) }
            }
        };

        var response = await AddServiceAsync(service);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("�����", "������ ���������", "��");
        }
        else
        {
            await DisplayAlert("������", "�� ������� �������� ������", "��");
        }
    }

    private async Task<HttpResponseMessage> AddServiceAsync(Service service)
    {
        // ����� ��� ��� �������� ������ � API
        return new HttpResponseMessage(HttpStatusCode.OK); // ��� �������
    }
}