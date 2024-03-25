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

        public static Histogram RequestDuration => _requestDuration;

        // Bu metrik, HTTP isteklerinin süresini ölçmek için kullanılabilir
        public static void ObserveRequestDuration(string method, string endpoint, double durationInSeconds)
        {
            _requestDuration.Labels(method, endpoint).Observe(durationInSeconds);
        }

    }
}

