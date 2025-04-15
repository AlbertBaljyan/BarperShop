using System.Net;
using System.Text.Json;

namespace BarbershopClient.Views;


public partial class AddSchedulePage : ContentPage
{
    public AddSchedulePage()
    {
        InitializeComponent();
        LoadBarbersAsync(); // ��������� �������� ��� �������������
    }

    private async void LoadBarbersAsync()
    {
        // ������: �������� �������� ����� API
        var barbers = await GetBarbersAsync();
        BarberPicker.ItemsSource = barbers;
        BarberPicker.ItemDisplayBinding = new Binding("FullName"); // ���������� ���
    }

    private async void OnAddScheduleClicked(object sender, EventArgs e)
    {
        if (BarberPicker.SelectedItem is not Barber selectedBarber ||
            DayOfWeekPicker.SelectedIndex == -1 ||
            !TimeSpan.TryParse(StartTimeEntry.Text, out var startTime) ||
            !TimeSpan.TryParse(EndTimeEntry.Text, out var endTime))
        {
            await DisplayAlert("������", "����������, ��������� ��� ���� ���������.", "��");
            return;
        }

        var schedule = new BarberSchedule
        {
            BarberId = selectedBarber.Id,
            DayOfWeek = (DayOfWeek)DayOfWeekPicker.SelectedIndex,
            StartTime = startTime,
            EndTime = endTime
        };

        var response = await AddScheduleAsync(schedule);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("�����", "���������� ���������", "��");
        }
        else
        {
            await DisplayAlert("������", "�� ������� �������� ����������", "��");
        }
    }

    private async Task<HttpResponseMessage> AddScheduleAsync(BarberSchedule schedule)
    {
        var httpClient = new HttpClient();
        var json = JsonSerializer.Serialize(schedule);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await httpClient.PostAsync("https://your-api.com/api/schedules", content);
    }

    private async Task<List<Barber>> GetBarbersAsync()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://your-api.com/api/barbers");
        if (!response.IsSuccessStatusCode) return new List<Barber>();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Barber>>(json) ?? new List<Barber>();
    }
}

}

