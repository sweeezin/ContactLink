using System.Windows;

using ContactLink.Core.Helpers;
using ContactLink.Properties;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ContactLink.Helpers;

internal static class AuthenticationHelper
{
    internal static async Task ShowLoginErrorAsync(LoginResultType loginResult)
    {
        var metroWindow = Application.Current.MainWindow as MetroWindow;
        switch (loginResult)
        {
            case LoginResultType.NoNetworkAvailable:
                await metroWindow.ShowMessageAsync(Resources.DialogNoNetworkAvailableContent, Resources.DialogAuthenticationTitle);
                break;
            case LoginResultType.UnknownError:
                await metroWindow.ShowMessageAsync(Resources.DialogAuthenticationTitle, Resources.DialogStatusUnknownErrorContent);
                break;
        }
    }
}
