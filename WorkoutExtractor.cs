using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndomondoJsonToSQL
{
    public class WorkoutExtractor
    {
        public WorkoutExtractor()
        {

        }

        /// <summary>
        /// Without string magic, this method essentially takes the json in the file
        /// and makes a new Workout object for each property defined. Because the file looks like this:
        /// [
        ///    {"sport": "RUNNING"},
        ///    {"source": "TRACK_MOBILE"},
        ///    { "created_date": "2013-05-02 22:11:37.0"},
        ///    { "start_time": "2013-05-02 21:38:52.0"},
        ///    { "end_time": "2013-05-02 22:10:02.0"},
        ///    { "duration_s": 1867},
        ///    { "distance_km": 2.42},
        ///    { "calories_kcal": 130.966},
        ///    { "altitude_min_m": 1.9},
        ///    { "altitude_max_m": 32.4},
        ///    { "speed_avg_kmh": 4.6663095875736476},
        ///    { "speed_max_kmh": 8.33},
        ///    { "ascend_m": 23.9},
        ///    { "descend_m": 26.5}
        ///]
        /// That's very dumb.
        /// </summary>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        private EndomondoWorkout ExtractOld(string jsonContent)
        {
            var workout = EndomondoWorkout.FromJson(jsonContent);
            return workout;
        }

        public EndomondoWorkout ExtractWithStringMagic(string jsonContent)
        {
            var pointsIndex = -1;
            var picturesIndex = jsonContent.IndexOf("{\"pictures\":");
            var tagsIndex = jsonContent.IndexOf("{\"tags\":");

            var smallerIndex = picturesIndex;
            if (picturesIndex == -1)
                smallerIndex = tagsIndex;
            else if (tagsIndex == -1)
                smallerIndex = picturesIndex;
            else
                smallerIndex = (picturesIndex < tagsIndex) ? picturesIndex : tagsIndex;
            
            if (smallerIndex > -1)
                pointsIndex = smallerIndex;
            else
                pointsIndex = jsonContent.IndexOf("{\"points\":");
            

            var contentWithoutPoints = jsonContent;

            if (pointsIndex > -1)
                contentWithoutPoints = jsonContent.Substring(0, pointsIndex);

            var lastComma = contentWithoutPoints.LastIndexOf(",");
            var noLastComma = contentWithoutPoints.Substring(0, lastComma);
            var contentWithNoBrace = noLastComma
                .Replace('[', ' ')
                .Replace('{', ' ')
                .Replace('}', ' ');
            var freshBraces = "{" + contentWithNoBrace + "}";

            return ExtractOld(freshBraces);
        }
    }
}
