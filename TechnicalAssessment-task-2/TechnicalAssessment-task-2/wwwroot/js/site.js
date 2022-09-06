// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = '/api'

function getForecast() {

    var selectLocation = document.getElementById("selectLocation");

    if (selectLocation.value == "")
        return;


    fetch(uri + "/Forecast?location=" + selectLocation.value)
        .then(response => response.json())
        .then(data => displayResults(data));
}

function displayResults(forecast) {
    var lastestForecast = forecast.properties.timeseries[0];
    var output = document.createElement("span");
    output.textContent = `Time: ${lastestForecast.time}`;
    document.getElementById("forecast-output").appendChild(output);
    output.textContent = `Time: ${lastestForecast.time}\nTemperature: ${lastestForecast.data.instant.details.air_temperature}\nWind Speed: ${lastestForecast.data.instant.details.wind_speed}`;
    document.getElementById("forecast-output").appendChild(output);
}


//\n Wind Speed: ${lastestForecast.data.instant.details.wind_speed }