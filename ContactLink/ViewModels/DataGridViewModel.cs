using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ContactLink.Contracts.ViewModels;
using ContactLink.Core.Contracts.Services;
using ContactLink.Core.Models;
using ContactLinkDBAccess;

namespace ContactLink.ViewModels;

public class DataGridViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<CLOG> Source { get; } = new ObservableCollection<CLOG>();

    public DataGridViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public  void OnNavigatedTo(object parameter)
    {
        FetchAllStudents();
    }

    public void OnNavigatedFrom()
    {
    }

    public void FetchAllStudents()
    {
        Source.Clear();

        // Replace this with your actual data
        var data = CLOG.GetAllStudents();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
}
