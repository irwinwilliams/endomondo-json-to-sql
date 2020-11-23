namespace EndomondoJsonToSQL
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public partial class EndomondoWorkout
    {
        public int ID { get; set; }

        [JsonPropertyName("sport")]
        public string Sport { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("created_date")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonPropertyName("start_time")]
        public DateTimeOffset? StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public DateTimeOffset? EndTime { get; set; }

        [JsonPropertyName("duration_s")]
        public double? DurationS { get; set; }

        [JsonPropertyName("distance_km")]
        public double? DistanceKm { get; set; }

        [JsonPropertyName("calories_kcal")]
        public double? CaloriesKcal { get; set; }

        [JsonPropertyName("altitude_min_m")]
        public double? AltitudeMinM { get; set; }

        [JsonPropertyName("altitude_max_m")]
        public double? AltitudeMaxM { get; set; }

        [JsonPropertyName("speed_avg_kmh")]
        public double? SpeedAvgKmh { get; set; }

        [JsonPropertyName("speed_max_kmh")]
        public double? SpeedMaxKmh { get; set; }

        [JsonPropertyName("ascend_m")]
        public double? AscendM { get; set; }

        [JsonPropertyName("descend_m")]
        public double? DescendM { get; set; }

        public static EndomondoWorkout FromJson(string json)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new DateTimeOffsetConverter());
            serializeOptions.WriteIndented = true;
            return JsonSerializer.Deserialize<EndomondoWorkout>(json, serializeOptions);
        }
    }


    public static class Serialize
    {
        public static string ToJson(this EndomondoWorkout[] self) 
        => JsonSerializer.Serialize(self);
    }


}
