using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ContactLink.Contracts.ViewModels;
using ContactLink.Core.Contracts.Services;
using ContactLink.Core.Models;

namespace ContactLink.ViewModels;

public class DataGridViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public DataGridViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // Replace this with your actual data retrieval logic
        var CLOG = CLOG
        var data = CLOG.GetAllStudents();

        foreach (var item in data)
        {
            // Create a new SampleOrder and map properties from CLOG
            SampleOrder order = new SampleOrder
            {
                OrderID = item.studentID,
                LastName = item.LastName,
                FirstName = item.FirstName,
                Email = item.email,
                Number = item.number,
                // Map other properties as needed
            };

            // Add the mapped SampleOrder to the ObservableCollection
            Source.Add(order);
        }
    }

}
