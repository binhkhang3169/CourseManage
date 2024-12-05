using System.Text.RegularExpressions;

namespace CourseManage.Utilities
{
    public static class ConverterUtility
    {
        public static string ToMinutesSeconds(this double totalSeconds)
        {
            int minutes = (int)Math.Floor(totalSeconds / 60);
            int seconds = (int)(totalSeconds % 60);

            return $"{minutes}m {seconds}s";
        }
        public static string GetEmbedUrl(this string youtubeUrl)
        {
            // Kiểm tra xem URL có hợp lệ không
            if (string.IsNullOrEmpty(youtubeUrl))
            {
                return null;
            }

            // Các mẫu regex để khớp với các định dạng URL YouTube khác nhau
            string[] patterns = {
            @"youtu\.be/(?<id>[^?&#]+)", // youtu.be/videoId
            @"youtube\.com/watch\?v=(?<id>[^?&#]+)", // youtube.com/watch?v=videoId
            @"youtube\.com/embed/(?<id>[^?&#]+)", // youtube.com/embed/videoId
            @"youtube\.com/v/(?<id>[^?&#]+)" // youtube.com/v/videoId
        };


            foreach (string pattern in patterns)
            {
                Match match = Regex.Match(youtubeUrl, pattern);
                if (match.Success)
                {
                    string videoId = match.Groups["id"].Value;
                    return $"https://www.youtube.com/embed/{videoId}";
                }
            }


            // Nếu không khớp với bất kỳ mẫu nào, trả về null hoặc chuỗi trống
            return null;

        }
    }
}
