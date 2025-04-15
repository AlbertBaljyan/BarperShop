namespace BarbershopClient.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
    }
    private void OnBookingClicked(object sender, EventArgs e)
    {
        // � ������� � ������� � �������� ������������
        DisplayAlert("������", "������� ������ ��� � ����������", "��");
    }
    private async void OnAddBarberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBarberPage());
    }

    private async void OnAddServiceClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddServicePage());
    }
    private async void OnAddScheduleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddSchedulePage());
    }

    private async void OnManageBookingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageBookingsPage());
    }


}