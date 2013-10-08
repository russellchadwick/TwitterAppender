using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using LinqToTwitter;
using log4net.Appender;
using log4net.Core;

namespace russellchadwick.Appenders
{
    public class TwitterAppender : AppenderSkeleton
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string HashTag { get; set; }

        private const int MaximumTweetLength = 140;

        protected override void Append(LoggingEvent loggingEvent)
        {
            var status = GetStatus(loggingEvent);
            SendTweet(status);
            Debug.WriteLine(status);
        }
        
        private string GetStatus(LoggingEvent loggingEvent)
        {
            var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            RenderLoggingEvent(stringWriter, loggingEvent);
            var tweet = stringWriter.ToString();
            tweet = tweet.TrimEnd(new[] { '\r', '\n' });

            if (HashTag != null)
            {
                var hashTagLength = HashTag.Length + 2; // padding for ' #'
                if (tweet.Length + hashTagLength > MaximumTweetLength)
                {
                    tweet = tweet.Substring(0, MaximumTweetLength - hashTagLength);
                }

                tweet = string.Format("{0} #{1}", tweet, HashTag);
            }

            return tweet;
        }

        private void SendTweet(string status)
        {
            var singleUserAuthorizer = new SingleUserAuthorizer
            {
                Credentials = new SingleUserInMemoryCredentials
                {
                    ConsumerKey = ConsumerKey,
                    ConsumerSecret = ConsumerSecret,
                    TwitterAccessToken = AccessToken,
                    TwitterAccessTokenSecret = AccessTokenSecret
                }
            };

            using (var twitterContext = new TwitterContext(singleUserAuthorizer))
            {
                try
                {
                    twitterContext.UpdateStatus(status);
                }
                catch (Exception e)
                {
                    var message = string.Format("Unable to tweet log due to {0}", e);
                    Console.Error.WriteLine(message);
                    Trace.WriteLine(message);
                }
            }
        }
    }
}
