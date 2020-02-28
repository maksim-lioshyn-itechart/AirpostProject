// src/components/WeatherForecasts.js

import React from 'react'

const WeatherForecast = ({ weatherForecasts }) => {
  return (
    <div>
      <center><h1>WeatherForecast List</h1></center>
      {weatherForecasts.map((WeatherForecast) => (
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">{WeatherForecast.Date}</h5>
            <h6 class="card-subtitle mb-2 text-muted">{WeatherForecast.TemperatureC}</h6>
            <p class="card-text">{WeatherForecast.Summary}</p>
          </div>
        </div>
      ))}
    </div>
  )
};

export default WeatherForecast;