using Dnc.Common.Razor.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Common.Razor.Interfaces
{
    public interface IToastService
    {
        Task ShowMessage(string message, MessageType messageType, TimeSpan? duration = null);
        Task ShowSuccessMessage(string message, TimeSpan? duration = null);
        Task ShowErrorMessage(string message, TimeSpan? duration = null);
        Task ShowWarningMessage(string message, TimeSpan? duration = null);
        Task ShowInfoMessage(string message, TimeSpan? duration = null);
    }
}
