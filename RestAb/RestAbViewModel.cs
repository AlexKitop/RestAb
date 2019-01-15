using RestAb.View.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestAb
{
  /// <summary>
  /// ViewModel for <see cref="RestAbWnd"/>
  /// </summary>
  public class RestAbViewModel : INotifyPropertyChanged, IDisposable
  {
    const string ServerUriConfigName = "ServerUri";
    const string RouteConfigName = "Route";
    const string DateTime0ConfigName = "DateTime0";

    public DateTime _time;
    public DateTime Time
    {
      get => _time;
      set
      {
        if (_time == value)
          return;
        _time = value;
        Timestamp = Helpers.TimestampStr(Time);
        OutputValue = null;
        Chart = null;
        OnPropertyChanged();
      }
    }

    private string _timestamp;

    public string Timestamp
    {
      get { return _timestamp; }
      set
      {
        if (_timestamp == value)
          return;
        _timestamp = value;
        OnPropertyChanged();
      }
    }


    private string _outputValue;
    public string OutputValue
    {
      get => _outputValue;
      set
      {
        if (_outputValue == value)
          return;
        _outputValue = value;
        OnPropertyChanged();
      }
    }

    ICommand _runCommand;
    public ICommand RunCommand => _runCommand ?? (_runCommand = new RelayCommand(RunExecute, RunCanExecute));

    public IEnumerable<KeyValuePair<char, int>> _chart;
    public IEnumerable<KeyValuePair<char, int>> Chart
    {
      get => _chart;
      protected set
      {
        if (_chart == value)
          return;
        _chart = value;
        OnPropertyChanged();
      }
    }

    Lazy<BeaconClient> Client { get; }
    Task<recordType> _recordTask;

    public RestAbViewModel()
    {

      if (DateTime.TryParse(ConfigurationManager.AppSettings[DateTime0ConfigName],
          CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime time))
        Time = time;
      else
        Time = DateTime.Now;
      Client = new Lazy<BeaconClient>(CreateClient);

    }

    private static BeaconClient CreateClient()
    {
      try
      {
        var serverUri = ConfigurationManager.AppSettings[ServerUriConfigName];
        var route = ConfigurationManager.AppSettings[RouteConfigName];
        return new BeaconClient(serverUri, route);
      }
      catch (Exception x)
      {
        MessageBox.Show(x.Message);
        Application.Current.Shutdown();
        return null;
      }
    }

    private async void RunExecute(object p)
    {
      try
      {
        _recordTask = Client.Value.GetRecordAsync(Timestamp);
        EnabledRefresh();
        var record = await _recordTask;
        OutputValue = record.outputValue;
        var chart = Helpers.GetHashChart(OutputValue);
        Chart = chart.OrderBy(i => i.Key).ToList();
      }
      catch(Exception x)
      {
        MessageBox.Show(Application.Current.MainWindow, x.Message);
      }
      finally
      {
        EnabledRefresh();
      }

      void EnabledRefresh()
      {
        OnPropertyChanged(nameof(IsReadOnly));
        CommandManager.InvalidateRequerySuggested();
      }
    }

    private bool RunCanExecute(object p)
    {
      return !IsReadOnly;
    }

    public bool IsReadOnly => !(_recordTask?.IsCompleted ?? true);


    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    ///     Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">
    ///     Name of the property used to notify listeners.  This
    ///     value is optional and can be provided automatically when invoked from compilers
    ///     that support <see cref="CallerMemberNameAttribute" />.
    /// </param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion INotifyPropertyChanged

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (Client.IsValueCreated)
          Client.Value.Dispose();
        disposedValue = true;
      }
    }

     ~RestAbViewModel()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(false);
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion

  }
}
