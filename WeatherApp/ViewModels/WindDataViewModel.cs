﻿using System;
using System.ComponentModel;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel
    {
        public IWindDataService WindDataService { get; set; }
        public DelegateCommand<string> GetDataCommand { get; set; }

        private WindDataModel currentData;
        public WindDataModel CurrentData
        {
            get { return currentData; }

            set
            {
                currentData = value;

                NotifyPropertyChanged(nameof(CurrentData));
            }
        }

        public event PropertyChangedEventHandler eventPropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            eventPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double KPHtoMPS(double kph) => kph * 1.0 / 36.0;
        public double MPStoKPH(double mps) => mps * 3.6;
        
        public WindDataViewModel()
        {
            GetDataCommand = new DelegateCommand<string>(getData);
        }

        public async void getData(string obj)
        {
            OpenWeatherService openWeatherService = new OpenWeatherService(AppConfiguration.GetValue("Secrets:OWApiKey"));

            CurrentData = await openWeatherService.GetDataAsync();
        }

    }
}