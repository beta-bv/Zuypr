﻿namespace View.Pages.Register;

public partial class Step3 : ContentPage
{
    // int count = 0;

    public Step3()
    {
        InitializeComponent();
    }

    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step4());
    }
}