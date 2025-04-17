﻿//@BaseCode
#if EXTERNALGUID_ON
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using SETemplate.MVVMApp.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SETemplate.MVVMApp.ViewModels
{
    partial class GenericItemsViewModel<TModel>
    {
        [RelayCommand]
        public virtual async Task DeleteItem(TModel model)
        {
            var messageDialog = new MessageDialog("Delete", $"Do you want to delete the '{model}'?", MessageType.Question);
            var mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;

            // Aktuelles Hauptfenster als Parent setzen
            await messageDialog.ShowDialog(mainWindow!);

            if (messageDialog.Result == MessageResult.Yes)
            {
                using var httpClient = CreateHttpClient();


                var response = await httpClient.DeleteAsync($"{RequestUri}/{model.Guid}");

                if (response.IsSuccessStatusCode == false)
                {
                    messageDialog = new MessageDialog("Error", "An error occurred during deletion!", MessageType.Error);
                    await messageDialog.ShowDialog(mainWindow!);
                }
                else
                {
                    _ = LoadModelsAsync();
                }
            }
        }

        protected virtual async void ApplyFilter(string filter)
        {
            // UI-Update sicherstellen
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var selectedItem = SelectedItem;

                Models.Clear();
                foreach (var model in _models)
                {
                    if (model != default && model.ToString()!.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        Models.Add(model);
                    }
                }
                OnPropertyChanged(nameof(Models));
                if (selectedItem != null)
                {
                    SelectedItem = Models.FirstOrDefault(e => e.Guid == selectedItem.Guid);
                }
            });
        }

    }
}
#endif