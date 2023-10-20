using System.Windows.Controls;

namespace ContactLink.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
