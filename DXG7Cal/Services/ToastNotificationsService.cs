using CommunityToolkit.WinUI.Notifications;

using DXG7Cal.Contracts.Services;

using Windows.UI.Notifications;

namespace DXG7Cal.Services;

public partial class ToastNotificationsService : IToastNotificationsService
{
    public ToastNotificationsService()
    {
    }

    public void ShowToastNotification(ToastNotification toastNotification)
    {
        ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
    }
}
