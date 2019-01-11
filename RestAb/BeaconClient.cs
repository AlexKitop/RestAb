using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestAb
{
  /// <summary> Client for beacon service </summary>
  public class BeaconClient : IDisposable
  {
    private static readonly List<MediaTypeFormatter> Formatters = new List<MediaTypeFormatter>()
    {
      new XmlMediaTypeFormatter() { UseXmlSerializer = true }
    };

    readonly HttpClient _client;
    readonly string _route;

    /// <summary> ctor </summary>
    /// <param name="uri"></param>
    /// <param name="route"></param>
    public BeaconClient(string uri, string route)
    {
      _route = route ?? String.Empty;
      if (!route.EndsWith("/"))
        route += "/";
      _client = new HttpClient()
      {
        BaseAddress = new Uri(uri)
      };
      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
    }

    /// <summary>
    /// async returns <see cref="recordType"/> for <see cref="time`"/>
    /// </summary>
    public async Task<recordType> GetRecordAsync(string timestamp)
    {
      var response = await _client.GetAsync(_route + timestamp);
      if (!response.IsSuccessStatusCode)
        throw new Exception(response.ReasonPhrase);
      return await response.Content.ReadAsAsync<recordType>(Formatters);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        _client?.Dispose();

        disposedValue = true;
      }
    }

    ~BeaconClient()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(false);
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
