using Dnc.Common.Razor.Enums;
using Dnc.Common.Razor.Interfaces;
using Dnc.Common.Razor.Wrapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Common.Razor.Toast
{
    public class DncToastComponent : ComponentBase, IToastService, IDisposable
    {
        [CascadingParameter] 
        protected DncWrapperComponent DncWrapper { get; set; }

        [Inject] 
        protected NavigationManager NavigationManager { get; set; }
        protected MarkupString Message { get; set; }
        protected bool Show { get; set; }
        protected string ToastBackgroundColor { get; set; }


        private string currentLocation = string.Empty; 

        protected override void OnInitialized()
        {
            DncWrapper.SetToastService(this); 
        }

        public async Task ShowSuccessMessage(string message, TimeSpan? duration = null)
        {
            await ShowMessage(message, MessageType.Success,duration); 
        }
        public async Task ShowErrorMessage(string message, TimeSpan? duration = null)
        {
            await ShowMessage(message, MessageType.Error, duration);

        }
        public async Task ShowWarningMessage(string message, TimeSpan? duration = null)
        {
            await ShowMessage(message, MessageType.Warning, duration);
        }
        public async Task ShowInfoMessage(string message, TimeSpan? duration = null)
        {
            await ShowMessage(message, MessageType.Info, duration);
        }
        public async Task ShowMessage(string message, MessageType messageType, TimeSpan? duration = null)
        {
            Show = true;
            Message = (MarkupString)message;

            switch (messageType)
            {
                case MessageType.Success:
                    ToastBackgroundColor = "dnc-toast-success";
                    break;

                case MessageType.Error:
                    ToastBackgroundColor = "dnc-toast-error";
                    break;

                case MessageType.Warning:
                    ToastBackgroundColor = "dnc-toast-warning";
                    break;

                case MessageType.Info:
                    ToastBackgroundColor = "dnc-toast-info";
                    break;
            }

            currentLocation = NavigationManager.Uri;
            NavigationManager.LocationChanged -= NavigationHandler;
            NavigationManager.LocationChanged += NavigationHandler;
            StateHasChanged();

            if (duration != null)
            {
                await Task.Delay((TimeSpan)duration);
                Clear();
            }
        }

        protected void Close()
        {
            Show = false;
        }
        public void Clear()
        {
            Show = false;
            StateHasChanged();
        }
        public void Dispose()
        {
            NavigationManager.LocationChanged -= NavigationHandler;
        }
        private void NavigationHandler(object sender, LocationChangedEventArgs args)
        {
            if(!string.Equals(args.Location, currentLocation, StringComparison.OrdinalIgnoreCase)){
                Clear();
                NavigationManager.LocationChanged -= NavigationHandler;
                StateHasChanged();
            }
        }
    }
}
