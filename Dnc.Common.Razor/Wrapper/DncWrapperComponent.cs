using Dnc.Common.Razor.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Common.Razor.Wrapper
{
    public class DncWrapperComponent:ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        protected IToastService ToastService { get; set; }

        public void SetToastService(IToastService toastService)
        {
            ToastService = toastService;
        }

        public void ShowSuccessMessage(string message, TimeSpan? duration = null)
        {
            ToastService?.ShowSuccessMessage(message, duration);
        }
        public void ShowErrorMessage(string message, TimeSpan? duration = null)
        {
            ToastService?.ShowErrorMessage(message, duration);
        }
        public void ShowWarningMessage(string message, TimeSpan? duration = null)
        {
            ToastService?.ShowWarningMessage(message, duration);
        }
        public void ShowInfoMessage(string message, TimeSpan? duration = null)
        {
            ToastService?.ShowInfoMessage(message, duration);
        }
    }
}
