using Prometheus;

namespace MonitoringExample.Monitoring
{
    public class CustomMetrics
    {
        public CustomMetrics()
        {
        }

        private static readonly Histogram _requestDuration = Metrics.CreateHistogram(
            "yourapp_request_duration_seconds",
            "Duration of HTTP requests",
            new HistogramConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            }
        );

        private static readonly Gauge _openDbConnection = Metrics.CreateGauge(
            "OpenDbConnection",
            "Shows Open Db Connections");


        public static Histogram RequestDuration => _requestDuration;

        public static Gauge OpenDbConnection => _openDbConnection;

        public static void IncrementDbConnectionCounter()
        {
            _openDbConnection.Inc();
            _openDbConnection.Publish();
        }

        public static void DecrementDbConnectionCounter()
        {
            _openDbConnection.Dec();
            _openDbConnection.Publish();
        }

        // Bu metrik, HTTP isteklerinin süresini ölçmek için kullanılabilir
        public static void ObserveRequestDuration(string method, string endpoint, double durationInSeconds)
        {
            _requestDuration.Labels(method, endpoint).Observe(durationInSeconds);
        }

    }
}

