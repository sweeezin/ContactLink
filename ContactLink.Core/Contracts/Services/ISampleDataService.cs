using ContactLink.Core.Models;

namespace ContactLink.Core.Contracts.Services;

public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetGridDataAsync();
}
