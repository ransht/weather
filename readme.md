# Project Name

Weather App

## Installation

1. set your db connection string
2. Run EF migrations: update-database
3. run the api

## Usage with data examples

Get locations autocomplete:
[GET]https://localhost:44334/api/location/cities?lang=en&key=yavne

Get weather data:
[GET]https://localhost:44334/api/weather/212593?lang=he

post favorite
[POST]https://localhost:44334/api/favorites?lang=he
{
	"LocalizedName" : "יבנה",
	"LocationId" : "212593"
}

remove favorite:
[DELETE] https://localhost:44334/api/favorites/212593

## Notes

didnt have time so:
1. no input validations
2. no error handling
3. need to remove constants from code
4. missing another services layes so some logic will be in the controller

## License

Ran, MIT :)