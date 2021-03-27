# WeatherService

Simple Service to get the current weather forecast for Warsaw or by coordinates passed by the user.
Weather forecast is a download by external API from [7timer.info](http://www.7timer.info/index.php?lang=en)
API has been created using .NetCore 3.1 and in-memory database.
For more API readability I had added swagger (Swashbuckle) integration available under /swagger/index.html.
To wrote the tests I had used XUnit, Moq, FluentAssertion and [AutoFixture](https://github.com/AutoFixture/AutoFixture)   
