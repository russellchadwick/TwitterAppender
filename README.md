TwitterAppender
===============

Log4net appender to send logs to twitter

### Example config
```
  <log4net>
    <appender name="TwitterAppender" type="russellchadwick.Appenders.TwitterAppender, russellchadwick.Appenders">
      <layout type="log4net.Layout.PatternLayout" value="%date %-5level %logger - %message%newline" />
      <consumerKey value="grinAevpfvoTTc9BtSrWg"/>
      <consumerSecret value="clYKxhxEdVS3N2gI5P0Vy0Ud3sym1dIz6inieash87Y"/>
      <accessToken value="24971840-n8flDhYYEJictiZXX3NUN4fZT07aHTERVGdDDDIYU"/>
      <accessTokenSecret value="yCydTrizUF0dmEOugD8WnmDsAATU2gzFHoIiuMPMOAA"/>
      <hashTag value="segfault" />
    </appender>

    <root>
      <level value="ALL" />
      <appender-ref ref="TwitterAppender" />
    </root>
  </log4net>
```

### FAQ
1. What if my log message is over 140 characters?

I copied a feature from MySQL, just silently truncate it to fit and carry on.

2. Doesn't Twitter rate limit their APIs?

Log less
