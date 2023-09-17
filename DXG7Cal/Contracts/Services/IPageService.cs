using System.Windows.Controls;

namespace DXG7Cal.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
